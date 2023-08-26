using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIButton : MonoBehaviour {

	private Button _button;
	
	// Use this for initialization
	void Start () {
		_button = GetComponent<Button>();
	}

	public void visButton(int vis) {
		foreach (var r in _button.GetComponentsInChildren<CanvasRenderer>())
		{
			r.SetAlpha (vis);
			//print ("//////////break = false" );
		}
	}
}
