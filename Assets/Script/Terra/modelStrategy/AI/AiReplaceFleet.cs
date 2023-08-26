using System.Collections;
using System.Collections.Generic;


public class AiReplaceFleet 
{
	public static Point Replace_Ship_From_Island(Island isl, List<List<int>> ShoalSeaBasa_ar,
			List<Country> DispositionCountry_ar, List<Island> Island_ar,
			List<GridTileBar> GridTile_ar)
	{
		List<Point> mapFlagIsland_ar = CoordinateSearch.GetMapFlagIslandArray();

		int free = 1;

		foreach (Point point in mapFlagIsland_ar)
		{
			Point pointIsl = new Point(point.X + isl.SpotX, point.Y + isl.SpotY);


			AiReplaceFleet aiReplaceFleet = new AiReplaceFleet();

			Point allowPoint = aiReplaceFleet.GetPointAllowMap(ShoalSeaBasa_ar, pointIsl,
					GridTile_ar, isl, DispositionCountry_ar, Island_ar, free);

			if (allowPoint != null)
			{
				return allowPoint;
			}
			
		}
		return null;

	}
	private Point GetPointAllowMap(List<List<int>> ShoalSeaBasa_ar, Point pointIsl,
			List<GridTileBar> GridTile_ar, Island isl,
			List<Country> DispositionCountry_ar, List<Island> Island_ar, int free)
	{
		if (AI_Behavior_Existence.AllowPointMap(ShoalSeaBasa_ar, pointIsl))
		{


			List<long[]> map_ar_ar = ModelStrategy.PreparationMap(
					GridTile_ar, MapWorldModel._prototypeHeroDemo.GetHeroFleet(),
					isl.FlagId, DispositionCountry_ar, false, false, Island_ar);


			if (map_ar_ar[isl.SpotX][isl.SpotY] == free)
			{
				return new Point(isl.SpotX, isl.SpotY);
			}
		}
		return null;
	}
}
