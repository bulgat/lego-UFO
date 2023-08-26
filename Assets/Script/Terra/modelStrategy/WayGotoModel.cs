using System.Collections;
using System.Collections.Generic;


public class WayGotoModel : Point
{
	/*
	public WayGotoModel(float SpotX, float SpotY)
	{
		//Point(SpotX, SpotY);
	}
	*/
	public WayGotoModel(float SpotX, float SpotY)
	   : base(SpotX, SpotY)
	{ }

	public List<Point> PathGoto_ar;
}
