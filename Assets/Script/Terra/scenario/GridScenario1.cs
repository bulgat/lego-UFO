﻿using System.Collections;
using System.Collections.Generic;


public class GridScenario1 : GridScenarioAbstract, IGridScenario
{
	private string Mission = "Убей всех!";
	public string NameTileMap = "map/duneMap01.tmx";

	public string GetNameTileMap()
	{
		return NameTileMap;
	}
	public string GetMission()
	{
		return Mission;
	}

	public void Init()
	{
		/*
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
		BattlePlanetModel.SetShoalSeaBasa_ar( new List<List<int>>  {
			  new List<int>(){0,0,0,0,0, 0,0,0,0,0, 0,1,4},
			  new List<int>(){0,0,0,0,0, 0,0,0,0,0,0,4,8},
			  new List<int>(){0,0,0,0,0, 0,0,0,0,0,0,0,11},
			 new List<int>(){0,0,0,0,0, 0,0,0,0 ,0, 0,0,7},
			 new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			 new List<int>(){0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			  new List<int>(){0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			  new List<int>(){0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			  new List<int>(){0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
			  new List<int>(){0,0,0,0,0, 0,0,0,0,0,0,3,0},
			  new List<int>(){0,0,0,0,0, 0,0,0,0,0,0,0,0},
			 new List<int>() {0,0,0,0,0, 0,0,0,0,0,0,0,0}
		 });

		CreateGridScenario.AddCountry();


		MapWorldModel.GetIslandMemento().AddIsland(new Island("Dion", 0, 2, 0, false, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()));
		MapWorldModel.GetIslandMemento().AddIsland(new Island("Madagascar", 2, 2, 1, false, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()));

		MapWorldModel.GetIslandMemento().AddIsland(new Island("Malta", 10, 0, 0, false, BattlePlanetModel.DispositionCountry_ar[2].IdCountry));

		MapWorldModel._prototypeHeroDemo.HeroFleetInit();

		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(2, 3,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(),
				"Ned", 0,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));


		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(9, 4,
				2, "Kligan", 2,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));

		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(4, 6,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(),
				"Star", 1,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));

		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(7, 2,
				2, "Nemo2", 2, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));

		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(2, 1,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), "he-3", 2,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(1, 1,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), "hero4", 1,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(9, 1,
				1, "h-5", 2, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(9, 2,
				1, "h-6", 2, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(10, 3,
				1, "h-7", 2, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(10, 4,
				1, "h-8", 2, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));

		List<Point> mountaun_ar = new List<Point>();
		mountaun_ar.Add(new Point(3, 1));
		mountaun_ar.Add(new Point(4, 3));
		mountaun_ar.Add(new Point(5, 3));
		mountaun_ar.Add(new Point(6, 3));
		mountaun_ar.Add(new Point(7, 3));
		mountaun_ar.Add(new Point(8, 3));
		mountaun_ar.Add(new Point(9, 3));
		mountaun_ar.Add(new Point(0, 6));
		mountaun_ar.Add(new Point(1, 6));
		mountaun_ar.Add(new Point(2, 6));
		mountaun_ar.Add(new Point(3, 6));
		mountaun_ar.Add(new Point(3, 7));
		mountaun_ar.Add(new Point(3, 8));
		mountaun_ar.Add(new Point(3, 9));
		mountaun_ar.Add(new Point(3, 10));

		List<Point> road_ar = new List<Point>();
		List<Point> sea_ar = new List<Point>();
		BattlePlanetModel.SetGridTileList( new CreateGridScenario().CreateGridInit(mountaun_ar, road_ar, sea_ar, 
			BattlePlanetModel.GetShoalSeaBasa_ar()));


		CreateGridScenario.AddUnhide();
		InitSetHeroSelect();
	}
	public int ImageMission()
	{
		return 0;
	}
}
