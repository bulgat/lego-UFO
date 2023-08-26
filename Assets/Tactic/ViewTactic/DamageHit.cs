using UnityEngine;
using System.Collections;
using RTS;


public class DamageHit : MonoBehaviour {

	protected GUIStyle damageStyle = new GUIStyle();
	public string _damageLabel = "##";

	protected virtual void Awake() {
		damageStyle.normal.textColor = Color.green;
		damageStyle.alignment = TextAnchor.MiddleCenter;
		damageStyle.fontStyle = FontStyle.Bold;
	}
	// Use this for initialization
	void Start () {

		Destroy(gameObject, 3);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0,5.5f,0)*0.5f*Time.deltaTime);
	}
	protected virtual void OnGUI() {
		if (ResourceManager.tacticMap) {
		
		
			Vector3 screenPosition = Camera.main.WorldToScreenPoint (gameObject.transform.position);

			Vector3 cameraRelative = Camera.main.transform.InverseTransformPoint (transform.position);
			if (cameraRelative.z > 0) {
				Rect rect = new Rect (screenPosition.x - 60f, Screen.height - screenPosition.y - 10f, 120f, 20f);
				// считаем позицию
				//Rect rect = new Rect(this.transform.position.x, this.transform.position.y, 120f, 20f);


				// создаем стиль с выравниванием по центру
				//GUIStyle label = new GUIStyle (GUI.skin.label);


				GUI.Label (rect, _damageLabel, damageStyle);
			}
		}


	}
}
