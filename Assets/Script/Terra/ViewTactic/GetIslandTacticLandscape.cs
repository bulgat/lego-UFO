using System.Collections;
using System.Collections.Generic;


public class GetIslandTacticLandscape 
{
	public static IslandTacticLandscapeModel GetIslandTacticLandscapeResult(
			IslandDemoMemento islandDemoMemento,
			GridFleet PlayerFleet,
			GridFleet FiendFleet)
	{
		IslandTacticLandscapeModel islandTacticLandscapeModel = new IslandTacticLandscapeModel();

		islandTacticLandscapeModel.PlayerIsland = BattlePlanetModel.GetIslandWithGridFleet(islandDemoMemento.GetIslandArray(), PlayerFleet);
		islandTacticLandscapeModel.FiendIsland = BattlePlanetModel.GetIslandWithGridFleet(islandDemoMemento.GetIslandArray(), FiendFleet);

		return islandTacticLandscapeModel;
	}
}
