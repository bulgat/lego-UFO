using System.Collections;
using System.Collections.Generic;


public interface IExecuteCommand
{
	 void PerformCommand(CommandStrategy commandStrategy);
	 void PrototypeHeroCreateFleet(CommandStrategy commandStrategy);
	void PerformCommandMoveFleet(CommandStrategy commandStrategy);
	 void PerformAttackFleet(CommandStrategy commandStrategy, int CountTurn, int GlobalParamsGale);
}
