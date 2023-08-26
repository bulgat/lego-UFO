using System.Collections;
using System.Collections.Generic;


public class ShipCapsule 
{
	public ShipCapsule(List<CannonAmmunition> cannonAmmunition_ar, int Level, int idCannon)
	{
		Board = 4;
		Armor = 0;
		if (idCannon >= 1)
		{
			this.ShipCannon = new ShipCannon(GetCannon(cannonAmmunition_ar, idCannon - 1), Level);

		}

	}
	private CannonAmmunition GetCannon(List<CannonAmmunition> cannonAmmunition_ar, int idCannon)
	{
		foreach (CannonAmmunition cannonAmmunition in cannonAmmunition_ar)
		{
			if (cannonAmmunition.Num == idCannon)
			{
				return cannonAmmunition;
			}
		}
		return null;
	}

	public int Board;
	public int Armor;
	public bool ArmorBoard;
	public bool WaterLine;
	public bool Damage;
	public int GoalSurge;
	public ShipCannon ShipCannon;

}
