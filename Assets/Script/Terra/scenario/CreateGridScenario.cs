using System;
using System.Collections;
using System.Collections.Generic;

public class CreateGridScenario 
{
	public List<GridTileBar> CreateGridInit(List<Point> mountaun_ar,
			  List<Point> road_ar,
			  List<Point> sea_ar, List<List<int>> ShoalSeaBasa_ar)
	{

		int widthMap = 13;

		List<GridTileBar> GridTile_ar = new List<GridTileBar>();


		GridTile_ar = this.CreateGridArray(ShoalSeaBasa_ar);

		foreach (Point point in mountaun_ar)
		{
			GridTile_ar[(int)point.X * widthMap + (int)point.Y].Terrain = BattlePlanetModel.ObstacleMap;
			GridTile_ar[(int)point.X * widthMap + (int)point.Y].Tile = 3;

        }
		foreach (Point point in road_ar)
		{
			GridTile_ar[(int)point.X * widthMap + (int)point.Y].Terrain = BattlePlanetModel.ObstacleRoadMap;

		}
		foreach (Point point in sea_ar)
		{
			GridTile_ar[(int)point.X * widthMap + (int)point.Y].Terrain = BattlePlanetModel.ObstacleSeaMap;
			GridTile_ar[(int)point.X * widthMap + (int)point.Y].Tile = 5;

        }
		ResetEconomic();
		return GridTile_ar;
	}
	public List<GridTileBar> CreateGridArray(List<List<int>> ShoalSeaBasa_ar)
	{
		
		List<GridTileBar> Grid_ar = new List<GridTileBar>();


		int ii = 0;
		int zz = 0;
		foreach(var itemList in ShoalSeaBasa_ar)
		{
			
			foreach(var item in itemList)
			{
				
				bool shoal = ShoalSeaBasa_ar[ii][zz] == 0 ? false : true;
				Grid_ar.Add(new GridTileBar(ii, zz, shoal));
				zz++;
			}
			zz = 0;
			ii++;
		}

		return Grid_ar;
	}


	public void ResetEconomic()
	{
		ModelStrategy.EconomicReset();
	}
	public static void AddUnhide()
	{
		GridControl.GridSelect(BattlePlanetModel.GetGridTileList(), 0, 0).Hide = false;
		GridControl.GridSelect(BattlePlanetModel.GetGridTileList(), 1, 0).Hide = false;
		GridControl.GridSelect(BattlePlanetModel.GetGridTileList(), 0, 1).Hide = false;
		GridControl.GridSelect(BattlePlanetModel.GetGridTileList(), 1, 1).Hide = false;
	}

	public static void AddCountry()
	{
		BattlePlanetModel.DispositionCountry_ar = new List<Country>();

		BattlePlanetModel.DispositionCountry_ar.Add(new Country(1, 1, 3, false));
		BattlePlanetModel.DispositionCountry_ar.Add(new Country(BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer(),
				2, 30, true));
		BattlePlanetModel.DispositionCountry_ar.Add(new Country(2, 0, 0, false));


		ModelStrategy.InitContact(BattlePlanetModel.DispositionCountry_ar);

		ModelStrategy.SetContactPeace(BattlePlanetModel.DispositionCountry_ar, new Point(1, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()), false);
		ModelStrategy.SetContactPeace(BattlePlanetModel.DispositionCountry_ar, new Point(2, BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()), false);

	}
	public static string GetImageIcon(int UnitTypeId)
	{
		string nameImage;
		switch (UnitTypeId)
		{
			case 0:
				nameImage = GraficBibleConstant.UnitIcon0;
				break;
			case 1:
				nameImage = GraficBibleConstant.UnitIcon1;
				break;
			case 2:
				nameImage = GraficBibleConstant.UnitIcon2;
				break;
			case 3:
				nameImage = GraficBibleConstant.UnitIcon3;
				break;
            case 4:
                nameImage = GraficBibleConstant.UnitIcon4;
                break;
            case 5:
                nameImage = GraficBibleConstant.UnitIcon5;
                break;
            default:
				nameImage = GraficBibleConstant.Jaw;
                //nameImage = GraficBibleConstant.UnitIcon5;
                throw new Exception("Invalid month");
                break;
		}
		return nameImage;
	}
}
