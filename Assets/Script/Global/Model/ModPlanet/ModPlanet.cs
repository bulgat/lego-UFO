using UnityEngine;
using System.Collections;
using RTS;
using SimpleJSON;

public class ModPlanet  {
	//static int left = 13;
	//static int right =6;
	static int _stopDescentBattle=0;
	public static InfoPlanet _planetLanding;
	public static InfoPlanet _planetGoto;

	public static InfoFleet _planetFleetAttack;


	public void bombPlanet (string isPower, string obj) {
		if (isPower == CommandState.BombPlanet.ToString ()) {

			var ar = JSONNode.Parse (obj);
			InfoPlanet planet = ModelGlobal.PlanetSelectCoordinate(int.Parse (ar ["x"]),int.Parse (ar ["y"]));
			//foreach (InfoPlanet planet in GlobalConf.planet_ar) {
			
			//if (planet.coordinate.x == int.Parse (ar ["x"]) && planet.coordinate.y == int.Parse (ar ["y"])) {

			
			if (Random.Range (0, 2) == 0) {
				destroyFactoryPlanet (planet);
			} else {
				destroyChooterPlanet (planet);
			}
			
			//}
			
			//}
		}
	}
	

	private void destroyFactoryPlanet (InfoPlanet planet) {
		if (planet.factory>0) {
			planet.factory--;
		}
		
	}
	private void destroyChooterPlanet (InfoPlanet planet) {
		if (planet.chooter>0) {
			planet.chooter--;
		}
	}
	public void PlanetLanding (string isPower, string obj) {
		if (isPower == CommandState.PlanetLanding.ToString ()) {
			var ar = JSONNode.Parse (obj);
			_stopDescentBattle =0;
			_planetLanding = ModelGlobal.PlanetSelectCoordinate(int.Parse (ar ["x"]),int.Parse (ar ["y"]));
			_planetLanding.player = true;
			//_planetFleetAttack = ModelGlobal.getFleetId (int.Parse (ar ["id"]));

		}
	}
	public void GotoPlanet (string isPower, string obj) {
		if (isPower == CommandState.GotoPlanet.ToString ()) {

			var ar = JSONNode.Parse (obj);
			_planetGoto = ModelGlobal.PlanetSelectCoordinate(int.Parse (ar ["x"]),int.Parse (ar ["y"]));
			Debug.Log("__planetGoto___________"+_planetGoto);
		}
	}


	public static Vector2 DrawDescentBattle() {
		return new Vector2(_planetLanding.chooter,ModelGlobal.getFleetTransport (_planetFleetAttack));
	}
	
	public static int StopDescentBattle() {

		
		return _stopDescentBattle;
	}
	public void planetChooterBattle(string isPower, string obj) {
		if (isPower == CommandState.PlanetChooter.ToString ()) {
			/*
			int impact = Random.Range (0, 2);

			if (impact==0) {
				_planetLanding.chooter--;
				
			} else {
				//_planetFleetAttack.chooter --;
				ModelGlobal.destroyFirstFleetTransport (_planetFleetAttack);

				//right--;
			}
			Debug.Log (_planetLanding.chooter+" Clicked  = "+ModelGlobal.getFleetTransport (_planetFleetAttack));
			if (_planetLanding.chooter <= 0) {

				_stopDescentBattle=1;
				_planetLanding.player = _planetFleetAttack.player;
				_planetLanding.chooter = ModelGlobal.getFleetTransport (_planetFleetAttack);
				ModelGlobal.destroyAllFleetTransport (_planetFleetAttack);
				ModelGlobal.ResetAttackPlanet ();
			}

			if (ModelGlobal.getFleetTransport (_planetFleetAttack) <= 0) 
			{

				_stopDescentBattle=2;
				ModelGlobal.ResetAttackPlanet ();
				
			}
			*/
			// Просто захватить без боя.

			_stopDescentBattle=1;
			_planetLanding.player = _planetFleetAttack.player;
			//ModelGlobal.ResetAttackPlanet ();


		}
		
	}

}
