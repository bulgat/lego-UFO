using UnityEngine;
using System.Collections;
using RTS;
using SimpleJSON;
using System.Collections.Generic;

public class ChangeHeroShip {



	public static void searchPlayer (string isPower,string obj) {
		if (isPower == CommandState.ClickFleet.ToString ()) {
			var ar = JSONNode.Parse(obj);
			InfoFleet selectFleet = ModelGlobal.getFleetId (int.Parse (ar["id"]));

			List<InfoFleet> fleet_ar = getFleedArray ((int)selectFleet.coordinate.x,(int)selectFleet.coordinate.y);
			if ( fleet_ar.Count>1) {
				ModelGlobal._clickFleetChangeHero = new Vector2 ((float)fleet_ar[0].id,(float)fleet_ar[1].id);;
				Debug.Log ("searchPlayer  TRUE");
				ModelGlobal._RightChangeShip = fleet_ar [1].ship_ar;
			} else {
				ModelGlobal._clickFleetChangeHero=Vector2.zero;
				Debug.Log ("searchPlayer  FALSE");
			}

			ModelGlobal._LeftChangeShip = selectFleet.ship_ar;
			//getFleedAbovePlanet (int x,int y);


		}
	}
	public static List<InfoFleet> getFleedArray (int x,int y) {
		List<InfoFleet> fleet_ar = new List<InfoFleet> ();

		foreach (InfoFleet fleet in GlobalConf.GetViewFleetList()) {
			if(fleet.coordinate.x==x&&fleet.coordinate.y==y)
			{
				fleet_ar.Add(fleet);
				//return fleet_ar;
			}
		}
		return fleet_ar;
	}
	public static void LeftChangeShipFleet(string isPower,string obj) {
		if (isPower == CommandState.LeftChangeShipFleet.ToString ()) {
			
			ModelGlobal._RightChangeShip.Add (ModelGlobal._LeftChangeShip[ModelGlobal._LeftChangeShip.Count-1]);
			ModelGlobal._LeftChangeShip.Remove (ModelGlobal._LeftChangeShip[ModelGlobal._LeftChangeShip.Count-1]);
			//ModelGlobal._RightChangeShip
		}
	}
	public static void RightChangeShipFleet(string isPower,string obj) {
		if (isPower == CommandState.RightChangeShipFleet.ToString ()) {
			ModelGlobal._LeftChangeShip.Add (ModelGlobal._RightChangeShip[ModelGlobal._RightChangeShip.Count-1]);
			ModelGlobal._RightChangeShip.Remove (ModelGlobal._RightChangeShip[ModelGlobal._RightChangeShip.Count-1]);

		}
	}
}
