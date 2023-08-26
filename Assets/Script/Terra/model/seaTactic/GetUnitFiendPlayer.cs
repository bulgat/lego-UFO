using System.Collections;
using System.Collections.Generic;


public class GetUnitFiendPlayer 
{
	public ArmUnit armUnitFiend;
	public ArmUnit armUnitPlayer;

	public GetUnitFiendPlayer(List<ArmUnit> armUnitAll,
			CommandStrategy commandStrategy, int OneUnitId, int TwoUnitId)
	{
		List<ArmUnit> ArmUnit_ar = new List<ArmUnit>();
		armUnitFiend = SeaTactic.GetTactic().GetArmUnitNameHere(
				armUnitAll,
				commandStrategy.GridFleetVictim.GetId()
				);
		ArmUnit_ar.Add(armUnitFiend);

		armUnitPlayer = SeaTactic.GetTactic().GetArmUnitNameHere(
				armUnitAll,
				commandStrategy.GridFleet.GetId()
				);
		ArmUnit_ar.Add(armUnitPlayer);

	}
}
