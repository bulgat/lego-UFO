using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StartStandartPanel : MonoBehaviour {

	public Text title;
	public string _title;
    public Button CloseButton;

    void Update () {

		title.text = _title;
	}

}
