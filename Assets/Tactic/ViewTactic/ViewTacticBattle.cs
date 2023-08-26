using UnityEngine;
using System.Collections;
using RTS;
using UnityEngine.UI;
using System.Collections.Generic;
using SimpleJSON;

public class ViewTacticBattle : MonoBehaviour {

	//public GameObject BattleInterface;
	//private GameObject _BattleInterface;
	//public GameObject moveCursor;

	public Image BattleInterfaceImageHero;

	// Use this for initialization
	void Start () {
		EventListeren.eventListerenEvent += on_start_battle;
		EventListeren.eventListerenEvent += off_start_battle;
	}
	// Событие Сражение между игроками
	private void on_start_battle(string isPower, string obj) {
		if (isPower == CommandState.BattleInterface.ToString ()) {
			var ar = JSONNode.Parse(obj);	
			int idFleet = int.Parse (ar[CommandSend.fleetOne.ToString()]);
			//try
			//{
				//GameObject wButton = Instantiate(BattleInterface) as GameObject;
				//_BattleInterface = wButton;
				//UIBattleTactic[] lenL = wButton.GetComponentsInChildren<UIBattleTactic>();

			//if (lenL == null || lenL.Length == 0)
			//{
			///	lenL[0].BattleInterfaceImageHero.sprite = ViewGlobal.selViewGlobal.imageHero[ModelGlobal.getFleetId(idFleet).imageId];
			//	lenL[0].BattleInterfaceNameHero.text = ModelGlobal.getFleetId(ModelGlobal.getFleetId(idFleet).imageId).nameHero;
			//}
			//} catch
			//{
			//	Debug.LogWarning("Error on_start_battle");
			//}
		}

	}
	private void off_start_battle(string isPower, string obj) {
		if (isPower == CommandState.EndAttackShip.ToString ()) {
			//Destroy(_BattleInterface);
			// вернуть cursor.
			Cursor.visible = true; 
		}
	}
	// Update is called once per frame
	void Update () {
		if (ResourceManager.tacticMap) {
			//BattleInterface.d

		}
	}
}
