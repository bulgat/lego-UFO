using System.Collections;
using System.Collections.Generic;

public class ExecuteCommandTactic : IExecuteCommand
{
	public void PerformCommand(CommandStrategy commandStrategy)
	{

	}
	public void PrototypeHeroCreateFleet(CommandStrategy commandStrategy)
	{

	}
	public void PerformCommandMoveFleet(CommandStrategy commandStrategy, PrototypeHeroDemo prototypeHeroDemo)
	{
        //ModelStrategy.PerformCommandMoveFleet(SeaTactic.GetTactic()._prototypeHeroSea, commandStrategy);
        ModelStrategy.PerformCommandMoveFleet(prototypeHeroDemo, commandStrategy);
    }
	public void PerformAttackFleet(CommandStrategy commandStrategy, int CountTurn, int GlobalParamsGale)
	{



		if (commandStrategy.unitResultTactic_ar == null)
		{
			commandStrategy.unitResultTactic_ar = GetUnitResultTactic(commandStrategy, CountTurn, GlobalParamsGale);
		}

		

		//ModelStrategy.SetTurnDoneAndPower(SeaTactic.GetPlayerFleet());
		//ModelStrategy.SetTurnDoneAndPower(commandStrategy.GridFleet);
		//System.out.println("  $$$$  UnitId    +++++++++++++++++++++++++++++++++++++++++++++" + commandStrategy.GridFleet.GetTurnDone());
		//System.out.println(" ---Total  PerformAttackFleet = TACTIC  id =" + commandStrategy.GridFleet.GetId());
		if (false)
		{

			MeleeShip meleeShip = new MeleeShip();

			meleeShip.ReleaseDead(
					commandStrategy.unitResultTactic_ar,
					BattlePlanetModel.GetBattlePlanetModelSingleton().GetBasaPurchaseUnitScience(),
					SeaTactic.GetTactic().GetPlayerFleet().GetShipNameFirst(),
					SeaTactic.GetTactic().GetFiendFleet().GetShipNameFirst());

		}

	}
	public List<UnitResultTactic> GetUnitResultTactic(CommandStrategy commandStrategy,
			int GlobalParamsTimeQuick, int GlobalParamsGale)
	{

		// set lever
		ModelStrategy.PerformAttackFleetAction(SeaTactic.GetTactic()._prototypeHeroSea, commandStrategy);

		RobotResultMelee robotResultMelee = null;
		ArmUnit armUnitFiend = null;
		ArmUnit armUnitPlayer = null;
		bool moveAi = false;



		// copy unit.
		List<ArmUnit> armUnitAll = GetStickTogether(SeaTactic.GetTactic().GetFiendFleet().GetShipNameFirst().GetArmUnitArray(),
				SeaTactic.GetTactic().GetPlayerFleet().GetShipNameFirst().GetArmUnitArray());

		bool salvo = true;
		//System.out.println(" &&&&&&&&&&& Unfavour &&&&&&&&&&& &&&&&&& commandStrategy.AttackPlayer= " + commandStrategy.AttackPlayer);
		if (commandStrategy.AttackPlayer)
		{

			// attack player
			commandStrategy.GridFleet.SpotX = (int)commandStrategy.GridFleetOldPoint.X;
			commandStrategy.GridFleet.SpotY = (int)commandStrategy.GridFleetOldPoint.Y;

			GetUnitFiendPlayer getUnitFiendPlayer = new GetUnitFiendPlayer(armUnitAll,
				commandStrategy,
				commandStrategy.GridFleetVictim.GetId(),
				commandStrategy.GridFleet.GetId());
			armUnitFiend = getUnitFiendPlayer.armUnitFiend;
			armUnitPlayer = getUnitFiendPlayer.armUnitPlayer;

			if (salvo)
			{
				robotResultMelee = RobotSalvo.AutoExistense(SeaTactic.GetTactic().GetFiendFleet(),
						SeaTactic.GetTactic().GetFiendFleet().GetShipNameFirst(),
						armUnitFiend,
						SeaTactic.GetTactic().GetPlayerFleet(),
						SeaTactic.GetTactic().GetPlayerFleet().GetShipNameFirst(),
						armUnitPlayer,
						0,
						true,
						new IslandMemento(),
						GlobalParamsTimeQuick,
						GlobalParamsGale);
			}
			else
			{
				robotResultMelee = RobotExistence.Auto_Existense(
						SeaTactic.GetTactic().GetFiendFleet(),
						SeaTactic.GetTactic().GetFiendFleet().GetShipNameFirst(),
						armUnitFiend,
						SeaTactic.GetTactic().GetPlayerFleet(),
						SeaTactic.GetTactic().GetPlayerFleet().GetShipNameFirst(),
						armUnitPlayer,
						0,
						true,
						new IslandMemento()
					);
			}
			moveAi = true;
		}
		else
		{


			GetUnitFiendPlayer getUnitFiendPlayer = new GetUnitFiendPlayer(armUnitAll,
					commandStrategy,
					commandStrategy.GridFleet.GetId(),
					commandStrategy.GridFleetVictim.GetId()
					);
			armUnitFiend = getUnitFiendPlayer.armUnitFiend;
			armUnitPlayer = getUnitFiendPlayer.armUnitPlayer;

			if (salvo)
			{
				robotResultMelee = RobotSalvo.AutoExistense(SeaTactic.GetTactic().GetPlayerFleet(),
						SeaTactic.GetTactic().GetPlayerFleet().GetShipNameFirst(),
						armUnitFiend,
						SeaTactic.GetTactic().GetFiendFleet(),
						SeaTactic.GetTactic().GetFiendFleet().GetShipNameFirst(),
						armUnitPlayer,
						0,
						false,
						new IslandMemento(),
						GlobalParamsTimeQuick,
						GlobalParamsGale);
			}
			else
			{

				// attack fiend
				robotResultMelee = RobotExistence.Auto_Existense(
						SeaTactic.GetTactic().GetPlayerFleet(),
						SeaTactic.GetTactic().GetPlayerFleet().GetShipNameFirst(),
						armUnitFiend,
						SeaTactic.GetTactic().GetFiendFleet(),
						SeaTactic.GetTactic().GetFiendFleet().GetShipNameFirst(),
						armUnitPlayer,
						0,
						false,
						new IslandMemento()
				);
			}
			moveAi = false;
		}


		List<RobotResultMelee> robotResultMelee_ar = new List<RobotResultMelee>();
		robotResultMelee_ar.Add(robotResultMelee);

		UnitResultTactic unitResultTactic = null;
		if (salvo)
		{
			if (robotResultMelee == null)
			{
				//throw new ArithmeticException("robotResultMelee==null");
			}

			// salvo.
			unitResultTactic = MeleeUnitResult.GetUnitResultTacticSalvo(
					robotResultMelee,
					BattlePlanetModel.GetBattlePlanetModelSingleton(),
					SeaTactic.GetTactic().GetPlayerFleet().GetShipNameFirst().GetArmUnitArray(),
					SeaTactic.GetTactic().GetFiendFleet().GetShipNameFirst().GetArmUnitArray(),
					armUnitPlayer,
					armUnitFiend,
					moveAi,
					false
					);


		}
		else
		{
			unitResultTactic = MeleeUnitResult.GetUnitResultTactic(
				robotResultMelee,
				BattlePlanetModel.GetBattlePlanetModelSingleton(),
				SeaTactic.GetTactic().GetPlayerFleet().GetShipNameFirst().GetArmUnitArray(),
				SeaTactic.GetTactic().GetFiendFleet().GetShipNameFirst().GetArmUnitArray(),
				armUnitPlayer,
				armUnitFiend,
				moveAi,
				false
				);
		}


		List<UnitResultTactic> unitResultTactic_ar = new List<UnitResultTactic>();
		unitResultTactic_ar.Add(unitResultTactic);


		return unitResultTactic_ar;

	}


	private List<ArmUnit> GetStickTogether(List<ArmUnit> Ar1, List<ArmUnit> Ar2)
	{
		List<ArmUnit> copy = new List<ArmUnit>();
		copy.AddRange(Ar1);
		copy.AddRange(Ar2);
		return copy;
	}

	private ArmUnit GetArmUnitWithId(List<ArmUnit> ArmUnit_ar, int IdUnit)
	{
		foreach (ArmUnit armUnit in ArmUnit_ar)
		{
			if (armUnit.Id == IdUnit)
			{
				return armUnit;
			}
		}
		return null;
	}
}
