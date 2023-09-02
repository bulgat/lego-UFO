﻿using UnityEngine;
using System.Collections;
using RTS;
using Assets.Script.Global.View.fleetStrateg;
using UnityEditor;
using Assets.Script.Global;
using Assets.Script.strategChess;
//using RTS;


public class Fleet : TilePath, ITargetShoot
{

	public GameObject StrategShip;
	public GameObject Flag;
    public GameObject Pistol;
    public GameObject Bullet;
    public GameObject Target;

    public bool player;
	//public bool _showName;
	public string _nameObject="fleet strateg";
	public StateMoveFleet StateMove;
	public int SpotX { set; get; }
    public int SpotY { set; get; }
    public Animator _animatorMan;
    private float _scatter = 15;
    public bool Dead;

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
        Target.SetActive(false);

        // SetAnimation("gogo", 2, "gogo", 6);
  
    }
    public void SetParam(int id, bool player, string name, Vector2 Coordinate, int SpotX, int SpotY)
    {
        this.id = id;
        this.player = player;
        this.name = name + "_" + id;
        this.SetCoordinate(Coordinate);
        this.SpotX = SpotX;
        this.SpotY = SpotY;
    }
    public void VisibleTarget(bool Visible)
    {
        Target.SetActive(Visible);
    }
    public void RotationFleet(Point Target, float maxDegreesDelta)
    {
        var aimRotation = UnityEngine.Quaternion.LookRotation(new UnityEngine.Vector3(Target.X, 0, Target.Y) - new UnityEngine.Vector3(transform.position.x, 0, transform.position.z));
        transform.rotation = UnityEngine.Quaternion.RotateTowards(transform.rotation, aimRotation, maxDegreesDelta);
    }
    public void ParamAnimation(string position, int number, string positionHorse, int numberHorse)
    {
		if (_animatorMan != null)
		{

			_animatorMan.SetInteger(position, number);
		}

    }
    public void SetColorFleet()
	{
        Renderer renderer = GetComponent<Renderer>();
		if (renderer != null)
		{
			renderer.material.color = Color.yellow;
		}
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
    public void Shoot()
    {
        Quaternion constantAngle = Pistol.transform.rotation;
        Vector3 Angle = Pistol.transform.eulerAngles;
        Angle.x += Random.Range(-_scatter, _scatter);
        Angle.y += Random.Range(-_scatter, _scatter);
        Angle.z += Random.Range(-_scatter, _scatter);

        

        //Pistol.transform.rotation = Quaternion.AngleAxis(Random.Range(-60f, 60f), Vector3.forward);
        Pistol.transform.rotation = Quaternion.Euler(Angle);

        var bullet = Instantiate(Bullet, new Vector3( Pistol.transform.position.x+.5f, Pistol.transform.position.y, Pistol.transform.position.z), Quaternion.Euler(Angle));
        //bullet.transform.SetParent(Pistol.transform);

        // fleet.transform.position = new UnityEngine.Vector3(0,0,0);
        bullet.GetComponent<Rigidbody>().AddForce(Pistol.transform.forward * 25);

        Pistol.transform.rotation = constantAngle;




    
    }

    public void Damage()
    {
        Debug.Log("A  = " + name);
        Debug.Log(" Coordi  e =============   = "+gameObject);
        //throw new System.NotImplementedException();
        // Destroy(transform.parent);
        //Destroy(gameObject);
        //  Destroy(this);
        //Destroy(gameObject);
        this.Dead = true;
    }
    public void SetAnimation(string Anim)
    {
        if (this.Dead)
        {
            Debug.Log("!!!!!!!!!!!!! Dead  CommandPlayer  th PathLast.X  =  PathLast.   fleet id = ");
            ParamAnimation("gogo", 4, "gogo", 8);
            return;
        }
        if ("move"==Anim)
        {
            ParamAnimation("gogo", 2, "gogo", 6);
        }
        if ("attack" == Anim)
        {
            ParamAnimation("gogo", 3, "gogo", 7);
        }
    }
}
