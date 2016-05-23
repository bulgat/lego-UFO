using UnityEngine;
using System.Collections;

public class Cell  {
	public Vector2 coordinates {get; set;}
	public bool walk {get; set;}
	public virtual bool IsWalkable() {
		return walk;
	}
	public virtual float MovementCost() {
		return 0;
	}
}
public class miniCell : MonoBehaviour {

	public Vector2 coordinates {get; set;}
	public bool walk {get; set;}

	public miniCell (int x, int y, bool inWalk) {
		coordinates = new Vector2 (x,y);
		walk = inWalk;
	}
	public virtual bool IsWalkable() {
		return walk;
	}
	public virtual float MovementCost() {
		return 0;
	}
}