using System.Collections;
using System.Collections.Generic;


public class MockGlobalPlanet
{
    public MockGlobalPlanet(bool Tactic) {
        if (BattlePlanetView.NullBattlePlanetView())
        {
            BattlePlanetView battlePlanetView = BattlePlanetView.GetBattlePlanetViewSingleton();
            BattlePlanetModel.VictoryScenario.ScenarioNumber = 0;
            MapWorldModel.StartGame();
            AddArmyTown();
            if (Tactic == true)
            {
                AddArmyTactic();
            }
        }
    }
    private void AddArmyTown()
    {
        MapWorldModel._prototypeHeroDemo.GetHeroFleet()[0].SpotX = 2;
        MapWorldModel._prototypeHeroDemo.GetHeroFleet()[0].SpotY = 2;
    }
    private void AddArmyTactic() {
        new Tactic(MapWorldModel._prototypeHeroDemo.GetHeroFleet()[0], MapWorldModel._prototypeHeroDemo.GetHeroFleet()[1], true, false);
    }
}
