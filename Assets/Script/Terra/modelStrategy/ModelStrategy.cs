using System.Collections;
using System.Collections.Generic;

using System;
public class ModelStrategy 
{
    public static ButtonEvent GreatImpDrivingAI(
            List<Country> DispositionCountry_ar,
            int FlagIdHero,
            List<GridFleet> NameHero_ar,
            List<GridTileBar> Grid_ar,
            List<Island> Island_ar,
            List<List<int>> ShoalSeaBasa_ar,
            //List<GridCrewScience> BasaPurchaseUnitScience_ar,
            BattlePlanetModel battlePlanetModel,
            int HeroMax,
            List<CommandStrategy> CommandStrategy_ar,
            List<GridTileBar> GridTile_ar
            )
    {
        for (int Imperial = 0; Imperial < DispositionCountry_ar.Count; Imperial++)
        {

            // unPlayer turn
            if (DispositionCountry_ar[Imperial].PlayerControl != true)
            {

                // peace
                if (BattlePlanetModel.GetBattlePlanetModelSingleton()._contactStateProceeding.ContactGlobalPeace(DispositionCountry_ar[Imperial]))
                {


                    MendMovePeaceShip.moveFiend_MIR(DispositionCountry_ar[Imperial], NameHero_ar, Island_ar,
                            DispositionCountry_ar, Grid_ar, CommandStrategy_ar);

                }
                else
                {
                    // war

                    ButtonEvent buttonEvent = WarMove(DispositionCountry_ar, Imperial, NameHero_ar, Grid_ar,
                        Island_ar, CommandStrategy_ar);
                    if (buttonEvent != null)
                    {
                        return buttonEvent;

                    }



                }

                GridFleet fleet = RefillHero(DispositionCountry_ar[Imperial],
                        NameHero_ar, Island_ar, ShoalSeaBasa_ar,
                        DispositionCountry_ar, battlePlanetModel, HeroMax, GridTile_ar);

                if (fleet != null)
                {
                    CommandStrategy commandStrategy = new CommandStrategy();
                    commandStrategy.NameCommand = CommandStrategy.Type.CreateFleet;
                    commandStrategy.GridFleet = fleet;

                    CommandStrategy_ar.Add(commandStrategy);

                }
            }

        }

        return null;
    }
    public static ButtonEvent WarMove(List<Country> DispositionCountry_ar, int Imperial, List<GridFleet> NameHero_ar,
        List<GridTileBar> Grid_ar, List<Island> Island_ar, List<CommandStrategy> CommandStrategy_ar)
    {
        List<GridFleet> DispositionCountryNameHero_ar
                    = FiendFleet.GetHeroAll(DispositionCountry_ar[Imperial].IdCountry, NameHero_ar);

        foreach (GridFleet gridFleet in DispositionCountryNameHero_ar)
        {

            if (gridFleet.GetTurnDone())
            {

            }
            else
            {

                // old point 
                Point oldPoint = new Point(gridFleet.SpotX, gridFleet.SpotY);

                // move and search attack enemy.
                AttackMoveFleet attackMoveFleet = MendMoveShip.PlaceFiendX(
                        gridFleet,
                        NameHero_ar,
                        Grid_ar,
                        Island_ar,
                        DispositionCountry_ar, CommandStrategy_ar, null, 0, 0);


                FleetSacrifive fleetSacrifive = SetFleetSacrifive(attackMoveFleet,
                        gridFleet, oldPoint);
                GridFleet heroPlayerSacrifive = fleetSacrifive.HeroPlayerSacrifive;
                oldPoint = fleetSacrifive.OldPoint;

                if (heroPlayerSacrifive != null)
                {
                    // command Attack fleet 

                    CommandStrategy_ar.Add(GetCommandAttack(gridFleet, heroPlayerSacrifive,
                            attackMoveFleet, oldPoint));



                    return AgentEvent.GetButtonEventModelMeeleeFleet(heroPlayerSacrifive,
                            gridFleet, true, attackMoveFleet.LongRange);

                }
            }
        }
        return null;
    }
    public static GridTileBar GetOneGrid(List<GridTileBar> Grid_ar, int GridRow, int GridLine)
	{
		return AI_Behavior_Existence.GetOneGrid(Grid_ar, GridRow, GridLine);
	}
	public static bool GetContactPeace(List<Country> DispositionCountry_ar,
			Point flagIdPoint)
	{
		return BattlePlanetModel.GetBattlePlanetModelSingleton()._contactStateProceeding.GetContactPeace(DispositionCountry_ar,
				flagIdPoint);
	}
	public static List<long[]> PreparationMap(
			List<GridTileBar> Grid_ar,
			List<GridFleet> NameHero_ar, int FlagId, List<Country> DispositionCountry_ar,
			bool StopFiendHero, bool Sea, List<Island> Island_ar)
	{
		return AI_Behavior_Existence.PreparationMap(Grid_ar, NameHero_ar, FlagId,
				DispositionCountry_ar, StopFiendHero, Sea, Island_ar);
	}
	public static Island GetIsland(List<Island> Island_ar,
				List<Country> DispositionCountry_ar, int SpotX, int SpotY)
	{
		// пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅ - return null.
		return FiendFleet.GetIsland(Island_ar, DispositionCountry_ar, SpotX, SpotY);
	}
	public static void EconomicReset()
	{
		Economic.Reset();
	}
	public static List<Island> GetFlagIslandArray(List<Island> island_ar, int flagIdHero, bool FlagFiend)
	{
		// пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ. FlagFiend - пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ.
		return FiendFleet.GetFlagIslandArray(island_ar, flagIdHero, FlagFiend);
	}
	public static void InitContact(BattlePlanetModel battlePlanetModel)
	{
        battlePlanetModel._contactStateProceeding.InitContact(battlePlanetModel);
	}
	public static void SetContactPeace(BattlePlanetModel battlePlanetModel,
		Point flagIdPoint, bool Peace)
	{
        battlePlanetModel._contactStateProceeding.SetContactPeace(battlePlanetModel.GetDispositionCountryList(),
                flagIdPoint, Peace);
	}
	public static void RefreshHeroPower(List<GridFleet> NameHero_ar, bool SpeedStatic)
	{
		RefreshFleetPower.RefreshHeroPower(NameHero_ar, SpeedStatic);
	}
	public static List<ShipCapsule> GetAbleFireWithDistance(GridFleet gridFleet,
			Point pointLongRange, ArmUnit ArmUnitFleet,
			int GlobalParamsTimeQuick, int GlobalParamsGale
			)
	{
		return new MendMoveAbleFire().GetAbleFireWithDistance(gridFleet, pointLongRange, ArmUnitFleet, GlobalParamsTimeQuick, GlobalParamsGale);
	}
	public static double GetDistance(Point Start, Point End)
	{
		return WayGotoAttack.GetDistance(Start, End);
	}
	public static bool GetlongRangeDistance(Point Start, Point End) {
		return GetDistance(Start, End) > 1;
	}
	public static bool AllowPointMap(List<List<int>> ShoalSeaBasa_ar, Point point)
	{
		return AI_Behavior_Existence.AllowPointMap(ShoalSeaBasa_ar, point);
	}
	public static List<GridFleet> GetFiendHeroAll(int spotX, int spotY, int flagId,
				List<GridFleet> NameHero_ar)
	{
		return FiendFleet.GetFiendHeroAll(spotX, spotY, flagId,
				NameHero_ar);
	}
	public static FleetSacrifive SetFleetSacrifive(AttackMoveFleet attackMoveFleet, GridFleet gridFleet,
			Point oldPoint)
	{

		GridFleet heroPlayerSacrifive = null;
		if (attackMoveFleet != null)
		{
			heroPlayerSacrifive = attackMoveFleet.Fleet;
			if (attackMoveFleet.PlacePredator != null)
			{
				gridFleet.SpotX = (int)attackMoveFleet.PlacePredator.X;
				gridFleet.SpotY = (int)attackMoveFleet.PlacePredator.Y;
				oldPoint = attackMoveFleet.PlacePredator;
			}
		}
		FleetSacrifive fleetSacrifive = new FleetSacrifive();
		fleetSacrifive.HeroPlayerSacrifive = heroPlayerSacrifive;
		fleetSacrifive.OldPoint = oldPoint;

		return fleetSacrifive;
	}
	public static CommandStrategy GetCommandAttack(GridFleet gridFleet, GridFleet heroPlayerSacrifive,
			AttackMoveFleet attackMoveFleet, Point oldPoint)
	{
		// command Attack fleet 
		return GetAttackCommand(gridFleet,
				heroPlayerSacrifive,
				attackMoveFleet,
				oldPoint);
	}
	public static CommandStrategy GetAttackCommand(GridFleet gridFleet,
			GridFleet heroPlayerSacrifive,
			AttackMoveFleet attackMoveFleet,
			Point oldPoint)
	{
		CommandStrategy commandStrategy = new CommandStrategy();
		commandStrategy.GridFleetNewPoint = new Point(gridFleet.SpotX, gridFleet.SpotY);

		commandStrategy.GridFleetVictim = heroPlayerSacrifive;
		commandStrategy.NameCommand = CommandStrategy.Type.AttackFleet;
		commandStrategy.GridFleet = gridFleet;
		commandStrategy.GridFleet.SpotX = heroPlayerSacrifive.SpotX;
		commandStrategy.GridFleet.SpotY = heroPlayerSacrifive.SpotY;
		//GridFleetOldPoint

		commandStrategy.GridFleetOldPoint = oldPoint;
		commandStrategy.GridFleetNewPoint = new Point(heroPlayerSacrifive.SpotX, heroPlayerSacrifive.SpotY);
		commandStrategy.LongRange = attackMoveFleet.LongRange;

		return commandStrategy;
	}
	public static void PerformCommandMoveFleet(PrototypeHeroDemo prototypeHeroDemo,
			CommandStrategy commandStrategy)
	{
		new PerformCommandModel().PerformCommandMoveFleet(prototypeHeroDemo, commandStrategy);
	}
	public static void SetPrizeIsland(List<Country> DispositionCountry_ar, int flagId)
	{
		CaptureSeizureIsland.SetPrizeIsland(DispositionCountry_ar, flagId);
	}
	public static void PerformAttackFleetAction(PrototypeHeroDemo prototypeHeroDemo, CommandStrategy commandStrategy)
	{
		GridFleet gridFleet = prototypeHeroDemo.GetFleetWithId(commandStrategy.GridFleet.GetId());
	
		if (gridFleet != null)
		{
			gridFleet.SetAttackDone(true);
			gridFleet.SetTurnDone(true);
			gridFleet.PowerReserveChange(-1);
		}
	}
	public static void EconomicTurn(List<Country> DispositionCountry_ar, List<Island> Island_ar)
	{
		Economic.Turn(DispositionCountry_ar, Island_ar);
	}
	public static Country GetPlayerCountryFollow(List<Country> DispositionCountry_ar,
				int flagId)
	{
		return BattlePlanetModel.GetBattlePlanetModelSingleton()._contactStateProceeding.GetPlayerCountryFollow(DispositionCountry_ar,
				flagId);
	}
	public static CommandStrategy GetCommandMoveFleet(Point gridFleetOldPoint, Point resultPoint,
			GridFleet gridFleet)
	{
		return MendMoveShip.GetCommandMoveFleet(gridFleetOldPoint, resultPoint, gridFleet);
	}
	public static GridFleet SearchHeroOne(int spotX, int spotZ, List<GridFleet> NameHero_ar,
			int flagId, bool Fiend)
	{
		return FiendFleet.SearchHeroOne(spotX, spotZ, NameHero_ar, flagId, Fiend);

	}
	public static CommandStrategy GetCommandCaptureIsland(Island isl, GridFleet gridFleet)
	{
		return CaptureSeizureIsland.GetCommandCaptureIsland(isl, gridFleet);
	}
	public static AttackMoveFleet GetAttackMoveFleet(GridFleet fleetVictim, bool LongRange, Point PlacePredator)
	{
		return MendMoveShip.GetAttackMoveFleet(fleetVictim, LongRange, PlacePredator);
	}
	public static void FleetAddArmFast(GridFleet heroPlayer, int UnitTypeId,
            BattlePlanetModel battlePlanetModel, int customShip)
	{
		new CreateFleetFast().FleetAddArmFast(heroPlayer, UnitTypeId, battlePlanetModel, customShip);
	}
	public static Country GetDispositionCountry(List<Country> DispositionCountry_ar,
				int flagId)
	{
		return BattlePlanetModel.GetBattlePlanetModelSingleton()._contactStateProceeding.GetDispositionCountry(DispositionCountry_ar,
						flagId);

	}
	public static List<GridFleet> GetHeroAll(int flagId, List<GridFleet> NameHero_ar)
	{
		return FiendFleet.GetHeroAll(flagId, NameHero_ar);
	}
	
