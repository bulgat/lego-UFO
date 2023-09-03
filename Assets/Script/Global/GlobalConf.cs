using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RTS;
using Assets.Global;
using static UnityEditor.Experimental.GraphView.GraphView;
using System.Security.Cryptography;
using System.Numerics;
using System.Linq;

public static class GlobalConf
{
    public static bool CustomBattle = false;
    public static bool ModeStickBattle = false;
    public static int[] Money = new int[] { 10, 10 };
    public static List<Object> StrategShip_ar = new List<Object>();
    public static int IncrementFleet;
    public static int IncrementShip;
    public static int IncrementPlanet;
    public static int DepthFormation = 6;

    public static int widthMap = 8;
    public static int heightMap = 8;
    public static int distanceDeleteMap = 60;
    private static BattlePlanetView _BattlePlanetView;


    public static List<Fiend> Fiend_ar = new List<Fiend>() {
        new Fiend() {flag = ImageDuty.shield_0.ToString(),profit=0 },
        new Fiend() {flag = ImageDuty.shield_1.ToString(),profit=1 },
        new Fiend() {flag = ImageDuty.shield_2.ToString(),profit=2 },
        new Fiend() {flag = ImageDuty.shield_3.ToString(),profit=3 }
    };
    private static bool StateStrategGame;

    public static Fiend FiendOne = Fiend_ar[0];

    // Блок для глобальной карты.

    //CameraBlock
    public static List<CameraBlock> BlockScreenScroll_ar = new List<CameraBlock>()
    {
        // Блок для тактической карты.
        new CameraBlock() {Position_x=new UnityEngine.Vector2(-50, 70),Position_z=new UnityEngine.Vector2(-90, 40) },
        // Блок для глобальной карты.
        new CameraBlock() {Position_x=new UnityEngine.Vector2(2, 5),Position_z=new UnityEngine.Vector2(-10, 0) },
        // Stick Battle
        new CameraBlock() {Position_x=new UnityEngine.Vector2(-60, 70),Position_z=new UnityEngine.Vector2(-40, -40) },
    };

    public static IEnumerable<ButtonEvent> GetPath()
    {
        //BattlePlanetView
        List<ButtonEvent> buttonEventList = _BattlePlanetView.GetMapWorldStartGame().GetPathSelectHero(
                            MapWorldModel._prototypeHeroDemo,
                             BattlePlanetModel.GetShoalSeaBasa_ar(),
                             MapWorldModel.GetIslandMemento(),
                             BattlePlanetModel.GetGridTileList(),
                             ControllerConstant.PathHero,
                             ControllerConstant.AttackHero,
                             false,
                             null,
                             null,
                             0,
                             0,
                             BattlePlanetModel.GetSelectHeroId(),
                             BattlePlanetModel.GetBattlePlanetModelSingleton().GetFlagIdPlayer()
                             );

        System.Diagnostics.Debug.WriteLine("099 ____ turn = " + buttonEventList.Count());

        return buttonEventList;
    }
    public static void Turn()
    {
        ControllerButton.EventCall(ControllerConstant.Turn, ControllerConstant.Turn, null);
    }
    public static int GetIdSelectUnit()
    {
        return BattlePlanetModel.GetSelectHeroId();
    }
    /*
    public static void TurnButtonClick()
    {

        ControllerButton.EventCall(ControllerConstant.Turn, ControllerConstant.Turn, null);
    }
    */
    public static List<InfoFleet> GetViewFleetList()
    {
        List<GridTileBar> Grid_ar = BattlePlanetModel.GetGridTileList();


        List<GridFleet> gridFleet = MapWorldModel._prototypeHeroDemo.GetHeroFleet();
        List<InfoFleet> viewUnitFleetList = new List<InfoFleet>();
        foreach (GridFleet item in gridFleet)
        {
            //viewUnitFleetList.Add(new InfoFleet(item.Image, item.GetShipNameFirst().GetFirstUnit().GetIdTypeShip(), item.SpotX, item.SpotY, item.GetCountUnitArm()));
            List<NewUnit> ship_ar = new List<NewUnit>();
            foreach (var itemArm in item.GetShipNameFirst().GetArmUnitArray())
            {
                ship_ar.Add(AddShipBasa(1, item.GetFlagId() == 9));
            }

            viewUnitFleetList.Add(new InfoFleet(item.Name, new UnityEngine.Vector2(item.SpotX, item.SpotY), item.GetFlagId() == 9, item.GetId(), ship_ar, "kol", item.GetId(), item.SpotX, item.SpotY));

        }

        return viewUnitFleetList;
    }
    public static IEnumerable<InfoPlanet> GetTownList()
    {
        List<Island> islandList = MapWorldModel.GetIslandMemento().GetIslandArray();
        List<InfoPlanet> viewIslandList = new List<InfoPlanet>();
        foreach (Island item in islandList)
        {
            viewIslandList.Add(new InfoPlanet(item.Name, new UnityEngine.Vector2(item.SpotX, item.SpotY)));
        }

        return viewIslandList;
    }
    public static List<GridTileBar> GetGridTileList()
    {
        List<GridTileBar> Grid_ar = BattlePlanetModel.GetGridTileList();
        return Grid_ar;
    }
    public static void CreateGame()
    {

        StateStrategGame = true;
        _BattlePlanetView = BattlePlanetView.GetBattlePlanetViewSingleton();
    }
    public static bool GetStateStrategGame()
    {
        return StateStrategGame;
    }
    public static void ResetGame()
    {
        _BattlePlanetView = BattlePlanetView.GetBattlePlanetViewSingleton();
        //fleet_ar = new List<InfoFleet>();
        IncrementFleet = 0;
        IncrementShip = 0;
        IncrementPlanet = 0;
        CustomBattle = false;
        StateStrategGame = false;
    }
    public static List<UnityEngine.Vector3> CustomGameCrack(List<int> unit_ar)
    {

        int count = 0;
        List<UnityEngine.Vector3> coordFormation = new List<UnityEngine.Vector3>();
        foreach (var item in unit_ar)
        {

            int xFormation = count / DepthFormation;
            int yFormation = count % DepthFormation;
            coordFormation.Add(new UnityEngine.Vector3(xFormation, yFormation, item));

            count++;
        }
        return coordFormation;
    }

