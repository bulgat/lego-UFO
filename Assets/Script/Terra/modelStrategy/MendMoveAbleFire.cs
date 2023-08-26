using System.Collections;
using System.Collections.Generic;


public class MendMoveAbleFire 
{
	public List<ShipCapsule> GetAbleFireWithDistance(GridFleet gridFleet,
			Point pointLongRange, ArmUnit ArmUnitFleet,
			int GlobalParamsTimeQuick, int GlobalParamsGale
			)
	{
		TimeSalvoAppendHit timeSalvoAppendHit = new TimeSalvoAppendHit();

		int Distance = (int)ModelStrategy.GetDistance(
				new Point(gridFleet.SpotX, gridFleet.SpotY),
				pointLongRange);

		return timeSalvoAppendHit.GetCannonAbleList(Distance, ArmUnitFleet.ShipCapsuleList,
				GlobalParamsTimeQuick, GlobalParamsGale);
	}
	public bool DetermineAbleFire(GridFleet gridFleet,
			Point pointLongRange, ArmUnit ArmUnitFleet,
			int GlobalParamsTimeQuick, int GlobalParamsGale)
	{

		List<ShipCapsule> cannonAbleList = new MendMoveAbleFire().GetAbleFireWithDistance(gridFleet,
				pointLongRange, ArmUnitFleet,
				GlobalParamsTimeQuick, GlobalParamsGale
				);

		if (cannonAbleList.Count > 0)
		{
			return true;
		}
		return false;
	}
	public bool DetermineAbleFirePlayer(GridFleet fleetFiend, GridFleet fleetPlayer, GridFleet gridFleet,
			Point pointLongRange,
			int GlobalParamsTimeQuick, int GlobalParamsGale)
	{

		ArmUnitAndFleet armUnitAndFleet = new ArmUnitAndFleet();
		ArmUnit ArmUnitFleet = armUnitAndFleet.GetArmUnitIdFleet(gridFleet.GetId(),
			fleetFiend, fleetPlayer);

		List<ShipCapsule> cannonAbleList = ModelStrategy.GetAbleFireWithDistance(gridFleet,
				//pointLongRange,
				new Point(gridFleet.SpotX + 2, gridFleet.SpotY + 2),
			//null,
			ArmUnitFleet,
			GlobalParamsTimeQuick, GlobalParamsGale
			);
		return cannonAbleList.Count > 0;

	}
}
