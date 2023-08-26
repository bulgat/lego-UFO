using System.Collections;
using System.Collections.Generic;


public class MeleeUnitResult: UnitResultBattleTactic
{
	public static UnitResultTactic Add_Melee_Unit(
			  List<GridCrewScience> BasaPurchaseUnitScience_ar,
			  GridFleet HeroFiend,
			  GridFleet HeroPlayer,
			  List<ArmUnit> CrewPLayer_ar,
			  List<ArmUnit> CrewFiend_ar,
			  bool MoveAi,
			  bool LongRange,
			  IslandDemoMemento islandDemoMemento
			  )
	{
		if (CrewPLayer_ar.Count == 0 || CrewFiend_ar.Count == 0)
		{
			return null;
		}

		//Robot robot = new Robot();
		//bool AttackPlayer = false;

		//int SelectUnit_Player = 0;
		//int SelectUnit_Fiend = 0;
		//RobotResultMelee robotResultMelee = null;

		//ArmUnit UnitPlayer = null;
		//ArmUnit UnitFiend = null;

		UnitResultTactic unitResultTactic = null;

		if (HeroFiend != null && HeroPlayer != null)
		{
			

			bool player_AttackUnMove = RobotExistence.GetAttackPlayer(MoveAi);

			// filr
			if (LongRange)
			{
				if (player_AttackUnMove)
				{
					CrewPLayer_ar = RobotExistence.GetCrewLongRangeArray(CrewPLayer_ar);
				}
				else
				{
					CrewFiend_ar = RobotExistence.GetCrewLongRangeArray(CrewFiend_ar);
				}
			}
			Robot robot = new Robot();
			int SelectUnit_Player = robot.SelectUnitPlayerRandom(CrewPLayer_ar);
			int SelectUnit_Fiend = robot.SelectUnitPlayerRandom(CrewFiend_ar);

			ArmUnit UnitPlayer = Robot.GetUnit(CrewPLayer_ar, SelectUnit_Player);
			ArmUnit UnitFiend = Robot.GetUnit(CrewFiend_ar, SelectUnit_Fiend);

			ShipUnit shipPlayer = HeroPlayer.GetShipNameFirst();
			ShipUnit shipFiend = HeroFiend.GetShipNameFirst();


			RobotResultMelee robotResultMelee = RobotExistence.Auto_Existense(
					HeroFiend,
					shipFiend,
					UnitFiend,
					HeroPlayer,
					shipPlayer,
					UnitPlayer,
					BattlePlanetModel.TypeIsland,
					MoveAi,
					islandDemoMemento
				);

			RobotResultMelee _AttackMelee = robotResultMelee;


			int FiendMelee = robotResultMelee.Fiend_Melee;
			int PlayerMelee = robotResultMelee.Player_Melee;

			bool AttackPlayer = robotResultMelee.Player_Attack;
			
		

			ArmUnit unitPlayer = Robot.GetUnit(CrewPLayer_ar, SelectUnit_Player);
			ArmUnit unitFiend = Robot.GetUnit(CrewFiend_ar, SelectUnit_Fiend);



			unitResultTactic = GetUnitResultTactic(robotResultMelee,
					BasaPurchaseUnitScience_ar,
					CrewPLayer_ar,
					CrewFiend_ar,
					unitPlayer,
					unitFiend,
					MoveAi,
					LongRange
					);
		}
		return unitResultTactic;

	}

