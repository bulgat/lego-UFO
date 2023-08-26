using System.Collections;
using System.Collections.Generic;


public class GridScenario3 : GridScenarioAbstract, IGridScenario
{
	private string Mission = "Последний бой";

	private string NameTileMap = "map/duneMap03.tmx";

	public string GetNameTileMap()
	{
		return NameTileMap;
	}
	public string GetMission()
	{
		return Mission;
	}

	public void Init()
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
		BattlePlanetModel.SetShoalSeaBasa_ar(new List<List<int>>  {
			  new List<int>(){0,0,0,0,0, 0,0,0,0,0, 0,1,4},
			  new List<int>(){0,0,0,0,0, 0,0,0,0,0,0,4,8},
			  new List<int>(){0,0,0,0,0, 0,0,0,0,0,0,0,11},
			 new List<int>(){0,0,0,0,0, 0,0,0,0 ,0, 0,0,7},
			  new List<int>(){0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			 new List<int>(){0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			  new List<int>(){0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			  new List<int>(){0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			  new List<int>(){0,0,0,0,0, 0,0,0,0,0,0,3,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0,0,0,0,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0,0,0,0,0}
		 });

		CreateGridScenario.AddCountry();

		MapWorldModel.GetIslandMemento().AddIsland(new Island("desert", 3, 2, 0, false, BattlePlanetModel.DispositionCountry_ar[0].IdCountry));
		//BattlePlanetModel.Island_ar.add(new Island("aqua",2,6,1,false,BattlePlanetModel.DispositionCountry_ar.get(0).IdCountry));

		MapWorldModel.GetIslandMemento().AddIsland(new Island("sand", 3, 5, 0, false, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()));

		MapWorldModel.GetIslandMemento().AddIsland(new Island("cactus", 10, 4, 0, false, BattlePlanetModel.DispositionCountry_ar[2].IdCountry));

		MapWorldModel._prototypeHeroDemo.HeroFleetInit();
		// пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ.
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(2, 5,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(),
				"Ned", 0,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));


		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(9, 4, 2, "Kligan", 2,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));



		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(4, 6,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), "Star", 1,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));

		// пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ.

		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(8, 10,
				1, "Brann", 0, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(4, 2,
				2, "Nemo2", 2, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));

		// 3 пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ.

		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(2, 1,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), "he-3", 2, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(1, 3,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), "hero4", 1, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(9, 1,
				1, "hero5", 2, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));

		List<Point> mountaun_ar = new List<Point>();
		mountaun_ar.Add(new Point(3, 1));
		mountaun_ar.Add(new Point(4, 3));
		mountaun_ar.Add(new Point(5, 3));
		mountaun_ar.Add(new Point(6, 3));
		mountaun_ar.Add(new Point(3, 6));
		mountaun_ar.Add(new Point(3, 7));

		List<Point> road_ar = new List<Point>();

		road_ar.Add(new Point(3, 4));
		road_ar.Add(new Point(4, 4));
		road_ar.Add(new Point(5, 4));
		road_ar.Add(new Point(6, 4));
		road_ar.Add(new Point(7, 4));
		road_ar.Add(new Point(8, 4));
		road_ar.Add(new Point(9, 4));

		List<Point> sea_ar = new List<Point>();

		BattlePlanetModel.SetGridTileList( new CreateGridScenario().CreateGridInit(mountaun_ar, road_ar, sea_ar, BattlePlanetModel.GetShoalSeaBasa_ar()));


		CreateGridScenario.AddUnhide();

		//Main._victoryWin.SetVictoryImage(GraficBibleConstant.VictoryWin);
		InitSetHeroSelect();
	}
	public int ImageMission()
	{
		return 2;
	}
}
