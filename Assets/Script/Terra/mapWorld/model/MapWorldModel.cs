using System.Collections;
using System.Collections.Generic;
using ZedAngular.Model.Terra.scenario;

public class MapWorldModel 
{
	private int _turnCount = 0;
	public int TimeQuick = 0;
	private bool _turnOn = false;
	private bool _changeStateView = false;
	private Tactic _tactic;
	private SeaTactic _seaTactic;

	private List<CommandStrategy> _commandStrategyMap_ar=new List<CommandStrategy>();
	//public PrototypeHeroDemo _prototypeHeroDemo;
	private IslandMemento _islandDemoMemento;
	private static MapWorldModel _mapWorldModel;

    public static MapWorldModel MapWorldModelSingleton()
    {
        if (_mapWorldModel == null)
        {
            _mapWorldModel = new MapWorldModel();

        }
        return _mapWorldModel;
    }
    public MapWorldModel()
	{
        _islandDemoMemento = new IslandMemento();
        //_prototypeHeroDemo = new PrototypeHeroDemo();
        //_prototypeHeroDemo.HeroFleetInit();
    }
	public IslandMemento GetIslandMemento()
	{
		return _islandDemoMemento;
	}

	private void AddCommandStrategy(List<CommandStrategy> Command) {
		
		_commandStrategyMap_ar.AddRange(Command);
	}

	public void TurnEvent()
	{
		
		if (!_turnOn)
		{
			System.Diagnostics.Debug.WriteLine("Turn  "+ _turnOn);

			TurnPush();

			ModelStrategy.RefreshHeroPower(BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet(), false);
			ModelStrategy.EconomicTurn(BattlePlanetModel.GetBattlePlanetModelSingleton().GetDispositionCountryList(), MapWorldModel.MapWorldModelSingleton()._islandDemoMemento.GetIslandArray());

			
			DevelopmentTurn();

			if (BattlePlanetModel.GetBattlePlanetModelSingleton().VictoryScenario.Dual)
			{

				Country countryFollowPlayer = ModelStrategy.GetPlayerCountryFollow(
					BattlePlanetModel.GetBattlePlanetModelSingleton().GetDispositionCountryList(),
                        BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer());
				if (countryFollowPlayer != null)
				{
                    BattlePlanetModel.GetBattlePlanetModelSingleton().SetFlagIdPlayer( countryFollowPlayer.IdCountry);
					DeadHero();
				}
				else
				{
					
					GlobalVictoryWinDevelopment();
				}
			}
			Economic();
		}
		else
		{

		}
	}

	public void GotoTactic(
			int IdHeroPlayer, int IdHeroFiend, bool MoveAI, bool LongRange, int CountTurn, BattlePlanetModel battlePlanetModel
            )
	{




		GridFleet gridFleetFiend = BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetFleetWithId(IdHeroFiend);
		GridFleet gridFleetPlayer = BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetFleetWithId(IdHeroPlayer);

		
		if (gridFleetFiend != null)
		{
			/*
			gridFleetFiend.SetAttackDone(true);
			gridFleetFiend.SetTurnDone(true);
			gridFleetPlayer.SetAttackDone(true);
			gridFleetPlayer.SetTurnDone(true);
			*/
			if (gridFleetFiend.GetSea() && gridFleetPlayer.GetSea())
			{
				SetStateGame(MainFormat.SEA_BATTLE);
		
				_seaTactic = new SeaTactic(
						gridFleetFiend,
						gridFleetPlayer, CountTurn, battlePlanetModel);
                battlePlanetModel.GotoSeaTactic(null, null);
			}
			else
			{
				SetStateGame(MainFormat.BATTLE);
				_tactic = new Tactic(
						gridFleetFiend,
						gridFleetPlayer,
						MoveAI, LongRange);
                BattlePlanetModel.GetBattlePlanetModelSingleton().GotoTactic(null, null);
			}
		}

	}
	public void GotoStrateg(ButtonEvent model)
	{

		if (model.IdHero != -1)
		{

			// delete hero.
	
			bool deadGridFleet = MapWorldModelSingleton().DeadGridFleet(BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo, model.IdHero);
			if (deadGridFleet == true)
			{
				DeadHero();
			}
		
			GridFleet gridFleet0 = BattlePlanetModel.GetBattlePlanetModelSingleton().GetHeroWithId(BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet(), model.IdHero);

		}
		CloseTactic();

		
		if (model.MoveAI)
		{
			
			if (_commandStrategyMap_ar.Count != 0)
			{
				DevelopmentTurn();
			}
		}
	}
	public bool DeadGridFleet(PrototypeHeroDemo prototypeHeroDemo, int IdHero)
	{
		GridFleet gridFleet = BattlePlanetModel.GetBattlePlanetModelSingleton().GetHeroWithId(BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet(), IdHero);
		//??
		int index = prototypeHeroDemo.GetHeroFleet().IndexOf(gridFleet);

		if (index != -1)
		{

			//prototypeHeroDemo.GetHeroFleet().remove(index);
			prototypeHeroDemo.GetHeroFleet().RemoveAt(index);
			return true;
		}
		return false;
	}
	public void CloseTactic()
	{

		//SetStateGame(MainFormat.MAP);
		
		ReturnMapWorldScene();

		BattlePlanetModel.GetBattlePlanetModelSingleton().GotoPlanetWorld();
	}
	private void ReturnMapWorldScene() { 
		LoadSceneChange.LoadSceneRotation("SampleScene");
	}

