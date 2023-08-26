using System.Collections;
using System.Collections.Generic;


public class ShipCustom1 : IShipCustom
{
	public List<CapsuleItem> GetIdCapsuleList()
	{

		List<CapsuleItem> item_ar = new List<CapsuleItem>();
		item_ar.Add(new ItemCustom0());
		item_ar.Add(new ItemCustom0());
		item_ar.Add(new ItemCustom0());

		item_ar.Add(new ItemCustom0());
		item_ar.Add(new ItemCustom0());
		item_ar.Add(new ItemCustom0());

		item_ar.Add(new ItemCustom0());
		//item_ar.add(new ItemCustom62());
		item_ar.Add(new ItemCustom55());
		item_ar.Add(new ItemCustom0());

		item_ar.Add(new ItemCustom0());
		item_ar.Add(new ItemCustom0());
		item_ar.Add(new ItemCustom0());

		//item_ar.add(new ItemCustom62());
		item_ar.Add(new ItemCustom55());
		return item_ar;

		//return new int[] {0,0,0, 0,0,0, 0,2,0, 0,0,0, 2};


	}
}
