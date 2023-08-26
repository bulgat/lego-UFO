using System.Collections;
using System.Collections.Generic;


public class CreateHero 
{
	/*
	private List<GameObject> _heroImage_ar;
	int kol = 0;
	public CreateHero()
	{
		_heroImage_ar = new List<GameObject>();


	}
	public List<GameObject> GetFleetArray()
	{
		return _heroImage_ar;
	}

	public void DeleteFleetArray()
	{
		DeleteActorImage.DeleteActor( _heroImage_ar);
	}

	public void DrawHero(
			LoadBibleImage loadBibleImage,
			int width,
			 float SlipX, float SlipY, List<GridCrewScience> BasaPurchaseUnitScience_ar)
	{
		int widthTile = WidthTile.GetWidthTileOne(width,
				BattlePlanetModel.GridTile_ar[BattlePlanetModel.GridTile_ar.Count - 1].SpotX + 1);


		_heroImage_ar = DeleteActorImage.DeleteActor(_heroImage_ar);

		foreach (GridFleet hero in MapWorldModel._prototypeHeroDemo.GetHeroFleet())
		{
			Point pointHero = new Point(hero.SpotX, hero.SpotY);

			ButtonEvent modelEvent = new ButtonEvent();
			modelEvent.HeroFleet = hero;
			modelEvent.Point = pointHero;
			modelEvent.NameEvent = ControllerConstant.SelectHero;

			int numUnitImage = GetFirstUnitIdHero(hero);
			int countUnit = ModelStrategy.GetHeroShipFirstCount(hero);



			GameObject actorOne = DrawOneFleetIcon(loadBibleImage,
					numUnitImage, widthTile,
					pointHero, countUnit,  hero.GetId(), hero.GetFlagId(), SlipX, SlipY,
					BasaPurchaseUnitScience_ar);

			//stage.addActor(actorOne);

			_heroImage_ar.Add(actorOne);
			// hero

			//ButtonActorListerner.SetClickListenerBuilder(actorOne, modelEvent, actorOne.getName());

		}

	}


	public static GameObject DrawOneFleetIcon(
			LoadBibleImage loadBibleImage,
			int numUnitImage,
			int widthTile,
			Point pointHero,
			int countUnit, int Id, int FlagId, float SlipX, float SlipY,
			List<GridCrewScience> BasaPurchaseUnitScience_ar)
	{



		GameObject groupActor = new GameObject();

		// hero
		//Texture tileImage=null;





		GameObject imageTile = null;
		UnitShipTexture unitShipTexture = new UnitShipTexture();
		UnitTypeShipView unitTypeShipView = unitShipTexture.GetShipSea(numUnitImage, BasaPurchaseUnitScience_ar);

		if (unitTypeShipView != null)
		{
			
			imageTile = unitShipTexture.GetUnitShipFullTexture(unitTypeShipView.TypeShip.ToString());
			//imageTile =new UnitShipTexture().GetUnitShipTexture("ship"+unitTypeShipView.TypeShip) ;

			//imageTile.setHeight(widthTile / 2);
			//imageTile.setY(widthTile / 3);


		}
		else
		{
			//Texture heroTexture = loadBibleImage.GetLoadImage(GetImageUnit(numUnitImage, BasaPurchaseUnitScience_ar));
			//imageTile = new Image(heroTexture);
			//imageTile.setHeight(widthTile);
		}
		//imageTile =new Image(heroTexture);


		//imageTile.setWidth(widthTile);

		//imageTile.moveBy(SlipX + pointHero.X * widthTile, SlipY + pointHero.Y * widthTile);

		//groupActor.addActor(imageTile);

		//groupActor.setName(GlobalParamView.FleetGridMoveName + Id);

		// add jaw
		if (unitTypeShipView != null)
		{
			Texture Jaw = loadBibleImage.GetLoadImage(GraficBibleConstant.Jaw);
			//Image imageJaw = new Image(Jaw);
			GameObject imageJaw = new GameObject();
			//imageJaw.setWidth(widthTile / 2);
			//imageJaw.setHeight(widthTile / 3);
			//imageJaw.moveBy(SlipX + pointHero.X * widthTile, SlipY + pointHero.Y * widthTile);
			//imageJaw.moveBy(widthTile / 4, 0);
			//groupActor.addActor(imageJaw);
		}

		// label
		//Label text;
		//text = new Label(Integer.toString(countUnit), mySkin);

		float scaleFont = (float)widthTile / 70;

		//text.setFontScale(scaleFont);

		//text.moveBy(SlipX + pointHero.X * widthTile + (widthTile / 2) - 3, SlipY + pointHero.Y * widthTile - 3);

		//groupActor.addActor(text);



		// flag
	
		return groupActor;
	}

	
	public static int GetFirstUnitIdHero(GridFleet hero)
	{
		return GetUnitArrayIdHero(hero)[0].GetUnit();
	}
	private static List<ArmUnit> GetUnitArrayIdHero(GridFleet hero)
	{
		return hero.GetShipName().GetArmUnitArray();
	}
*/
}
