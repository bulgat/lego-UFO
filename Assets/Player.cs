using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RTS;
using SimpleJSON;
using System.Linq;
using Assets.Global;
using Assets.Script;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public string username;
    public Camera _camera;
	

	//public HUD hud;
    public UserInput UserInputPlayer;

    //public WorldObject WorldObjectSelectedClass { get; set; }
	public GameObject Ground;
    public GameObject GroundStick;

    public GameObject PanelCustom;
    public GameObject StickPanelBattle;

    public Transform Ship;
    public GameObject ShipGame;
    public GameObject ShipGameHorse;
    public GameObject ShipBuilding;
    public GameObject ShipOre;

    private int fleet_battle_one;
    private int idFleet_battle_two;
    
    private Vector3 CameraOldPosition;
    private Vector3 CameraOldRotation;

    // Режим битвы включен.
    public static bool _goBattle = false;
    private static int lapUnit = 3;

    // Use this for initialization
    void Start () {

		//hud = GetComponentInChildren< HUD >();
		ResourceManager.tacticMap = false;

		EventListeren.eventListerenEvent += on_start_battle;
        EventListeren.eventListerenEvent += OnStickStartBattle;
        EventListeren.eventListerenEvent += BuyUnitStickBattle;
        EventListeren.eventListerenEvent += BuyUnitStickBattleFiend;

        if (Param.Music == false)
        {
            AudioListener audioListener = _camera.GetComponent<AudioListener>();
            AudioListener.volume = 0.0F;
            //Destroy(audioListener);
        }
}

	void Update () {

		if (ResourceManager.tacticMap) {
            var ship_ar = GameObject.FindGameObjectsWithTag("ship");
            if (!GlobalConf.ModeStickBattle)
            {
                

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
   
                        if (ResourceManager.tacticMap)
                        {
                            ResourceManager.tacticMap = false;
                            StartCoroutine(DeleteAllTacticMap(true));
                        }
                    }
                    else
                    {
                        // уничтожить вражеский флот.

                        if (ResourceManager.tacticMap)
                        {
                            ResourceManager.tacticMap = false;
                            StartCoroutine(DeleteAllTacticMap(false));
                        }
                    }



                }
            }
            else
            {
                // ModeStickBattle.
                var shipUnit_ar = new List<Unit>();
                foreach (GameObject ship in ship_ar)
                {
                    if (ship != null)
                    {
                        Unit unitShip = ship.GetComponent<Unit>();
                        shipUnit_ar.Add(unitShip);
                    }

                }
                var building_ar = shipUnit_ar.Where(a => a.objectName == NameUnit.building.ToString());
                

                if (building_ar.Count() < 2)
                {
                    Debug.Log("   @@@@@@@@@@@@@@@ ) " + building_ar.Count());
                    var building = building_ar.FirstOrDefault();
                    if (ResourceManager.tacticMap)
                    {
                        ResourceManager.tacticMap = false;
                        GlobalConf.CustomBattle = true;
                        StartCoroutine(DeleteAllTacticMap(building.fiend));
                        if (building.fiend == false)
                        {
                            StickBattle.Level++;
                        }
                    }
                }
            }
        }
	}
    /// <summary>
    /// Уничтожить все юниты и карту, через некоторое время.
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    IEnumerator DeleteAllTacticMap(bool player)
    {
        bool k = true;
            while (k)
            {
                
                ResourceManager.tacticMap = false;
                yield return new WaitForSeconds(3.5f);
                destroyAll(player);
            k = false;
            }

    }
    private void BuyUnitStickBattle(string isPower, string obj) {
        if (isPower == CommandState.BuyUnitStickBattle.ToString())
        {
            var ar = JSONNode.Parse(obj);

            int typeUnit = int.Parse(ar[CommandSend.typeUnit.ToString()]);


            // buy player
            var I = new JSONClass();
            I["x"] = 3.ToString();
            I["y"] = 0.ToString();
            I["type"] = typeUnit.ToString();
            EventListeren.eventDispatchEvent(CommandState.BuyShip.ToString(), I.ToString());

            AddTacticUnit(GlobalConf.GetViewFleetList()[1].ship_ar.LastOrDefault(), 1, 1, lapUnit, GlobalConf.GetViewFleetList()[1].ship_ar.Count);

            
            }
    }
    private void BuyUnitStickBattleFiend(string isPower, string obj)
    {
        if (isPower == CommandState.BuyUnitStickBattleFiend.ToString()) {
            var ar = JSONNode.Parse(obj);

            int typeUnit = int.Parse(ar[CommandSend.typeUnit.ToString()]);
            // buy fiend
            typeUnit = (int)Random.Range(0, 3);
            var If = new JSONClass();
            If["x"] = 7.ToString();
            If["y"] = 7.ToString();
            If["type"] = typeUnit.ToString();
            EventListeren.eventDispatchEvent(CommandState.BuyShip.ToString(), If.ToString());
            AddTacticUnit(GlobalConf.GetViewFleetList()[0].ship_ar.LastOrDefault(), 0, 0, lapUnit, GlobalConf.GetViewFleetList()[0].ship_ar.Count);
        }
    }


    private void OnStickStartBattle(string isPower, string obj)
    {
        if (isPower == CommandState.AttackTacticStick.ToString())
        {
            
            //print("OnStickStartBattle     DeleteAllTacticMap ");
            if (_goBattle)
            {
                return;
            }
            _goBattle = true;

            CameraOldPosition = Camera.main.transform.transform.position;
            CameraOldRotation = Camera.main.transform.eulerAngles;

            GlobalConf.FiendOne = GlobalConf.Fiend_ar[StickBattle.Level];

            SetCameraPosition(new List<int>() { 47, 20, -32 }, new List<int>() { (int)StickBattle.StickBattleRotateCamera.x, (int)StickBattle.StickBattleRotateCamera.y, (int)StickBattle.StickBattleRotateCamera.z });

            ResourceManager.tacticMap = true;
            GlobalConf.ModeStickBattle = true;

            Destroy(PanelCustom);


            Instantiate(GroundStick);
            Instantiate(StickPanelBattle);

            addLevel(0, 1);
        }
     }

    /// <summary>
    /// Событие Сражение между игроками
    /// </summary>
    /// <param name="isPower"></param>
    /// <param name="obj"></param>
    private void on_start_battle(string isPower, string obj) {
		if (isPower == CommandState.AttackShip.ToString ()) {

            Debug.Log("Players-------------on_start_battle");
            // Сражение начено. Надо блокировать. еще растоновку войск.
            if (_goBattle) {
                return;
            }
            _goBattle = true;

            GlobalConf.FiendOne = GlobalConf.Fiend_ar[0];

            var ar = JSONNode.Parse(obj);

            addLevel(int.Parse(ar[CommandSend.fleetOne.ToString()]), int.Parse(ar[CommandSend.fleetTwo.ToString()]));
            SceneManager.LoadScene("BattleField");
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


    private void addLevel (int fleet_one, int fleet_two) {

		fleet_battle_one=fleet_one;
        idFleet_battle_two = fleet_two;
    // враг
        addFleet(fleet_one,0);
		// игрок
		addFleet(fleet_two,1);



	}

	private void addFleet (int idFleet,int id_side) {

		List<NewUnit> addfleet_ar = ModelGlobal.getFleetId (idFleet).ship_ar;

		int count = 0;

			// Добавить корабли.
			foreach (NewUnit unit in addfleet_ar) {
            

            AddTacticUnit(unit, idFleet, id_side,lapUnit,count);
            

            count++;

            }

	}
    private GameObject AddTacticUnit(NewUnit unit, int idFleet, int id_side,int lap,int count)
    {
        GameObject shipGame;
        switch (unit.typeShipId)
        {
            case 3:
                shipGame = Instantiate(ShipGameHorse);
                break;
            case 4:
                shipGame = Instantiate(ShipBuilding);
                break;
            case 6:
                shipGame = Instantiate(ShipOre);
                break;
            case 7:
                shipGame = Instantiate(ShipOre);
                break;
            default:
                shipGame = Instantiate(ShipGame);
                break;
        }
  
        var unitShip = shipGame.GetComponent<Unit>();

        unitShip.fiend = (id_side == 0);


        unitShip.player = this;
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

        if (unit.placeUnitMap)
        {
            // Точная установка юнита.
            if (id_side == 0)
            {
                unitShip.positionStart = new Vector3(-15 - unit.placeUnitY * lap, ResourceManager.shipAltitude, -10.59f + unit.placeUnitX * lap);
                shipGame.transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else
            {
                unitShip.positionStart = new Vector3(16 + unit.placeUnitY * lap, ResourceManager.shipAltitude, -10.59f + unit.placeUnitX * lap);
                shipGame.transform.eulerAngles = new Vector3(0, -90, 0);
            }
        }
        else
        {
           int amendment = 1;
            int fff = 0;
            if (GlobalConf.ModeStickBattle)
            {
                amendment = 3;
            }
            if (unitShip.objectName== NameUnit.building.ToString()) {
               fff = 12;
                unitShip.speed = 0;
            }
            if (unitShip.objectName == NameUnit.Ore.ToString())
            {
                unitShip.speed = 0;
        
            }
            if (unitShip.objectName == NameUnit.Repository.ToString())
            {
                unitShip.speed = 0;
                fff = 1;
            }
            if (id_side == 0)
            {
                // враг
                unitShip.positionStart = new Vector3((-15 - squadUnit(count).y * lap)* amendment, ResourceManager.shipAltitude, -10.59f + squadUnit(count).x * lap+fff);
                shipGame.transform.eulerAngles = new Vector3(0, 90, 0);
               
            }
            else
            {
                // игрок
                unitShip.positionStart = new Vector3((16 + squadUnit(count).y * lap)* amendment, ResourceManager.shipAltitude, -10.59f + squadUnit(count).x * lap+fff);
                shipGame.transform.eulerAngles = new Vector3(0, -90, 0);
                
            }
        }

        if (unitShip.objectName == NameUnit.Ore.ToString())
        {
            print("ORE create " + unitShip.id);
            Ship.tag = "Ore";
            unitShip.tagStart = "Ore";
        }
        else
        {
            Ship.tag = "ship";
            unitShip.tagStart = "ship";
        }
        if (unitShip.objectName == NameUnit.Repository.ToString())
        {
            Ship.tag = NameUnit.Repository.ToString();
            unitShip.tagStart = NameUnit.Repository.ToString();
            unitShip.positionStart.x = 73;
        }

            unitShip.id = unit.uid;

        return shipGame;
    }

    private Vector2 squadUnit(int count)
    {
        Vector2 coordinat = new Vector2();
        coordinat.x = count / GlobalConf.DepthFormation;
        coordinat.y = count % GlobalConf.DepthFormation;
        return coordinat;
    }


    private void destroyAllShip (string destrName) {
		var ship_ar = GameObject.FindGameObjectsWithTag(destrName);
		foreach (GameObject ship in ship_ar)
		{
			if (ship!=null) {
				Destroy (ship);
			}
		}
	}
    
    public void destroyAll (bool playerDestr) {

		ResourceManager.tacticMap = false;
		var Ground = GameObject.Find ("Ground(Clone)");
        if (Ground!=null) { 
        Destroy (Ground);}
        var GroundStick = GameObject.Find("GrounStick(Clone)");
        if (GroundStick != null)
        {
            Destroy(GroundStick);
        }
        var stickPanel = GameObject.Find("StickPanelBattle(Clone)");
        if (stickPanel != null)
        {
            Destroy(stickPanel);
        }


        destroyAllShip ("ship");
		destroyAllShip ("shipSink");
        destroyAllShip("Bolt");

        // передача полученных данных сражения
        if (playerDestr) {
			// уничтожить  флот игрока.

            ModelGlobal.destroyFleet (idFleet_battle_two);
		} else {
			// уничтожить вражеский флот.

            ModelGlobal.destroyFleet(fleet_battle_one);
		}
		EventListeren.eventDispatchEvent(CommandState.EndAttackShip.ToString(),"I.ToString()");
        Camera.main.transform.transform.position = CameraOldPosition;
        Camera.main.transform.eulerAngles = CameraOldRotation;
        _goBattle = false;
        
        if (GlobalConf.CustomBattle == true) {

            var textI = new JSONClass();
            textI[CommandState.MessageGlobalWin.ToString()] = (playerDestr==false).ToString();
            EventListeren.eventDispatchEvent(CommandState.MessageGlobalWin.ToString(), textI.ToString());

            GlobalConf.CustomBattle = false;

        }
        if (playerDestr)
        {
            // уничтожить  флот игрока.

            var textI = new JSONClass();
            textI["image"] = "battleFiend";
            textI[CommandState.Message.ToString()] = "ВАШ ФЛОТ УНИЧТОЖЕН.";
            EventListeren.eventDispatchEvent(CommandState.Message.ToString(), textI.ToString());
        }
        else
        {
            // уничтожить вражеский флот.

            var textI = new JSONClass();
            textI["image"] = "battlePlayer";
            textI[CommandState.Message.ToString()] = "ВРАГ ПОВЕРЖЕН.";
            EventListeren.eventDispatchEvent(CommandState.Message.ToString(), textI.ToString());
        }

    }
	public static void restartGame () {
		//Debug.Log("END  =======ВРАГ ПОВЕРЖЕН.");
		//Application.Quit ();
		//Application.LoadLevel ("basic");

	}

}
