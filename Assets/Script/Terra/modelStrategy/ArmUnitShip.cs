using System.Collections;
using System.Collections.Generic;

using System;
public class ArmUnitShip 
{
	public int Id = 0;

	public int HeartPowerState;
	public int HeartPower;
	public int CritDamage;
	public List<ShipCapsule> ShipCapsuleList;
	public int SpeedSteam;
	public int Speed;
	public int SizeAim;
	public int FalconetSupply;
	public int CountCrew = 100;
	private string TypeShip;
	private int IdTypeShip;
	public List<CapsuleItem> CapsuleItem_ar;
	private int Unit = 1;
	public bool Sea;

	public ArmUnitShip(int IdTypeShip)
	{
		this.IdTypeShip = IdTypeShip;
        //TimeSalvoConstant timeSalvoConstant = new TimeSalvoConstant();
        //ArrayList<CannonAmmunition> cannonAmmunition_ar = timeSalvoConstant.GetCannonAmmunition();
        //int Level = 20;
        /*
		ShipCapsuleList = new ArrayList<ShipCapsule>();
		int[] id_ar = new int[] {0,0,0, 0,0,0, 0,1,0,0,0,0,1};
		for(Integer id:id_ar)
		{
			ShipCapsuleList.add(new ShipCapsule(cannonAmmunition_ar,Level,id));
		}
*/


    }
	public void SetUnit(int Value)
	{
		Unit = Value;
	}
	public int GetUnit()
	{
		
		return Unit;
	}
	public string GetTypeShip()
	{
		
		return TypeShip;
	}
	public int GetIdTypeShip()
	{
		
		return IdTypeShip;
	}
	private void SetCapsule(List<CannonAmmunition> cannonAmmunition_ar, int Level, List<CapsuleItem> id_ar)
	{
		ShipCapsuleList = new List<ShipCapsule>();
		//int[] id_ar = new int[] {0,0,0, 0,0,0, 0,1,0,0,0,0,1};
		foreach (CapsuleItem item in id_ar)
		{
			ShipCapsuleList.Add(new ShipCapsule(cannonAmmunition_ar, Level, item.CannonId));
		}
	}
	public void SetShip(int idTypeShip, int idCustomTypeShip)
	{
		IdTypeShip = idTypeShip;
		TypeShip = "ship" + idTypeShip;

		TimeSalvoConstant timeSalvoConstant = new TimeSalvoConstant();
		List<CannonAmmunition> cannonAmmunition_ar = timeSalvoConstant.GetCannonAmmunition();
		int Level = 20;
		BuilderShipCustom builderShipCustom = new BuilderShipCustom();
		CapsuleItem_ar = builderShipCustom.GetBuilderShipCustom(idCustomTypeShip);
		SetCapsule(cannonAmmunition_ar, 20, CapsuleItem_ar);

	}
	public bool ShipStatusDead()
	{

		return HeartPower <= 0;
	}
	public void DamageTurn()
	{
		HeartPower -= CritDamage;

	}
	public void StunDamage(int Damage)
	{
		HeartPower -= Math.Abs(Damage); 
		CritDamage += 1;
	}
	public int SalvoDamage(List<ImprintVolley> ImprintVolleyList)
	{
		int damageCount = 0;
		foreach (ImprintVolley ImprintVolley in ImprintVolleyList)
		{
			if (ImprintVolley.AffectHit != null)
			{
				/*
				if (ImprintVolley.AffectHit.CapsuleCount==damageCount) {
					//ImprintVolley.AffectHit.
					ShipCapsule shipCapsule =ShipCapsuleList.get(damageCount);
					shipCapsule.Damage = true; 
				}
				 */
				HeartPower -= ImprintVolley.AffectHit.OccurHit.Within;
				damageCount += ImprintVolley.AffectHit.OccurHit.Within;
				// set damage capsule.
				SetCapsuleDamage(ImprintVolley.AffectHit, ImprintVolley.AffectHit.Nature);

			}
		}

		return damageCount;
	}
	public void SetCapsuleDamage(AffectHit AffectHit, DamageFromCannon Nature)
	{
		int count = 0;
		foreach (ShipCapsule ShipCapsule in ShipCapsuleList)
		{
			if (AffectHit.CapsuleCount == count)
			{
				if (Nature.Pierce)
				{
					ShipCapsule.Damage = true;
					CritDamage += AffectHit.Nature.FlowValue;
					CountCrew -= AffectHit.Nature.Shrapnel;

				}
			}
			count++;
		}
	}
}
