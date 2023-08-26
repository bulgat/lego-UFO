using System.Collections;
using System.Collections.Generic;


public class ShipCannon 
{
	public ShipCannon(CannonAmmunition cannonAmmunition, int Level)
	{
		this.Velocity = cannonAmmunition.Velocity;
		this.Worse = cannonAmmunition.Worse;
		this.Range = cannonAmmunition.Range;
		this.Pierce = cannonAmmunition.Pierce;
		this.PierceMin = cannonAmmunition.PierceMin;
		this.Size = cannonAmmunition.Size;
		this.Exact = cannonAmmunition.Exact + cannonAmmunition.BonusExact * Level;
		Charge = 50;
		this.TypeCannon = cannonAmmunition.Num;

	}
	public int Velocity;
	public int Range;
	public int Pierce;
	public bool PierceMin;
	public int TimeQuick;
	public int Worse;
	public int Size;
	public int Charge;
	public int Exact;
	public int TypeCannon;
	public int Ammunition;
}
