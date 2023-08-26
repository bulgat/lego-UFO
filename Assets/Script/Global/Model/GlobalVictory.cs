using UnityEngine;
using System.Collections;

public class GlobalVictory  {

	// Глобальная победа.
	public static bool StrategVictoryPlayer(bool player) {
		//bool byPlayer = false;
		foreach (InfoFleet fleet in GlobalConf.GetViewFleetList()) {
			if (fleet.player==player) {
				return true;
			}
		}
		return false;
	}
}
