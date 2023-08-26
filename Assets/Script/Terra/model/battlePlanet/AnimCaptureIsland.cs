using System.Collections;
using System.Collections.Generic;


public class AnimCaptureIsland 
{
	/*
	private List<GameObject> _image_ar = new List<GameObject>();
	
	public void DrawCapture(
			
			int width,
			int Xpoint, int Ypoint, GameObject NameImage, float SlipX, float SlipY)
	{
		//SelectAttack
		Debug.Log("SelectAttack   ######   commandSuation Exp    MoveFleet  GetId = ");

		//DeleteActorImage.DeleteActor(_image_ar);

		int widthTile = WidthTile.GetWidthTileOne(width,
				BattlePlanetModel.GridTile_ar[BattlePlanetModel.GridTile_ar.Count - 1].SpotX + 1);

		//GameObject tileImage = new GameObject();

		//tileImage = loadBibleImage.GetLoadImage(NameImage);
		//tileImage = loadBibleImage.GetLoadImage(GraficBibleConstant.Sad);


		//GameObject imageName = new GameObject();
	
		//_image_ar.Add(imageName);
		

		NameImage.transform.position = new Vector3(SlipX+Xpoint, SlipY+Ypoint, -5f);
	}
	public void DrawCaptureHide(GameObject NameImage) {
		NameImage.transform.position = new Vector3(0, 0, 0);
	}

	public GameObject DrawCreateFleet(
			LoadBibleImage loadBibleImage,
			int width,
			float Xpoint, float Ypoint,
			GridFleet gridFleet,  float SlipX, float SlipY, List<GridCrewScience> BasaPurchaseUnitScience_ar)
	{

		DeleteActorImage.DeleteActor( _image_ar);

		int widthTile = WidthTile.GetWidthTileOne(width,
				BattlePlanetModel.GridTile_ar[BattlePlanetModel.GridTile_ar.Count - 1].SpotX + 1);

		int numUnit = CreateHero.GetFirstUnitIdHero(gridFleet);
		int countUnit = ModelStrategy.GetHeroShipFirstCount(gridFleet);

		GameObject actorOne = CreateHero.DrawOneFleetIcon(loadBibleImage, numUnit, widthTile,
				new Point(Xpoint, Ypoint),
				countUnit,  gridFleet.GetId(), gridFleet.GetFlagId(),
				SlipX, SlipY, BasaPurchaseUnitScience_ar);

		_image_ar.Add(actorOne);

		return actorOne;
	}

	public void ResetCapture()
	{
		DeleteActorImage.DeleteActor( _image_ar);
	}
*/
}
