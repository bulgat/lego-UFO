using System.Collections;
using System.Collections.Generic;

using System;
using ZedAngular.Model.Terra;
using ZedAngular.Model.Terra.scenario;
using System.Reflection;
using System.ComponentModel.Design;
using UnityEngine;

public class BattlePlanetModel
{
    private List<GridTileBar> GridTile_ar = new List<GridTileBar>();
    public int ObstacleMap = 2;
    public int ObstacleRoadMap = 3;
    public int ObstacleSeaMap = 4;
    private static int CreateUnitId = 1;
    private static bool _tempSingletonBattle = false;
    public static InitGlobalParams _initGlobalParams;
    private List<GridCrewScience> BasaPurchaseUnitScience_ar = new List<GridCrewScience>();
    public static int TypeIsland = 16;
    private List<Country> DispositionCountry_ar = new List<Country>();

    private int FlagIdHero = 9;
    public VictoryStipulation VictoryScenario = new VictoryStipulation();
    public static int SizeSquad = 6;
    private int SelectHeroId = 0;
    public static bool BlockSelectHero = false;
    private List<List<int>> ShoalSeaBasa_ar;
    public List<GoalTypeShip> GoalTypeShip_ar;

    public Island SelectIsland = null;
    private static BattlePlanetModel _BattlePlanetModel;
    public ContactStateProceeding _contactStateProceeding;
    public PrototypeHeroDemo _prototypeHeroDemo;

    public static BattlePlanetModel GetBattlePlanetModelSingleton()
    {
        if (_BattlePlanetModel == null)
        {
            _BattlePlanetModel = new BattlePlanetModel();
            _BattlePlanetModel.Init();

        }
        return _BattlePlanetModel;
    }
    public List<Country> GetDispositionCountryList() {
        return this.DispositionCountry_ar;
    }
    public void InitDispositionCountry()
    {
        Debug.Log("INIT  DispositionCountry");
        this.DispositionCountry_ar = new List<Country>();
    }
    public void AddDispositionCountry(Country country)
    {
        Debug.Log("AddDispositionCountry");
        this.DispositionCountry_ar.Add(country);
    }
    public BattlePlanetModel()
    {
        _contactStateProceeding = new ContactStateProceeding();
        _initGlobalParams = new InitGlobalParams(this);
        
        
        
    }
    void Init()
    {
        _prototypeHeroDemo = new PrototypeHeroDemo();
        _prototypeHeroDemo.HeroFleetInit();
        new MapWorldStartGame().StartGameFirstReset(new VictoryStipulation(), new FactoryScenario().GetFactoryScenario(0), this);
    }
    public int GetIdUnit() {
        return CreateUnitId ++;
    }
    public int GetFlagIdPlayer()
    {
        return this.FlagIdHero;
    }
    public void SetFlagIdPlayer(int value)
    {
        this.FlagIdHero = value;
    }
    public List<List<int>> GetShoalSeaBasa_ar()
    {
        return ShoalSeaBasa_ar;
    }
    public void SetShoalSeaBasa_ar(List<List<int>> value)
    {
        ShoalSeaBasa_ar = value;
    }
   public List<GridTileBar>  GetGridTileList()
    {
        if (_BattlePlanetModel == null)
        {
            return null;
        }
        return _BattlePlanetModel.GridTile_ar;
    }
    public void SetGridTileList(List<GridTileBar> value)
    {
        if (_BattlePlanetModel == null)
        {
            return;
        }
        _BattlePlanetModel.GridTile_ar = value;
    }


    public List<GridCrewScience> GetBasaPurchaseUnitScience() {
        return BasaPurchaseUnitScience_ar;
    }
    public void InitBasaPurchaseUnitScience()
    {
        BasaPurchaseUnitScience_ar= new List<GridCrewScience>();
    }
    public void BasaPurchaseUnitScienceAdd(GridCrewScience gridCrewScience)
    {
        BasaPurchaseUnitScience_ar.Add(gridCrewScience);
    }
    public void SetSelectHeroId(int selectHeroId) {
        _BattlePlanetModel.SelectHeroId = selectHeroId;
    }
    public int GetSelectHeroId()
    {
        return _BattlePlanetModel.SelectHeroId;
    }

