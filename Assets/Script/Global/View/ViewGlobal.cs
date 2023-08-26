using UnityEngine;

using RTS;
using SimpleJSON;
using System.Collections.Generic;
using Assets.Script.Global.Model.strateg;
using UnityEngine.SceneManagement;
using System.Drawing;
//using System.Numerics;

//using Model;

public class ViewGlobal : MonoBehaviour {

	//public GameObject GlobalGround;
	//public GameObject StrategShip;
	//public GameObject Tile;
	//public GameObject Planet;

	public Sprite[] imageHero;

	public GUISkin resourceSkin;
	public GUISkin rightBarSkin;

	public static int selectNameId=-1;

	//private static int _sel_FleetCount=0;
	public static InfoFleet _selectFleet;
	public static  InfoPlanet _selectPlanet;

	public static bool viewBombButton=false;
	public static Vector2 clickFleetChangeHero=Vector2.zero;
	private bool viewPortButton=false;

	public const int ORDERS_BAR_WIDTH = 150, RESOURCE_BAR_HEIGHT = 40;

    // global
    public static ViewGlobal _ViewGlobalModel;

    public GameObject standartPanel;
    public GameObject _messagePanel;
    public GameObject GreetingPanelInside;
    public GameObject _planetNewPanel;
    public GameObject CustomBattlePanel;
    public GameObject GlobalWinPanel;
    public GameObject StickLevelPanel;
    private GameObject _globalGround;
    private GameObject _greetingStandartPanel;
    //public GameObject PanelCustom;

    private static bool fleetInitGamestart = false;

    /*
    public static int selectFleetCount {
		get
		{
			return _sel_FleetCount;
		}
		set
		{
			_sel_FleetCount = value;
		}
	}
    */
	public static ViewGlobal selViewGlobal;

	// start.
	void Start () {

        EventListeren.eventListerenController += initGameLevel;
        EventListeren.eventListerenController += initCustomGameLevel;
        EventListeren.eventListerenController += initStickGameLevel;
        EventListeren.eventListerenController += messagePanel;
        EventListeren.eventListerenController += planetPanel;
        EventListeren.eventListerenController += messageGlobalWin;
        EventListeren.eventListerenController += destroyGameLevel;
        EventListeren.eventListerenController += GreetingPlayerMenu;
        if (_ViewGlobalModel == null)
        {
            _ViewGlobalModel = this;
        }


        // Заставка приветствия игрока.
        greetingPlayerMenu();
        //Destroy(PanelCustom);
    }

    private void GreetingPlayerMenu(string isPower, string obj) {
        
        if (isPower == CommandState.GreetingPlayerMenu.ToString())
        {
            print("=== ПОВЕРЖЕН.     DeleteAllTacticMap ");
            // Заставка приветствия игрока.
            greetingPlayerMenu();
        }
    }

    // Заставка приветствия игрока.
    private void greetingPlayerMenu()
    {
        if (!GlobalConf.ModeStickBattle) {
            _greetingStandartPanel = Instantiate(standartPanel) as GameObject;
            StartStandartPanel panel = standartPanel.GetComponent<StartStandartPanel>();
            //var k = this.transform.parent.GetComponent<StandartPanelMenu>();
            panel.CloseButton.gameObject.SetActive(false);

            panel._title = "";

            GameObject greeting = Instantiate(GreetingPanelInside) as GameObject;
            greeting.transform.SetParent(_greetingStandartPanel.transform);
        } else
        {
            // StickBattle.
            Instantiate(StickLevelPanel);

        }
    }
    private void messagePanel(string isPower, string obj)
    {
        if (isPower == CommandState.Message.ToString())
        {
            var ar = JSONNode.Parse(obj);
            MessagePanel.spriteImage = ar["image"];

            Instantiate(_messagePanel);
            //MessagePanel mPanel = _messagePanel.GetComponent<MessagePanel>();

            MessagePanel.infoTitle= ar[CommandState.Message.ToString()];
            

            
        }
    }
    //messageGlobalWin
    private void messageGlobalWin(string isPower, string obj)
    {
        if (isPower == CommandState.MessageGlobalWin.ToString())
        {

            GameObject wButton = Instantiate(GlobalWinPanel) as GameObject;
            var globalWinPanel = wButton.GetComponent<GlobalWinPanel>();
            var ar = JSONNode.Parse(obj);
            var playerWin = bool.Parse(ar[CommandState.MessageGlobalWin.ToString()]);
            globalWinPanel.playerWin = playerWin;
   
        }
    }
 
    private static void initGameLevel(string isPower, string obj)
    {
        if (isPower == CommandState.InitGameLevel.ToString())
        {
            var ar = JSONNode.Parse(obj);
           var level = int.Parse(ar[CommandState.InitGameLevel.ToString()]);
           
            _ViewGlobalModel.instanceLevel(level);
        }
    }
    private void destroyGameLevel(string isPower, string obj)
    {
        if (isPower == CommandState.DestroyGameLevel.ToString())
        {

            
            destroyLevel();
        }

    }

