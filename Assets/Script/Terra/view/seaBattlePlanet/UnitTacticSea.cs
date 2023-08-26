using System.Collections;
using System.Collections.Generic;


public class UnitTacticSea : UnitTacticBasic
{
	public UnitTacticSea()
	{
		//super();
		base.UnitTacticBasicInit();
	}

	
	public override Point GetPerspective(int range, float Width, float Height)
	{

		return new Point(Width, Height);
	}
	
}
