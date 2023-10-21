using System.Collections;
using System.Collections.Generic;

using System;
public class AI_Behavior_Replace 
{
	public GridFleet Replace_Ship_AfterLoss(int FlagId, List<Island> Island_ar,
			List<List<int>> ShoalSeaBasa_ar, List<Country> DispositionCountry_ar,
            BattlePlanetModel battlePlanetModel, int typeUnit,
			List<GridTileBar> GridTile_ar)
	{

		List<Island> islandFiend_ar = FiendFleet.GetFlagIslandArray(Island_ar, FlagId, false);

		if (islandFiend_ar.Count > 0)
		{
			var rand =new  System.Random();
			//double index = Math.floor(Math.random() * islandFiend_ar.Count);
			int index = rand.Next(islandFiend_ar.Count);
			Island isl = islandFiend_ar[index];

			Point placeFleet = AiReplaceFleet.Replace_Ship_From_Island(isl, ShoalSeaBasa_ar,
					DispositionCountry_ar, Island_ar, GridTile_ar);

			if (placeFleet != null)
			{

				return ModelStrategy.GetFleetFast((int)placeFleet.X, (int)placeFleet.Y,
						FlagId,
						"Fiend" + BattlePlanetModel.GetBattlePlanetModelSingleton().GetIdUnit(),
						typeUnit,
                         battlePlanetModel, false, 0);

			}
		}
		return null;
	}
}
