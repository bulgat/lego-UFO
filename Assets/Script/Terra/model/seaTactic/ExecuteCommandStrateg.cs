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
		MapWorldModel._prototypeHeroDemo.GetHeroFleet().Add(commandStrategy.GridFleet);
	}
	public void PerformCommandMoveFleet(CommandStrategy commandStrategy)
	{
		ModelStrategy.PerformCommandMoveFleet(MapWorldModel._prototypeHeroDemo, commandStrategy);
	}
	public void PerformAttackFleet(CommandStrategy commandStrategy, int CountTurn, int GlobalParamsGale)
	{



		ModelStrategy.PerformAttackFleetAction(MapWorldModel._prototypeHeroDemo, commandStrategy);


		// fiend attack
		if (commandStrategy.AttackPlayer)
		{
			// attack player
			commandStrategy.GridFleet.SpotX = (int)commandStrategy.GridFleetOldPoint.X;
			commandStrategy.GridFleet.SpotY = (int)commandStrategy.GridFleetOldPoint.Y;

			MapWorldModel.GotoTactic(
					commandStrategy.GridFleet.GetId(),
					commandStrategy.GridFleetVictim.GetId(),
					false,
					commandStrategy.LongRange, CountTurn);

		}
		else
		{

			// attack fiend
			MapWorldModel.GotoTactic(
					commandStrategy.GridFleetVictim.GetId(),
					commandStrategy.GridFleet.GetId(),
					true,
					commandStrategy.LongRange, CountTurn);

		}
	}
}
