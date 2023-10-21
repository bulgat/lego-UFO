using System.Collections;
using System.Collections.Generic;

public class FiendFleet 
{
	
	public static Island GetIsland(List<Island> Island_ar,
			List<Country> DispositionCountry_ar, int SpotX, int SpotY)
	{
		foreach (Island isl in Island_ar)
		{
			if (isl.SpotX == SpotX && isl.SpotY == SpotY)
			{
				return isl;
			}
		}


		return null;
	}


	// Get not our. get fiend island.
	public static Island GetFiendIsland(List<Island> Island_ar, GridFleet GridFleet,
			List<Country> DispositionCountry_ar)
	{
		foreach (Island isl in Island_ar)
		{
			if (isl.FlagId != GridFleet.GetFlagId())
			{


				if (isl.SpotX == GridFleet.SpotX && isl.SpotY == GridFleet.SpotY)
				{

					if (ModelStrategy.GetContactPeace(DispositionCountry_ar, new Point(isl.FlagId, GridFleet.GetFlagId())))
					{

					}
					else
					{
						// this not our. this fiend island.
						return isl;
					}
				}
			}
		}
		return null;
	}
	
	public static List<Island> GetFlagIslandArray(List<Island> Island_ar, int FlagId, bool FlagFiend)
	{
		List<Island> islandFiend_ar = new List<Island>();
		foreach (Island isl in Island_ar)
		{

			if (FlagFiend)
			{

				if (isl.FlagId != FlagId)
				{
					islandFiend_ar.Add(isl);
				}
			}
			else
			{
	

				if (isl.FlagId == FlagId)
				{
					islandFiend_ar.Add(isl);
				}
			}
		}
		return islandFiend_ar;
	}



	public static List<GridFleet> GetHeroAll(int flagId, List<GridFleet> NameHero_ar)
	{
		List<GridFleet> hero_ar = new List<GridFleet>();
		for (int S = 0; S < NameHero_ar.Count; S++)
		{

			if (NameHero_ar[S].GetFlagId() == flagId)
			{

				hero_ar.Add(NameHero_ar[S]);

			}
		}
		return hero_ar;

	}
	public static List<GridFleet> HeroAllCoordinateCoincidence(int spotX, int spotY,
			List<GridFleet> NameHero_ar)
	{
		List<GridFleet> squareHero_ar = new List<GridFleet>();
		for (int S = 0; S < NameHero_ar.Count; S++)
		{
			if (CoordinateCoincidence(spotX, spotY, NameHero_ar[S]))
			{
				squareHero_ar.Add(NameHero_ar[S]);
			}
		}
		return squareHero_ar;
	}
	private static bool CoordinateCoincidence(int spotX, int spotY, GridFleet GridFleet)
	{
		if (GridFleet.SpotX == spotX && GridFleet.SpotY == spotY)
		{
			return true;
		}
		return false;
	}


	public static GridFleet SearchHeroOne(int spotX, int spotZ, List<GridFleet> NameHero_ar,
			int flagId, bool Fiend)
	{
		for (int S = 0; S < NameHero_ar.Count; S++)
		{

			if (CoordinateCoincidence(spotX, spotZ, NameHero_ar[S]))
			{
		
				if (Fiend)
				{
					if (flagId != NameHero_ar[S].GetFlagId())
					{
						return NameHero_ar[S];
					}
				}
				else
				{
					if (flagId == NameHero_ar[S].GetFlagId())
					{
						return NameHero_ar[S];
					}
				}
			}
		}

		return null;
	}

	public static List<GridFleet> GetFiendHeroAllWar(int spotX, int spotY, int flagId,
			List<GridFleet> NameHero_ar)
	{
		List<GridFleet> hero_ar = GetFiendHeroAll(spotX, spotY, flagId, NameHero_ar);
		List<GridFleet> heroWar_ar = new List<GridFleet>();
		for (int S = 0; S < hero_ar.Count; S++)
		{
			heroWar_ar.Add(hero_ar[S]);

		}
		return heroWar_ar;
	}

	public static List<GridFleet> GetFiendHeroAll(int spotX, int spotY, int flagId,
			List<GridFleet> NameHero_ar)
	{
		List<GridFleet> hero_ar = new List<GridFleet>();
		for (int S = 0; S < NameHero_ar.Count; S++)
		{

			if (CoordinateCoincidence(spotX, spotY, NameHero_ar[S]))
			{
				if (NameHero_ar[S].GetFlagId() != flagId)
				{
					hero_ar.Add(NameHero_ar[S]);

				}
			}
		}
		return hero_ar;
	}
}
