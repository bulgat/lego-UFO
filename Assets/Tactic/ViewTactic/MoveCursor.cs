using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0,-1,0)*0.5f*Time.deltaTime);
	}
}
