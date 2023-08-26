using System.Collections;
using System.Collections.Generic;

public class UnitTech 
{
	public static GridCrewScience GetUnit(int Index)
	{
		return BattlePlanetModel.GetBasaPurchaseUnitScience()[Index];
	}
}