    public void SetScenario(int ScenarioId)
    {
        BattlePlanetModel._initGlobalParams = new InitGlobalParams(BattlePlanetModel.GetBattlePlanetModelSingleton());
        new MapWorldStartGame().StartGameFirstReset(VictoryScenario, new FactoryScenario().GetFactoryScenario(ScenarioId), this);
    }
    public Island GetIslandWithGridFleet(List<Island> Island_ar, GridFleet gridFleet)
    {
        return ModelStrategy.GetIsland(Island_ar,
                DispositionCountry_ar, gridFleet.SpotX, gridFleet.SpotY);
    }
    public void GotoSeaTactic(ButtonEvent buttonEvent, GridFleet heroFiend)
    {
    
        /*
        _tactic = new SeaTactic(
                        gridFleetFiend,
                        gridFleetPlayer,
                        MoveAI, LongRange);
                        */
        LoadSceneChange.LoadSceneRotation("SeaTactic");
        //throw new Exception("GotoSeaTactic");
       // Main._main.ChangeDrawBattleViewModel(FactoryDictionary.SeaTacticPlanet);
    }
    public void GotoTactic(ButtonEvent buttonEvent, GridFleet heroFiend)
    {

        //throw new Exception("GotoTactic");
        //Main._main.ChangeDrawBattleViewModel(FactoryDictionary.TacticPlanet);
    }
    public void GotoPlanetWorld()
    {
        
        //throw new Exception("GotoPlanetWorld");
       // Main._main.ChangeDrawBattleViewModel(FactoryDictionary.BattlePlanet);
        LoadSceneChange.LoadSceneRotation("SampleScene");
    }
    public void GotoSuperGlobalWinEnd()
    {
        throw new Exception("GotoSuperGlobalWinEnd");
        //Main._main.ChangeDrawBattleViewModel(FactoryDictionary.Win);
    }
    public void GotoGlobalWin()
    {
        LoadSceneChange.LoadSceneRotation("GlobalWin");
       // throw new Exception("GotoGlobalWin");
        //Main._main.ChangeDrawBattleViewModel(FactoryDictionary.TotalMenu);
    }
    public void GotoGlobalFail()
    {
       // throw new Exception("GotoGlobalFail");
        //GlobalFail
        LoadSceneChange.LoadSceneRotation("GlobalFail");
        // Main._main.ChangeDrawBattleViewModel(FactoryDictionary.Defeat);
    }
    public GridFleet GetHeroWithId(List<GridFleet> NameHero_ar, int SelectHeroId)
    {
        if (NameHero_ar != null)
        {
            foreach (GridFleet gridFleet in NameHero_ar)
            {
                
                if (gridFleet.GetId() == SelectHeroId)
                {
                    return gridFleet;
                }
            }
        }
        return null;
    }
    public List<CommandStrategy> BattlePlanetTurn()
    {

        MapWorldModel.MapWorldModelSingleton().TurnEvent();
        return _BattlePlanetModel.AnimationCommand();
    }
    public List<CommandStrategy> AnimationCommand()
    {
        List<CommandStrategy> CommandMoveAttackList = MapWorldModel.MapWorldModelSingleton().GetCommandMoveAttackList();
        foreach (CommandStrategy item in CommandMoveAttackList)
        {
            //this.MoveFleet(item);
            MapWorldModel.MapWorldModelSingleton().PickUpCommandCaptureIsland(item);
        }
        return CommandMoveAttackList;
    }

