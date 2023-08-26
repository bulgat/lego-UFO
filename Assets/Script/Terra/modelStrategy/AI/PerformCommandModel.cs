using System.Collections;
using System.Collections.Generic;


public class PerformCommandModel
{
	public static void PerformCommand(CommandStrategy commandStrategy)
	{

		if (commandStrategy.NameCommand == CommandStrategy.Type.CaptureIsland)
		{

			Island island = MapWorldModel.GetIslandMemento().GetIslandWithId(commandStrategy.CaptureIsland.Id);
			island.FlagId = commandStrategy.CaptureIsland.FlagId;

			SetTurnDoneAndPower(commandStrategy.GridFleet);
			// money?
			ModelStrategy.SetPrizeIsland(BattlePlanetModel.DispositionCountry_ar, commandStrategy.CaptureIsland.FlagId);
		}
	}
	public static void PerformCommandMoveFleet(PrototypeHeroDemo prototypeHeroDemo, CommandStrategy commandStrategy)
	{
		if (commandStrategy.GridFleet != null)
		{

			GridFleet gridFleet = prototypeHeroDemo.GetFleetWithId(commandStrategy.GridFleet.GetId());
			
			if (gridFleet != null)
			{
				gridFleet.SpotX = (int)commandStrategy.GridFleetNewPoint.X;
				gridFleet.SpotY = (int)commandStrategy.GridFleetNewPoint.Y;
			
				SetTurnDoneAndPower(gridFleet);
				//gridFleet.
				// command player
				if (gridFleet.GetFlagId() == BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer())
				{
					gridFleet.PowerReserveChange(-99);
				}
			}
		}
	}
	public static void SetTurnDoneAndPower(GridFleet gridFleet)
	{
		gridFleet.SetTurnDone(true);
		gridFleet.PowerReserveChange(-1);
	}
}
