using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InfoFleet {
	public string name = "fleet";
	public Vector2 coordinate;
	public bool player;

	// Ид флота.
	public int id = 0;
	public int countTurn = 1;
	public List<NewUnit> ship_ar;
	public int imageId;
	public string nameHero;
	public bool useBomb=false;
	public bool useLand=false;

	public string nameRegion = "Империя";
	public int SpotX { get; set; }
    public int SpotY { get; set; }

    public InfoFleet(string _name, Vector2 _coordinate, bool _player, int _id, List<NewUnit> _ship_ar,string _nameHero,int _imageId, int spotX, int spotY){
		name = _name;
		coordinate = _coordinate;

		player = _player;
		if (_player) {
			nameRegion = "Повстанцы";
		}
		// Ид флота.
		id = _id;
		ship_ar = _ship_ar;
		this.nameHero = _nameHero;
		this.imageId = _imageId;
		this.SpotX = spotX;
		this.SpotY = spotY;
	}
	
}