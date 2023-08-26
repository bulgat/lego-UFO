using System.Collections;
using System.Collections.Generic;


public class ArmUnitAndFleet 
{
	public ArmUnit GetArmUnitIdFleet(int IdFleet, GridFleet fleetFiend, GridFleet fleetPlayer)
	{
		List<ArmUnit> armUnitList = new List<ArmUnit>();
		armUnitList.AddRange(fleetFiend.GetShipNameFirst().GetArmUnitArray());
		armUnitList.AddRange(fleetPlayer.GetShipNameFirst().GetArmUnitArray());
		foreach (ArmUnit armUnit in armUnitList)
		{
			if (IdFleet == armUnit.Id)
			{
				return armUnit;
			}
		}
		return null;
	}
}
