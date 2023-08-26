using System.Collections;
using System.Collections.Generic;


public class SearchImminenFleet 
{
	// search near hero.
	public static Point SearchImminenHero(List<GridFleet> NameHero_ar,
			GridFleet gridFleet, List<GridTileBar> Grid_ar, List<Country> DispositionCountry_ar)
	{
		//пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ.



		int SpotStrPlX = 0;
		int SpotStrPlY = 0;

		Point point = new Point(SpotStrPlX, SpotStrPlY);

		int DifferenceX = Grid_ar[Grid_ar.Count - 1].SpotX;
		int DifferenceY = Grid_ar[Grid_ar.Count - 1].SpotY;



		for (int d2 = 0; d2 < NameHero_ar.Count; d2++)
		{
			if (NameHero_ar[d2].GetFlagId() != gridFleet.GetFlagId())
			{
				// пїЅпїЅпїЅпїЅ.
				// пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅ.
				if (ModelStrategy.GetContactPeace(DispositionCountry_ar, new Point(NameHero_ar[d2].GetFlagId(), gridFleet.GetFlagId())))
				{
					// peace
				}
				else
				{
					// war
					//пїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ, пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ
					if (NameHero_ar[d2].SpotX < DifferenceX && NameHero_ar[d2].SpotY < DifferenceY)
					{

						DifferenceX = DifferenceX - NameHero_ar[d2].SpotX;
						DifferenceY = DifferenceY - NameHero_ar[d2].SpotY;

						SpotStrPlX = NameHero_ar[d2].SpotX;
						SpotStrPlY = NameHero_ar[d2].SpotY;

						// most near fleet
						point.X = SpotStrPlX;
						point.Y = SpotStrPlY;
					}
				}
			}
		}
		return point;
	}
}