    private static void initCustomGameLevel(string isPower, string obj)
    {
        if (isPower == CommandState.InitCustomGameLevel.ToString())
        {
            var ar = JSONNode.Parse(obj);

            var fleetOne = JsonUtility.FromJson<TypeUnitSend>(ar[CommandSend.fleetOne.ToString()]);
            var fleetTwo = JsonUtility.FromJson<TypeUnitSend>(ar[CommandSend.fleetTwo.ToString()]);

            _ViewGlobalModel.instanceCustomLevel(fleetOne.unitArray, fleetTwo.unitArray);
          _ViewGlobalModel.instanceLevel(null);
        }
    }
    /// <summary>
    /// Вызов Стик боя!
    /// </summary>
    /// <param name="isPower"></param>
    /// <param name="obj"></param>
    private static void initStickGameLevel(string isPower, string obj)
    {
        if (isPower == CommandState.InitStickGameLevel.ToString())
        {
            
            EventListeren.eventDispatchEvent(CommandState.AttackTacticStick.ToString(), "Istart".ToString());
        }
    }


    private void planetPanel(string isPower, string obj)
    {
        if (isPower == CommandState.PlanetPanel.ToString())
        {
           
            var ar = JSONNode.Parse(obj);
            MessagePanel.spriteImage = ar["image"];


            GameObject wButton = Instantiate(_planetNewPanel) as GameObject;
            PlanetNewPanel panel = wButton.GetComponent<PlanetNewPanel>();
            panel.namePlanet = ar["name"];
            panel.planetX = int.Parse(ar["x"]);
            panel.planetY = int.Parse(ar["y"]);


        }
    }

    private void instanceCustomLevel(List<int> player, List<int> fiend)
    {
        GlobalConf.initCustomGameLevel(player, fiend);
    }
    private void destroyLevel()
    {
        GlobalConf.ResetGame();
        
        Destroy(_globalGround);

        // Удаляем планеты.
        var planet_ar = GameObject.FindGameObjectsWithTag("Planet");
        foreach (var planetDel in  planet_ar)
        {
            Destroy(planetDel);
        }
        // Заставка приветствия игрока.
        greetingPlayerMenu();

    }
    private void instanceLevel(int? level)
    {
        
        if (level != null)
        {
            // GlobalConf.initGameLevel((int)level);
            new CreateLevel().InitGameLevel((int)level);
        }

        selViewGlobal = this;
        SceneManager.LoadScene("StrategChess", LoadSceneMode.Single);

       
    }
    /*
    private void addFleet (InfoFleet floorFleet) {
		GameObject strShip = (GameObject) Instantiate (StrategShip, new Vector3 (floorFleet.coordinate.x, 3, floorFleet.coordinate.y), Quaternion.identity);
		

		Fleet fleet = strShip.GetComponent<Fleet>();
        fleet.SetParam(floorFleet.id, floorFleet.player, floorFleet.name, new Vector2(floorFleet.coordinate.x, floorFleet.coordinate.y), floorFleet.SpotX, floorFleet.SpotY);
		//fleet.SetCoordinate( new Vector2(floorFleet.coordinate.x, floorFleet.coordinate.y));


		//fleet.name = floorFleet.name;
		//fleet.player = floorFleet.player;
		//fleet.id = floorFleet.id;
		GlobalConf.StrategShip_ar.Add(strShip);

         
    }
    */

