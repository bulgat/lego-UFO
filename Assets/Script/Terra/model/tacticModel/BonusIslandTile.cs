using System.Collections;
using System.Collections.Generic;

public class BonusIslandTile 
{
	public static Point GetBonusIsland(IslandMemento islandDemoMemento, GridFleet NameHero, ArmUnit shipPlayer)
	{

		Island playerIsland = BattlePlanetModel.GetBattlePlanetModelSingleton().GetIslandWithGridFleet(islandDemoMemento.GetIslandArray(), NameHero);
		if (playerIsland != null)
		{
			return new Point(shipPlayer.Attack / 2, shipPlayer.Defence / 2);
		}
		return new Point(0, 0);
	}
}
