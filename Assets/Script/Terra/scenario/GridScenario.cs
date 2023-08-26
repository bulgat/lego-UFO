using System.Collections;
using System.Collections.Generic;

public class GridScenario: GridScenarioAbstract,IGridScenario
{
	private string Mission = "Вперед рекрут!";
	private string NameTileMap = "map/duneMap.tmx";

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
		
		BattlePlanetModel.SetShoalSeaBasa_ar(new List<List<int>>  {
				  new List<int>() {3,0,0,0,0, 0,0,0,0,0, 0,1,4},
				  new List<int>() {0,0,0,0,0, 0,0,0,0,0,0,4,8},
				  new List<int>() {0,0,0,0,3, 3,3,0,0,0,0,0,11},
				 new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,7},
				 new List<int>()  {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
				 new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
				 new List<int>()  {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
				  new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
				  new List<int>() {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
				 new List<int>()  {0,0,0,0,0, 0,0,0,0 ,0, 0,0,0},
				  new List<int>() {0,0,0,0,0, 0,0,0,0,0,0,3,0},
				 new List<int>()  {0,0,0,0,0, 0,0,0,0,0,0,0,0},
				 new List<int>()  {0,0,0,0,0, 0,0,0,0,0,0,0,0}
			 });

		



		CreateGridScenario.AddCountry();

		MapWorldModel.GetIslandMemento().AddIsland(new Island("Dion", 0, 2, 0, false, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()));
		MapWorldModel.GetIslandMemento().AddIsland(new Island("Madagascar", 2, 2, 1, false, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()));
		MapWorldModel.GetIslandMemento().AddIsland(new Island("Gonkong", 10, 7, 0, false, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()));

		MapWorldModel.GetIslandMemento().AddIsland(new Island("Runa", 3, 8, 0, false, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()));

		MapWorldModel.GetIslandMemento().AddIsland(new Island("Irish", 5, 3, 1, false, BattlePlanetModel.DispositionCountry_ar[2].IdCountry));

		MapWorldModel.GetIslandMemento().AddIsland(new Island("Malta", 10, 0, 0, false, BattlePlanetModel.DispositionCountry_ar[2].IdCountry));
		MapWorldModel.GetIslandMemento().AddIsland(new Island("Orion", 6, 10, 0, false, BattlePlanetModel.DispositionCountry_ar[2].IdCountry));

		MapWorldModel._prototypeHeroDemo.HeroFleetInit();
		
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(2, 3,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(),
				InitGlobalParams.GetOfferNameHero(), 0,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));


		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(9, 4,
				2, InitGlobalParams.GetOfferNameHero(), 2,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));

		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(4, 6,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(),
				InitGlobalParams.GetOfferNameHero()
				, 1,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));


		// fiend tank.
		GridFleet gridFleet = MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(8, 8,
				1, InitGlobalParams.GetOfferNameHero(), 0, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));


		// fiend racket tank.
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(4, 2,
				2, InitGlobalParams.GetOfferNameHero(), 3, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(5, 2,
				2, InitGlobalParams.GetOfferNameHero(), 2, BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));

		
		//MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(2, 1,
           //     BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), InitGlobalParams.GetOfferNameHero(), 2,
			//	BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		//MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(1, 3,
             //   BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), InitGlobalParams.GetOfferNameHero(), 2,
			//	BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(9, 1,
				1, InitGlobalParams.GetOfferNameHero(), 3,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(1, 0,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), InitGlobalParams.GetOfferNameHero(), 4,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(0, 0,
                BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), InitGlobalParams.GetOfferNameHero(), 3,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
		//MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(2, 5,
            //    BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), InitGlobalParams.GetOfferNameHero(), 3,
			//	BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));
				
		//ship
		//MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(7, 11,
       //         BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(), InitGlobalParams.GetOfferNameHero(), 5,
		//	BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 1));

		//fiend ship
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(9, 11,
				1, InitGlobalParams.GetOfferNameHero(), 5,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 2));
				
		//infantery
		MapWorldModel._prototypeHeroDemo.HeroFleetAdd(ModelStrategy.GetFleetFast(6, 10,
				1, InitGlobalParams.GetOfferNameHero(), 4,
				BattlePlanetModel.GetBasaPurchaseUnitScience(), false, 0));

		List<Point> mountaun_ar = new List<Point>();
		mountaun_ar.Add(new Point(3, 1));
		mountaun_ar.Add(new Point(3, 2));
		mountaun_ar.Add(new Point(3, 3));
		mountaun_ar.Add(new Point(3, 4));
		mountaun_ar.Add(new Point(3, 5));
		mountaun_ar.Add(new Point(3, 6));

		mountaun_ar.Add(new Point(3, 10));
		mountaun_ar.Add(new Point(3, 11));
		mountaun_ar.Add(new Point(3, 12));

		List<Point> road_ar = new List<Point>();
		List<Point> sea_ar = new List<Point>();
		sea_ar.Add(new Point(0, 12));
		sea_ar.Add(new Point(0, 11));
		sea_ar.Add(new Point(1, 12));
		sea_ar.Add(new Point(1, 11));
		sea_ar.Add(new Point(2, 12));
		sea_ar.Add(new Point(2, 11));
		sea_ar.Add(new Point(3, 12));
		sea_ar.Add(new Point(3, 11));
		sea_ar.Add(new Point(4, 12));
		sea_ar.Add(new Point(4, 11));
		sea_ar.Add(new Point(5, 12));
		sea_ar.Add(new Point(5, 11));
		sea_ar.Add(new Point(6, 12));
		sea_ar.Add(new Point(6, 11));
		sea_ar.Add(new Point(7, 12));
		sea_ar.Add(new Point(7, 11));
		sea_ar.Add(new Point(8, 12));
		sea_ar.Add(new Point(8, 11));
		sea_ar.Add(new Point(9, 12));
		sea_ar.Add(new Point(9, 11));
		sea_ar.Add(new Point(10, 12));
		sea_ar.Add(new Point(10, 11));
		sea_ar.Add(new Point(11, 12));
		sea_ar.Add(new Point(11, 11));
		sea_ar.Add(new Point(12, 12));
		sea_ar.Add(new Point(12, 11));

	

		BattlePlanetModel.SetGridTileList(new CreateGridScenario().CreateGridInit(mountaun_ar, road_ar,
				sea_ar, BattlePlanetModel.GetShoalSeaBasa_ar()));


		CreateGridScenario.AddUnhide();


		BattlePlanetModel.VictoryScenario.ScenarioNumber = 0;


		//Main._victoryWin.SetVictoryImage(GraficBibleConstant.VictoryCompleteWin0);
		InitSetHeroSelect();
	}
	public int ImageMission()
	{
		return 0;
	}
}
