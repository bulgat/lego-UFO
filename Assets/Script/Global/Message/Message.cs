using UnityEngine;
using System.Collections;

public class Message : MonoBehaviour {

	//private static bool viewMessageClick=false;
	private static string  MessageSend="";
	public GUISkin messageSkin;

	private int MWidth = 500;
	private int Mheight = 150;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	} 
    
	
	public void DrawPlanet() {


		
		GUI.skin = messageSkin;
		GUI.BeginGroup(new Rect(0,0,Screen.width,Screen.height));

		GUI.Box(new Rect(0+MWidth/4,Mheight,MWidth,Mheight),MessageSend);

		if (GUI.Button (new Rect (0 + MWidth, Mheight+80, 80, 40), "Close")) {
			//viewMessageClick = false;
		}
	
		GUI.EndGroup();
		
	}

}
