using System.Collections;
using System.Collections.Generic;


public class SeaTactic : BasicTactic
{
	private List<CommandStrategy> _commandStrategy_ar;
	public PrototypeHeroDemo _prototypeHeroSea;
	private int SeaSelectHeroId;
	public List<List<int>> shoalSea_ar;
	public List<GridTileBar> SeaGridTile_ar;
	public bool _seaChangeStateView;
	public int _globalParamsTimeQuick;
	public int _globalParamsGale = 0;

	
	private static SeaTactic TacticSingleton;

	public static SeaTactic GetTactic()
	{
		
		return TacticSingleton;
	}

	public List<CommandStrategy> GetCommandStrategyList()
	{
		return _commandStrategy_ar;
	}
	public PrototypeHeroDemo GetPrototypeHeroDemo() {
		return _prototypeHeroSea;
	}
	public int GetSeaSelectHeroId()
	{
		return SeaSelectHeroId;
	}
	public SeaTactic()
	{
		if (TacticSingleton == null)
		{
			_seaChangeStateView = true;
			/*
			shoalSea_ar = new int[6, 6]  {
				  {0,0,0,0,0, 0},
				  {0,0,0,0,0, 0},
				  {0,0,0,0,0, 0},
				 {0,0,0,0,0, 0},
				  {0,0,0,0,0, 0},
				 {0,0,0,0,0, 0}
			 };
			 */
			InitShoalSeaList();
	


			
TacticSingleton = this;
		}
		else 
		{
			
		}
		
	}
	private void InitShoalSeaList() {
		shoalSea_ar = new List<List<int>>()
		{
			new List<int>() {0,0,0, 0,0,0, },
			new List<int>() {0,0,0, 0,0,0, },
			new List<int>() {0,0,0, 0,0,0, },
			new List<int>() {0,0,0, 0,0,0, },
			new List<int>() {0,0,0, 0,0,0, },
			new List<int>() {0,0,0, 0,0,0, },
		};
		SeaGridTile_ar = new CreateGridScenario().CreateGridInit(new List<Point>(),
					   new List<Point>(), new List<Point>(), shoalSea_ar);
	}

	public SeaTactic(GridFleet HeroFiend, GridFleet HeroPlayer, int CountTurn)
	{
		if (TacticSingleton == null)
		{

			_globalParamsTimeQuick = 1000 + CountTurn * 1000;
			InitShoalSeaList();

			SetFiendFleet(HeroFiend);
			SetPlayerFleet(HeroPlayer);
			
			_commandStrategy_ar = new List<CommandStrategy>();

			// heroFleet
			RefreshPrototypeHeroSea();

			TacticSingleton = this;
		}
		else { 
		
		}
		
	}
	private void RefreshPrototypeHeroSea()
	{
		_prototypeHeroSea = new PrototypeHeroDemo();
		_prototypeHeroSea.HeroFleetInit();
		_prototypeHeroSea.HeroFleetAddAll(SetUnitInNameHero(GetFiendFleet(), 5));
		SeaSelectHeroId = _prototypeHeroSea.GetHeroFleetFirst().GetId();
		_prototypeHeroSea.HeroFleetAddAll(SetUnitInNameHero(GetPlayerFleet(), 0));
	}
	
	public void SeaSelectHero(ButtonEvent stop)
	{

		SeaSelectHeroId = stop.IdHero;
		_seaChangeStateView = true;
	}
	public void GotoHero(ButtonEvent buttonEvent)
	{

		_commandStrategy_ar.AddRange(MapWorldModel.SetMoveCommand(buttonEvent));

	}
	public void AttackHero(ButtonEvent buttonEvent)
	{
		buttonEvent.HeroFleet.SetAttackDone(true);
		_commandStrategy_ar.Add(MapWorldModel.CommandAttackFleet(
				buttonEvent.HeroFleet, buttonEvent.VictimFleet, buttonEvent.LongRange));
		_seaChangeStateView = true;
	}
	public void DeadArmUnitSeaTactic(ButtonEvent buttonEvent)
	{
		//System.out.println(buttonEvent.IdHero + "--Name  Dead  $$   ==================== -" + buttonEvent.IdHeroVictim);
		// dead ship

		Robot robot = new Robot();

		robot.DeadUnit(
				buttonEvent.IdHero,
				buttonEvent.IdHeroVictim,
				BattlePlanetModel.GetBasaPurchaseUnitScience(),
				GetPlayerFleet().GetShipNameFirst(),
					GetFiendFleet().GetShipNameFirst()
				);

		TurnSeaTacticPartial();
	}

