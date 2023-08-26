using System.Collections;
using System.Collections.Generic;


public class SelectHeroMap 
{
	public static GridFleet PuttingShadeAttack(List<GridFleet> NameHero_ar, GridFleet heroFiend)
	{

		// пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ (пїЅпїЅпїЅпїЅпїЅпїЅ) пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ.
		GridFleet heroPlayer = PuttingRelayBattle_Hero(heroFiend.SpotX, heroFiend.SpotY,
				NameHero_ar, heroFiend.GetFlagId());


		if (heroPlayer != null)
		{

			List<GridFleet> allFiendHero = FiendFleet.GetFiendHeroAllWar(
					heroFiend.SpotX, heroFiend.SpotY
					, heroFiend.GetFlagId(),
					NameHero_ar);

			if (allFiendHero.Count > 0)
			{

				return heroPlayer;


			}

		}


		return null;
	}
	// пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ (пїЅпїЅпїЅпїЅпїЅпїЅ) пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ.
	public static GridFleet PuttingRelayBattle_Hero(int PlaceX, int PlaceZ, List<GridFleet> NameHero_ar, int flagId)
	{

		for (int d = 0; d < NameHero_ar.Count; d++)
		{
			// пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ, пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ.
			GridFleet heroFiend = FiendFleet.SearchHeroOne(PlaceX, PlaceZ, NameHero_ar, flagId, true);


			if (heroFiend != null)
			{

				if (heroFiend.GetFlagId() != flagId)
				{

					if (NameHero_ar[d].SpotX == PlaceX && NameHero_ar[d].SpotY == PlaceZ)
					{

						return heroFiend;

					}
				}
			}
		}

		return null;


	}
}
