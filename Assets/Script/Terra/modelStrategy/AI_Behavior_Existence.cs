using System.Collections;
using System.Collections.Generic;


public class AI_Behavior_Existence 
{
	public static bool AllowPointMap(List<List<int>> ShoalSeaBasa_ar, Point point)
	{
		if (point.X < 0 || point.Y < 0)
		{
			return false;
		}
		if (point.X >= ShoalSeaBasa_ar.Count || point.Y >= ShoalSeaBasa_ar[0].Count)
		{
			return false;
		}
		return true;
	}


	public static GridTileBar GetOneGrid(List<GridTileBar> Grid_ar, int GridRow, int GridLine)
	{
		return Grid_ar[GridRow * (Grid_ar[Grid_ar.Count - 1].SpotX + 1) + GridLine];
	}


	public static List<long[]> PreparationMap(
			List<GridTileBar> GridTile_ar,
			List<GridFleet> NameHero_ar,
			int FlagId,
			List<Country> DispositionCountry_ar,
			bool StopFiendHero,
			bool Sea,
			List<Island> Island_ar)
	{

		int wallObstacleStatic = 2;
		int[] wallObstacle_ar = null;
		if (Sea)
		{
			wallObstacle_ar = new int[] { 0, 1, BattlePlanetModel.ObstacleRoadMap, BattlePlanetModel.ObstacleMap };



		}
		else
		{
			// obstacle = 2
			wallObstacle_ar = new int[] { BattlePlanetModel.ObstacleMap, BattlePlanetModel.ObstacleSeaMap };
		}
		// obstacle = 2

		int costGround = 1;

		List<long[]> CreateMap_ar = new List<long[]>();

		for (int GridRow = 0; GridRow < GridTile_ar[GridTile_ar.Count - 1].SpotX + 1; GridRow++)
		{

			long[] arrayLong = new long[GridTile_ar[GridTile_ar.Count - 1].SpotY + 1];

			CreateMap_ar.Add(arrayLong);
			for (int GridLine = 0; GridLine < GridTile_ar[GridTile_ar.Count - 1].SpotY + 1; GridLine++)
			{

				CreateMap_ar[GridRow][GridLine] = costGround;
				GridTileBar oneGrid = GetOneGrid(GridTile_ar, GridRow, GridLine);


				for (int QuadObstacle = 0; QuadObstacle < wallObstacle_ar.Length; QuadObstacle++)
				{
					if (oneGrid.Terrain == wallObstacle_ar[QuadObstacle])
					{
						CreateMap_ar[GridRow][GridLine] = wallObstacleStatic;
					}
				}


			}

		}
		// set allow visit.
		foreach (Island island in Island_ar)
		{
			CreateMap_ar[island.SpotX][island.SpotY] = 0;
		}
		// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ.
		if (StopFiendHero)
		{
			foreach (GridFleet hero in NameHero_ar)
			{
				CreateMap_ar[hero.SpotX][hero.SpotY] = wallObstacleStatic;
			}
		}
		else
		{


			foreach (GridFleet hero in NameHero_ar)
			{
				if (hero.GetFlagId() == FlagId)
				{
					CreateMap_ar[hero.SpotX][hero.SpotY] = wallObstacleStatic;
				}
				else
				{
					// пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅ пїЅпїЅпїЅ.
					if (ModelStrategy.GetContactPeace(DispositionCountry_ar, new Point(hero.GetFlagId(), FlagId)))
					{
						CreateMap_ar[hero.SpotX][hero.SpotY] = wallObstacleStatic;
					}
				}

			}
		}

		/*
		CreateMap_ar.get(3)[4] =0;
		CreateMap_ar.get(4)[4] =0;
		CreateMap_ar.get(5)[4] =0;
		CreateMap_ar.get(6)[4] =0;
		CreateMap_ar.get(7)[4] =0;
		CreateMap_ar.get(8)[4] =0;
		CreateMap_ar.get(9)[4] =0;
	*/

		return CreateMap_ar;
	}
}