    public void GotoFragDropArmy()
    {

       // Main._main.ChangeDrawBattleViewModel(FactoryDictionary.DragDropArmy);
    }
    public void SelectIslandFleet(Island island)
    {
        if (island != null)
        {
            SelectIsland = island;
        }
    }
    public void GotoIsland(Island island)
    {
        if (island != null)
        {
            SelectIsland = island;
        }
        LoadSceneChange.LoadSceneRotation("TownScene");
        //Main._main.ChangeDrawBattleViewModel(FactoryDictionary.IslandHarbor);

    }
    public List<ButtonEvent> GetPathSelectHeroButtonEventList()
    {
        List<ButtonEvent> buttonEventList = GetPathSelectHero(
                        this._prototypeHeroDemo,
                         BattlePlanetModel.GetBattlePlanetModelSingleton().GetShoalSeaBasa_ar(),
                         MapWorldModel.MapWorldModelSingleton().GetIslandMemento(),
                         BattlePlanetModel.GetBattlePlanetModelSingleton().GetGridTileList(),
                         ControllerConstant.PathHero,
                         ControllerConstant.AttackHero,
                         false,
                         BattlePlanetModel.GetBattlePlanetModelSingleton().GetSelectHeroId(),
                         BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()
                         );
        return buttonEventList;
    }


