using System.Collections;
using System.Collections.Generic;

public class MapWorldStartGame 
{
	public static void StartGameFirstReset(VictoryStipulation VictoryScenario)
	{
		BattlePlanetModel._initGlobalParams = new InitGlobalParams();
		VictoryScenario.Scenario = new GridScenario();

		VictoryScenario.Scenario.Init();

	}
	public static bool StartGameChange(VictoryStipulation VictoryScenario)
	{

		if (VictoryScenario.Dual)
		{
			// hak
			BattlePlanetModel.VictoryScenario.ScenarioNumber = 0;
			VictoryScenario.Scenario = new GridScenario();
			VictoryScenario.Scenario.Init();
			BattlePlanetModel.VictoryScenario.Dual = false;
			VictoryScenario.ReturnStart = true;
			////Main._victoryWin.SetVictoryImage(GraficBibleConstant.VictoryWin);
			//Main.stateGame = MainFormat.VICTORY_WIN;
			MapWorldModel.SetStateGame(MainFormat.VICTORY_WIN);
			return false;
		}
		if (VictoryScenario.ScenarioNumber == 0)
		{
			StartGameFirstReset(VictoryScenario);
			//VictoryScenario.Scenario = new GridScenario();
			//VictoryScenario.Scenario.Init();
		}
		if (VictoryScenario.ScenarioNumber == 1)
		{
			VictoryScenario.Scenario = new GridScenario1();
			VictoryScenario.Scenario.Init();
		}
		if (VictoryScenario.ScenarioNumber == 2)
		{
			VictoryScenario.Scenario = new GridScenario2();
			VictoryScenario.Scenario.Init();
		}
		if (VictoryScenario.ScenarioNumber == 3)
		{
			VictoryScenario.Scenario = new GridScenario3();
			VictoryScenario.Scenario.Init();
		}

		// default
		if (VictoryScenario.ScenarioNumber > 3)
		{

			StartGameFirstReset(VictoryScenario);

			return true;
		}
		else
		{
			VictoryScenario.ReturnStart = false;
		}

		return false;
	}
	public static void StartGameDual(VictoryStipulation VictoryScenario)
	{

		VictoryScenario.ScenarioNumber = 3;
		VictoryScenario.Dual = true;

		VictoryScenario.Scenario = new GridScenario3();
		VictoryScenario.Scenario.Init();

		BattlePlanetModel.DispositionCountry_ar[2].PlayerControl = true;

	}
}
