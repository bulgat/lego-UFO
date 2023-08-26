using System.Collections;
using System.Collections.Generic;

public class UsingCommand 
{
	public List<CommandStrategy> PickUpCommandCaptureIsland(
		   IExecuteCommand executeCommand,
		   List<CommandStrategy> _commandStrategy_ar, int Id, int CountTurn, int GlobalParamsGale)
	{


		CommandStrategy commandStrategyRemove = null;
		if (_commandStrategy_ar != null) { 
		foreach (CommandStrategy commandStrategy in _commandStrategy_ar)
		{

			if (commandStrategy.Id == Id)
			{

				if (commandStrategy.NameCommand == CommandStrategy.Type.CaptureIsland)
				{

					executeCommand.PerformCommand(commandStrategy);
				}
				if (commandStrategy.NameCommand == CommandStrategy.Type.CreateFleet)
				{

					executeCommand.PrototypeHeroCreateFleet(commandStrategy);
				}
				// move fleet.
				if (commandStrategy.NameCommand == CommandStrategy.Type.MoveFleet)
				{


					executeCommand.PerformCommandMoveFleet(commandStrategy);
				}
				if (commandStrategy.NameCommand == CommandStrategy.Type.AttackFleet)
				{

					executeCommand.PerformAttackFleet(commandStrategy, CountTurn, GlobalParamsGale);

				}
				commandStrategyRemove = commandStrategy;
			}
		}
_commandStrategy_ar.Remove(commandStrategyRemove);
	}
		//_commandStrategy_ar.remove(commandStrategyRemove);
		
		return _commandStrategy_ar;
	}
}
