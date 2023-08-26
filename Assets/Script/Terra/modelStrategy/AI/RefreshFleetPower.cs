using System.Collections;
using System.Collections.Generic;


public class RefreshFleetPower 
{
	public static void RefreshHeroPower(List<GridFleet> NameHero_ar, bool SpeedStatic)
	{
		foreach (GridFleet hero in NameHero_ar)
		{
			if (SpeedStatic)
			{
				hero.SetPowerStatic();
			}
			else
			{
				hero.SetPowerReserve();// = hero.GetStaticSpeed();
			}

			hero.SetTurnDone(false);
			hero.SetAttackDone(false);
		}
	}
}
