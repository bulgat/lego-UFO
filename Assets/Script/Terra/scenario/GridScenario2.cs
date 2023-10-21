using System.Collections;
using System.Collections.Generic;


public class GridScenario2: GridScenarioAbstract, IGridScenario
{
	private string Mission = "ВСЕ СЛИШКОМ СЛОЖНО";

	private string NameTileMap = "map/duneMap02.tmx";

	public string GetNameTileMap()
	{
		return NameTileMap;
	}
	public string GetMission()
	{
		return Mission;
	}
	public void Init(BattlePlanetModel battlePlanetModel)
	{/*
		BattlePlanetModel.ShoalSeaBasa_ar = new int[][]  {
			  {0,0,0,0,0, 0,0,0,0,0, 0,1,4},
			  {0,0,0,0,0, 0,0,0,0,0,0,4,8},
			  {0,0,0,0,0, 0,0,0,0,0,0,0,11},
			 {0,0,0,0,0, 0,0,0,0 ,0, 0,0,7},
			  {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			 {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			  {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			  {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			  {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			  {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			  {0,0,0,0,0, 0,0,0,0,0,0,3,0},
			  {0,0,0,0,0, 0,0,0,0,0,0,0,0},
			  {0,0,0,0,0, 0,0,0,0,0,0,0,0}
		 };
		 */

		BattlePlanetModel.GetBattlePlanetModelSingleton().SetShoalSeaBasa_ar(new List<List<int>>  {
			 new List<int>() {0,0,0,0,0, 0,0,0,0,0, 0,1,4},
			  new List<int>(){0,0,0,0,0, 0,0,0,0,0,0,4,8},
			  new List<int>(){0,0,0,0,0, 0,0,0,0,0,0,0,11},
			new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,7},
			new List<int>()  {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0,0,0,3,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0,0,0,0,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0,0,0,0,0}
		 });
        //_initGlobalParams = new InitGlobalParams();


        new CreateGridScenario().AddCountry(battlePlanetModel);
        battlePlanetModel._prototypeHeroDemo.Reset();

        MapWorldModel.MapWorldModelSingleton().GetIslandMemento().AddIsland(new Island("zero", 3, 2, 0, false, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()));
		MapWorldModel.MapWorldModelSingleton().GetIslandMemento().AddIsland(new Island("sector", 2, 6, 1, false, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()));

		MapWorldModel.MapWorldModelSingleton().GetIslandMemento().AddIsland(new Island("fabric", 10, 4, 0, false, BattlePlanetModel.GetBattlePlanetModelSingleton().DispositionCountry_ar[2].IdCountry));

        //BattlePlanetModel.NameHero_ar = new ArrayList<GridFleet>();
        battlePlanetModel._prototypeHeroDemo.HeroFleetInit();

        battlePlanetModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(2, 3,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(),
				"Ned", 0,
                battlePlanetModel, false, 0));


        battlePlanetModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(9, 4,
				2, "Kligan", 2,
                battlePlanetModel, false, 0));



        battlePlanetModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(4, 5,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(),
				"Star", 1,
                battlePlanetModel, false, 0));



        battlePlanetModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(8, 8,
				1, "Brann", 0, battlePlanetModel, false, 0));
        battlePlanetModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(7, 5,
				2, "N-2", 2, battlePlanetModel, false, 0));
        battlePlanetModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(9, 9,
				2, "N-2", 3, battlePlanetModel, false, 0));
        battlePlanetModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(8, 3,
				2, "N-2", 2, battlePlanetModel, false, 0));


        battlePlanetModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(2, 0,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), "h-3", 2, battlePlanetModel, false, 0));
        battlePlanetModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(2, 1,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), "h-3", 2, battlePlanetModel, false, 0));
        battlePlanetModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(1, 1,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), "h-4", 2, battlePlanetModel, false, 0));
        battlePlanetModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(9, 1,
				1, "hero5", 2, battlePlanetModel, false, 0));

		List<Point> mountaun_ar = new List<Point>();
		mountaun_ar.Add(new Point(3, 0));
		mountaun_ar.Add(new Point(3, 1));
		mountaun_ar.Add(new Point(4, 3));
		mountaun_ar.Add(new Point(5, 3));
		mountaun_ar.Add(new Point(6, 3));
		mountaun_ar.Add(new Point(7, 3));
		mountaun_ar.Add(new Point(3, 6));
		mountaun_ar.Add(new Point(3, 7));
		mountaun_ar.Add(new Point(3, 8));
		mountaun_ar.Add(new Point(3, 9));
		mountaun_ar.Add(new Point(3, 10));
		mountaun_ar.Add(new Point(3, 11));
		mountaun_ar.Add(new Point(3, 12));
		mountaun_ar.Add(new Point(4, 6));
		mountaun_ar.Add(new Point(4, 7));
		mountaun_ar.Add(new Point(5, 6));
		mountaun_ar.Add(new Point(5, 2));
		mountaun_ar.Add(new Point(5, 1));
		mountaun_ar.Add(new Point(6, 6));
		mountaun_ar.Add(new Point(6, 8));

		List<Point> road_ar = new List<Point>();
		List<Point> sea_ar = new List<Point>();
        battlePlanetModel.SetGridTileList(new CreateGridScenario().CreateGridInit(mountaun_ar, road_ar, sea_ar, BattlePlanetModel.GetBattlePlanetModelSingleton().GetShoalSeaBasa_ar(), battlePlanetModel));


		new CreateGridScenario().AddUnhide(battlePlanetModel);


		//Main._victoryWin.SetVictoryImage(GraficBibleConstant.VictoryCompleteWin2);
		InitSetHeroSelect();
	}
	public int ImageMission()
	{
		return 1;
	}
}
