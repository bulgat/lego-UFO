using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RTS;
//using UnityEngine.UI;

public class UIScrollPanel : MonoBehaviour {

	public string kol="EEEEEEEEEEEEE";

	public GameObject sampleButton;
	
	
	public List<Sprite> image_ar;
	public Transform contentPanel;

	//public static bool singleton;
	private List<NewUnit> _itemList;
	private bool _transform = false;

	// Use this for initialization
	public void init (List<NewUnit> itemList,bool transform = false) {
		_itemList = itemList;
		_transform = transform;
	}
	private void CreateListStart () {
		//Debug.Log("0$$$script=  CreateListStart = "+_itemList);

		if (_itemList!=null) {
			int count = 0;
			foreach (var item in _itemList) {
				GameObject newButton = Instantiate (sampleButton) as GameObject;
				SampleButton button = newButton.GetComponent <SampleButton> ();
				button.title.text =item.objectName+"-"+count;
				button.description.text =item.typeShip;
				button.icon.sprite = image_ar[item.typeShipId];
				newButton.tag = "Sbutton";
				newButton.transform.SetParent (contentPanel);
				count++;
				if (_transform) {
					button.transform.localScale = new Vector3 (1, 1, 0);
				}
			}
			//_itemList = itemList;
		}
	}
	// Удаляем все кнопки.
	public void removeListStart () {
		//EventListeren.eventDispatchEvent(CommandState.BlockScroll.ToString(),"");


		//GameObject[] n_ar = GameObject.FindGameObjectsWithTag ("Sbutton");

		//var tton_ar = contentPanel.transform.GetComponentsInChildren<SampleButton>(true);
		var tton_ar = contentPanel.transform.GetComponentsInChildren<Transform>(true);


		foreach (Transform k in tton_ar) {

			if (k.gameObject.name == "SampleButton(Clone)") {
				Destroy (k.gameObject);
			}
		}

		// Рабочий код, сохраним как образец.
		/*
		GameObject[] button_ar = GameObject.FindGameObjectsWithTag ("Sbutton");
		foreach (GameObject button in button_ar) {
			Destroy (button);

		}
		*/
	}

	// Update is called once per frame
	void Update () {
		if (ViewGlobal._selectFleet!=null) {
            /*
			removeListStart ();
		
			CreateListStart ();
		*/

		}
	}
}
