using System.Collections;
using System.Collections.Generic;

using System;
public class Robot
{
	public int SelectUnitPlayerRandom(List<ArmUnit> Crew_ar)
	{

	
		//double order = Math.floor(Math.random() * Crew_ar.Count);

		var rand = new System.Random();
		var order = rand.Next(Crew_ar.Count);

		return (int)order;
	}
	
	public static bool BonusShipIsland(ShipUnit FiendShip, ShipUnit PlayerShip, int TypeIsland)
	{
		if (FiendShip.GetTypeShip() == TypeIsland
			|| PlayerShip.GetTypeShip() == TypeIsland)
		{
			return false;
		}
		else
		{
			return true;
		}

	}

	public static bool Yes_Refreshment(ShipUnit shipName)
	{


		if (shipName != null)
		{
			if (shipName.GetArmUnitArray() != null)
			{
				if (shipName.GetArmUnitArray().Count > 0)
				{
					return true;
				}
			}

		}
		return false;

	}
	public static int AllAttack(ArmUnit Unit, int ShipAttack, int HeroAttack)
	{
		int TehPlayer = Unit.Attack
				+ ShipAttack
				+ HeroAttack;
		return TehPlayer;
	}
	public static int AllDefence(ArmUnit Unit, int ShipDefence,
			int HeroDefence)
	{
		int MaterielFiend = Unit.Attack 
				+ ShipDefence + HeroDefence;
		return MaterielFiend;
	}

	public static ShipUnit GetShip(GridFleet Fleet)
	{
		return Fleet.GetShipName();
	}
	public static ArmUnit GetUnit(List<ArmUnit> Crew_ar, int SelectUnit)
	{
		if (Crew_ar.Count <= SelectUnit)
		{
			throw new Exception("error GetUnit() size=" + Crew_ar.Count + " SelectUnit= " + SelectUnit);
		}
		return Crew_ar[SelectUnit];
	}
	public List<ArmUnit> DeadUnit(
			int UnitIdDead,
			int UnitIdWin,
			  List<GridCrewScience> BasaPurchaseUnitScience_ar,
			  ShipUnit CrewPLayer,
			  ShipUnit CrewFiend
	)
	{
		List<ArmUnit> basaUnitFiendDead_ar = new List<ArmUnit>();


		//dead
		int index = GetIndexUnit(CrewPLayer.GetArmUnitArray(), UnitIdDead);

		if (index != -1)
		{

			basaUnitFiendDead_ar.Add(CrewPLayer.GetArmUnitArray()[index]);

			CrewPLayer.RemoveUnit(index);

		}
		else
		{

			index = GetIndexUnit(CrewFiend.GetArmUnitArray(), UnitIdDead);
			if (index != -1)
			{
				basaUnitFiendDead_ar.Add(CrewFiend.GetArmUnitArray()[index]);

				CrewFiend.RemoveUnit(index);
			}
			else
			{
				//System.out.println("Error id player Win? =" + UnitIdDead);
			}
		}

		//win
		if (UnitIdWin != 0)
		{
			int indexWin = GetIndexUnit(CrewPLayer.GetArmUnitArray(), UnitIdWin);

			if (indexWin != -1)
			{

				FunctionShare.Add_Level_Unit(CrewPLayer.GetArmUnitArray()[indexWin], BasaPurchaseUnitScience_ar);
			}
			else
			{
				int indexFiend = GetIndexUnit(CrewFiend.GetArmUnitArray(), UnitIdWin);
				if (indexFiend != -1)
				{
					FunctionShare.Add_Level_Unit(CrewFiend.GetArmUnitArray()[indexFiend], BasaPurchaseUnitScience_ar);
				}
				else
				{
					//System.out.println("Error id fiend Win? =" + indexFiend);
				}
			}
		}
		return basaUnitFiendDead_ar;

	}

	public ArmUnit RemoveUnitId(List<ArmUnit> CrewFiend_ar, int UnitId)
	{
		int index = GetIndexUnit(CrewFiend_ar, UnitId);
		ArmUnit armUnit = CrewFiend_ar[index];
		CrewFiend_ar.RemoveAt(index);
		return armUnit;
	}
	private int GetIndexUnit(List<ArmUnit> CrewFiend_ar, int UnitId)
	{
		int index = 0;
		foreach (ArmUnit armUnit in CrewFiend_ar)
		{
			if (armUnit.Id == UnitId)
			{
				return index;
			}
			index++;
		}
		return -1;
	}
}
