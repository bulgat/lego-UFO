using System.Collections;
using System.Collections.Generic;


public class GridFleet : BasicTile
{
	public string Name;

	private int FlagId;
	private int FleetId;
	public string Image;
	public int Strateg_Memory_BasaSpotX = 0;
	public int Strateg_Memory_BasaSpotY = 0;
	private ShipUnit ShipName;
	public int Attack = 0;
	public int Defence = 0;
	public int LandAttack = 0;
	public int LandDefence = 0;
	private int PowerReserve = 1;
	private int Speed = 1;
	private Point AimPeaceCaravan;
	private bool TurnDone;
	private bool AttackDone;
	private bool StaticLongRange;

	public GridFleet(string name, int spotX, int spotY, int flagId, string image)
	{
		Name = name;
		SpotX = spotX;
		SpotY = spotY;
		FlagId = flagId;
		ShipName = new ShipUnit();
		Image = image;
	}
	public bool GetSea()
	{
		bool sea = false;
		//foreach (ShipUnit ship in ShipName)
		//{

			foreach (ArmUnit armUnit in ShipName.GetArmUnitArray())
			{
				if (armUnit.Sea)
				{
					return true;
				}
			}

		//}
		return false;
	}
	public int GetCountUnitArm()
	{
		return ShipName.GetArmUnitArray().Count;
	}

    public int GetSpeedStatic()
	{
		return Speed;
	}
	public int GetSpeed()
	{
		int maxSpeed = 999;

		//foreach (ShipUnit ship in ShipName_ar)
		//{

			foreach (ArmUnit armUnit in ShipName.GetArmUnitArray())
			{

				if (armUnit.Speed < maxSpeed)
				{
					maxSpeed = (int)armUnit.Speed;
				}
			}
		//}
		return maxSpeed;
	}
	public bool GetRange()
	{
		int maxSpeed = 999;
		if (StaticLongRange)
		{
			return true;
		}
		//foreach (ShipUnit ship in ShipName_ar)
		//{

			foreach (ArmUnit armUnit in ShipName.GetArmUnitArray())
			{

				if (armUnit.LongRange == true)
				{
					return true;
				}
			}
		//}
		return false;
	}
	public void SetStaticRange(bool LongRange)
	{
		StaticLongRange = LongRange;
		/*
		for (ShipUnit ship: ShipName_ar)
		{
			
			for (ArmUnit armUnit: ship.GetArmUnitArray())
			{
				armUnit.LongRange=LongRange;
			}
		}
		*/
	}


	public int GetStaticSpeed()
	{
		return Speed;
	}
	public void SetTurnDone(bool turnDone)
	{
		TurnDone = turnDone;
	}
	public bool GetTurnDone()
	{
		return TurnDone;
	}
	public void SetAttackDone(bool attackDone)
	{
		AttackDone = attackDone;
	}
	public bool GetAttackDone()
	{
		return AttackDone;
	}
	public void SetPowerStatic()
	{
		PowerReserve = Speed;
	}
	public void SetPowerReserve()
	{
		PowerReserve = GetSpeed();
	}
	public int GetPowerReserve()
	{
		return PowerReserve;
	}
	public void PowerReserveChange(int num)
	{
		PowerReserve += num;
	}
	public void SetAimPeaceCaravan(Point aimPeaceCaravan)
	{
		AimPeaceCaravan = aimPeaceCaravan;
	}
	public Point GetAimPeaceCaravan()
	{
		return AimPeaceCaravan;
	}
	public int GetFlagId()
	{
		return FlagId;
	}
	public void SetId(int fleetId)
	{
		FleetId = fleetId;
	}
	public int GetId()
	{
		return FleetId;
	}
	public void AddShipName(ShipUnit shipUnit)
	{
		ShipName =shipUnit;
	}
	public ShipUnit GetShipName()
	{
		return ShipName;
	}
	public ShipUnit GetShipNameFirst()
	{
		return ShipName;
	}
	public GridFleet Copy()
	{
		GridFleet fleetCopy = new GridFleet(Name, SpotX, SpotY, FlagId, Image);
		fleetCopy.ShipName = new ShipUnit();
		//foreach (ShipUnit shipUnit in ShipName_ar)
		//{
			fleetCopy.ShipName = ShipName.Copy();
		//}
		fleetCopy.FleetId = this.FleetId;
		fleetCopy.FlagId = FlagId;
		fleetCopy.Image = Image;
		fleetCopy.Strateg_Memory_BasaSpotX = this.Strateg_Memory_BasaSpotX;
		fleetCopy.Strateg_Memory_BasaSpotY = this.Strateg_Memory_BasaSpotY;
		fleetCopy.PowerReserve = this.PowerReserve;
		fleetCopy.Speed = this.Speed;
		fleetCopy.AimPeaceCaravan = this.AimPeaceCaravan;
		fleetCopy.TurnDone = this.TurnDone;
		fleetCopy.AttackDone = this.AttackDone;
		fleetCopy.StaticLongRange = this.StaticLongRange;

		return fleetCopy;
	}
}
