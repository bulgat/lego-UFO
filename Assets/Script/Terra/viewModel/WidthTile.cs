using System.Collections;
using System.Collections.Generic;


public class WidthTile
{
	public static int GetWidthTile(int width, int[][] ShoalSeaBasa_ar)
	{
		return width / ShoalSeaBasa_ar.Length;
	}
	public int GetWidthTileOne(int width, int Length)
	{
		return width / Length;
	}
}