    public List<ButtonEvent> GetPathSelectHero(
        PrototypeHeroDemo prototypeHeroDemo,
             List<List<int>> shoalSeaBasa_ar,
            IslandMemento islandDemoMemento,
            List<GridTileBar> GridTile_ar,
            String PathHeroName,
            String AttackHeroName,
            bool SpeedStatic,
            int SelectHeroId,
            int FlagIdHeroFleet
            )
    {

        GridFleet gridFleet = GetHeroWithId(prototypeHeroDemo.GetHeroFleet(), SelectHeroId);


        if (gridFleet == null)
        {

            return new List<ButtonEvent>();
        }
        if (FlagIdHeroFleet == 0) 
        {
            FlagIdHeroFleet = gridFleet.GetFlagId();
        }
        int gridFleetSpeed = gridFleet.GetSpeed();
 
    
        if (SpeedStatic)
        {
            gridFleetSpeed = gridFleet.GetPowerReserve();

     
        }
     
        bool range = false;
        /*
        if (fleetFiend != null && fleetPlayer != null)
        {
            
            range = new MendMoveAbleFire().DetermineAbleFirePlayer(fleetFiend, fleetPlayer, gridFleet,
                    new Point(gridFleet.SpotX + 2, gridFleet.SpotY + 2),
                    GlobalParamsTimeQuick, GlobalParamsGale);


        }
        else
        {
        */
            range = gridFleet.GetRange();
        //}
        
   
 
        //////
        return SelectHeroPath(gridFleet,
                prototypeHeroDemo,
                FlagIdHeroFleet,
                shoalSeaBasa_ar, islandDemoMemento, GridTile_ar,
                PathHeroName, AttackHeroName, gridFleetSpeed, range);


    }
    public List<ButtonEvent> SelectHeroPath(
            GridFleet HeroFleet,
            PrototypeHeroDemo prototypeHeroDemo,
            int flagIdHero, 
            List<List<int>> shoalSeaBasa_ar,
            IslandMemento islandDemoMemento,
            List<GridTileBar> GridTile_ar,
            String PathHeroName, String AttackHeroName, int HeroFleetSpeed, bool range)
    {
        
        if (HeroFleet == null)
        {
            return new List<ButtonEvent>();
        }

        List<ButtonEvent> buttonEvent_ar = new List<ButtonEvent>();

        if (ModelStrategy.GetHeroAll(flagIdHero, prototypeHeroDemo.GetHeroFleet()).Count > 0)
        {
          
            if (HeroFleet.GetFlagId() == flagIdHero)
            {


                if (HeroFleet.GetPowerReserve() > 0)
                {
                    List<Point> wayRude_ar = ModelStrategy.CreateVariationWay(HeroFleetSpeed);

                    List<WayGotoModel> wayGotoModel_ar =
                            ModelStrategy.SelectVariationWayFleet(HeroFleet, wayRude_ar,
                            DispositionCountry_ar, shoalSeaBasa_ar,
                            islandDemoMemento.GetIslandArray(), prototypeHeroDemo, GridTile_ar);



                    foreach (WayGotoModel wayPoint in wayGotoModel_ar)
                    {

                        if (wayPoint.PathGoto_ar.Count <= HeroFleetSpeed + 1)
                        {

                            Point pointHero = new Point(wayPoint.X, wayPoint.Y);

                            if (ModelStrategy.AllowPointMap(shoalSeaBasa_ar, pointHero))
                            {


                                List<long[]> map_ar_ar = ModelStrategy.PreparationMap(
                                        GridTile_ar,
                                        prototypeHeroDemo.GetHeroFleet(),
                                        HeroFleet.GetFlagId(),
                                        DispositionCountry_ar,
                                        true,
                                        HeroFleet.GetSea(),
                                        islandDemoMemento.GetIslandArray());


                                if (map_ar_ar[(int)pointHero.X][(int)pointHero.Y] != BattlePlanetModel.GetBattlePlanetModelSingleton().ObstacleMap)
                                {

                                    ButtonEvent modelEvent = new ButtonEvent();
                                    modelEvent.HeroFleet = HeroFleet;
                                    modelEvent.Point = pointHero;
                                    modelEvent.SpotX = (int)pointHero.X;
                                    modelEvent.SpotY = (int)pointHero.Y;
                                    modelEvent.PathGoto_ar = wayPoint.PathGoto_ar;
                                    modelEvent.TypeEventId = 1;
                                    //modelEvent.NameEvent = ControllerConstant.PathHero;
                                    modelEvent.NameEvent = PathHeroName;
                                    modelEvent.MoveAI = false;
                                    buttonEvent_ar.Add(modelEvent);

                                }
                            }
                        }
                    }
                }
            }
            

            bool attack = !HeroFleet.GetAttackDone() && HeroFleet.GetPowerReserve() <= 0;
            
            if (attack)
            {
                // click Attack
                // Is long range unit?
                //boolean range = HeroFleet.GetRange();
                //boolean rangeDistance = false;
                List<GridFleet> fiendHeroWar_ar = SelectHeroAttacSemikPath(range, HeroFleet, prototypeHeroDemo,
         shoalSeaBasa_ar);
                /*
                List<GridFleet> fiendHeroWar_ar;

                if (range)
                {
                    fiendHeroWar_ar = ModelStrategy.PreparationAttackFleet(HeroFleet,
                            DispositionCountry_ar,
                            prototypeHeroDemo.GetHeroFleet(),
                            shoalSeaBasa_ar,
                            ModelStrategy.GetXmapNear(false)
                         );

                }
                else
                {

                    fiendHeroWar_ar = ModelStrategy.PreparationAttackFleet(HeroFleet,
                               DispositionCountry_ar,
                               prototypeHeroDemo.GetHeroFleet(),
                               shoalSeaBasa_ar,
                               ModelStrategy.GetMapFlagIslandArray()
                            );
                }
                */
                foreach (GridFleet attackFiendFleetWar in fiendHeroWar_ar)
                {

                    Point pointAttack = new Point(attackFiendFleetWar.SpotX, attackFiendFleetWar.SpotY);


                    ButtonEvent modelEvent = new ButtonEvent();
                    modelEvent.HeroFleet = HeroFleet;
                    modelEvent.VictimFleet = attackFiendFleetWar;
                    modelEvent.Point = pointAttack;
                    modelEvent.SpotX = (int)pointAttack.X;
                    modelEvent.SpotY = (int)pointAttack.Y;
                    modelEvent.TypeEventId = 1;
                    modelEvent.NameEvent = AttackHeroName;
                    //modelEvent.NameEvent = ControllerConstant.AttackHero;
                    modelEvent.MoveAI = false;
                    modelEvent.LongRange = ModelStrategy.GetDistanceSQRT(
                            new Point(HeroFleet.SpotX, HeroFleet.SpotY),
                            pointAttack);
                    buttonEvent_ar.Add(modelEvent);

                }
            }

        }

        return buttonEvent_ar;
    }
    public List<GridFleet> SelectHeroAttacSemikPath(bool Range, GridFleet HeroFleet, PrototypeHeroDemo prototypeHeroDemo,
        List<List<int>> shoalSeaBasa_ar) {
        List<GridFleet> fiendHeroWar_ar;

        if (Range)
        {
            fiendHeroWar_ar = ModelStrategy.PreparationAttackFleet(HeroFleet,
                    DispositionCountry_ar,
                    prototypeHeroDemo.GetHeroFleet(),
                    shoalSeaBasa_ar,
                    ModelStrategy.GetXmapNear(false)
                 );

        }
        else
        {

            fiendHeroWar_ar = ModelStrategy.PreparationAttackFleet(HeroFleet,
                       DispositionCountry_ar,
                       prototypeHeroDemo.GetHeroFleet(),
                       shoalSeaBasa_ar,
                       ModelStrategy.GetMapFlagIslandArray()
                    );
        }
        return fiendHeroWar_ar;
    }
    public List<ArmUnit> GetHarrisonHarborPort()
    {
        /*
        ButtonEvent buttonEvent = BattlePlanetModel.VisButtonHarborPort();
        if (buttonEvent == null) {
            return null;
        }
        
            GridFleet gridFleet = ModelStrategy.SearchHeroOne(
                           (int)buttonEvent.Point.X,
                           (int)buttonEvent.Point.Y,
                           MapWorldModel._prototypeHeroDemo.GetHeroFleet(),
                           BattlePlanetModel.FlagIdHero,
                           false);
*/
        GridFleet gridFleet = GetHarrisonGridFleetHarborPort();
        int countUnit = ModelStrategy.GetHeroShipFirstCount(gridFleet);
        return ModelStrategy.GetHeroShipFirstCrewArray(gridFleet);

    }
    public GridFleet GetHarrisonGridFleetHarborPort()
    {
        ButtonEvent buttonEvent = BattlePlanetModel.GetBattlePlanetModelSingleton().VisButtonHarborPort();
        if (buttonEvent == null)
        {
            return null;
        }
        return ModelStrategy.SearchHeroOne(
                           (int)buttonEvent.Point.X,
                           (int)buttonEvent.Point.Y,
                           this._prototypeHeroDemo.GetHeroFleet(),
                           BattlePlanetModel._BattlePlanetModel.FlagIdHero,
                           false);
    }

