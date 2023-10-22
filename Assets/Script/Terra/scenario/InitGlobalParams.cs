using System.Collections;
using System.Collections.Generic;

using System;
public class InitGlobalParams
{
    public static String[] OfferNameHero_ar = new String[] { "fleet_00", "fleet_01", "fleet_02", "fleet_03", "fleet_04", "fleet_05", "fleet_06", "fleet_07", "fleet_08", "fleet_09", "fleet_10", "fleet_11", "fleet_12",
        "fleet_13", "fleet_14", "fleet_15", "fleet_16", "fleet_17", "fleet_18", "fleet_19", "fleet_20",
        "fleet_21", "fleet_22", "fleet_23", "fleet_24", "fleet_25", "fleet_26", "fleet_27", "fleet_28",
        "fleet_29", "fleet_30" };
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


    public InitGlobalParams(BattlePlanetModel battlePlanetModel)
	{


        battlePlanetModel.InitBasaPurchaseUnitScience();

        battlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[0]);

        battlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[1]);

        battlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[2]);

        battlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[3]);

        battlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[4]);

        battlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[5]);

        battlePlanetModel.BasaPurchaseUnitScienceAdd(this.UnitrewScience_ar[6]);
        MapWorldModel.MapWorldModelSingleton();
   

		GoalTypeShip drakar = new GoalTypeShip();
		drakar.Goal.Add(new Point(544, 573));
		drakar.Goal.Add(new Point(614, 573));
		drakar.Goal.Add(new Point(684, 573));
		drakar.Goal.Add(new Point(754, 573));
		drakar.Goal.Add(new Point(824, 573));
		drakar.Goal.Add(new Point(894, 573));

        battlePlanetModel.GoalTypeShip_ar = new List<GoalTypeShip>();
        battlePlanetModel.GoalTypeShip_ar.Add(drakar);

        battlePlanetModel.InitDispositionCountry();
	}

}