    public static List<InfoFleet> initCustomGameLevel(List<int> player, List<int> fiend)
    {

        var fleet_ar = new List<InfoFleet>();
        fleet_ar.Add(fillGameLFleet(7, 7, "Капитан", 0, false, null, CustomGameCrack(player)));
        fleet_ar.Add(fillGameLFleet(3, 0, "Сестра", 1, true, null, CustomGameCrack(fiend)));

        return fleet_ar;

    }



    public static List<UnitSpecification> UnitConfig_ar = new List<UnitSpecification>() {
        new UnitSpecification() {Id=0,Name = NameUnit.pikeman.ToString(),HitPoint=3,WeaponRange=10,WeaponDamage=1,WeaponRecharge=1,Fast=0,Cost=1 },
        new UnitSpecification() {Id=1,Name = NameUnit.sword.ToString(),HitPoint=10,WeaponRange=10,WeaponDamage=2,WeaponRecharge=1,Fast=0,Cost=4 },
        new UnitSpecification() {Id=2,Name = NameUnit.crossbow.ToString(),HitPoint=3,WeaponRange=50,WeaponDamage=5,WeaponRecharge=3,Fast=0,Cost=3 },
        new UnitSpecification() {Id=3,Name = NameUnit.horse.ToString(),HitPoint=24,WeaponRange=10,WeaponDamage=5,WeaponRecharge=1,Fast=6,Cost=10 },
        new UnitSpecification() {Id=4,Name = NameUnit.building.ToString(),HitPoint=24,WeaponRange=0,WeaponDamage=0,WeaponRecharge=1,Fast=0,Cost=1 },
        new UnitSpecification() {Id=5,Name = NameUnit.labor.ToString(),HitPoint=1,WeaponRange=10,WeaponDamage=1,WeaponRecharge=1,Fast=0,Cost=3 },
        new UnitSpecification() {Id=6,Name = NameUnit.Ore.ToString(),HitPoint=2400,WeaponRange=0,WeaponDamage=0,WeaponRecharge=1,Fast=0,Cost=1 },
        new UnitSpecification() {Id=7,Name = NameUnit.Repository.ToString(),HitPoint=2400,WeaponRange=0,WeaponDamage=0,WeaponRecharge=1,Fast=0,Cost=1 },
        new UnitSpecification() {Id=8,Name = NameUnit.longSword.ToString(),HitPoint=5,WeaponRange=10,WeaponDamage=3,WeaponRecharge=1,Fast=0,Cost=5 },
    };


    public static InfoFleet fillGameLFleet(int x, int y, string name, int image, bool player, List<int> massFleet, List<UnityEngine.Vector3> massFleetCoordinate = null)
    {
        var k = new InfoFleet("fiend", new UnityEngine.Vector2(x, y), player, IncrementFleet++, new List<NewUnit>() { }
        , name, image, x, y);
        if (massFleet != null)
        {
            for (int i = 0; i < massFleet.Count; i++)
            {
                k.ship_ar.Add(AddShipBasa(massFleet[i], player));

            }
        }
        else
        {
            foreach (var unit in massFleetCoordinate)
            {
                if ((int)unit.z > 0)
                {
                    k.ship_ar.Add(AddShipBasa((int)unit.z - 1, player, true, (int)unit.x, (int)unit.y));

                }
            }
        }
        return k;
    }
    /// <summary>
    /// Добавить юнит в глобальную базу.
    /// </summary>
    /// <param name="z"></param>
    /// <param name="player"></param>
    /// <param name="placeUnitMap"></param>
    /// <param name="placeUnitX"></param>
    /// <param name="placeUnitY"></param>
    /// <returns></returns>
    public static NewUnit AddShipBasa(int z, bool player, bool placeUnitMap = false, int placeUnitX = 0, int placeUnitY = 0)
    {
        return new NewUnit()
        {
            objectName = UnitConfig_ar[z].Name,
            fiend = (player == true),
            hitPoints = UnitConfig_ar[z].HitPoint,
            weaponRange = UnitConfig_ar[z].WeaponRange,
            weaponDamage = UnitConfig_ar[z].WeaponDamage,
            weaponRecharge = UnitConfig_ar[z].WeaponRecharge,
            fast = UnitConfig_ar[z].Fast,
            uid = IncrementShip++,
            type_Ship = z,
            placeUnitMap = placeUnitMap,
            placeUnitX = placeUnitX,
            placeUnitY = placeUnitY

        };
    }



}