	public void TurnPush()
	{
		_turnCount++;

	}
	public int GetTurnCount()
	{
		return _turnCount;

    }
	public List<CommandStrategy> SetMoveCommand(ButtonEvent buttonEvent)
	{
		int count = 0;
		List<CommandStrategy> commandStrategy_ar = new List<CommandStrategy>();
		foreach (Point pointPath in buttonEvent.PathGoto_ar)
		{
			if (count != 0)
			{

				CommandStrategy commandStrategy = ModelStrategy.GetCommandMoveFleet(
						buttonEvent.PathGoto_ar[count - 1],
						buttonEvent.PathGoto_ar[count],
						buttonEvent.HeroFleet);
				commandStrategy_ar.Add(commandStrategy);

			}
			count++;
		}

		return commandStrategy_ar;
	}


	public void GotoHero(ButtonEvent buttonEvent)
	{

        MapWorldModelSingleton().AddCommandStrategy(MapWorldModelSingleton().SetMoveCommand(buttonEvent));

		int spotPlayerX = (int)buttonEvent.Point.X;
		int spotPlayerY = (int)buttonEvent.Point.Y;

		GridFleet heroFiend = ModelStrategy.SearchHeroOne(
				spotPlayerX, spotPlayerY,
				BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet(), BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), true);

	

		if (heroFiend != null)
		{
			// attack fiend
			// old point 

			MapWorldModelSingleton().AddCommandStrategy(new List<CommandStrategy>() { CommandAttackFleet(buttonEvent.HeroFleet, heroFiend, buttonEvent.LongRange) });
		}