        public ButtonEvent VisButtonHarborPort()
    {

        GridFleet gridFleet = BattlePlanetModel.GetBattlePlanetModelSingleton().GetHeroWithId(
                this._prototypeHeroDemo.GetHeroFleet(),
                BattlePlanetModel._BattlePlanetModel.SelectHeroId);


        if (gridFleet != null)
        {
            Island island = ModelStrategy.GetIsland(MapWorldModel.MapWorldModelSingleton().GetIslandMemento().GetIslandArray(),
                    DispositionCountry_ar, gridFleet.SpotX, gridFleet.SpotY);




            if (island != null)
            {

                if (island.FlagId == gridFleet.GetFlagId())
                {

                    ButtonEvent modelEvent = GetButtonEvent(island, gridFleet);

                    return modelEvent;
                }
            }
        }

        return null;
    }
    public ButtonEvent GetButtonEvent(Island isl, GridFleet gridFleet)
    {
        ButtonEvent modelEvent = new ButtonEvent();

        modelEvent.Point = new Point(isl.SpotX, isl.SpotY);
        modelEvent.SpotX = (int)isl.SpotX;
        modelEvent.SpotY = (int)isl.SpotY;
        modelEvent.Island = isl;
        modelEvent.NameEvent = ControllerConstant.IslandHero;
        modelEvent.HeroFleet = gridFleet;

        return modelEvent;
    }
}