	public void TurnSeaTactic()
	{
		
		_globalParamsTimeQuick++;

		// add Power.
		ModelStrategy.RefreshHeroPower(_prototypeHeroSea.GetHeroFleet(), true);
		
		TurnSeaTacticPartial();

	}
	private void TurnSeaTacticPartial()
	{

		this._commandStrategy_ar = new List<CommandStrategy>();


		shoalSea_ar = new List<List<int>>()
		{
			new List<int>() {0,0,0, 0,0,0, },
			new List<int>() {0,0,0, 0,0,0, },
			new List<int>() {0,0,0, 0,0,0, },
			new List<int>() {0,0,0, 0,0,0, },
			new List<int>() {0,0,0, 0,0,0, },
			new List<int>() {0,0,0, 0,0,0, },
		};

		List<GridTileBar> GridSea_ar = new CreateGridScenario().CreateGridArray(shoalSea_ar);

		SeaGridTile_ar = new CreateGridScenario().CreateGridInit(new List<Point>(),
				new List<Point>(), new List<Point>(), shoalSea_ar);

		List<GridFleet> copyNameHero_ar = _prototypeHeroSea.HeroFleetCopy();
		// SetLongRange.


		foreach (GridFleet gridFleet in copyNameHero_ar)
		{



			if (gridFleet.GetFlagId() == GetFiendFleet().GetFlagId())
			{

				// old point 
				Point oldPoint = new Point(gridFleet.SpotX, gridFleet.SpotY);

				//Set Range.
				//gridFleet.SetStaticRange(true);
				////////////////////
				ArmUnitAndFleet armUnitAndFleet = new ArmUnitAndFleet();
				ArmUnit ArmUnitFleet = armUnitAndFleet.GetArmUnitIdFleet(gridFleet.GetId(),
						GetFiendFleet(), GetPlayerFleet());
				//ArmUnit ArmUnitFleet = GetArmUnitIdFleet(gridFleet.GetId());
				/*
				TimeSalvoAppendHit timeSalvoAppendHit = new TimeSalvoAppendHit ();
				
				timeSalvoAppendHit.GetCannonAbleList(int Distance, ArrayList<ShipCapsule> ShipCapsuleList,
						int GlobalParamsTimeQuick,int GlobalParamsGale)
		*/
				////////////////////

				// move and search attack enemy.
				AttackMoveFleet attackMoveFleet = MendMoveShip.PlaceFiendX(
						gridFleet,
						copyNameHero_ar,
						GridSea_ar,
						new List<Island>(),
						BattlePlanetModel.DispositionCountry_ar,
						_commandStrategy_ar,
						ArmUnitFleet,
						_globalParamsTimeQuick,
						 _globalParamsGale
						);

				FleetSacrifive fleetSacrifive = ModelStrategy.SetFleetSacrifive(attackMoveFleet,
						gridFleet, oldPoint);

				GridFleet heroPlayerSacrifive = fleetSacrifive.HeroPlayerSacrifive;
				oldPoint = fleetSacrifive.OldPoint;


				if (heroPlayerSacrifive != null)
				{
				
					if (gridFleet.GetAttackDone() == false || gridFleet.GetTurnDone() == false)
					{
						_commandStrategy_ar.Add(ModelStrategy.GetCommandAttack(gridFleet, heroPlayerSacrifive,
								attackMoveFleet, oldPoint));
					}
					// stop attack! Animation.

				}

			}
			// set critic damage
			
		}

	}


	public ArmUnit GetArmUnitNameHere(
			List<ArmUnit> ArmUnit_ar,
			int GridFleetId)
	{
		ArmUnit armUnit = GetArmUnit(ArmUnit_ar, GridFleetId);

		return armUnit;

	}
	public ArmUnit GetArmUnit(List<ArmUnit> ArmUnit_ar, int Id)
	{
		foreach (ArmUnit armUnit in ArmUnit_ar)
		{

			if (Id == armUnit.Id)
			{
				return armUnit;
			}
		}
		return null;
	}
	public void PerformTacticCommand(int Id)
	{
		UsingCommand usingCommand = new UsingCommand();
		_commandStrategy_ar = usingCommand.PickUpCommandCaptureIsland(new ExecuteCommandTactic(),
				_commandStrategy_ar, Id, _globalParamsTimeQuick, _globalParamsGale);

	}
	public bool CheckVictory()
	{
		if (GetPlayerFleet().GetShipNameFirst().GetArmUnitArray().Count == 0 ||
				GetFiendFleet().GetShipNameFirst().GetArmUnitArray().Count == 0)
		{
			return true;
		}
		return false;
	}

	private List<GridFleet> SetUnitInNameHero(
			GridFleet HeroFiend,
			int placeNum)
	{

		List<GridFleet> nameHero_ar = new List<GridFleet>();
		List<ArmUnit> unitFiend_ar = HeroFiend.GetShipNameFirst().GetArmUnitArray();

		int count = 0;
		foreach (ArmUnit shipUnit in unitFiend_ar)
		{
			GridFleet unitFleet = new GridFleet("", placeNum, count, HeroFiend.GetFlagId(), "");

			unitFleet.SetId(shipUnit.Id);

			nameHero_ar.Add(unitFleet);
			count++;
		}
		return nameHero_ar;
	}
}
