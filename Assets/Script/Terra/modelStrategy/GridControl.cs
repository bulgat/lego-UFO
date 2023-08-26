using System.Collections;
using System.Collections.Generic;


public class GridControl
{
	public static GridTileBar GridSelect(List<GridTileBar> Grid_ar, int spotX, int spotY)
	{
		foreach (GridTileBar gridBar in Grid_ar)
		{
			if (gridBar.SpotX == spotX && gridBar.SpotY == spotY)
			{
				return gridBar;
			}
		}
		return null;
	}
}