	public static UnitResultTactic GetUnitResultTactic(
			RobotResultMelee robotResultMelee,
			List<GridCrewScience> BasaPurchaseUnitScience_ar,
			List<ArmUnit> CrewPLayer_ar,
			List<ArmUnit> CrewFiend_ar,
			ArmUnit unitPlayer,
			ArmUnit unitFiend,
			bool MoveAi,
			bool LongRange
			)
	{

		ArmUnit unitWinPsevdo = null;
		ArmUnit unitDeadPsevdo = null;

		int FiendMelee = robotResultMelee.Fiend_Melee;
		int PlayerMelee = robotResultMelee.Player_Melee;

		bool AttackPlayer = robotResultMelee.Player_Attack;
		bool DeadPlayer = false;
		int unitIdWin = 0;
		int unitIdDead = 0;

		

		if (robotResultMelee.Existense >= 0)
		{
			//dead fiend
			DeadPlayer = false;

			unitWinPsevdo = CreatePseudoUnit(BasaPurchaseUnitScience_ar,
					unitPlayer
					);

			unitDeadPsevdo = CreatePseudoUnit(BasaPurchaseUnitScience_ar,
					unitFiend
					);
			// surrogat
			unitIdWin = unitPlayer.Id;
			unitIdDead = unitFiend.Id;
		}
		else
		{
			//dead player
			DeadPlayer = true;
			unitWinPsevdo = CreatePseudoUnit(BasaPurchaseUnitScience_ar,
					unitFiend
					);
			unitDeadPsevdo = CreatePseudoUnit(BasaPurchaseUnitScience_ar,
					unitPlayer
					);
			// surrogat	
			unitIdWin = unitFiend.Id;
			unitIdDead = unitPlayer.Id;
		}

		bool blockDead = GetBlockDead(MoveAi,
				LongRange, DeadPlayer, unitWinPsevdo);

		return new UnitResultTactic(
				AttackPlayer,
		DeadPlayer,
		unitIdWin,
		unitIdDead,
		unitWinPsevdo,
		unitDeadPsevdo,
		robotResultMelee.Existense,
			CrewPLayer_ar,
			CrewFiend_ar,
			unitPlayer,
			unitFiend,
			robotResultMelee.PlayerMeleeFull,
			robotResultMelee.FiendMeleeFull,
			blockDead,
			false,
			null
				);
	}
	public static UnitResultTactic GetUnitResultTacticSalvo(
			RobotResultMelee robotResultMelee,
			List<GridCrewScience> BasaPurchaseUnitScience_ar,
			List<ArmUnit> CrewPLayer_ar,
			List<ArmUnit> CrewFiend_ar,
			ArmUnit unitPlayer,
			ArmUnit unitFiend,
			bool MoveAi,
			bool LongRange
			)
	{

		ArmUnit unitWinPsevdo = null;
		ArmUnit unitDeadPsevdo = null;

		int FiendMelee = robotResultMelee.Fiend_Melee;
		int PlayerMelee = robotResultMelee.Player_Melee;

		bool AttackPlayer = robotResultMelee.Player_Attack;
		bool DeadPlayer = false;
		int unitIdWin = 0;
		int unitIdDead = 0;

		if (robotResultMelee.ExistenseSalvo)
		{
			//dead fiend
			DeadPlayer = false;

			unitWinPsevdo = CreatePseudoUnit(BasaPurchaseUnitScience_ar,
					unitPlayer
					);

			unitDeadPsevdo = CreatePseudoUnit(BasaPurchaseUnitScience_ar,
					unitFiend
					);
			// surrogat
			unitIdWin = unitPlayer.Id;
			unitIdDead = unitFiend.Id;
		}
		else
		{
			//dead player
			DeadPlayer = true;
			unitWinPsevdo = CreatePseudoUnit(BasaPurchaseUnitScience_ar,
					unitFiend
					);
			unitDeadPsevdo = CreatePseudoUnit(BasaPurchaseUnitScience_ar,
					unitPlayer
					);
			// surrogat	
			unitIdWin = unitFiend.Id;
			unitIdDead = unitPlayer.Id;
		}

		bool blockDead = GetBlockDead(MoveAi,
				LongRange, DeadPlayer, unitWinPsevdo);

		return new UnitResultTactic(
				AttackPlayer,
		DeadPlayer,
		unitIdWin,
		unitIdDead,
		unitWinPsevdo,
		unitDeadPsevdo,
		robotResultMelee.Existense,
			CrewPLayer_ar,
			CrewFiend_ar,
			unitPlayer,
			unitFiend,
			robotResultMelee.PlayerMeleeFull,
			robotResultMelee.FiendMeleeFull,
			blockDead,
			true,
			robotResultMelee.ImprintVolleyList
				);
	}
	public static bool GetLongRange(bool Attack, bool MoveAi,
			bool LongRange)
	{
		if (MoveAi == true)
		{
			if (LongRange)
			{
				return true;
			}
		}
		else
		{
			if (LongRange)
			{
				return true;
			}
		}

		return false;
	}
	
}
