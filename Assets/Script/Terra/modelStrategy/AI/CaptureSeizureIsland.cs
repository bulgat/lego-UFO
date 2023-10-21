using System.Collections;
using System.Collections.Generic;


public class CaptureSeizureIsland 
{
	public static void CaptureIsland(List<Island> Island_ar, GridFleet gridFleet,
			List<GridFleet> NameHero_ar,
			List<Country> DispositionCountry_ar, List<CommandStrategy> CommandStrategy_ar)
	{
		// Get not our. get fiend island.
		Island isl = FiendFleet.GetFiendIsland(Island_ar, gridFleet, DispositionCountry_ar);
		if (isl != null)
		{
			// island his?
			if (isl.FlagId != gridFleet.GetFlagId())
			{

				// get all fleet in this place.
				List<GridFleet> hereinHero_ar = FiendFleet.HeroAllCoordinateCoincidence(isl.SpotX, isl.SpotY, NameHero_ar);
				if (hereinHero_ar.Count <= 1)
				{
					/*
					CommandStrategy commandStrategy = new CommandStrategy();
					commandStrategy.OldIslandFlag = isl.FlagId;

					// capture island.
					isl.FlagId =gridFleet.GetFlagId();
					
					commandStrategy.CaptureIsland = isl; 
					commandStrategy.NameCommand = CommandStrategy.Type.CaptureIsland;
					*/
					CommandStrategy commandStrategy = GetCommandCaptureIsland(isl, gridFleet);
					CommandStrategy_ar.Add(commandStrategy);
	
					// get money behind capture island.
					SetPrizeIsland(DispositionCountry_ar, gridFleet.GetFlagId());
				}
			}
		}
	}
	public static CommandStrategy GetCommandCaptureIsland(Island isl, GridFleet gridFleet)
	{
		CommandStrategy commandStrategy = new CommandStrategy();
		commandStrategy.OldIslandFlag = isl.FlagId;

		// capture island.
		isl.FlagId = gridFleet.GetFlagId();
		commandStrategy.GridFleet = gridFleet;
		commandStrategy.CaptureIsland = isl;
		commandStrategy.NameCommand = CommandStrategy.Type.CaptureIsland;
		return commandStrategy;
		//CommandStrategy_ar.add(commandStrategy);
	}


	public static void SetPrizeIsland(List<Country> DispositionCountry_ar, int flagId)
	{
		Country country = BattlePlanetModel.GetBattlePlanetModelSingleton()._contactStateProceeding.GetDispositionCountry(DispositionCountry_ar,
				flagId);
		if (country != null)
		{
			country.Money++;
		}


	}
}
