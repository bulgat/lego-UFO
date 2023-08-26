using UnityEngine;
using System.Collections;
using RTS;
using SimpleJSON;
using Assets.Script.strategChess;
using System.Collections.Generic;
using System.Reflection;

public class TilePath : MonoBehaviour {

	private Vector2 coordinat {get; set;}
	public int id=0;

    PathMove _PathMove;
    public Vector2 GetCoordinate()
    {
        return coordinat;
    }
    public void SetCoordinate(Vector2 Coordinate)
    {
        
        this.coordinat = Coordinate;
    }
    public void SetParam(int Id, PathMove pathMove)
    {

        this.id = Id;
        this._PathMove = pathMove;
    }

    void OnMouseDown()
    {
        Debug.Log("TilePath   OnMouseDown  "+ this._PathMove);

        RusticEventTile.Send(this._PathMove);
    }
}
