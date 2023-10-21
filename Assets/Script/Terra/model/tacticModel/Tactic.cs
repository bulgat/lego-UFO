using System.Collections;
using System.Collections.Generic;

using System;

public class Tactic : BasicTactic
{
	public int Select_Unit_Fiend = 0;
	public int Select_Unit_Player = 0;
	public int Player_Melee = 0;
	public int Fiend_Melee = 0;

	public bool AttackPlayer = false;


	public RobotResultMelee _AttackMelee;

	public bool DeadPlayer = false;
	//public MeleeShip _meleeShip;
	public int _unitIdDead = 0;
	public int _unitIdWin = 0;
	public ArmUnit _unitDeadPsevdo;
	public ArmUnit _unitWinPsevdo;

	public bool MoveAI;
	public bool LongRange;
	private List<UnitResultTactic> _unitResultTactic_ar;
	
	private static Tactic TacticSingleton;

	public static Tactic GetTactic() {
		return TacticSingleton;
	}
	public List<UnitResultTactic> GetResultTacticBattle() { 
		return _unitResultTactic_ar; 
	}

	public Tactic(GridFleet HeroFiend, GridFleet HeroPlayer, bool MoveAi, bool longRange)
	{
		

		SetFiendFleet(HeroFiend);
		SetPlayerFleet(HeroPlayer);

		MeleeShip meleeShip = new MeleeShip();
		//_meleeShip = meleeShip;
		MoveAI = MoveAi;
		LongRange = longRange;
		//meleeShip.Launch(HeroFiend, HeroPlayer);
		meleeShip.Launch();
		
		_AttackMelee = new RobotResultMelee();
		////////
		
		//int limitDeadUnit = (int)Math.floor(Math.random() * 9) + 1;

		var rand = new System.Random();
		int limitDeadUnit = rand.Next(9)+1;

		

		_unitResultTactic_ar = meleeShip.GetStreamRunFast(
				GetFiendFleet(),
				GetPlayerFleet(),
				GetPlayerFleet().GetShipNameFirst(),
				GetFiendFleet().GetShipNameFirst(),
				limitDeadUnit,
				MoveAi, LongRange);

		TacticSingleton = this;

	}
	public void ReleaseDead()
	{
		MeleeShip meleeShip = new MeleeShip();
		meleeShip.ReleaseDead(_unitResultTactic_ar,
				BattlePlanetModel.GetBattlePlanetModelSingleton().GetBasaPurchaseUnitScience(),
				GetPlayerFleet().GetShipNameFirst(),
				GetFiendFleet().GetShipNameFirst()
				);

		StopBattleVictory(BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo);

	}
}
