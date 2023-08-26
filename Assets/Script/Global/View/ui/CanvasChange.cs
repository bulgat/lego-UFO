using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using RTS;

public class CanvasChange : MonoBehaviour {
	public Text title;
	public Text nameLeft;
	public Text nameRight;
	public Image imageLeft;
	public Image imageRight;
	public Button leftButton;
	public Button rightButton;
	// Use this for initialization
	void Start () {
		leftButton.onClick.AddListener(() => leftButtonMethod());
		rightButton.onClick.AddListener(() => rightButtonMethod());
	}
	void leftButtonMethod () {
		
		EventListeren.eventDispatchEvent(CommandState.LeftChangeShipFleet.ToString(),"I.ToString()");
	}
	void rightButtonMethod () {
		
		EventListeren.eventDispatchEvent(CommandState.RightChangeShipFleet.ToString(),"I.ToString()");
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void moveShipRight () {
	}
	public void moveShipLeft () {
	}
}
