using System.Collections;
using System.Collections.Generic;

public class BuilderShipCustom 
{
	public List<CapsuleItem> GetBuilderShipCustom(int Id)
	{
		IShipCustom shipCustom1;
		if (Id == 1)
		{
			shipCustom1 = new ShipCustom1();
			return shipCustom1.GetIdCapsuleList();
		}
		if (Id == 2)
		{
			shipCustom1 = new ShipCustom2();
			return shipCustom1.GetIdCapsuleList();
		}
		shipCustom1 = new ShipCustom1();
		return shipCustom1.GetIdCapsuleList();
	}
}
