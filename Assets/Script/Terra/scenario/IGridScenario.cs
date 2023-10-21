using System.Collections;
using System.Collections.Generic;


public interface IGridScenario 
{
	void Init(BattlePlanetModel battlePlanetModel);
	string GetMission();
	int ImageMission();
	string GetNameTileMap();
}
