using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InfoPlanet {
	
	public string name = "planet";
	public Vector2 coordinate;
	public bool player;
	public int id;
	public int factory;
	public int chooter;
	public string nameRegion = "Империя";
	
	public InfoPlanet(string _name, Vector2 _coordinate){
		name = _name;
		coordinate = _coordinate;

		
	}
	
	
}
