using System.Collections;
using System.Collections.Generic;


public class ExecuteCommandStrateg : IExecuteCommand
{
	public void PerformCommand(CommandStrategy commandStrategy)
	{
		ModelStrategy.PerformCommand(commandStrategy);
	}
	public void PrototypeHeroCreateFleet(CommandStrategy commandStrategy)
	{
        BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet().Add(commandStrategy.GridFleet);
	}
	public void PerformCommandMoveFleet(CommandStrategy commandStrategy, PrototypeHeroDemo prototypeHeroDemo)
	{
		ModelStrategy.PerformCommandMoveFleet(prototypeHeroDemo, commandStrategy);
	}
	public void PerformAttackFleet(CommandStrategy commandStrategy, int CountTurn, int GlobalParamsGale)
	{



		ModelStrategy.PerformAttackFleetAction(BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo, commandStrategy);


		// fiend attack
		if (commandStrategy.AttackPlayer)
		{
			// attack player
			commandStrategy.GridFleet.SpotX = (int)commandStrategy.GridFleetOldPoint.X;
			commandStrategy.GridFleet.SpotY = (int)commandStrategy.GridFleetOldPoint.Y;

			MapWorldModel.MapWorldModelSingleton().GotoTactic(
					commandStrategy.GridFleet.GetId(),
					commandStrategy.GridFleetVictim.GetId(),
					false,
					commandStrategy.LongRange, CountTurn, BattlePlanetModel.GetBattlePlanetModelSingleton());

		}
		else
		{

			// attack fiend
			MapWorldModel.MapWorldModelSingleton().GotoTactic(
					commandStrategy.GridFleetVictim.GetId(),
					commandStrategy.GridFleet.GetId(),
					true,
					commandStrategy.LongRange, CountTurn, BattlePlanetModel.GetBattlePlanetModelSingleton());

		}
	}
}
