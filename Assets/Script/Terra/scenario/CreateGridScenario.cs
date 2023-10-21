using System;
using System.Collections;
using System.Collections.Generic;

public class CreateGridScenario 
{
	public List<GridTileBar> CreateGridInit(List<Point> mountaun_ar,
			  List<Point> road_ar,
			  List<Point> sea_ar, List<List<int>> ShoalSeaBasa_ar, BattlePlanetModel battlePlanetModel)
	{

		int widthMap = 13;

		List<GridTileBar> GridTile_ar = new List<GridTileBar>();


		GridTile_ar = this.CreateGridArray(ShoalSeaBasa_ar);

		foreach (Point point in mountaun_ar)
		{
			GridTile_ar[(int)point.X * widthMap + (int)point.Y].Terrain = battlePlanetModel.ObstacleMap;
			GridTile_ar[(int)point.X * widthMap + (int)point.Y].Tile = 3;

        }
		foreach (Point point in road_ar)
		{
			GridTile_ar[(int)point.X * widthMap + (int)point.Y].Terrain = battlePlanetModel.ObstacleRoadMap;

		}
		foreach (Point point in sea_ar)
		{
			GridTile_ar[(int)point.X * widthMap + (int)point.Y].Terrain = battlePlanetModel.ObstacleSeaMap;
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
	public void AddUnhide(BattlePlanetModel battlePlanetModel)
	{
		GridControl.GridSelect(battlePlanetModel.GetGridTileList(), 0, 0).Hide = false;
		GridControl.GridSelect(battlePlanetModel.GetGridTileList(), 1, 0).Hide = false;
		GridControl.GridSelect(battlePlanetModel.GetGridTileList(), 0, 1).Hide = false;
		GridControl.GridSelect(battlePlanetModel.GetGridTileList(), 1, 1).Hide = false;
	}

	public void AddCountry(BattlePlanetModel battlePlanetModel)
	{
        battlePlanetModel.DispositionCountry_ar = new List<Country>();

        battlePlanetModel.DispositionCountry_ar.Add(new Country(1, 1, 3, false));
        battlePlanetModel.DispositionCountry_ar.Add(new Country(battlePlanetModel.GetFlagIdPlayer(),
				2, 30, true));
        battlePlanetModel.DispositionCountry_ar.Add(new Country(2, 0, 0, false));


		ModelStrategy.InitContact(battlePlanetModel);

		ModelStrategy.SetContactPeace(battlePlanetModel, new Point(1, battlePlanetModel.GetFlagIdPlayer()), false);
		ModelStrategy.SetContactPeace(battlePlanetModel, new Point(2, battlePlanetModel.GetFlagIdPlayer()), false);

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
