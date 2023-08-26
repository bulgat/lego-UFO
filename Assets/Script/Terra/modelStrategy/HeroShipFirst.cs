using System.Collections;
using System.Collections.Generic;


public class HeroShipFirst 
{
	public static int GetHeroShipFirstCount(GridFleet Hero)
	{
		return GetHeroShipFirstCrewArray(Hero).Count;
	}
	public static List<ArmUnit> GetHeroShipFirstCrewArray(GridFleet Hero)
	{
		return Hero.GetShipName().GetArmUnitArray();
	}
}
