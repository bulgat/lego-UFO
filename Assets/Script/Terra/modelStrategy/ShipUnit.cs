using System.Collections;
using System.Collections.Generic;


public class ShipUnit 
{
	public ShipUnit()
	{
		Crew_ar = new List<ArmUnit>();
	}
	public int GetTypeShip()
	{
		return TypeShip;
	}
	public ArmUnit GetFirstUnit()
	{
		return Crew_ar[0];
	}


	private List<ArmUnit> Crew_ar;
	private int TypeShip = 0;
	public int Attack = 0;
	public int Defence = 0;
	public int LandAttack = 0;
	public int LandDefence = 0;
	//public List<ArmUnit> Team_ar;

	public void SetArmUnitArray(List<ArmUnit> crew_ar)
	{
		Crew_ar = crew_ar;
	}
	public List<ArmUnit> GetArmUnitArray()
	{
		return Crew_ar;
	}
	public void RemoveUnit(int index)
	{
		//Crew_ar.remove(index);
		Crew_ar.RemoveAt(index);
	}
	public ShipUnit Copy()
	{
		ShipUnit shipUnitCopy = new ShipUnit();
		shipUnitCopy.Crew_ar = new List<ArmUnit>();
		foreach (ArmUnit armUnit in Crew_ar)
		{
			shipUnitCopy.Crew_ar.Add(armUnit.Copy());
		}

		return shipUnitCopy;
	}
}
