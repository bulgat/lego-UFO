using System.Collections;
using System.Collections.Generic;

using System;
using ZedAngular.Model.Terra;

public class BattlePlanetModel 
{
    private static List<GridTileBar> GridTile_ar = new List<GridTileBar>();
    public static int ObstacleMap = 2;
    public static int ObstacleRoadMap = 3;
    public static int ObstacleSeaMap = 4;
    public static int UnitId = 1;
    private static bool _tempSingletonBattle = false;
    public static InitGlobalParams _initGlobalParams;
    private static List<GridCrewScience> BasaPurchaseUnitScience_ar = new List<GridCrewScience>();
    public static int TypeIsland = 16;
    public static List<Country> DispositionCountry_ar = new List<Country>();
    public static int FleetId = 1;
    private int FlagIdHero = 9;
    public static VictoryStipulation VictoryScenario = new VictoryStipulation();
    public static int SizeSquad = 6;
    private int SelectHeroId = 0;
    public static bool BlockSelectHero = false;
    private static List<List<int>> ShoalSeaBasa_ar;
    public static List<GoalTypeShip> GoalTypeShip_ar;
    public static String[] OfferNameHero_ar = new String[] { "001", "002", "003", "004", "005" };
    public static Island SelectIsland = null;
    private static BattlePlanetModel _BattlePlanetModel;

    public int GetFlagIdPlayer()
    {
        return this.FlagIdHero;
    }
    public void SetFlagIdPlayer(int value)
    {
        this.FlagIdHero = value;
    }
    public static List<List<int>> GetShoalSeaBasa_ar()
    {
        return ShoalSeaBasa_ar;
    }
    public static void SetShoalSeaBasa_ar(List<List<int>> value)
    {
        ShoalSeaBasa_ar = value;
    }
   public static List<GridTileBar>  GetGridTileList()
    {
        return GridTile_ar;
    }
    public static void SetGridTileList(List<GridTileBar> value)
    {
        GridTile_ar = value;
    }

