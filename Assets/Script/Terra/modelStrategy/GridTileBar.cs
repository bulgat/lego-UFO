using System.Collections;
using System.Collections.Generic;


public class GridTileBar : BasicTile
{
	public int Terrain { get; set; }
	public int Tile { get; set; }
    public bool Shoal { get; set; }
    public bool Hide { get; set; }


	public GridTileBar(int spotX, int spotY, bool shoal)
	{

		this.SpotX = spotX;
		this.SpotY = spotY;

		this.Shoal = shoal;
		this.Hide = true;
	}


	
}
