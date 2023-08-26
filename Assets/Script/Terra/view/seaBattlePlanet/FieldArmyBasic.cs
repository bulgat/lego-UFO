using System.Collections;
using System.Collections.Generic;


public class FieldArmyBasic 
{
	public Point GetProportionScene(GridCrewScience scienceUnit, float widthStage, float proportion, int NumPortion)
	{

		return new Point((scienceUnit.WidthUnit * proportion), (scienceUnit.HeightUnit * proportion));
	}
	public UnitTacticBasic GetUnitTactic(List<UnitTacticBasic> BattleTactic_ar, int Id)
	{
		foreach (UnitTacticBasic unit in BattleTactic_ar)
		{
			if (unit.GetId() == Id)
			{
				return unit;
			}
		}
		return null;
	}
}
