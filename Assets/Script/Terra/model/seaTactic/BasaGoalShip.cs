using System.Collections;
using System.Collections.Generic;


public class BasaGoalShip 
{
	public BasaGoalShip(int Id)
	{

		if (Id == 29)
		{
			IShipData shipData30 = new ShipData29();
			BasaGoalItem_ar = shipData30.GetShipData();
			return;
		}
		if (Id == 30)
		{
			IShipData shipData30 = new ShipData30();
			BasaGoalItem_ar = shipData30.GetShipData();
			return;
		}

		BasaGoalItem_ar = new List<BasaGoalItem>();

	}
	public List<BasaGoalItem> BasaGoalItem_ar;
}