    // показываем каждый раз флот.
    void Update () {
        /*
        // уровень выбрали, можно показывать флоты.
        if (fleetInitGamestart)
        {
            MouseActivity();

            // move ship
            var ship_ar = GameObject.FindGameObjectsWithTag("fleet");
            List<int> id_ar = new List<int>();

            foreach (GameObject fleet in ship_ar)
            {

                Fleet c = fleet.GetComponent<Fleet>();
                bool byWorld = false;
                foreach (InfoFleet floor in GlobalConf.GetViewFleetList())
                {
                    if (c.id == floor.id)
                    {
                        fleet.transform.position = new Vector3(floor.coordinate.x, 3, floor.coordinate.y);

                        byWorld = true;
                        id_ar.Add(c.id);
                    }
                }
                // если такого флота с ид нет, уничтожить флот.
                if (!byWorld)
                {
                    Destroy(fleet);
                }


            }

            if (ModelGlobal.getAttackFleetPlanet() != null)
            {
                if (!ViewPlanet.viewPlanetClick)
                {
                    //Message.message("Враг атаковал вашу планету!");
                    var textI = new JSONClass();
                    textI["image"] = "planet";
                    textI[CommandState.Message.ToString()] = "Враг атаковал вашу планету!";
                    EventListeren.eventDispatchEvent(CommandState.Message.ToString(), textI.ToString());

                    attackPlanet(ModelGlobal.getAttackFleetPlanet(), ModelGlobal.getAttackDefencePlanet());
                }
            }
            clickFleetChangeHero = ModelGlobal._clickFleetChangeHero;
        }
        */
	}
    /*
	private void MouseActivity() {
		if (Input.GetMouseButtonDown (0)) {
			
			LeftMouseClick ();
		}
	}
    */
    /*
	private void LeftMouseClick() {
		GameObject hitObject = FindHitObject();
		if (hitObject != null) {

			if (hitObject.name == "GlobalGround(Clone)") {

			}
			if (hitObject.name == "StrategShip(Clone)") {
				
				
				
				Fleet cfleet = hitObject.GetComponent<Fleet>();


               // ClickMouseShipPlayerInstantiatePath(cfleet.id);
				
				
			}
			if (hitObject.name == "Tile(Clone)") {
				TilePath tileClass = hitObject.GetComponent<TilePath>();
				
				clickTile((int)tileClass.GetCoordinate().x,(int)tileClass.GetCoordinate().y,tileClass.id);
			}
			if (hitObject.name == "Planet(Clone)") {
				InfoPlanet c = ModelGlobal.PlanetSelectCoordinate((int)hitObject.transform.position.x,(int)hitObject.transform.position.z);
				

				if (c.player) {
					gotoPlanet(c.name,c.id, (int)hitObject.transform.position.x, (int)hitObject.transform.position.z,false) ;
					
				} else {
					
					//Message.message("Это вражеская планета!");
                    var textI = new JSONClass();
                    textI["image"] = "planet";
                    textI[CommandState.Message.ToString()] = "Это вражеская планета!";
                    EventListeren.eventDispatchEvent(CommandState.Message.ToString(), textI.ToString());
                }
			}
		}
		
		Cursor.visible = true;
	}
   */
    public void SetSelectNameId(int id)
    {
        selectNameId = id;
    }
    

        void clickTile (int x, int y, int id) {

        Debug.Log(" clickTile  ---------- Game  ");

        var tile_ar = GameObject.FindGameObjectsWithTag("Tile");
			
			foreach (GameObject tile in tile_ar)
			{
				if (tile!=null) {
					Destroy (tile);
				}
			}
		

		var I = new JSONClass();
		I["x"] =x.ToString();
		I["y"] =y.ToString();
		I["id"] =id.ToString();
		EventListeren.eventDispatchEvent(CommandState.ClickTile.ToString(),I.ToString());
		resetSelectFleet ();
	}
	void resetSelectFleet () {
		viewPortButton=false;
	}
	
	



	private static void gotoPlanet(string name,int id, int x, int y,bool attack) 
	{
		
		

        var textI = new JSONClass();
        textI["name"] = name;
        textI["idPlanet"] = id.ToString();
        textI["state"] = (attack).ToString();
        textI["x"] = ((int)x).ToString();
        textI["y"] = ((int)y).ToString();

        EventListeren.eventDispatchEvent(CommandState.PlanetPanel.ToString(), textI.ToString());

    }
	
	private GameObject FindHitObject() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			return hit.collider.gameObject;
		}
		return null;
	}
	private Vector3 FindHitPoint() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)) return hit.point;
		return ResourceManager.InvalidPosition;
	}

    
	void OnGUI()  {
		if (!ResourceManager.tacticMap) {

			if (_selectFleet!=null) {
				if (viewBombButton) {

				}
				if (viewPortButton) {
					if (GUI.Button (new Rect (Screen.width - ORDERS_BAR_WIDTH+10, Screen.height - 150, ORDERS_BAR_WIDTH-20, 40), "Goto planet")) 
					{
		
                        var textI = new JSONClass();
                        textI["name"] = _selectPlanet.name;
                        textI["idPlanet"] = _selectPlanet.id.ToString();
                        textI["state"] = (false).ToString();
                        textI["x"] = ((int)_selectFleet.coordinate.x).ToString();
                        textI["y"] = ((int)_selectFleet.coordinate.y).ToString();

                        EventListeren.eventDispatchEvent(CommandState.PlanetPanel.ToString(), textI.ToString());
                        
                    }
				}

			}
		}
	}

	public static void attackPlanet(InfoFleet InnerSelectFleet, InfoPlanet InnerPlanet) {

		var I = new JSONClass();
		I["x"] =InnerSelectFleet.coordinate.x.ToString();
		I["y"] =InnerSelectFleet.coordinate.y.ToString();
		I["id"] =InnerSelectFleet.id.ToString();
		EventListeren.eventDispatchEvent(CommandState.PlanetLanding.ToString(),I.ToString());

		gotoPlanet(InnerPlanet.name,InnerPlanet.id, (int)InnerSelectFleet.coordinate.x, (int)InnerSelectFleet.coordinate.y,true);
	}
    /*
	public static void selectFleet(InfoFleet InnerSelectFleet) {

		var I = new JSONClass();
		I["id"] =InnerSelectFleet.id.ToString();
		EventListeren.eventDispatchEvent(CommandState.ClickFleet.ToString(),I.ToString());
	}
    */
}
