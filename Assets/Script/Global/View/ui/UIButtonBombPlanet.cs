using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using RTS;

public class UIButtonBombPlanet : UIButton {

	//Button _button;

	// Use this for initialization
	//void Start () {
	//	_button = GetComponent<Button>();
	//}
	
	// Update is called once per frame
	void Update () {

		if (ViewGlobal.viewBombButton) {
			//_button.enabled = true;
			//_button.GetComponentInChildren<CanvasRenderer> ().SetAlpha (1);


			visButton(1);
		} else {
			//_button.enabled = false;
			//_button.GetComponentInChildren<CanvasRenderer> ().SetAlpha (0);
			//_button.GetComponentsInParent<CanvasRenderer>().SetAlpha(0);
			//_button.
			//
			visButton(0);

		}

	}


	public void clickBombPlanet() {

		Debug.Log ("Clicked Bomb planet");
		var I = new JSONClass();
		I["x"] =ViewGlobal._selectFleet.coordinate.x.ToString();
		I["y"] =ViewGlobal._selectFleet.coordinate.y.ToString();
		I["id"] =ViewGlobal._selectFleet.id.ToString();
		EventListeren.eventDispatchEvent(CommandState.BombPlanet.ToString(),I.ToString());
		ViewGlobal._selectFleet.useBomb=true;
		ViewGlobal.viewBombButton = false;
	}
}
