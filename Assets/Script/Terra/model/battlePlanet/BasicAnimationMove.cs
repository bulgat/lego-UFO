using System.Collections;
using System.Collections.Generic;

public class BasicAnimationMove 
{
	/*
	public Point _moveObjectOld;
	public int _continuance = 50;
	public long _tickReal;
	public float speedUnit = 1.13f;

	public Point GetPointMoveFleet(CommandStrategy commandStrategy)
	{
		int indiciumX = -(int)(commandStrategy.GridFleetOldPoint.X - commandStrategy.GridFleetNewPoint.X);
		int indiciumY = -(int)(commandStrategy.GridFleetOldPoint.Y - commandStrategy.GridFleetNewPoint.Y);
		return new Point(indiciumX, indiciumY);
	}
	public void SetOldMove(GameObject MoveObject)
	{
		_moveObjectOld = new Point(MoveObject.transform.position.x, MoveObject.transform.position.y);
	}
	public float GetStepTick(long Tick)
	{
		return (float)(((_tickReal + _continuance) - Tick) * 2) / 100;
	}
	public void CorrectRealActor(float widthTile, float heightTile, Point indicium,
			GameObject moveObject, float WidthPanelBattlePlanet)
	{
		moveObject.transform.position.Set( (float)(widthTile) * indicium.X, moveObject.transform.position.y, 0);
		float setY = heightTile * indicium.Y;
		moveObject.transform.position.Set(moveObject.transform.position.x, WidthPanelBattlePlanet + setY, 0);

	}
	public void MoveRealActor(float widthTile, float heightTile, float stepTick, Point indicium,
			GameObject moveObject, float WidthPanelBattlePlanet)
	{

		float coef = widthTile / heightTile;

		//actor.

		moveObject.transform.position.Set(_moveObjectOld.X + (float)(widthTile) * (1.0f - stepTick) * indicium.X, _moveObjectOld.Y + (float)(heightTile) * (1.0f - stepTick) * indicium.Y, 0);

	}
	public float GetStep() {
		return speedUnit * Time.deltaTime;
	}
	public GameObject GetTileGameObject(List<GameObject> SceneList, int SpotX, int SpotY)
	{
		foreach (GameObject tileSandObj in SceneList)
		{
			TileSand tileSandScript = tileSandObj.GetComponent<TileSand>();
			if (tileSandScript.SpotX == SpotX && tileSandScript.SpotY == SpotY)
			{
				return tileSandObj;
			}
		}
		return null;
	}
	public GameObject GetUnitGameObject(List<GameObject> UnitHeroGameObjectList, int IdHero)
	{
		foreach (GameObject heroGameObject in UnitHeroGameObjectList)
		{
			TileSand HeroTileSand = heroGameObject.GetComponent<TileSand>();
			
			if (HeroTileSand.IdTileSand == IdHero)
			{
				return heroGameObject;
			}
		}
		return null;
	}
	public void MoveFleet(SetFieldArmyView setFieldArmyView, CommandStrategy commandStrategy
			, int StageWidthX, int StageHeightY
			)
	{
		if (commandStrategy.NameCommand == CommandStrategy.Type.MoveFleet)
		{

			SetMoveArmUnit(setFieldArmyView, commandStrategy, StageWidthX, StageHeightY);
		
		}
	}
	public void SetMoveArmUnit(SetFieldArmyView setFieldArmyView, CommandStrategy commandStrategy
			, int StageWidthX, int StageHeightY
			)
	{
		
	}
*/
}
