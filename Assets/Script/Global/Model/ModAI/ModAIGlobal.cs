using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using RTS;

public class ModAIGlobal {

	public static int aimShipId;
	
	public Vector2 AI_strateg (Vector2 isPower, Vector2 aim) {
		
		Board board = new Board ();
		List<Vector3> path_ar = board.FindPath (new Vector3 (isPower.x, isPower.y, 0), new Vector3 (aim.x, aim.y, 0));
		if (path_ar.Count > 0) {
			return new Vector2(path_ar[0].x,path_ar[0].y);
		}
		
		return new Vector2(-1,-1);
	}
	
	public static Vector2 getAimFiend() {
		foreach (InfoFleet fleet in GlobalConf.GetViewFleetList()) {
			if (fleet.coordinate != new Vector2 (-1, -1)) {
				if (fleet.player) {
					aimShipId=fleet.id;
					return fleet.coordinate;
				}
			}
			
		}
		return new Vector2 (-1, -1);
	}
	/*
	public static void commandshipPlayer (string isPower,string obj) {
		if (isPower == CommandState.ClickTile.ToString ()) {

           

            var ar = JSONNode.Parse(obj);

			int id = int.Parse(ar["id"]);
			int x = int.Parse(ar["x"]);
			int y = int.Parse(ar["y"]);



            foreach (InfoFleet fleet in GlobalConf.GetViewFleetList()) {
				
				
				if (fleet.player) {
					if (fleet.id == id) {
						fleet.coordinate = new Vector2 (x, y);
						fleet.countTurn = 0;
 Debug.Log("id = "+id+"  Level "+x+"  Pow = ClickTile  "+y);

						//c.coordinat = new Vector2(x,y);
					}
				}
				
			}
		}
	}
	*/
}
