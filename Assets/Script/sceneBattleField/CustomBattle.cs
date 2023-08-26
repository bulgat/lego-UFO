using Assets.Global;
using RTS;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.Script.Global
{
    public class CustomBattle: MonoBehaviour
    {
        public GameObject GlobalGroundPrefab;
        private GameObject _globalGround;
        public GameObject PlanetPrefab;
        private static bool fleetInitGamestart = false;
        public GameObject PanelCustomPrefab;
        public GameObject BattleInterfacePrefab;
        // Режим битвы включен.
        public static bool _goBattle = false;
        private UnityEngine.Vector3 CameraOldPosition;
        private UnityEngine.Vector3 CameraOldRotation;
        public Transform GroundPrefab;
        private int fleet_battle_one;
        private int idFleet_battle_two;
        private static int lapUnit = 3;

        public Transform ShipPrefab;
        public GameObject ShipGamePrefab;
        public GameObject ShipGameHorsePrefab;
        public GameObject ShipBuildingPrefab;
        public GameObject ShipOrePrefab;

        public void Awake()
        {
            
            GlobalConf.CustomBattle = true;

            List<int> panelLeftId_ar = new List<int>();
            List<int> panelRightId_ar = new List<int>();

            panelLeftId_ar = CustomBattleParam.panelLeft_ar;
            panelRightId_ar = CustomBattleParam.panelRight_ar;

            // Собираем информацию, кого мы поставили.

            
           

            // Начать настройки песочный бой.
  
            var Ifleet = new JSONClass();

            Ifleet[CommandSend.fleetOne.ToString()] = 0.ToString();

            Ifleet[CommandSend.fleetTwo.ToString()] = 1.ToString();

            // Начать непосредственно бой - взлом стратегической игры.

            instanceLevel(null,panelLeftId_ar, panelRightId_ar);
            on_start_battle(CommandState.AttackShip.ToString(), Ifleet.ToString());
        }
        
      

        private void on_start_battle(string isPower, string obj)
        {
            


            if (isPower == CommandState.AttackShip.ToString())
            {
                Debug.Log("  on_start_battle = " );

                // Сражение начено. Надо блокировать. еще растоновку войск.
                if (_goBattle)
                {
                    return;
                }
                _goBattle = true;

                GlobalConf.FiendOne = GlobalConf.Fiend_ar[0];

                SetCameraPosition(new List<int>() { 2, 40, -16 }, new List<int>() { 47, 2, 0 });

                //CameraSetUp

                var ar = JSONNode.Parse(obj);
                EventListeren.eventDispatchEvent(CommandState.BattleInterface.ToString(), obj);

                ResourceManager.tacticMap = true;

               
                    Instantiate(GroundPrefab);
                    addLevel(int.Parse(ar[CommandSend.fleetOne.ToString()]), int.Parse(ar[CommandSend.fleetTwo.ToString()]));

            }
        }
        private void SetCameraPosition(List<int> position, List<int> rotation)
        {
            ///////
            TypeUnitSend typeUnitSendLeft = new TypeUnitSend() { unitArray = position };
            TypeUnitSend typeUnitSendRight = new TypeUnitSend() { unitArray = rotation };

            var Istart = new JSONClass();
            Istart[CommandSend.fleetOne.ToString()] = JsonUtility.ToJson(typeUnitSendLeft);
            Istart[CommandSend.fleetTwo.ToString()] = JsonUtility.ToJson(typeUnitSendRight);

            ///////
            EventListeren.eventDispatchEvent(CommandState.CameraSetUpBattle.ToString(), Istart.ToString());

        }

        private void instanceLevel(int? level, List<int> player, List<int> fiend)
        {
      
                var fleet_ar = GlobalConf.initCustomGameLevel(player, fiend);
          
            fleetInitGamestart = true;

            InterfaceBattle(fleet_ar[0].id);
        }
        private void InterfaceBattle(int idFleet)
        {

            GameObject wButton = Instantiate(BattleInterfacePrefab) as GameObject;
   
            UIBattleTactic lenL = wButton.GetComponent<UIBattleTactic>();

            InfoFleet infoFleet = ModelGlobal.getFleetId(idFleet);

            

            lenL.SetInfo(infoFleet.imageId, infoFleet.nameHero);

        }

        private void addLevel(int fleet_one, int fleet_two)
        {

            fleet_battle_one = fleet_one;
            idFleet_battle_two = fleet_two;
            // враг
            addFleet(fleet_one, 0);
            // игрок
            addFleet(fleet_two, 1);

        }
        private void addFleet(int idFleet, int id_side)
        {
            Debug.Log(" __ idFleet="+ idFleet);

            List<NewUnit> addfleet_ar = ModelGlobal.getFleetId(idFleet).ship_ar;

            int count = 0;

            Debug.Log(  "   Global .fleet_ar=" + addfleet_ar.Count);

            // Добавить unit
            foreach (NewUnit unit in addfleet_ar)
            {


                AddTacticUnit(unit, idFleet, id_side, lapUnit, count);


                count++;

            }

        }
        private GameObject AddTacticUnit(NewUnit unit, int idFleet, int id_side, int lap, int count)
        {
            GameObject shipGame;
            switch (unit.typeShipId)
            {
                case 3:
                    shipGame = Instantiate(ShipGameHorsePrefab);
                    break;
                case 4:
                    shipGame = Instantiate(ShipBuildingPrefab);
                    break;
                case 6:
                    shipGame = Instantiate(ShipOrePrefab);
                    break;
                case 7:
                    shipGame = Instantiate(ShipOrePrefab);
                    break;
                default:
                    shipGame = Instantiate(ShipGamePrefab);
                    break;
            }

            var unitShip = shipGame.GetComponent<Unit>();

            unitShip.fiend = (id_side == 0);


           // unitShip.player = this;
            unitShip.idFleet = idFleet;
            unitShip.objectName = unit.objectName;

            unitShip.hitPoints = unit.hitPoints;
            unitShip.maxHitPoints = unit.hitPoints;
            unitShip.weaponRange = unit.weaponRange;
            unitShip.weaponDamage = unit.weaponDamage;
            unitShip.weaponRechargeTime = unit.weaponRecharge;
            unitShip.currentRotationSpeed += unit.fast;
            unitShip.rotationSpeed += unit.fast;
            unitShip.speed += unit.fast;
            unitShip.unit_Ship.Add(unit);

        
                // Точная установка юнита.
                if (id_side == 0)
                {
                    unitShip.positionStart = new UnityEngine.Vector3(-15 - unit.placeUnitY * lap, ResourceManager.shipAltitude, -10.59f + unit.placeUnitX * lap);
                    shipGame.transform.eulerAngles = new UnityEngine.Vector3(0, 90, 0);
                }
                else
                {
                    unitShip.positionStart = new UnityEngine.Vector3(16 + unit.placeUnitY * lap, ResourceManager.shipAltitude, -10.59f + unit.placeUnitX * lap);
                    shipGame.transform.eulerAngles = new UnityEngine.Vector3(0, -90, 0);
                }
            

            

            unitShip.id = unit.uid;

            return shipGame;
        }
        private UnityEngine.Vector2 squadUnit(int count)
        {
            UnityEngine.Vector2 coordinat = new UnityEngine.Vector2();
            coordinat.x = count / GlobalConf.DepthFormation;
            coordinat.y = count % GlobalConf.DepthFormation;
            return coordinat;
        }
        private void Update()
        {
            var ship_ar = GameObject.FindGameObjectsWithTag("ship");
            int byShipPlayer = 0;
            int byShipFiend = 0;

            foreach (GameObject ship in ship_ar)
            {
                if (ship != null)
                {
                    Unit unitShip = ship.GetComponent<Unit>();
                    if (unitShip != null)
                    {
                        if (!unitShip.fiend)
                        {
                            byShipPlayer++;
                        }
                        else
                        {
                            byShipFiend++;
                        }
                    }
                }
            }

            if (byShipPlayer == 0 || byShipFiend == 0)
            {
                if (byShipPlayer == 0)
                {
                    // уничтожить  флот игрока.

                    //destroyAll (true);
                    //DeleteAllTacticMap(true);
                    if (ResourceManager.tacticMap)
                    {
                        ResourceManager.tacticMap = false;
                        StartCoroutine(DeleteAllTacticMap(true));
                    }
                }
                else
                {
                    // уничтожить вражеский флот.

                    //destroyAll (false);
                    //DeleteAllTacticMap(false);
                    if (ResourceManager.tacticMap)
                    {
                        ResourceManager.tacticMap = false;
                        StartCoroutine(DeleteAllTacticMap(false));
                    }
                }



            }
        }
        IEnumerator DeleteAllTacticMap(bool player)
        {
            bool kTask = true;
            while (kTask)
            {

                ResourceManager.tacticMap = false;
                yield return new WaitForSeconds(3.5f);
                //destroyAll(player);
                Debug.Log("ПОБЕДА!!!!!");
                kTask = false;
                //  SceneManager.LoadScene("basic");
                SceneManager.LoadScene("Win");
            }

        }
    }
}
