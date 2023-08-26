using UnityEngine;
using System.Collections;

public class UIButtonDesant : UIButton {


	
	// Update is called once per frame
	void Update () {
		if (ViewGlobal.viewBombButton) {

			visButton(1);
		} else {

			visButton(0);
			
		}
	}
	public void clickLandingPlanet() {
		ViewGlobal._selectFleet.useLand=true;
		ViewGlobal._selectFleet.useBomb=true;
		ViewGlobal.viewBombButton = false;

		ViewGlobal._selectPlanet = ModelGlobal.getFleedAbovePlanet ((int)ViewGlobal._selectFleet.coordinate.x,(int)ViewGlobal._selectFleet.coordinate.y);
		ViewGlobal.attackPlanet(ViewGlobal._selectFleet,ViewGlobal._selectPlanet);
	}
}
