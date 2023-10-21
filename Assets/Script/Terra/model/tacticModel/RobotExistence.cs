using System.Collections;
using System.Collections.Generic;

using System;

public class RobotExistence 
{
	public static RobotResultMelee Auto_Existense(
			GridFleet HeroFiend,
			ShipUnit shipFiend,
			ArmUnit Unit_Fiend,
			GridFleet NameHero,
			ShipUnit shipPlayer,
			ArmUnit Unit_Player,
			int TypeIsland,
			bool MoveAi,
			IslandMemento islandDemoMemento
		)
	{



		if (Unit_Fiend == null || Unit_Player == null)
		{
			throw new ArithmeticException("Error! Not Unit! units fiends =  " + Unit_Fiend + " and player = " + Unit_Player);
			//return null;
		}

		if (GetErrorRobot(Unit_Fiend, Unit_Player))
		{
			throw new ArithmeticException("ErrorRobot");
			//return null;
		}

		//bool Player_AttackUnMove = GetAttackPlayer(MoveAi);

		int TehPlayer = 0;
		int MaterielFiend = 0;
		/*
		bool BonusShip = Robot.BonusShipIsland(shipFiend,
				shipPlayer,
				TypeIsland);*/
		//int AttackHero = NameHero.Attack;
		//Player_Attack = Math.floor(Math.random() * 2) == 0;

		if (GetAttackPlayer(MoveAi))
		{


			if (Robot.BonusShipIsland(shipFiend,
				shipPlayer,
				TypeIsland))
			{

				MaterielFiend = Robot.AllDefence(Unit_Fiend, shipFiend.Defence
						, HeroFiend.Defence
						+ (int)BonusIslandTile.GetBonusIsland(islandDemoMemento, HeroFiend, Unit_Fiend).Y);

				TehPlayer = Robot.AllAttack(Unit_Player, shipPlayer.Attack,
						NameHero.Attack
						+ (int)BonusIslandTile.GetBonusIsland(islandDemoMemento, NameHero, Unit_Player).X);
			}
			else
			{
				//island
				MaterielFiend = Unit_Fiend.Defence + shipFiend.Defence + HeroFiend.LandDefence;

				TehPlayer = Unit_Player.Attack + shipPlayer.LandAttack + NameHero.Attack;


			}

		}
		else
		{

			if (Robot.BonusShipIsland(shipFiend,
				shipPlayer,
				TypeIsland))
			{
				

				MaterielFiend = Robot.AllAttack(Unit_Fiend, shipFiend.Attack,
						HeroFiend.Attack
						+ (int)BonusIslandTile.GetBonusIsland(islandDemoMemento, HeroFiend, Unit_Fiend).X);


				TehPlayer = Robot.AllDefence(Unit_Player, shipPlayer.Defence
						, NameHero.Defence
						+ (int)BonusIslandTile.GetBonusIsland(islandDemoMemento, NameHero, Unit_Player).Y);

			}
			else
			{
				//island
				MaterielFiend = Unit_Fiend.Attack + shipFiend.Defence + HeroFiend.LandAttack;
				TehPlayer = Unit_Player.Defence + shipPlayer.LandDefence + NameHero.Defence;

			}

		}


		

		var rand = new System.Random();
		

		// Count result attack/defence.
	
		RobotResultMelee resultMelee = new RobotResultMelee();
		////resultMelee.Player_Melee = UnityEngine.Random.Range(0,TehPlayer);
		////resultMelee.Fiend_Melee = UnityEngine.Random.Range(0,MaterielFiend);

        resultMelee.Player_Melee = 0;
        resultMelee.Fiend_Melee = 0;

        resultMelee.PlayerMeleeFull = TehPlayer;
		resultMelee.FiendMeleeFull = MaterielFiend;
		resultMelee.Existense = resultMelee.Player_Melee - resultMelee.Fiend_Melee;
		resultMelee.Player_Attack = GetAttackPlayer(MoveAi);
		return resultMelee;

	}
	public static bool GetErrorRobot(ArmUnit Unit_Fiend, ArmUnit Unit_Player)
	{
		if (Unit_Fiend == null || Unit_Player == null)
		{
			//System.out.println("Error! Not Unit! units fiends =  " + Unit_Fiend + " and player = " + Unit_Player);
			return true;
		}
		return false;
	}

	public static bool GetAttackPlayer(bool MoveAi)
	{
		return (MoveAi == false);
	}
	public static List<ArmUnit> GetCrewLongRangeArray(List<ArmUnit> Crew_ar)
	{
		List<ArmUnit> CrewLongRange_ar = new List<ArmUnit>();
		foreach (ArmUnit armUnit in Crew_ar)
		{
			if (armUnit.LongRange)
			{
				CrewLongRange_ar.Add(armUnit);
			}
		}
		return CrewLongRange_ar;
	}
}
