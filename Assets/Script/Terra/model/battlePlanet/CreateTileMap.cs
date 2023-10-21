using System.Collections;
using System.Collections.Generic;


public class CreateTileMap 
{

	public void DrawTileMap(List<GridTileBar> Grid_ar)
	{

		//_image_ar = DeleteActorImage.DeleteActor( _image_ar);
		//int widthTile = new WidthTile().GetWidthTileOne(Grid_ar[Grid_ar.Count - 1].SpotX + 1);

		for (int GridRow = 0; GridRow < Grid_ar[Grid_ar.Count - 1].SpotX + 1; GridRow++)
		{
			for (int GridLine = 0; GridLine < Grid_ar[Grid_ar.Count - 1].SpotY + 1; GridLine++)
			{

				GridTileBar gridTileBar = ModelStrategy.GetOneGrid(Grid_ar, GridRow, GridLine);


				int shoal = gridTileBar.Shoal == true ? 1 : 0;
				// road
				if (gridTileBar.Terrain == 3)
				{
					shoal = 3;
				}
				// mountain
				if (gridTileBar.Terrain == 2)
				{
					shoal = 2;

				}
				// sea
				if (gridTileBar.Terrain == 4)
				{
					shoal = 5;

				}


			}
		}
	}

}
