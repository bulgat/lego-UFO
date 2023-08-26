using System.Collections;
using System.Collections.Generic;

public class WayGotoSelectField 
{
	public static List<Point> CreateVariationWay(int Speed)
	{
		List<Point> wayRude_ar = new List<Point>();
		Point center = new Point(Speed, Speed);

		for (int i = 0; i < (center.X * 2 + 1); i++)
		{
			for (int z = 0; z < (center.Y * 2 + 1); z++)
			{
				if (center.X == i && center.Y == z)
				{

				}
				else
				{

					wayRude_ar.Add(new Point(center.X - i, center.Y - z));

				}
			}
		}
		return wayRude_ar;
	}
	public static List<WayGotoModel> SelectVariationWayFleet(
			GridFleet Hero,
			List<Point> wayRude_ar,
			List<Country> DispositionCountry_ar,
			List<List<int>> ShoalSeaBasa_ar,
			List<Island> Island_ar, PrototypeHeroDemo prototypeHeroDemo,
			List<GridTileBar> GridTile_ar)
	{

		List<WayGotoModel> wayGotoModel_ar = new List<WayGotoModel>();


		// all point move.
		foreach (Point wayPoint in wayRude_ar)
		{


			Point mapPoint = new Point(Hero.SpotX + wayPoint.X, Hero.SpotY + wayPoint.Y);
			if (ModelStrategy.AllowPointMap(ShoalSeaBasa_ar,
							new Point(mapPoint.X, mapPoint.Y)))
			{

				List<Point> pathPoint_ar = ModelStrategy.GetFindPathBigArray(
						mapPoint,
					new Point(Hero.SpotX, Hero.SpotY),
					Hero.GetFlagId(),
					prototypeHeroDemo.GetHeroFleet(),
					GridTile_ar,
					DispositionCountry_ar, true, Hero.GetSea(), Island_ar);

				WayGotoModel wayGotoModel = new WayGotoModel((int)mapPoint.X, (int)mapPoint.Y);
				wayGotoModel.PathGoto_ar = pathPoint_ar;
				wayGotoModel_ar.Add(wayGotoModel);

			}


		}
		return wayGotoModel_ar;
	}
}
