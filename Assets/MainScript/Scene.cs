using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Scene  {

    private int SceneTick = 0;
    public List<Unit> _unit_ar;
    public Board sceneTile;

    public static Scene scene;

    // Use this for initialization
    public void OnInit()
    {
        // Инициализация карты.
        sceneTile = new Board();
        sceneTile.CreateBoard();
        scene = this;

        _unit_ar = new List<Unit>() { new Unit(), new Unit() };

        // Иницилизировать юниты.
  
        AddUnitToScene();


    }

    private void AddUnitToScene()
    {
        _unit_ar[0].OnInit(1, 1, false);
        _unit_ar[1].OnInit(3, 3, true);
    }

    // Update is called once per frame
    public void Update () {
        
        // Обновить действия всех юнитов. 
        foreach (Unit un in _unit_ar) {
            un.Update();
        }

        SceneTick++;
        
    }
    // Возращает текущий тик.
    public int GetTick() {
        return SceneTick;
    }

    public Unit FindNearestEnemyUnit(Unit unit) {
        int distanceMin = 99999;
        Unit unitMin = null;

        // Создаем массив всех врагов c минимальной дистанцией.
        foreach (Unit anyUnit in GetEnemyUnit())
        {

                if (distanceMin> GetQuadDistance(unit.GetTileX(), unit.GetTileY(), anyUnit.GetTileX(), anyUnit.GetTileY())) {
                    distanceMin = GetQuadDistance(unit.GetTileX(), unit.GetTileY(), anyUnit.GetTileX(), anyUnit.GetTileY());
                    unitMin = anyUnit;
                }

        }

        // Отправляем ближайшего.
        if (unitMin!=null) {
            return unitMin;
        }


        return null;
    }
    public int GetQuadDistance(int x1, int y1, int x2, int y2)
    {
        return (int)System.Math.Sqrt((x2 - x1)* (x2 - x1) + (y2 - y1)*(y2 - y1));
        
    }
    public bool CanShoot(Unit from, Unit to) {
        // Просчет карты.
        return true;
    }


    public List<Unit> GetEnemyUnit() {
        List<Unit> unitFiend_ar = new List<Unit>();
        foreach (Unit anyUnit in _unit_ar)
        {
            if (anyUnit.GetFiend()) {
                unitFiend_ar.Add(anyUnit);
            }
        }

            return unitFiend_ar;
    }
    public List<Unit> GetAllUnit()
    {
        return _unit_ar;
    }
    
    public void destroyUnit(Unit delUnit)
    {
        _unit_ar.Remove(delUnit);
    }

    }
