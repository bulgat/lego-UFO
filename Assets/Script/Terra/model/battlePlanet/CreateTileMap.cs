using System.Collections;
using System.Collections.Generic;


public class CreateTileMap 
{
	/*
    public List<GameObject> _image_ar;
    public CreateTileMap()
    {
        _image_ar = new List<GameObject>();
    }
	*/
	public void DrawTileMap(int width, List<GridTileBar> Grid_ar, float SlipX, float SlipY,
		LoadBibleImage loadBibleImage, bool Debug)
	{

		//_image_ar = DeleteActorImage.DeleteActor( _image_ar);
		int widthTile = new WidthTile().GetWidthTileOne(width, Grid_ar[Grid_ar.Count - 1].SpotX + 1);

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

				


			
			//	ButtonActorListerner.SetClickListenerBuilder(imageTile, modelEvent, "");

			}
		}
	}

}