    public static GridFleet RefillHero(Country country, List<GridFleet> NameHero_ar,
			List<Island> Island_ar, List<List<int>> ShoalSeaBasa_ar,
			List<Country> DispositionCountry_ar,
            //List<GridCrewScience> BasaPurchaseUnitScience_ar,
            BattlePlanetModel BattlePlanetModel,
            int HeroMax, List<GridTileBar> GridTile_ar)
	{



		List<GridFleet> heroCountry_ar = FiendFleet.GetHeroAll(country.IdCountry, NameHero_ar);
		if (heroCountry_ar.Count < HeroMax)
		{
			var rand = new System.Random();

			//int typeUnit = (int)Math.floor(Math.random() * BasaPurchaseUnitScience_ar.size());
			int typeUnit = rand.Next(BattlePlanetModel.GetBasaPurchaseUnitScience().Count);

			int cost = UnitTech.GetUnit(typeUnit).Cost * BattlePlanetModel.SizeSquad;

			if (country.Money - cost >= 0)
			{


				GridFleet fleet = new AI_Behavior_Replace().Replace_Ship_AfterLoss(
						country.IdCountry, Island_ar, ShoalSeaBasa_ar,
						DispositionCountry_ar, BattlePlanetModel, typeUnit, GridTile_ar);
				if (fleet != null)
				{
					country.Money -= cost;
				}
				return fleet;

			}
		}
		return null;
	}
	public static GridFleet GetFleetFast(int SpotX, int SpotY, int FlagId,
			String Name, int UnitTypeId,
            BattlePlanetModel battlePlanetModel,
			bool AddOne, int customShip)
	{
		String image = CreateGridScenario.GetImageIcon(UnitTypeId);
		//System.Diagnostics.Debug.WriteLine(" UnitTypeId = " + UnitTypeId);
		return new CreateFleetFast().GetFleetFast(SpotX, SpotY, FlagId, image, Name, UnitTypeId,
                battlePlanetModel, AddOne, customShip);
	}
	public static void PerformCommand(CommandStrategy commandStrategy)
	{
		new PerformCommandModel().PerformCommand(commandStrategy);
	}
	public static int GetHeroShipFirstCount(GridFleet Hero)
	{
		return HeroShipFirst.GetHeroShipFirstCount(Hero);
	}
	public static List<Point> CreateVariationWay(int Speed)
	{
		return WayGotoSelectField.CreateVariationWay(Speed);
	}
	public static List<Point> GetFindPathBigArray(Point pointAim,
				Point FiendPoint, int FiendFlagId,
				List<GridFleet> NameHero_ar,
				List<GridTileBar> Grid_ar,
				List<Country> DispositionCountry_ar, bool StopFiendHero,
				bool Sea, List<Island> Island_ar)
	{

		List<Point> pointPath_ar = new List<Point>();

		// map?

		//StartNode_ID_Fiend
		List<SuperNode> pathBasa_ar = AI_Behavior.GetFindPathBigArray(pointAim,
				FiendPoint, FiendFlagId,
				NameHero_ar, Grid_ar,
				DispositionCountry_ar, StopFiendHero, Sea, Island_ar);



		foreach (SuperNode superNode in pathBasa_ar)
		{


			Point nodePoint = new Point((superNode.id % 100), (superNode.id / 100));
			pointPath_ar.Add(nodePoint);
		}
		return pointPath_ar;

	}
	public static List<WayGotoModel> SelectVariationWayFleet(GridFleet Hero,
				List<Point> wayRude_ar,
				List<Country> DispositionCountry_ar, List<List<int>> ShoalSeaBasa_ar,
				List<Island> Island_ar, PrototypeHeroDemo prototypeHeroDemo,
				List<GridTileBar> GridTile_ar)
	{
		return WayGotoSelectField.SelectVariationWayFleet(Hero, wayRude_ar,
				DispositionCountry_ar, ShoalSeaBasa_ar, Island_ar, prototypeHeroDemo,
				GridTile_ar);
	}
	public static List<GridFleet> PreparationAttackFleet(GridFleet Hero,
				List<Country> DispositionCountry_ar, List<GridFleet> NameHero_ar,
				List<List<int>> ShoalSeaBasa_ar, List<Point> CircleFleet_ar)
	{

		return WayGotoAttack.PreparationAttackFleet(Hero,
				DispositionCountry_ar, NameHero_ar, ShoalSeaBasa_ar, CircleFleet_ar);
	}
	public static List<Point> GetXmapNear(bool AddCenter)
	{
		return CoordinateSearch.GetXmapNear(AddCenter);
	}
	public static List<Point> GetMapFlagIslandArray()
	{
		return CoordinateSearch.GetMapFlagIslandArray();
	}
	public static bool GetDistanceSQRT(Point Start, Point End)
	{
		return WayGotoAttack.GetDistanceSQRT(Start, End);
	}
	public static List<ArmUnit> GetHeroShipFirstCrewArray(GridFleet Hero)
	{
		return HeroShipFirst.GetHeroShipFirstCrewArray(Hero);
	}
}