		Island island = ModelStrategy.GetIsland(MapWorldModel.MapWorldModelSingleton()._islandDemoMemento.GetIslandArray(),
				BattlePlanetModel.GetBattlePlanetModelSingleton().GetDispositionCountryList(),
				buttonEvent.HeroFleet.SpotX,
				buttonEvent.HeroFleet.SpotY);
		if (island != null)
		{

			if (island.FlagId != BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer())
			{


				// seizure island.
				island.FlagId = buttonEvent.HeroFleet.GetFlagId();

				CommandStrategy commandStrategyHero = ModelStrategy.GetCommandCaptureIsland(island, buttonEvent.HeroFleet);
				//_commandStrategy_ar = new ArrayList<CommandStrategy>();
				MapWorldModelSingleton().AddCommandStrategy(new List<CommandStrategy>() { commandStrategyHero });
			}


		}
		// refreshView	
		_changeStateView = true;
	}
	public CommandStrategy CommandAttackFleet(GridFleet PlayerFleet,
			GridFleet FiendFleet, bool LongRange)
	{
		Point oldPoint = new Point(PlayerFleet.SpotX, PlayerFleet.SpotY);
		AttackMoveFleet attackMoveFleet = ModelStrategy.GetAttackMoveFleet(FiendFleet, LongRange, null);
		CommandStrategy commandAttack = ModelStrategy.GetAttackCommand(PlayerFleet,
				FiendFleet, attackMoveFleet, oldPoint);
		commandAttack.AttackPlayer = true;
		return commandAttack;

	}

	private void AttackHeroEvent(ButtonEvent buttonEvent, GridFleet heroFiend)
	{

		// player attack AI
		MapWorldModelSingleton().AddCommandStrategy(new List<CommandStrategy>() { CommandAttackFleet(buttonEvent.HeroFleet, heroFiend, buttonEvent.LongRange) });

	}
	public void AttackHero(ButtonEvent buttonEvent)
	{

		buttonEvent.HeroFleet.SetAttackDone(true);

		AttackHeroEvent(buttonEvent, buttonEvent.VictimFleet);

	}


	public void SelectIsland(ButtonEvent buttonEvent)
	{
		if (buttonEvent != null)
		{

			IslandPort.HeroFleet = buttonEvent.HeroFleet;
		}
		else
		{
			IslandPort.HeroFleet = null;
		}
		//Main.stateGame = MainFormat.ISLAND;
		SetStateGame(MainFormat.ISLAND);
	}

	public void BuyUnit(ButtonEvent buttonEvent)
	{
		//System.out.println(buttonEvent.HeroFleet + "//  start   ===" + buttonEvent.UnitId);

		Country country = GetCountCountry(buttonEvent.HeroFleet.GetFlagId());

		
		//if (EnoughMoneyOnUnit(country, buttonEvent.UnitId))
	if(EnoughMoneyUnit(buttonEvent.HeroFleet.GetFlagId(), buttonEvent.UnitId))
		{

			TakeAwayMoney(country, buttonEvent.UnitId);
			//System.out.println(BattlePlanetModel.BasaPurchaseUnitScience_ar.size() + "Ass player ___sixe  =");
			ModelStrategy.FleetAddArmFast(buttonEvent.HeroFleet, buttonEvent.UnitId,
					BattlePlanetModel.GetBattlePlanetModelSingleton(), 0);
		}

	}
	public  bool EnoughMoneyUnit(int FlagId,int UnitId)
	{
		Country country = GetCountCountry(FlagId);
		if (EnoughMoneyOnUnit(country, UnitId))
		{
			return true;
		}
		return false;
	}
	public  void TakeAwayMoney(Country country, int UnitId)
	{
		country.Money -= BattlePlanetModel.GetBattlePlanetModelSingleton().GetBasaPurchaseUnitScience()[UnitId].Cost;
	}
	public  Country GetCountCountry(int FlagId)
	{
		return ModelStrategy.GetDispositionCountry(BattlePlanetModel.GetBattlePlanetModelSingleton().GetDispositionCountryList(),
				FlagId);
	}
	public  bool EnoughMoneyOnUnit(Country country, int UnitId)
	{
		return country.Money - BattlePlanetModel.GetBattlePlanetModelSingleton().GetBasaPurchaseUnitScience()[UnitId].Cost >= 0;
	}
	public  void SelectHeroLeft()
	{
        int id = BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetNextFleetIdPlayer(BattlePlanetModel.GetBattlePlanetModelSingleton().GetSelectHeroId(), -1, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer());
        BattlePlanetModel.GetBattlePlanetModelSingleton().SetSelectHeroId(id);
    }
	public  void SelectHeroRight()
	{
        int id = BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetNextFleetIdPlayer(BattlePlanetModel.GetBattlePlanetModelSingleton().GetSelectHeroId(), 1, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer());
        BattlePlanetModel.GetBattlePlanetModelSingleton().SetSelectHeroId(id);
    }
	public  void SelectHero(ButtonEvent buttonEvent)
	{
		
		if (buttonEvent.HeroFleet.GetFlagId() == BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer())
		{

			BattlePlanetModel.GetBattlePlanetModelSingleton().SetSelectHeroId(GetHeroSelect(buttonEvent.HeroFleet));

			MapWorldModel.MapWorldModelSingleton()._changeStateView = true;
		}
	}
	public int GetHeroSelect(GridFleet hero)
	{

		GridFleet gridFleet = BattlePlanetModel.GetBattlePlanetModelSingleton().GetHeroWithId(BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet(), hero.GetId());

		if (gridFleet != null)
		{
			BattlePlanetModel.BlockSelectHero = false;
			return gridFleet.GetId();
		}
		BattlePlanetModel.BlockSelectHero = true;

		return 0;
	}
	public void DeadHero()
	{
		List<GridFleet> nameHero_ar = ModelStrategy.GetHeroAll(BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet());
		if (nameHero_ar.Count > 0)
		{
			GridFleet hero = ModelStrategy.GetHeroAll(BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet())[0];
			BattlePlanetModel.GetBattlePlanetModelSingleton().SetSelectHeroId(GetHeroSelect(hero));

		}
	}

	public void StartGame()
	{
		
		if (BattlePlanetModel.GetBattlePlanetModelSingleton().VictoryScenario.ReturnStart)
		{

			BattlePlanetModel.GetBattlePlanetModelSingleton().VictoryScenario.ReturnStart = false;

			SetStateGame(MainFormat.START_GAME);
		}
		else
		{
			new MapWorldStartGame().StartGameChange(BattlePlanetModel.GetBattlePlanetModelSingleton().VictoryScenario,BattlePlanetModel.GetBattlePlanetModelSingleton());
		}
	}


	public  void DualMode()
	{


		new MapWorldStartGame().StartGameDual(BattlePlanetModel.GetBattlePlanetModelSingleton().VictoryScenario,BattlePlanetModel.GetBattlePlanetModelSingleton());
	}
	public List<GridFleet> CopyHeroNameArray()
	{
		return BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.HeroFleetCopy();
	}

	private ButtonEvent _eventModel;
	public  void DevelopmentTurn()
	{
		
		// get copy island list.
		List<Island> copyIsland_ar = MapWorldModel.MapWorldModelSingleton()._islandDemoMemento.GetCopyIslandArray();
		_commandStrategyMap_ar = new List<CommandStrategy>();
		
		List<GridFleet> copyFleetGrid_ar = CopyHeroNameArray();

		ButtonEvent eventModel = ModelStrategy.GreatImpDrivingAI
				(
						BattlePlanetModel.GetBattlePlanetModelSingleton().GetDispositionCountryList(),
                        BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(),
						copyFleetGrid_ar,
						BattlePlanetModel.GetBattlePlanetModelSingleton().GetGridTileList(),
						MapWorldModel.MapWorldModelSingleton()._islandDemoMemento.GetIslandArray(),
						BattlePlanetModel.GetBattlePlanetModelSingleton().GetShoalSeaBasa_ar(),
						BattlePlanetModel.GetBattlePlanetModelSingleton(),
						2,
						_commandStrategyMap_ar,
						BattlePlanetModel.GetBattlePlanetModelSingleton().GetGridTileList()
                );
		System.Diagnostics.Debug.WriteLine(_commandStrategyMap_ar.Count+"  eventModel = " + eventModel);

		// input command
		foreach (CommandStrategy commandStrategy in _commandStrategyMap_ar)
		{


		}
		if (eventModel != null)
		{

			// Ai 
			_eventModel = eventModel;

		}
		if (_commandStrategyMap_ar.Count == 0)
		{
			CheckGlobalVictory();
		}
	}
	public void CheckGlobalVictory()
	{
	
		List<Island> islandHero_ar = ModelStrategy.GetFlagIslandArray(MapWorldModel.MapWorldModelSingleton()._islandDemoMemento.GetIslandArray(),
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), false);

		if (islandHero_ar.Count== 0)
		{

			
			GlobalVictoryFailDevelopment(BattlePlanetModel.GetBattlePlanetModelSingleton());
		}
		
		islandHero_ar = ModelStrategy.GetFlagIslandArray(MapWorldModel.MapWorldModelSingleton()._islandDemoMemento.GetIslandArray(), BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), true);

		ListIsland listIsland = new ListIsland();
		listIsland.PrintIslandName(islandHero_ar);

		if (islandHero_ar.Count == 0)
		{

			BattlePlanetModel.GetBattlePlanetModelSingleton().VictoryScenario.ScenarioNumber++;

			if (BattlePlanetModel.GetBattlePlanetModelSingleton().VictoryScenario.Dual)
			{

				new MapWorldStartGame().StartGameChange(BattlePlanetModel.GetBattlePlanetModelSingleton().VictoryScenario, BattlePlanetModel.GetBattlePlanetModelSingleton());

			}
			else
			{


				GlobalVictoryWinDevelopment();
			}

		}

	}
	public CommandStrategy GetCommandCaptureFirst()
	{
		return _commandStrategyMap_ar[0];
	}
	public List<CommandStrategy> GetCommandMoveAttackList()
	{
		
		return _commandStrategyMap_ar;
	}
	public  void PickUpCommandCaptureIsland(CommandStrategy commandStrategy)
	{

		UsingCommand usingCommand = new UsingCommand();

		usingCommand.PickUpCommandCaptureIsland(
                commandStrategy, _turnCount, 0, BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo);
		MapWorldModel.MapWorldModelSingleton().CheckGlobalVictory();

	}

	public void Economic()
	{

	}
	public void GlobalVictoryWinDevelopment()
	{


		if (new MapWorldStartGame().StartGameChange(BattlePlanetModel.GetBattlePlanetModelSingleton().VictoryScenario, BattlePlanetModel.GetBattlePlanetModelSingleton()))
		{
			BattlePlanetModel.GetBattlePlanetModelSingleton().GotoSuperGlobalWinEnd();
		}
		else
		{
			BattlePlanetModel.GetBattlePlanetModelSingleton().GotoGlobalWin();
		}

		// change scenario
	}
	public void GlobalVictoryFailDevelopment(BattlePlanetModel battlePlanetModel)
	{
        BattlePlanetModel._initGlobalParams = new InitGlobalParams(battlePlanetModel);
        //new MapWorldStartGame().StartGameFirstReset(battlePlanetModel.VictoryScenario, 
		//	new FactoryScenario().GetFactoryScenario(0), battlePlanetModel);
		BattlePlanetModel.GetBattlePlanetModelSingleton().GotoGlobalFail();
	}

	public void SetStateGame(string MainFormat)
	{

		if (MainFormat=="SEA_BATTLE") {
			LoadSceneChange.LoadSceneRotation("SeaTactic");
			return;
		}

		LoadSceneChange.LoadSceneRotation("TacticScene");
	}

}
