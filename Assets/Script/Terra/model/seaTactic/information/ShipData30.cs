using System.Collections;
using System.Collections.Generic;


public class ShipData30 : IShipData
{
	public List<BasaGoalItem> GetShipData()
	{
		List<BasaGoalItem> BasaGoalItem_ar = new List<BasaGoalItem>();
		BasaGoalItem_ar.Add(new BasaGoalItem(390, 603, false));
		BasaGoalItem_ar.Add(new BasaGoalItem(450, 603, false));
		BasaGoalItem_ar.Add(new BasaGoalItem(510, 603, false));
		BasaGoalItem_ar.Add(new BasaGoalItem(570, 603, false));
		BasaGoalItem_ar.Add(new BasaGoalItem(630, 603, false));

		BasaGoalItem_ar.Add(new BasaGoalItem(690, 603, false));
		BasaGoalItem_ar.Add(new BasaGoalItem(750, 603, false));
		BasaGoalItem_ar.Add(new BasaGoalItem(450, 550, false));
		BasaGoalItem_ar.Add(new BasaGoalItem(510, 540, false));
		BasaGoalItem_ar.Add(new BasaGoalItem(570, 540, false));

		BasaGoalItem_ar.Add(new BasaGoalItem(630, 540, false));
		BasaGoalItem_ar.Add(new BasaGoalItem(690, 540, false));
		BasaGoalItem_ar.Add(new BasaGoalItem(750, 550, true));
		return BasaGoalItem_ar;
	}
}
