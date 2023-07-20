using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board {
    private int widthMap = 8;
    private int heightMap= 8;
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

	void Awake() {

		CreateBoard ();

	}
	/// <summary>
	/// Creates the board. Создание карты. Init.
	/// </summary>
	public void CreateBoard() {

		board = new Vector3[widthMap,heightMap];
		int k = 0;
		for (int i = 0; i < heightMap; i++) {
			for (int j = 0; j < widthMap; j++) {


				Vector3 c = new Vector3(j,i,miniBoard[k]);
				board [j, i] = c;

				k++;
			}

		}
        
    }
    /// <summary>
    /// Раставление оперативных препятствий, свои юниты, минные поля и всякая другая дребедень.
    /// </summary>
    public void operativeObstacle()
    {

    }

    public List<Vector3> FindPath(Vector3 origin, Vector3 goal) {
		//CreateBoard ();
		
		AStar pathFinder = new AStar();
		pathFinder.FindPath (origin, goal, board, false);
		return pathFinder.CellsFromPath ();
	}
}