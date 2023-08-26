using System.Collections;
using System.Collections.Generic;

using System;

public class WayGotoAttack 
{
	public static bool GetDistanceSQRT(Point Start, Point End)
	{
		//double distance = Math.sqrt((Math.pow((Start.X-End.X),2) + Math.pow((Start.Y-End.Y),2)));
		double distance = GetDistance(Start, End);
		return ((int)Math.Abs(distance) >= 2);
	}
	public static double GetDistance(Point Start, Point End)
	{
		return Math.Sqrt((Math.Pow((Start.X - End.X), 2) + Math.Pow((Start.Y - End.Y), 2)));
	}
	public static List<GridFleet> PreparationAttackFleet(GridFleet Hero,
			List<Country> DispositionCountry_ar,
			List<GridFleet> NameHero_ar,
			List<List<int>> ShoalSeaBasa_ar,
			List<Point> GetMapFlagIslandArray
			)
	{

		List<Point> CircleFleet_ar = GetMapFlagIslandArray;
		List<GridFleet> fiendHero_ar = new List<GridFleet>();
		foreach (Point point in CircleFleet_ar)
		{
			//Hero.SpotX,Hero.SpotY
			Point searchPoint = new Point(point.X + Hero.SpotX, point.Y + Hero.SpotY);
			if (ModelStrategy.AllowPointMap(ShoalSeaBasa_ar,
					searchPoint))
			{
				List<GridFleet> fiendHeroLocal_ar = ModelStrategy.GetFiendHeroAll((int)searchPoint.X, (int)searchPoint.Y,
						Hero.GetFlagId(),
						NameHero_ar);
				foreach (GridFleet fleetFiend in fiendHeroLocal_ar)
				{
					fiendHero_ar.Add(fleetFiend);
				}
			}
		}
		// пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ, пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅ.
	    List<GridFleet> fiendHeroWar_ar = new List<GridFleet>();
		foreach (GridFleet fiendFleetWar in fiendHero_ar)
		{
			if (ModelStrategy.GetContactPeace(DispositionCountry_ar,
					new Point(fiendFleetWar.GetFlagId(), Hero.GetFlagId())))
			{

			}
			else
			{
				fiendHeroWar_ar.Add(fiendFleetWar);
			}
		}
		return fiendHeroWar_ar;
	}
}
