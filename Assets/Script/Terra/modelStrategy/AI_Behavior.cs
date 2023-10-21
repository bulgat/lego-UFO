using System.Collections;
using System.Collections.Generic;


public class AI_Behavior 
{
	// пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ.
	private static Point GetGlobalIsland(List<Island> Island_ar, GridFleet GridFleet, List<Country> DispositionCountry_ar)
	{

		List<Point> point_ar = GetGlobalIslandArray(Island_ar, GridFleet, DispositionCountry_ar, false);
		if (point_ar.Count == 0)
		{
			return null;
		}
		else
		{
			// пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ.
			return point_ar[0];
		}
	}
	public static List<Point> GetGlobalIslandArray(List<Island> Island_ar,
			GridFleet GridFleet, List<Country> DispositionCountry_ar, bool Their)
	{
		List<Point> point_ar = new List<Point>();

		foreach (Island isl in Island_ar)
		{
			if (Their)
			{
				// пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ.
				if (isl.FlagId == GridFleet.GetFlagId())
				{
					point_ar.Add(new Point(isl.SpotX, isl.SpotY));
				}
			}
			else
			{
				// пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ.
				if (isl.FlagId != GridFleet.GetFlagId())
				{
					if (ModelStrategy.GetContactPeace(DispositionCountry_ar, new Point(isl.FlagId, GridFleet.GetFlagId())))
					{
					}
					else
					{
						point_ar.Add(new Point(isl.SpotX, isl.SpotY));
					}
				}
			}

		}
		return point_ar;
	}


	// пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ, пїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ.
	public static Point TacticSearchIslandAndHero(
			List<GridFleet> NameHero_ar,
			GridFleet gridFleet,
			List<GridTileBar> Grid_ar,
			List<Island> Island_ar,
			List<Country> DispositionCountry_ar
			)
	{

		// search island
		Point point = AI_TacticSearch.GetNearTacticIsland(Grid_ar, Island_ar,
				gridFleet, DispositionCountry_ar);

		// search near hero
		if (point == null)
		{
			point = AI_TacticSearch.GetNearTacticHero(NameHero_ar, gridFleet,
					DispositionCountry_ar, CoordinateSearch.GetXmapNear(true));
		}
		// search global island
		if (point == null)
		{
			point = GetGlobalIsland(Island_ar, gridFleet, DispositionCountry_ar);

		}

		if (point == null)
		{
			// пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ.
			point = SearchImminenFleet.SearchImminenHero(NameHero_ar, gridFleet, Grid_ar, DispositionCountry_ar);
		}

		Point resultPoint = GetPathPoint(point, new Point(gridFleet.SpotX, gridFleet.SpotY),
				gridFleet.GetFlagId(),
				NameHero_ar, Grid_ar, DispositionCountry_ar,
				gridFleet.GetSea(), Island_ar
				);
		if (resultPoint != null)
		{

			return new Point(resultPoint.X, resultPoint.Y);
		}
		return null;

	}
	public static List<SuperNode> GetFindPathBigArray(Point pointAim,
			Point FiendPoint,
			int FiendFlagId,
			List<GridFleet> NameHero_ar,
			List<GridTileBar> Grid_ar,
			List<Country> DispositionCountry_ar,
			bool StopFiendHero,
			bool Sea,
			List<Island> Island_ar)
	{

		FindPath FINDPATH = new FindPath();
		long DestinationNode_ID_Player = ((int)(pointAim.Y) * 100) + (int)(pointAim.X);
		long StartNode_ID_Fiend = ((int)FiendPoint.Y * 100) + (int)FiendPoint.X;

		int wallObstacle = BattlePlanetModel.GetBattlePlanetModelSingleton().ObstacleMap;

		List<SuperNode> pathBasa_ar = FINDPATH.findShortestPath(
				StartNode_ID_Fiend,
				DestinationNode_ID_Player,
				AI_Behavior_Existence.PreparationMap(
					Grid_ar, NameHero_ar, FiendFlagId,
					DispositionCountry_ar,
					StopFiendHero, Sea, Island_ar)
				, wallObstacle, "manhattan", 10, 14);





		return pathBasa_ar;
	}


	public static Point GetPathPoint(Point pointAim, Point FiendPoint, int FiendFlagId,
			List<GridFleet> NameHero_ar, List<GridTileBar> Grid_ar,
			List<Country> DispositionCountry_ar, bool Sea, List<Island> Island_ar
			)
	{

		Point resultPoint = null;
		List<SuperNode> pathBasa_ar = GetFindPathBigArray(pointAim, FiendPoint,
				FiendFlagId,
				NameHero_ar,
				Grid_ar,
				DispositionCountry_ar, false, Sea, Island_ar);

		if (pathBasa_ar.Count >= 2)
		{
			resultPoint = new Point((pathBasa_ar[1].id % 100), (pathBasa_ar[1].id / 100));

		}

		return resultPoint;
	}
}
