using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIImageHero : MonoBehaviour {

	Image _image;
	public List<Sprite> image_ar;
	//public Sprite test;

	// Use this for initialization
	void Start () {
		_image = GetComponent<Image>();
	}

	// Update is called once per frame
	void Update () {
		if (ViewGlobal.selectNameId != -1) {
			_image.enabled = true;
			_image.sprite = image_ar [ViewGlobal.selectNameId];
		} else {
			_image.enabled = false;
		}
	}
}
