using System.Collections;
using System.Collections.Generic;


public class AI_TacticSearch 
{
	public static Point GetNearTacticIsland(
				List<GridTileBar> Grid_ar,
				List<Island> Island_ar,
				GridFleet GridFleet,
				List<Country> DispositionCountry_ar)
	{

		List<Point> nearMap_ar = CoordinateSearch.GetXmapNear(true);
		foreach (Island isl in Island_ar)
		{
			if (isl.FlagId != GridFleet.GetFlagId())
			{
				foreach (Point point in nearMap_ar)
				{
					if (point.X + isl.SpotX == GridFleet.SpotX && point.Y + isl.SpotY == GridFleet.SpotY)
					{
						if (ModelStrategy.GetContactPeace(DispositionCountry_ar, new Point(isl.FlagId, GridFleet.GetFlagId())))
						{

						}
						else
						{
							return new Point(isl.SpotX, isl.SpotY);
						}
					}
				}
			}
		}
		return null;
	}
	public static Point GetNearTacticHero(List<GridFleet> NameHero_ar, GridFleet GridFleet,
			List<Country> DispositionCountry_ar, List<Point> nearMap_ar)
	{

		//ArrayList<Point> nearMap_ar = CoordinateSearch.GetXmapNear(true);
		foreach (GridFleet hero in NameHero_ar)
		{
			if (GridFleet.GetId() != hero.GetId())
			{

				if (hero.GetFlagId() != GridFleet.GetFlagId())
				{
					foreach (Point point in nearMap_ar)
					{
						if (point.X + hero.SpotX == GridFleet.SpotX && point.Y + hero.SpotY == GridFleet.SpotY)
						{
							if (ModelStrategy.GetContactPeace(DispositionCountry_ar, new Point(hero.GetFlagId(), GridFleet.GetFlagId())))
							{

							}
							else
							{
								return new Point(hero.SpotX, hero.SpotY);
							}
						}
					}
				}
			}
		}
		return null;
	}
}
