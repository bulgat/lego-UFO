using System.Collections;
using System.Collections.Generic;


public class GetIslandTacticLandscape 
{
	public static IslandTacticLandscapeModel GetIslandTacticLandscapeResult(
			IslandMemento islandDemoMemento,
			GridFleet PlayerFleet,
			GridFleet FiendFleet)
	{
		IslandTacticLandscapeModel islandTacticLandscapeModel = new IslandTacticLandscapeModel();

		islandTacticLandscapeModel.PlayerIsland = BattlePlanetModel.GetBattlePlanetModelSingleton().GetIslandWithGridFleet(islandDemoMemento.GetIslandArray(), PlayerFleet);
		islandTacticLandscapeModel.FiendIsland = BattlePlanetModel.GetBattlePlanetModelSingleton().GetIslandWithGridFleet(islandDemoMemento.GetIslandArray(), FiendFleet);

		return islandTacticLandscapeModel;
	}
}
