using System.Collections;
using System.Collections.Generic;

using System;
public class InitGlobalParams
{
	public List<GridCrewScience> UnitrewScience_ar = new List<GridCrewScience>()
	{
        new GridCrewScience(0, 20, 20, 1, 1, 117, 53, "tank","tank", 0, 2, 2, false,
                MusicBibleConstant.Cannon,
                MusicBibleConstant.Vehicle, false, 3, false, 0),

        new GridCrewScience(1, 30, 30, 2, 2, 180, 65,  "siege tank","siegeTank", 0, 2, 1, false,
                MusicBibleConstant.Cannon,
                MusicBibleConstant.Vehicle, false, 4, false, 0),

        new GridCrewScience(2, 10, 10, 1, 1, 40, 40,  "infantery","soldier", .4, .4, 1, true,
                MusicBibleConstant.Musket,
                MusicBibleConstant.Walk, false, 1, false, 0),

        new GridCrewScience(3, 10, 10, 1, 1, 97, 48,  "baggy","baggy", 1, 2, 3, true,
                MusicBibleConstant.Machinegun,
                MusicBibleConstant.Vehicle, false, 2, false, 0),

        new GridCrewScience(4, 10, 10, 1, 1, 117, 53,  "rocket tank","rocketTank", .7, .7, 2, true,
                MusicBibleConstant.Missile,
                MusicBibleConstant.Vehicle, true, 4, false, 0),

        new GridCrewScience(5, 65, 30, 2, 2, 180, 65,  "ship","top", 0, 2, 3, false,
                MusicBibleConstant.Cannon,
                MusicBibleConstant.Vehicle, true, 4, true, 29),

        new GridCrewScience(6, 65, 30, 2, 2, 180, 65,  "fly","top", 0, 2, 3, false,
                MusicBibleConstant.Cannon,
                MusicBibleConstant.Vehicle, true, 4, true, 30)
    };


    public InitGlobalParams()
	{

		BattlePlanetModel.InitBasaPurchaseUnitScience();

		BattlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[0]);

		BattlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[1]);

		BattlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[2]);

		BattlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[3]);

		BattlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[4]);

		BattlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[5]);

		BattlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[6]);

				MapWorldModel._prototypeHeroDemo = new PrototypeHeroDemo();
		MapWorldModel._prototypeHeroDemo.HeroFleetInit();
		MapWorldModel.Init();

        //MapWorldModel._islandDemoMemento = new IslandDemoMemento();


		GoalTypeShip drakar = new GoalTypeShip();
		drakar.Goal.Add(new Point(544, 573));
		drakar.Goal.Add(new Point(614, 573));
		drakar.Goal.Add(new Point(684, 573));
		drakar.Goal.Add(new Point(754, 573));
		drakar.Goal.Add(new Point(824, 573));
		drakar.Goal.Add(new Point(894, 573));

		BattlePlanetModel.GoalTypeShip_ar = new List<GoalTypeShip>();
		BattlePlanetModel.GoalTypeShip_ar.Add(drakar);

		BattlePlanetModel.DispositionCountry_ar = new List<Country>();
	}
	public static string GetOfferNameHero()
	{
		var rand = new System.Random();
		//int num = (int)Math.floor(Math.random() * BattlePlanetModel.OfferNameHero_ar.length);
		int num = rand.Next(BattlePlanetModel.OfferNameHero_ar.Length);


		return BattlePlanetModel.OfferNameHero_ar[num];
	}
}
