using UnityEngine;
using System.Collections;
using RTS;
using Assets.Script.Global.View.fleetStrateg;
using UnityEditor;
//using RTS;


public class Fleet : TilePath {

	public GameObject StrategShip;
	public GameObject Flag;

	//public string name;
	public bool player;
	//public bool _showName;
	public string _nameObject="fleet strateg";
	public StateMoveFleet StateMove;
	public int SpotX { set; get; }
    public int SpotY { set; get; }
    public Animator _animatorMan;

    public void SetParam(int id,bool player,string name, Vector2 Coordinate,int SpotX, int SpotY)
	{
		this.id = id;
		this.player = player;
		this.name = name;
		this.SetCoordinate(Coordinate);
		this.SpotX = SpotX;
		this.SpotY = SpotY;
	}

    void Start () {
        if (Flag != null)
        {
            Renderer myRenderer = Flag.GetComponent<Renderer>();
            if (myRenderer != null)
            {
                if (!player)
                {


                    myRenderer.material.color = Color.red;
 

                    Vector3 targetAngles = transform.eulerAngles + 180f * Vector3.up;
                    transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 1);
                }
                else
                {
                    myRenderer.material.color = Color.blue;
                }
            }
        }
		
        _animatorMan = transform.GetChild(1).GetComponent<Animator>();
        Debug.Log(" Coordinate ===============    " + transform.GetChild(1) + " Cl = " );
        Debug.Log("c  fleet = "+ _animatorMan);
        SetAnimation("gogo", 2, "gogo", 6);
    }
    public void SetAnimation(string position, int number, string positionHorse, int numberHorse)
    {
		if (_animatorMan != null)
		{

			_animatorMan.SetInteger(position, number);
		}

    }
    public void SetColorFleet()
	{
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.yellow;
    }


	void Update ()
	{

			//if (GetStateMove())
			//{
			//	transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.y);
			//}
	
	}
    public void ResetStateMove()
	{
		this.StateMove = null;

    }

    public bool  GetStateMove()
	{
		if (this.StateMove != null)
		{
			return this.StateMove.Move;
		}
		return false;
    }
    public StateMoveFleet GetState()
	{
        if (this.StateMove != null)
        {
            return this.StateMove;
        }
		return null;
    }
	/*
	void OnGUI()
	{
		if (_showName) {
			if (!ResourceManager.tacticMap) {
				Vector3 screenPosition = Camera.main.WorldToScreenPoint (gameObject.transform.position);
		
				Vector3 cameraRelative = Camera.main.transform.InverseTransformPoint (transform.position);
				if (cameraRelative.z > 0) {
					Rect rect = new Rect (screenPosition.x - 60f, Screen.height - screenPosition.y - 10f, 120f, 20f);
					// считаем позицию

					// создаем стиль с выравниванием по центру
					GUIStyle label = new GUIStyle (GUI.skin.label);
					label.alignment = TextAnchor.MiddleCenter;

					GUI.Label (rect, name, label);
				}
			}
		}
		
		
		
	}
	*/

}
