using System.Collections;
using System.Collections.Generic;


public class FunctionShare 
{
	public static void Add_Level_Unit(ArmUnit Crew, List<GridCrewScience> BasaPurchaseUnitScience_ar)
	{
		if (Crew != null)
		{
			Crew.Level++;
			Crew.Attack += BasaPurchaseUnitScience_ar[Crew.GetUnit()].BonusAttack;
			Crew.Defence += BasaPurchaseUnitScience_ar[Crew.GetUnit()].BonusDefence;

		}


	}
}
