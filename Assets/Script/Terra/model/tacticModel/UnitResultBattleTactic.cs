using System.Collections;
using System.Collections.Generic;


public class UnitResultBattleTactic 
{
	public UnitResultBattleTactic() { }
	public static ArmUnit CreatePseudoUnit(BattlePlanetModel battlePlanetModel,

			ArmUnit unit
			)
	{

		ArmUnit armPsevdo = new ArmUnit(battlePlanetModel,
				unit.GetUnit(), 0
				);
		armPsevdo.Level = unit.Level;
		armPsevdo.SoundMusic = unit.SoundMusic;
		return armPsevdo;


	}
	public static bool GetBlockDead(bool MoveAi,
			bool LongRange, bool DeadPlayer, ArmUnit unitWinPsevdo)
	{
		if (LongRange)
		{
			if (unitWinPsevdo.LongRange)
			{
				return false;
			}
		}


		if (MoveAi == false)
		{
			//attack player
			if (LongRange)
			{
				return GetBlockDeadPlayerAndFiend(LongRange, true);

			}
		}
		else
		{
			if (LongRange)
			{
				return GetBlockDeadPlayerAndFiend(LongRange, false);

			}
		}
		return false;
	}
	public static bool GetBlockDeadPlayerAndFiend(bool LongRange, bool Player)
	{
		if (LongRange)
		{
			if (Player)
			{
				return true;
			}
			else
			{
				return true;
			}
		}
		return false;
	}
}
