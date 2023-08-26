using System.Collections;
using System.Collections.Generic;


public class CreateFleetFast 
{
	public static GridFleet GetFleetFast(int SpotX, int SpotY, int FlagId, string image,
			string Name, int UnitTypeId, List<GridCrewScience> BasaPurchaseUnitScience_ar,
			bool AddOne, int customShip)
	{



		GridFleet heroPlayer = new GridFleet(Name, SpotX, SpotY, FlagId, image);
		ShipUnit shipPlayer = new ShipUnit();
		if (AddOne)
		{
			shipPlayer.GetArmUnitArray().Add(new ArmUnit(BasaPurchaseUnitScience_ar, UnitTypeId, customShip));
		}
		else
		{
			for (int i = 0; i < BattlePlanetModel.SizeSquad; i++)
			{
				shipPlayer.GetArmUnitArray().Add(new ArmUnit(BasaPurchaseUnitScience_ar, UnitTypeId, customShip));
			}
		}


		heroPlayer.AddShipName(shipPlayer);
		heroPlayer.SetId(BattlePlanetModel.FleetId);
		BattlePlanetModel.FleetId += 1;

		return heroPlayer;
	}


	public static void FleetAddArmFast(GridFleet heroPlayer, int UnitTypeId,
			List<GridCrewScience> BasaPurchaseUnitScience_ar, int customShip)
	{
		//System.out.println("init harbor_____ map SeaShip Slip ==  " + heroPlayer);
		ShipUnit shipPlayer = heroPlayer.GetShipName();

		shipPlayer.GetArmUnitArray().Add(new ArmUnit(BasaPurchaseUnitScience_ar, UnitTypeId, customShip));
	}
}
