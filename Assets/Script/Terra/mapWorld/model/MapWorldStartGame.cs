using System.Collections;
using System.Collections.Generic;
using ZedAngular.Model.Terra.scenario;

public class MapWorldStartGame 
{
	public void StartGameFirstReset(VictoryStipulation VictoryScenario, IGridScenario gridScenario, BattlePlanetModel battlePlanetModel)
	{
        System.Diagnostics.Debug.WriteLine("01 isla = ");
        VictoryScenario.Scenario = gridScenario;
        VictoryScenario.Scenario.Init(battlePlanetModel);

	}
	public bool StartGameChange(VictoryStipulation VictoryScenario,BattlePlanetModel battlePlanetModel)
	{

		if (VictoryScenario.Dual)
		{
            // hak
            battlePlanetModel.VictoryScenario.ScenarioNumber = 0;
			VictoryScenario.Scenario = new FactoryScenario().GetFactoryScenario(0);
			VictoryScenario.Scenario.Init(battlePlanetModel);
            battlePlanetModel.VictoryScenario.Dual = false;
			VictoryScenario.ReturnStart = true;
		
			MapWorldModel.MapWorldModelSingleton().SetStateGame(MainFormat.VICTORY_WIN);
			return false;
		}
		if (VictoryScenario.ScenarioNumber == 0)
		{
            BattlePlanetModel._initGlobalParams = new InitGlobalParams(battlePlanetModel);
            StartGameFirstReset(VictoryScenario, new FactoryScenario().GetFactoryScenario(0), battlePlanetModel);

		}
		if (VictoryScenario.ScenarioNumber == 1)
		{
            StartGameFirstReset(VictoryScenario, new FactoryScenario().GetFactoryScenario(1), battlePlanetModel);

		}
		if (VictoryScenario.ScenarioNumber == 2)
		{
            StartGameFirstReset(VictoryScenario, new FactoryScenario().GetFactoryScenario(2), battlePlanetModel);

		}
		if (VictoryScenario.ScenarioNumber == 3)
		{
            StartGameFirstReset(VictoryScenario, new FactoryScenario().GetFactoryScenario(3), battlePlanetModel);

		}

		// default
		if (VictoryScenario.ScenarioNumber > 3)
		{

			StartGameFirstReset(VictoryScenario, new FactoryScenario().GetFactoryScenario(4), battlePlanetModel);

			return true;
		}
		else
		{
			VictoryScenario.ReturnStart = false;
		}

		return false;
	}

	public void StartGameDual(VictoryStipulation VictoryScenario,BattlePlanetModel battlePlanetModel)
	{

		VictoryScenario.ScenarioNumber = 3;
		VictoryScenario.Dual = true;

		VictoryScenario.Scenario = new FactoryScenario().GetFactoryScenario(3);
		VictoryScenario.Scenario.Init(battlePlanetModel);

        battlePlanetModel.GetDispositionCountryList()[2].PlayerControl = true;

	}
}
