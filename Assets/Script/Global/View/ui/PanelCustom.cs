using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelCustom : MonoBehaviour {

	public GameObject _ImagePanelScroll;
	public GameObject _Canvas;

	private static UIScrollPanel[] _list;

	// Use this for initialization
	void Start () {
		GameObject tonn = Instantiate (_ImagePanelScroll) as GameObject;

		tonn.transform.position = new Vector3(Screen.width-75,Screen.height/2-193,0);

        _Canvas.transform.SetParent(tonn.transform.parent);
        _list = tonn.GetComponentsInChildren<UIScrollPanel> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (_list!=null) {
			if (ViewGlobal._selectFleet != null) {
				_list [0].init (ViewGlobal._selectFleet.ship_ar);
			}
		}
	}
}