    public static BattlePlanetModel GetBattlePlanetModelSingleton() {
        if (_BattlePlanetModel == null) {
            _BattlePlanetModel = new BattlePlanetModel();

        }
        return _BattlePlanetModel;
    }
    public static List<GridCrewScience> GetBasaPurchaseUnitScience() {
        return BasaPurchaseUnitScience_ar;
    }
    public static void InitBasaPurchaseUnitScience()
    {
        BasaPurchaseUnitScience_ar= new List<GridCrewScience>();
    }
    public static void BasaPurchaseUnitScienceAdd(GridCrewScience gridCrewScience)
    {
        BasaPurchaseUnitScience_ar.Add(gridCrewScience);
    }
    public static void SetSelectHeroId(int selectHeroId) {
        _BattlePlanetModel.SelectHeroId = selectHeroId;
    }
    public static int GetSelectHeroId()
    {
        return _BattlePlanetModel.SelectHeroId;
    }
    public static void BattlePlanetModelInit()
    {
        if (!_tempSingletonBattle)
        {
            MapWorldStartGame.StartGameFirstReset(VictoryScenario);

            _tempSingletonBattle = true;
        }
    }
    public static Island GetIslandWithGridFleet(List<Island> Island_ar, GridFleet gridFleet)
    {
        return ModelStrategy.GetIsland(Island_ar,
                DispositionCountry_ar, gridFleet.SpotX, gridFleet.SpotY);
    }
    public static void GotoSeaTactic(ButtonEvent buttonEvent, GridFleet heroFiend)
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
    public static void GotoTactic(ButtonEvent buttonEvent, GridFleet heroFiend)
    {

        //throw new Exception("GotoTactic");
        //Main._main.ChangeDrawBattleViewModel(FactoryDictionary.TacticPlanet);
    }
    public static void GotoPlanetWorld()
    {
        
        //throw new Exception("GotoPlanetWorld");
       // Main._main.ChangeDrawBattleViewModel(FactoryDictionary.BattlePlanet);
        LoadSceneChange.LoadSceneRotation("SampleScene");
    }
    public static void GotoSuperGlobalWinEnd()
    {
        throw new Exception("GotoSuperGlobalWinEnd");
        //Main._main.ChangeDrawBattleViewModel(FactoryDictionary.Win);
    }
    public static void GotoGlobalWin()
    {
        LoadSceneChange.LoadSceneRotation("GlobalWin");
       // throw new Exception("GotoGlobalWin");
        //Main._main.ChangeDrawBattleViewModel(FactoryDictionary.TotalMenu);
    }
    public static void GotoGlobalFail()
    {
       // throw new Exception("GotoGlobalFail");
        //GlobalFail
        LoadSceneChange.LoadSceneRotation("GlobalFail");
        // Main._main.ChangeDrawBattleViewModel(FactoryDictionary.Defeat);
    }
    public static GridFleet GetHeroWithId(List<GridFleet> NameHero_ar, int SelectHeroId)
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
    public static void BattlePlanetTurn()
    {

        MapWorldModel.TurnEvent();
        AnimationCommand();
    }
    public static void AnimationCommand()
    {
        for(var i=0; i< MapWorldModel.GetCommandCapture().Count;i++)
        {
            MoveFleet(MapWorldModel.GetCommandCapture()[i]);
        }
    }
    public static void MoveFleet(CommandStrategy commandStrategy)
    {
        //if (commandStrategy.NameCommand == CommandStrategy.Type.MoveFleet)
        //{
            ControllerButton.SetCommandPerform(commandStrategy.Id);
            /*
            BattlePlanetView.SetCommandStrategy(_animationMove.AnimationCommand(StageWidthX, Tick,
                commandStrategy,
               //BattlePlanetView.GetCommandStrategy(),
               null, width, _animCaptureIsland, _createHero,
               SlipX, SlipY,
               BattlePlanetModel.GetBasaPurchaseUnitScience(),
               SceneList, SadIslandId, SelectAttackId, UnitHeroGameObjectList
               ));
            */
       // }








    }
    public static void GotoFragDropArmy()
    {

       // Main._main.ChangeDrawBattleViewModel(FactoryDictionary.DragDropArmy);
    }
    public static void SelectIslandFleet(Island island)
    {
        if (island != null)
        {
            SelectIsland = island;
        }
    }
    public static void GotoIsland(Island island)
    {
        if (island != null)
        {
            SelectIsland = island;
        }
        LoadSceneChange.LoadSceneRotation("TownScene");
        //Main._main.ChangeDrawBattleViewModel(FactoryDictionary.IslandHarbor);

    }
    public List<ButtonEvent> GetPathSelectHero(
        PrototypeHeroDemo prototypeHeroDemo,
             List<List<int>> shoalSeaBasa_ar,
            IslandDemoMemento islandDemoMemento,
            List<GridTileBar> GridTile_ar,
            String PathHeroName,
            String AttackHeroName,
            bool SpeedStatic,
            GridFleet fleetFiend,
            GridFleet fleetPlayer,
            int GlobalParamsTimeQuick,
            int GlobalParamsGale,
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
        //gridFleetSpeed = 1;
    
        if (SpeedStatic)
        {
            gridFleetSpeed = gridFleet.GetPowerReserve();

            // emulation set speed fleet.

        }
     
        bool range = false;
        if (fleetFiend != null && fleetPlayer != null)
        {
            
            range = new MendMoveAbleFire().DetermineAbleFirePlayer(fleetFiend, fleetPlayer, gridFleet,
                    new Point(gridFleet.SpotX + 2, gridFleet.SpotY + 2),
                    GlobalParamsTimeQuick, GlobalParamsGale);


        }
        else
        {
            range = gridFleet.GetRange();
        }
        
   
 
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
            IslandDemoMemento islandDemoMemento,
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


                                if (map_ar_ar[(int)pointHero.X][(int)pointHero.Y] != BattlePlanetModel.ObstacleMap)
                                {

                                    ButtonEvent modelEvent = new ButtonEvent();
                                    modelEvent.HeroFleet = HeroFleet;
                                    modelEvent.Point = pointHero;
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
    public static List<ArmUnit> GetHarrisonHarborPort()
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
    public static GridFleet GetHarrisonGridFleetHarborPort()
    {
        ButtonEvent buttonEvent = BattlePlanetModel.VisButtonHarborPort();
        if (buttonEvent == null)
        {
            return null;
        }
        return ModelStrategy.SearchHeroOne(
                           (int)buttonEvent.Point.X,
                           (int)buttonEvent.Point.Y,
                           MapWorldModel._prototypeHeroDemo.GetHeroFleet(),
                           BattlePlanetModel._BattlePlanetModel.FlagIdHero,
                           false);
    }

        public static ButtonEvent VisButtonHarborPort()
    {

        GridFleet gridFleet = BattlePlanetModel.GetHeroWithId(
                MapWorldModel._prototypeHeroDemo.GetHeroFleet(),
                BattlePlanetModel._BattlePlanetModel.SelectHeroId);


        if (gridFleet != null)
        {
            Island island = ModelStrategy.GetIsland(MapWorldModel.GetIslandMemento().GetIslandArray(),
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
    public static ButtonEvent GetButtonEvent(Island isl, GridFleet gridFleet)
    {
        ButtonEvent modelEvent = new ButtonEvent();

        modelEvent.Point = new Point(isl.SpotX, isl.SpotY);
        modelEvent.Island = isl;
        modelEvent.NameEvent = ControllerConstant.IslandHero;
        modelEvent.HeroFleet = gridFleet;

        return modelEvent;
    }
}
