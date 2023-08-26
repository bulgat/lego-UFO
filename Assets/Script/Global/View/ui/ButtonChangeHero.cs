using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonChangeHero : UIButton {

	public Transform contentPanel;
	//public GameObject standartPanel;

	public GameObject _canvasChange;

	public GameObject _ImagePanelScroll;

	// Update is called once per frame
	void Update () {
		if (ViewGlobal.clickFleetChangeHero != Vector2.zero) {
			
			visButton(1);
		} else {
			
			visButton(0);
			
		}

	}
	public void clickFleetChangeHero() {
		
		GameObject wButton = Instantiate (ViewGlobal._ViewGlobalModel.standartPanel) as GameObject;
		StartStandartPanel panel = ViewGlobal._ViewGlobalModel.standartPanel.GetComponent <StartStandartPanel> ();
		panel._title = "Обмен кораблями между героями";


		GameObject tonn = Instantiate (_canvasChange) as GameObject;
		CanvasChange tonnS = tonn.GetComponent<CanvasChange>();

        

        tonnS.title.text ="-обмен";

		tonnS.imageLeft.sprite = ViewGlobal.selViewGlobal.imageHero [ModelGlobal.getFleetId((int)ViewGlobal.clickFleetChangeHero.x).imageId];
		tonnS.imageRight.sprite = ViewGlobal.selViewGlobal.imageHero [ModelGlobal.getFleetId((int)ViewGlobal.clickFleetChangeHero.y).imageId];
		tonnS.nameLeft.text = ModelGlobal.getFleetId((int)ViewGlobal.clickFleetChangeHero.x).nameHero;
		tonnS.nameRight.text = ModelGlobal.getFleetId((int)ViewGlobal.clickFleetChangeHero.y).nameHero;

		tonn.transform.position = new Vector3(Screen.width/2,Screen.height/2,0);

        //wButton.transform.SetParent(tonn.transform.parent);
        //tonn.transform.localScale += new Vector3 (1,1,0);

		/////////// list button

		GameObject listBut = Instantiate (_ImagePanelScroll) as GameObject;

		

		listBut.transform.position = new Vector3(-253,-129,0);

        tonnS.transform.SetParent(listBut.transform.parent);
        listBut.transform.localScale = new Vector3 (1,1,0);


		// right
		GameObject listButR = Instantiate (_ImagePanelScroll) as GameObject;
		listButR.transform.position = new Vector3(97,-129,0);

        tonnS.transform.SetParent(listButR.transform.parent);
        listButR.transform.localScale = new Vector3 (1,1,0);

		// search ship
		var lenL = listBut.GetComponentsInChildren<UIScrollPanel> ();
		var lenR = listButR.GetComponentsInChildren<UIScrollPanel> ();


		lenL [0].init (ModelGlobal._LeftChangeShip, true);
		lenR [0].init (ModelGlobal._RightChangeShip, true);

        //
         tonn.transform.SetParent(wButton.transform);
        //
    }
}
