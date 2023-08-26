using System.Collections;
using System.Collections.Generic;

public class MapWorldModel 
{
	private static int _turnCount = 0;
	public static int TimeQuick = 0;
	private static bool _turnOn = false;
	private static bool _changeStateView = false;
	private static Tactic _tactic;
	private static SeaTactic _seaTactic;

	private static List<CommandStrategy> _commandStrategyMap_ar=new List<CommandStrategy>();
	public static PrototypeHeroDemo _prototypeHeroDemo;
	private static IslandDemoMemento _islandDemoMemento;

	public static void Init()
	{
        _islandDemoMemento = new IslandDemoMemento();
    }
	public static IslandDemoMemento GetIslandMemento()
	{
		return _islandDemoMemento;
	}
	public static void RemoveCommandStrategy(CommandStrategy Command)
	{
		_commandStrategyMap_ar.Remove(Command);
	}
		private static void AddCommandStrategy(List<CommandStrategy> Command) {
		
		_commandStrategyMap_ar.AddRange(Command);
	}
	public static bool GetChangeStateView()
	{
		return _changeStateView;
	}
	public static void SetChangeStateView(bool Change)
	{
		_changeStateView = Change;
	}
	public static void TurnEvent()
	{
		
		if (!_turnOn)
		{
System.Diagnostics.Debug.WriteLine("Turn  "+ _turnOn);

			TurnPush();

			ModelStrategy.RefreshHeroPower(_prototypeHeroDemo.GetHeroFleet(), false);
			ModelStrategy.EconomicTurn(BattlePlanetModel.DispositionCountry_ar, MapWorldModel._islandDemoMemento.GetIslandArray());

			
			DevelopmentTurn();

			if (BattlePlanetModel.VictoryScenario.Dual)
			{
				////
				//SetAlertMenu();
				///////
				//Main._main.SetAlertMenu();
				Country countryFollowPlayer = ModelStrategy.GetPlayerCountryFollow(BattlePlanetModel.DispositionCountry_ar,
                        BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer());
				if (countryFollowPlayer != null)
				{
                    BattlePlanetModel.GetBattlePlanetModelSingleton().SetFlagIdPlayer( countryFollowPlayer.IdCountry);
					// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ, пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ.
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

	public static void GotoTactic(
			int IdHeroPlayer, int IdHeroFiend, bool MoveAI, bool LongRange, int CountTurn
			)
	{




		GridFleet gridFleetFiend = _prototypeHeroDemo.GetFleetWithId(IdHeroFiend);
		GridFleet gridFleetPlayer = _prototypeHeroDemo.GetFleetWithId(IdHeroPlayer);

		
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
						gridFleetPlayer, CountTurn);
				BattlePlanetModel.GotoSeaTactic(null, null);
			}
			else
			{
				SetStateGame(MainFormat.BATTLE);
				_tactic = new Tactic(
						gridFleetFiend,
						gridFleetPlayer,
						MoveAI, LongRange);
				BattlePlanetModel.GotoTactic(null, null);
			}
		}

	}
	public static void GotoStrateg(ButtonEvent model)
	{

		if (model.IdHero != -1)
		{

			// delete hero.
	
			bool deadGridFleet = DeadGridFleet(_prototypeHeroDemo, model.IdHero);
			if (deadGridFleet == true)
			{
				DeadHero();
			}
		
			GridFleet gridFleet0 = BattlePlanetModel.GetHeroWithId(_prototypeHeroDemo.GetHeroFleet(), model.IdHero);

		}
		CloseTactic();

		// пїЅпїЅпїЅпїЅ пїЅпїЅпїЅ пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ, пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ, пїЅпїЅпїЅ пїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ.
		if (model.MoveAI)
		{
			
			if (_commandStrategyMap_ar.Count != 0)
			{
				DevelopmentTurn();
			}
		}
	}
	public static bool DeadGridFleet(PrototypeHeroDemo prototypeHeroDemo, int IdHero)
	{
		GridFleet gridFleet = BattlePlanetModel.GetHeroWithId(_prototypeHeroDemo.GetHeroFleet(), IdHero);
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
	public static void CloseTactic()
	{

		//SetStateGame(MainFormat.MAP);
		
		ReturnMapWorldScene();

		BattlePlanetModel.GotoPlanetWorld();
	}
	private static void ReturnMapWorldScene() { 
		LoadSceneChange.LoadSceneRotation("SampleScene");
	}

	public static void TurnPush()
	{
		_turnCount++;

	}
	public static int GetTurnCount()
	{
		return _turnCount;

    }
	public static List<CommandStrategy> SetMoveCommand(ButtonEvent buttonEvent)
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

	// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ.
	public static void GotoHero(ButtonEvent buttonEvent)
	{

		AddCommandStrategy(SetMoveCommand(buttonEvent));

		int spotPlayerX = (int)buttonEvent.Point.X;
		int spotPlayerY = (int)buttonEvent.Point.Y;

		GridFleet heroFiend = ModelStrategy.SearchHeroOne(
				spotPlayerX, spotPlayerY,
				_prototypeHeroDemo.GetHeroFleet(), BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), true);

	

		if (heroFiend != null)
		{
			// attack fiend
			// old point 

			AddCommandStrategy(new List<CommandStrategy>() { CommandAttackFleet(buttonEvent.HeroFleet, heroFiend, buttonEvent.LongRange) });
		}
		// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ-пїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ.
		Island island = ModelStrategy.GetIsland(MapWorldModel._islandDemoMemento.GetIslandArray(),
				BattlePlanetModel.DispositionCountry_ar,
				buttonEvent.HeroFleet.SpotX,
				buttonEvent.HeroFleet.SpotY);
		if (island != null)
		{

			if (island.FlagId != BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer())
			{
				//System.out.println("%%    $  island             Event  size = " + buttonEvent.PathGoto_ar.size());

				// seizure island.
				island.FlagId = buttonEvent.HeroFleet.GetFlagId();

				CommandStrategy commandStrategyHero = ModelStrategy.GetCommandCaptureIsland(island, buttonEvent.HeroFleet);
				//_commandStrategy_ar = new ArrayList<CommandStrategy>();
				AddCommandStrategy(new List<CommandStrategy>() { commandStrategyHero });
			}
			// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ, пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ.

		}
		// refreshView	
		_changeStateView = true;
	}
	public static CommandStrategy CommandAttackFleet(GridFleet PlayerFleet,
			GridFleet FiendFleet, bool LongRange)
	{
		Point oldPoint = new Point(PlayerFleet.SpotX, PlayerFleet.SpotY);
		AttackMoveFleet attackMoveFleet = ModelStrategy.GetAttackMoveFleet(FiendFleet, LongRange, null);
		CommandStrategy commandAttack = ModelStrategy.GetAttackCommand(PlayerFleet,
				FiendFleet, attackMoveFleet, oldPoint);
		commandAttack.AttackPlayer = true;
		return commandAttack;

	}

	private static void AttackHeroEvent(ButtonEvent buttonEvent, GridFleet heroFiend)
	{

		// player attack AI
		AddCommandStrategy(new List<CommandStrategy>() { CommandAttackFleet(buttonEvent.HeroFleet, heroFiend, buttonEvent.LongRange) });

	}
	public static void AttackHero(ButtonEvent buttonEvent)
	{

		buttonEvent.HeroFleet.SetAttackDone(true);

		AttackHeroEvent(buttonEvent, buttonEvent.VictimFleet);

	}


	public static void SelectIsland(ButtonEvent buttonEvent)
	{
		if (buttonEvent != null)
		{
			// пїЅпїЅпїЅпїЅпїЅ-пїЅпїЅ пїЅпїЅпїЅпїЅпїЅ, пїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ.
			IslandPort.HeroFleet = buttonEvent.HeroFleet;
		}
		else
		{
			IslandPort.HeroFleet = null;
		}
		//Main.stateGame = MainFormat.ISLAND;
		SetStateGame(MainFormat.ISLAND);
	}
	// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ.
	public static void BuyUnit(ButtonEvent buttonEvent)
	{
		//System.out.println(buttonEvent.HeroFleet + "//  start   ===" + buttonEvent.UnitId);

		Country country = GetCountCountry(buttonEvent.HeroFleet.GetFlagId());

		
		//if (EnoughMoneyOnUnit(country, buttonEvent.UnitId))
	if(EnoughMoneyUnit(buttonEvent.HeroFleet.GetFlagId(), buttonEvent.UnitId))
		{

			TakeAwayMoney(country, buttonEvent.UnitId);
			//System.out.println(BattlePlanetModel.BasaPurchaseUnitScience_ar.size() + "Ass player ___sixe  =");
			ModelStrategy.FleetAddArmFast(buttonEvent.HeroFleet, buttonEvent.UnitId,
					BattlePlanetModel.GetBasaPurchaseUnitScience(), 0);
		}

	}
	public static bool EnoughMoneyUnit(int FlagId,int UnitId)
	{
		Country country = GetCountCountry(FlagId);
		if (EnoughMoneyOnUnit(country, UnitId))
		{
			return true;
		}
		return false;
	}
	public static void TakeAwayMoney(Country country, int UnitId)
	{
		country.Money -= BattlePlanetModel.GetBasaPurchaseUnitScience()[UnitId].Cost;
	}
	public static Country GetCountCountry(int FlagId)
	{
		return ModelStrategy.GetDispositionCountry(BattlePlanetModel.DispositionCountry_ar,
				FlagId);
	}
	public static bool EnoughMoneyOnUnit(Country country, int UnitId)
	{
		return country.Money - BattlePlanetModel.GetBasaPurchaseUnitScience()[UnitId].Cost >= 0;
	}
	public static void SelectHeroLeft()
	{
		int id = _prototypeHeroDemo.GetNextFleetIdPlayer(BattlePlanetModel.GetSelectHeroId(), -1, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer());
        BattlePlanetModel.SetSelectHeroId(id);
    }
	public static void SelectHeroRight()
	{
        int id = _prototypeHeroDemo.GetNextFleetIdPlayer(BattlePlanetModel.GetSelectHeroId(), 1, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer());
        BattlePlanetModel.SetSelectHeroId(id);
    }
	public static void SelectHero(ButtonEvent buttonEvent)
	{
		
		if (buttonEvent.HeroFleet.GetFlagId() == BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer())
		{

			BattlePlanetModel.SetSelectHeroId(GetHeroSelect(buttonEvent.HeroFleet));

			MapWorldModel._changeStateView = true;
		}
	}
	public static int GetHeroSelect(GridFleet hero)
	{

		GridFleet gridFleet = BattlePlanetModel.GetHeroWithId(_prototypeHeroDemo.GetHeroFleet(), hero.GetId());

		if (gridFleet != null)
		{
			BattlePlanetModel.BlockSelectHero = false;
			return gridFleet.GetId();
		}
		BattlePlanetModel.BlockSelectHero = true;

		return 0;
	}
	public static void DeadHero()
	{
		List<GridFleet> nameHero_ar = ModelStrategy.GetHeroAll(BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), _prototypeHeroDemo.GetHeroFleet());
		if (nameHero_ar.Count > 0)
		{
			GridFleet hero = ModelStrategy.GetHeroAll(BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), _prototypeHeroDemo.GetHeroFleet())[0];
			BattlePlanetModel.SetSelectHeroId(GetHeroSelect(hero));

		}
	}

	public static void StartGame()
	{
		
		if (BattlePlanetModel.VictoryScenario.ReturnStart)
		{

			BattlePlanetModel.VictoryScenario.ReturnStart = false;
			//Main.stateGame = MainFormat.START_GAME;
			SetStateGame(MainFormat.START_GAME);
		}
		else
		{
			MapWorldStartGame.StartGameChange(BattlePlanetModel.VictoryScenario);
		}
	}
	public static void EndGame()
	{

		SetStateGame(MainFormat.START_GAME);
	}

	public static void DualMode()
	{
		// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ.

		MapWorldStartGame.StartGameDual(BattlePlanetModel.VictoryScenario);
	}
	public static List<GridFleet> CopyHeroNameArray()
	{
		return _prototypeHeroDemo.HeroFleetCopy();
	}

	private static ButtonEvent _eventModel;
	public static void DevelopmentTurn()
	{
		
		// get copy island list.
		List<Island> copyIsland_ar = MapWorldModel._islandDemoMemento.GetCopyIslandArray();
		_commandStrategyMap_ar = new List<CommandStrategy>();
		
		List<GridFleet> copyFleetGrid_ar = CopyHeroNameArray();

		ButtonEvent eventModel = ModelStrategy.GreatImpDrivingAI
				(
						BattlePlanetModel.DispositionCountry_ar,
                        BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(),
						copyFleetGrid_ar,
						BattlePlanetModel.GetGridTileList(),
						MapWorldModel._islandDemoMemento.GetIslandArray(),
						BattlePlanetModel.GetShoalSeaBasa_ar(),
						BattlePlanetModel.GetBasaPurchaseUnitScience(),
						2,
						_commandStrategyMap_ar,
						BattlePlanetModel.GetGridTileList()
                );
		System.Diagnostics.Debug.WriteLine(_commandStrategyMap_ar.Count+"  eventModel = " + eventModel);

		// input command
		foreach (CommandStrategy commandStrategy in _commandStrategyMap_ar)
		{


		}
		if (eventModel != null)
		{

			// Ai 
			// attack player/ 
			//GotoTactic(eventModel);
			_eventModel = eventModel;

		}
		if (_commandStrategyMap_ar.Count == 0)
		{
			CheckGlobalVictory();
		}
	}
	public static void CheckGlobalVictory()
	{
	
		List<Island> islandHero_ar = ModelStrategy.GetFlagIslandArray(MapWorldModel._islandDemoMemento.GetIslandArray(),
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), false);

		if (islandHero_ar.Count== 0)
		{

			
			GlobalVictoryFailDevelopment();
		}
		
		islandHero_ar = ModelStrategy.GetFlagIslandArray(MapWorldModel._islandDemoMemento.GetIslandArray(), BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), true);

		ListIsland listIsland = new ListIsland();
		listIsland.PrintIslandName(islandHero_ar);

		if (islandHero_ar.Count == 0)
		{

			BattlePlanetModel.VictoryScenario.ScenarioNumber++;

			if (BattlePlanetModel.VictoryScenario.Dual)
			{

				MapWorldStartGame.StartGameChange(BattlePlanetModel.VictoryScenario);

			}
			else
			{


				GlobalVictoryWinDevelopment();
			}

		}

	}
	public static CommandStrategy GetCommandCaptureFirst()
	{
		return _commandStrategyMap_ar[0];
	}
	public static List<CommandStrategy> GetCommandCapture()
	{
		
		return _commandStrategyMap_ar;
	}
	public static void PickUpCommandCaptureIsland(int Id)
	{

		UsingCommand usingCommand = new UsingCommand();
		_commandStrategyMap_ar = usingCommand.PickUpCommandCaptureIsland(new ExecuteCommandStrateg(),
				_commandStrategyMap_ar, Id, _turnCount, 0);
		MapWorldModel.CheckGlobalVictory();

	}

	public static void Economic()
	{

	}
	public static void GlobalVictoryWinDevelopment()
	{


		if (MapWorldStartGame.StartGameChange(BattlePlanetModel.VictoryScenario))
		{
			BattlePlanetModel.GotoSuperGlobalWinEnd();
		}
		else
		{
			BattlePlanetModel.GotoGlobalWin();
		}

		// change scenario
	}
	public static void GlobalVictoryFailDevelopment()
	{

		MapWorldStartGame.StartGameFirstReset(BattlePlanetModel.VictoryScenario);
		BattlePlanetModel.GotoGlobalFail();
	}

	public static void SetStateGame(string MainFormat)
	{
		//_mainStateGame = MainFormat;
		//Application.LoadLevel("TacticScene");
		//SceneManager.LoadScene("TacticScene", LoadSceneMode.Single);
		//SceneManager.LoadScene("TacticScene", LoadSceneMode.Additive);
		
		
		if (MainFormat=="SEA_BATTLE") {
			LoadSceneChange.LoadSceneRotation("SeaTactic");
			return;
		}

		LoadSceneChange.LoadSceneRotation("TacticScene");
	}

	public static void SetAlertMenu()
	{
		//Main._main.SetAlertMenu();
	}
}
