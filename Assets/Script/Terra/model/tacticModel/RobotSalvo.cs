using System.Collections;
using System.Collections.Generic;


public class RobotSalvo 
{
	public static RobotResultMelee AutoExistense(
			GridFleet HeroFiend,
			ShipUnit shipFiend,
			ArmUnit Unit_Fiend,
			GridFleet NameHero,
			ShipUnit shipPlayer,
			ArmUnit Unit_Player,
			int TypeIsland,
			bool MoveAi,
			IslandDemoMemento islandDemoMemento,
			int GlobalParamsTimeQuick,
			int GlobalParamsGale
		)
	{

		if (RobotExistence.GetErrorRobot(Unit_Fiend, Unit_Player))
		{
			return null;
		}

		bool PlayerAttackUnMove = RobotExistence.GetAttackPlayer(MoveAi);
		int damageTotal = 0;
		List<ImprintVolley> ImprintVolley_ar = new List<ImprintVolley>();
		TimeSalvoAppendHit timeSalvoAppendHit = new TimeSalvoAppendHit();
		int Distance = 1;
		if (PlayerAttackUnMove)
		{


			// attack player
			//Unit_Fiend
			//Unit_Player

			ImprintVolley_ar =
					timeSalvoAppendHit.CannonSalvoCount(
							Unit_Player,
							Distance,
					 Unit_Fiend,
					 GlobalParamsTimeQuick,
					 GlobalParamsGale
					 );



			foreach (ImprintVolley ImprintVolley in ImprintVolley_ar)
			{
				if (ImprintVolley.AffectHit != null)
				{
					damageTotal += ImprintVolley.AffectHit.HitPlace;

				}
			}

		}
		else
		{
			// attack fiend
			//Unit_Fiend
			//Unit_Player

			ImprintVolley_ar =
					timeSalvoAppendHit.CannonSalvoCount(
							Unit_Fiend,
							Distance,
					 Unit_Player,
					 GlobalParamsTimeQuick,
					 GlobalParamsGale
					 );



			foreach (ImprintVolley ImprintVolley in ImprintVolley_ar)
			{
				if (ImprintVolley.AffectHit != null)
				{
					damageTotal += ImprintVolley.AffectHit.HitPlace;

				}
			}
		}
		//System.out.println("IdTypeShip =" + Unit_Fiend.GetIdTypeShip() + " fiend ca"
		//		+ "№№№№ № IdTypeShip=" + Unit_Player.GetIdTypeShip() + "===Player =  " + Unit_Player.ShipCapsuleList.get(12).ShipCannon.TypeCannon);


		RobotResultMelee resultMelee = new RobotResultMelee();

		// Count result attack/defence.
		resultMelee.Player_Melee = damageTotal;
		resultMelee.Fiend_Melee = damageTotal;
		resultMelee.PlayerMeleeFull = damageTotal;
		resultMelee.FiendMeleeFull = damageTotal;

		resultMelee.Existense = 0;
		//resultMelee.Player_Attack = false;
		resultMelee.Player_Attack = PlayerAttackUnMove;

		resultMelee.Salvo = true;
		//resultMelee.ExistenseSalvo=Player_AttackUnMove;
		resultMelee.ExistenseSalvo = true;
		resultMelee.ImprintVolleyList = ImprintVolley_ar;

		return resultMelee;
	}
}
