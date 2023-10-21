using System.Collections;
using System.Collections.Generic;


public class MockGlobalPlanet
{

    private void AddArmyTown()
    {
        BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet()[0].SpotX = 2;
        BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet()[0].SpotY = 2;
    }
    private void AddArmyTactic() {
        new Tactic(BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet()[0], BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet()[1], true, false);
    }
}
