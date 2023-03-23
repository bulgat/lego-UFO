using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Unit  {

	private bool Idle = true;

	// Движение персонажа.
	private bool Moving = false;

	private bool Dead = false;

    private int factX = 1;
    private int factY = 1;
    private int tileX = 1;
    private int tileY = 1;
    private int tileWidth = 100;

    // Скорость перемещения.
    private int stepUnit = 2;
    
    private int _destinationTileX = 1;
    private int _destinationTileY = 1;


    private int _life = 100;
    private Scene _scene;
    
    private int _id;
    private int _type;
    private Dictionary<string, int> _params = new Dictionary<string, int>();

    public string _animatorMan;

    // Фракция.
    public bool _fiend = false;

    
    // Use this for initialization
    public void Start () {
        //_board = new Board();
        _scene = Scene.scene;
    }

	public void OnInit (int newX, int newY, bool fiend) {
        _scene = Scene.scene;
        tileX = newX;
        tileY = newY;
        _fiend = fiend;
}

	// Update is called once per frame
	public void Update () {
        
        if (Idle) {
			OnThink ();
			return;
		}
		if (Moving) {
            OnMoving ();
			return;
		}
		if (Dead) {
			OnDie ();
			return;
		}
	}

	void MoveToTile() {
		Moving = true;
	}
	void OnThink() {

        // Мы атакуем противника.
        if (!_fiend) {

            // Кого бы атаковать? Атакуем ближайшего.
            Unit enemy = _scene.FindNearestEnemyUnit(this);
            if (enemy != null) {
               

                // Достижима - ли цель?
                if (CanMoveToTile(enemy.GetTileX(), enemy.GetTileY())) {
                   
                    // Идем на нее.
                    MoveToTile(enemy.GetTileX(), enemy.GetTileY());
                }

            }
        }
        

    }
	void OnMoving(){
       if (_destinationTileX > tileX && _destinationTileY == tileY)
        {
            factX+= stepUnit;  
        }
        if (_destinationTileX < tileX && _destinationTileY == tileY)
        {
            factX-= stepUnit;
        }
        if (_destinationTileX == tileX && _destinationTileY > tileY)
        {
            factY+= stepUnit;
        }
        if (_destinationTileX == tileX && _destinationTileY < tileY)
        {
            factY-= stepUnit;
        }

        // Если дошли до сереидины тайла. Начинаем думать.
        if (tileWidth< Math.Abs(factX) || tileWidth < Math.Abs(factY)) {
            tileX = _destinationTileX;
            tileY = _destinationTileY;
            factX = 0;
            factY = 0;
            Moving = false;
            Idle = true;
            
        }
        
    }
	void OnDie(){
        // Destroy.
        //Destroy(gameObject);
        _scene.destroyUnit(this);
    }
    ///
    public int GetX() {
        return factX;
    }
    public int GetY()
    {
        return factY;
    }
    public int GetTileX()
    {
        return tileX;
    }
    public int GetTileY()
    {
        return tileY;
    }
    public bool MoveToTile(int targetTileX,int targetTileY) {
       
        // Находим путь.
        List<Vector3> path_ar = _scene.sceneTile.FindPath(new Vector3(tileX, tileY,0),new Vector3(targetTileX, targetTileY,0));
        
        if (path_ar.Count > 0) {

            // Проверка, есть ли там юнит?
            if (UnVacantSpace((int)path_ar[0].x, (int)path_ar[0].y)) {
                
                // Увы, тут занято.
                return false;
            }

            
            // Один шаг в сторону противника, без пересечения вдоль клеток.
            _destinationTileX = (int)path_ar[0].x;
            _destinationTileY = (int)path_ar[0].y;
            Moving = true;
            Idle = false;
            
            return true;
        }
        return false;
    }

    // Проверка, есть ли там юнит?
    private bool UnVacantSpace(int tileX, int tileY)
    {
   
        List<Unit> unit_ar = _scene.GetAllUnit();
        foreach (Unit un in unit_ar)
        {
            
            if (un.GetTileX() == tileX && un.GetTileY()==tileY)
            {

                // Увы, тут занято.
                return true;
            }
        }
        return false;
    }


    public bool CanMoveToTile(int targetTileX, int targetTileY) {

        

        // Находим путь.
        List<Vector3> path_ar = _scene.sceneTile.FindPath(new Vector3(tileX, tileY, 0), new Vector3(targetTileX, targetTileY, 0));

        

        if (path_ar.Count > 0)
        {
            

            // Проверка, есть ли там юнит?
            if (UnVacantSpace((int)path_ar[0].x, (int)path_ar[0].y))
            {
                
                return false;
            }
        
            return true;
        }
        return false;
    }
    public void ReceiveDamage(int damage) {
        _life -= damage;
    }
    public int GetHealth() {
        return _life;
    }
    public void _Die() {
        _life = 0;
        Dead = true;

    }
    public void PlayAnimation(string state,int offset,bool loop) {
        
        switch (state)
        {
            case "moving":
                //_animatorMan.SetInteger("go", 1);
                _animatorMan = "moving";
                break;
            case "attack_1":
                //_animatorMan.SetInteger("go", 2);
                _animatorMan = "attack_1";
                break;
            case "attack_2":
                //_animatorMan.SetInteger("go", 3);
                _animatorMan = "attack_2";
                break;
            case "idle":
                //_animatorMan.SetInteger("go", 4);
                _animatorMan = "idle";
                break;
            case "die":
                //_animatorMan.SetInteger("go", 5);
                _animatorMan = "die";
                break;
            default:
                Debug.Log("Error Animation");
                //_animatorMan.SetInteger("go", 4);
                _animatorMan = "stop";
                break;
        }

    }
    public void StopAnimation() {
        //_animatorMan.SetInteger("gogo", 4);
        _animatorMan = "stop";
    }
    public string getAnimation()
    {
        return _animatorMan;
    }

    public Scene GetScene() {
        return _scene;
    }
    public int GetId()
    {
        return _id;
    }
    public int GetParams(string type) {
            return _params[type];
    }
    public void SetParams(string type, int value) {
        _params.Add(type, value);
    }
    public bool GetFiend()
    {
        return _fiend;
    }
  }
