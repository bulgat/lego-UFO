using System.Collections;
using System.Collections.Generic;


public class CannonAmmunition 
{
	public CannonAmmunition(int Num, int Ammunition, int Charge,
		int Range, int Velocity, int Worse, int Crumble, int Pierce,
		bool PierceMin, int Size, int Seniority,
		bool Chopper, bool Flak, string Help, int Exact, int BonusExact)
	{
		this.Num = Num;
		this.Ammunition = Ammunition;
		this.Charge = Charge;
		this.Range = Range;
		this.Velocity = Velocity;
		this.Worse = Worse;
		this.Crumble = Crumble;
		this.Pierce = Pierce;
		this.PierceMin = PierceMin;
		this.Size = Size;
		this.Seniority = Seniority;
		this.Chopper = Chopper;
		this.Flak = Flak;
		this.Help = Help;
		this.Exact = Exact;
		this.BonusExact = BonusExact;
	}
	public int Num;
	public int Ammunition;
	public int Charge;
	public int Range;
	public int Velocity;
	public int Worse;
	public int Crumble;
	public int Pierce;
	public bool PierceMin;
	public int Size;
	public int Seniority;
	public bool Chopper;
	public bool Flak;
	public string Help;
	public int Exact;
	public int BonusExact;
}
