using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board {
	//private int width = 5;
	//private int height= 5;
	public GameObject cellPrefab;
	Vector3 [,]board;

	int [] miniBoard = new int [] {
		0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,

		0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,
	};

	//Vector3 mCell = new Vector3(0,0,1);

	void Awake() {

		CreateBoard ();

	}
	/// <summary>
	/// Creates the board. Создание карты.
	/// </summary>
	void CreateBoard() {
		//board = new Cell[width,height];
		board = new Vector3[GlobalConf.widthMap,GlobalConf.heightMap];
		int k = 0;
		for (int i = 0; i < GlobalConf.heightMap; i++) {
			for (int j = 0; j < GlobalConf.widthMap; j++) {


				Vector3 c = new Vector3(j,i,miniBoard[k]);
				board [j, i] = c;


				//c.IsWalkable = false;
				k++;
			}

		}
	
	}
	
	public List<Vector3> FindPath(Vector3 origin, Vector3 goal) {
		CreateBoard ();
		Debug.Log (origin.x+","+origin.y+" FindPath   "+goal.x+","+goal.y);
		AStar pathFinder = new AStar();
		pathFinder.FindPath (origin, goal, board, false);
		return pathFinder.CellsFromPath ();
	}
}