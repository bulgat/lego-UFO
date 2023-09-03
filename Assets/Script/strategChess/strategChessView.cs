using Assets.Global;
using Assets.Script.Global.View.fleetStrateg;
using Assets.Script.strategChess;
using NUnit.Framework;
using RTS;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class strategChessView : MonoBehaviour
{
    public UnityEngine.UI.Button ButtonLeft;
    public UnityEngine.UI.Button ButtonRight;
    public UnityEngine.UI.Button ButtonTurn;
    public UnityEngine.UI.Button ButtonLanding;
    public UnityEngine.UI.Button ButtonFire;

    public GameObject GlobalGround;
    public GameObject PlanetIsland;
    public GameObject StrategShipUnit;
    public GameObject TilePrefab;
    public GameObject ChestPrefab;
   
    public Camera MainCamera;
    public Text MoneyText;


    private bool viewPortButton = false;
    public static InfoFleet _selectFleet;
    public static InfoPlanet _selectPlanet;
    public static bool viewBombButton = false;
    List<UnityEngine.Vector2> TileLevelPathList = new List<UnityEngine.Vector2>() {
            new UnityEngine.Vector2(1f, 0f),
            new UnityEngine.Vector2(0f, 1f),
            new UnityEngine.Vector2(0f, -1f),
            new UnityEngine.Vector2(-1f, 0f) };
    public GameObject Bullet;

    static strategChessView _strategChessView;
    private List<GameObject> pathMoveList;

    void Start()
    {
        _strategChessView = this;
        // Ставим землю.
        var _globalGround = (GameObject)Instantiate(GlobalGround,new UnityEngine.Vector3(5.12f,3.00f,4.9f), UnityEngine.Quaternion.identity);

        // Раставляем планеты.
        //foreach (InfoPlanet planet in GlobalConf.GetTownList())
       // {

         //   GameObject strPlanet = (GameObject)Instantiate(PlanetIsland, new UnityEngine.Vector3(planet.coordinate.x, 2.95f, planet.coordinate.y), UnityEngine.Quaternion.identity);


         //   Fleet fleet = strPlanet.GetComponent<Fleet>();


         //   fleet.SetParam(planet.id, planet.player, planet.name, new UnityEngine.Vector2(planet.coordinate.x, planet.coordinate.y), 0, 0);
       // }
        //расставляем ящики
        foreach(GridTileBar gridTileBar in GlobalConf.GetGridTileList())
        {
            if (gridTileBar.Tile == 3)
            {
                GameObject strPlanet = (GameObject)Instantiate(ChestPrefab, new UnityEngine.Vector3(gridTileBar.SpotX, 3.55f, gridTileBar.SpotY), UnityEngine.Quaternion.identity);
            }
        }


        MainCamera.transform.position = new UnityEngine.Vector3(3.62f, 7.05f, -10.0f);

        ButtonTurn.onClick.AddListener(() => TurnStrateg());
        ButtonLeft.onClick.AddListener(() => UnitPlayerLeft());
        ButtonRight.onClick.AddListener(() => UnitPlayerRight());
        ButtonLanding.onClick.AddListener(() => TownLanding());
       ButtonFire.onClick.AddListener(() => Fire());

        RusticEventTile.HappyBirthday += new EventHandler(CommandMovePlayer);


        this.pathMoveList = new List<GameObject>();
    }
    void Fire()
    {
        var fleetObj = GetFleetSceneWithId(BattlePlanetModel.GetSelectHeroId());
        Fleet fleetUnit = fleetObj.GetComponent<Fleet>();
        fleetUnit.Shoot();
       
        //fleet.SetActive(false);
       //var bullet =  Instantiate(Bullet);
        // fleet.transform.position = new UnityEngine.Vector3(0,0,0);
       // bullet.GetComponent<Rigidbody>().AddForce(transform.forward *20);

        //bullet.transform.SetParent(fleet.transform);
       // GameObject b = Instantiate(Bullet, transform.position, transform.rotation);
       // b.GetComponent<Rigidbody>().AddForce(Vector3.forward * Power, ForceMode.Impulse);
    }

    void TurnStrateg()
    {
       // Debug.Log("!!!!!!!!!  CommandPlayer  th PathLast.X  =  PathLast.   fleet id = ");
     //   EventListeren.eventDispatchEvent(CommandState.Turn.ToString(), "");
        GlobalConf.Turn();
    }

    List<PathMove> GetPathList()
    {
        List<ButtonEvent> pathList = (List<ButtonEvent>)GlobalConf.GetPath();

        List<PathMove> tilePathList = new List<PathMove>();
        foreach (ButtonEvent item in pathList)
        {

            tilePathList.Add(new PathMove(item.PathGoto_ar, item, GlobalConf.GetIdSelectUnit()));
        }
        return tilePathList;
    }

    void UnitPlayerLeft()
    {
        

        ButtonEvent buttonEvent = GetButtonEventHeoSelect();

        ControllerButton.EventCall(ControllerConstant.SelectHeroLeft, ControllerConstant.SelectHeroLeft, buttonEvent);
List<PathMove> tilePathList = GetPathList();
        changefleetRotation(BattlePlanetModel.GetSelectHeroId(), tilePathList);
   

        Debug.Log(" fleet = " + BattlePlanetModel.GetSelectHeroId() + "     State = " + buttonEvent.HeroFleet.GetId());
    }

    void UnitPlayerRight()
    {
        

        ButtonEvent buttonEvent = GetButtonEventHeoSelect();
        ControllerButton.EventCall(ControllerConstant.SelectHeroRight, ControllerConstant.SelectHeroRight, buttonEvent);
List<PathMove> tilePathList = GetPathList();
        changefleetRotation(BattlePlanetModel.GetSelectHeroId(), tilePathList);

        
    }
    private ButtonEvent GetButtonEventHeoSelect()
    {
        int selectHeroId = BattlePlanetModel.GetSelectHeroId();
        GridFleet gridFleet = BattlePlanetModel.GetHeroWithId(MapWorldModel._prototypeHeroDemo.GetHeroFleet(), selectHeroId);
        ButtonEvent buttonEvent = new ButtonEvent();
        buttonEvent.HeroFleet = gridFleet;
        return buttonEvent;
    }

    //public void changefleetRotation(int floorId, List<PathMove> tileLevelPathList)
    //{

       // ClickMouseShipPlayerInstantiatePath(floorId, tileLevelPathList);



    //}
    public void changefleetRotation(int id, List<PathMove> tileLevelPathList)
    {


        foreach (InfoFleet fleet in GlobalConf.GetViewFleetList())
        {


            if (fleet.id == id)
            {

                if (fleet.player)
                {
                    if (fleet.countTurn > 0)
                    {
                        ResetPathMoveList();
                        // ADD TILE select
                        foreach (PathMove point in tileLevelPathList)
                        {
                            if (fleet.coordinate.x + point.PathLast.X >= 0 && fleet.coordinate.y + point.PathLast.Y >= 0)
                            {
                                if (fleet.coordinate.x + point.PathLast.X < GlobalConf.widthMap && fleet.coordinate.y + point.PathLast.Y < GlobalConf.heightMap)
                                {
                                    Debug.Log(tileLevelPathList.First().FleetId+"  pathMoveList id = " + id);
                                    GameObject tile = InstantiateCreatePathSelectMove(fleet, point, id);
                                    this.pathMoveList.Add(tile);
                                }
                            }
                        }
                    }


                }

                ViewGlobal.selViewGlobal.SetSelectNameId((int)fleet.imageId);

                _selectFleet = fleet;
                selectFleet(fleet);

            }

        }


    }

    void TownLanding()
    {
        ViewGlobal._selectFleet.useLand = true;
        ViewGlobal._selectFleet.useBomb = true;
        ViewGlobal.viewBombButton = false;

        ViewGlobal._selectPlanet = ModelGlobal.getFleedAbovePlanet((int)ViewGlobal._selectFleet.coordinate.x, (int)ViewGlobal._selectFleet.coordinate.y);
        ViewGlobal.attackPlanet(ViewGlobal._selectFleet, ViewGlobal._selectPlanet);
    }
    GameObject GetFleetSceneWithId(int IdFleet)
    {
        //GameObject[] shipObj_ar = GameObject.FindGameObjectsWithTag("fleet");
        GameObject[] shipObj_ar = GetAllFleetMap();
        GameObject fleet = GetFleetWithId(shipObj_ar, IdFleet);
        return fleet;
    }
    GameObject GetFleetWithId(GameObject[] ship_ar, int IdFleet)
    {
        foreach (GameObject fleet in ship_ar)
        {

            Fleet fleetUnit = fleet.GetComponent<Fleet>();

            //foreach (InfoFleet floor in GlobalConf.GetViewFleetList())
          //  {
                if (fleetUnit.id == IdFleet)
                {

                    return fleet;


                }
           // }



        }
        return null;
    }

    // показываем каждый раз флот.
    void DrawFleet()
    {

        MouseActivity();

        // move ship
        //GameObject[] shipObj_ar = GameObject.FindGameObjectsWithTag("fleet");
        GameObject[] shipObj_ar = GetAllFleetMap();
        List<int> id_ar = new List<int>();

        foreach (GameObject fleetObj in shipObj_ar)
        {

            Fleet fleetUnit = fleetObj.GetComponent<Fleet>();

            if (fleetObj == null)
            {
                Destroy(fleetObj);
                return;
            }
            InfoFleet modelFleet = GlobalConf.GetViewFleetList().Where(a => a.id == fleetUnit.id).FirstOrDefault();
        //   Debug.Log(" Player  FALSE   fleetUnit.id" + fleetUnit.id);
            if (fleetUnit.GetStateMove())
            {
                fleetUnit.GetState().MoveX -= (fleetUnit.GetState().OldPoint.X - fleetUnit.GetState().GetFirstDestination().X) * 0.01f;
                fleetUnit.GetState().MoveY -= (fleetUnit.GetState().OldPoint.Y - fleetUnit.GetState().GetFirstDestination().Y) * 0.01f;

                float dist = GetDistance(new UnityEngine.Vector2(fleetUnit.GetState().MoveX, fleetUnit.GetState().MoveY),
                    new UnityEngine.Vector2(fleetUnit.GetState().GetFirstDestination().X, fleetUnit.GetState().GetFirstDestination().Y));

                
                fleetObj.transform.position = new UnityEngine.Vector3(fleetUnit.GetState().MoveX, 3, fleetUnit.GetState().MoveY);

                fleetUnit.RotationFleet(fleetUnit.GetState().GetFirstDestination(),10);

                //var aimRotation = UnityEngine.Quaternion.LookRotation(new UnityEngine.Vector3(fleetUnit.GetState().GetFirstDestination().X, 0, fleetUnit.GetState().GetFirstDestination().Y) - new UnityEngine.Vector3(fleetObj.transform.position.x, 0, fleetObj.transform.position.z));
                //fleetObj.transform.rotation = UnityEngine.Quaternion.RotateTowards(fleetObj.transform.rotation, aimRotation, 10);
                fleetUnit.SetAnimation("move");
               // fleetUnit.SetAnimation("gogo", 2, "gogo", 6);

                if (0.1f > dist)
                {
                    NormalizeFleet(fleetObj, fleetUnit.GetState().GetFirstDestination().X, fleetUnit.GetState().GetFirstDestination().Y);
                    if (fleetUnit.GetState().NextDestination() == false)
                    {
                        fleetUnit.ResetStateMove();
                    }


                    Debug.Log(BattlePlanetModel.GetSelectHeroId()+" moveX = STOP  move = " + fleetUnit.id);

                }

            }
            else
            {
                // Debug.Log(fleet+"     move  x   move  "+ modelFleet);
                //  fleetUnit.SetAnimation("gogo", 1, "gogo", 5);
                fleetUnit.SetAnimation("attack");
               // fleetUnit.SetAnimation("gogo",3, "gogo", 7);
                if (modelFleet != null)
                {
                    NormalizeFleet(fleetObj, modelFleet.coordinate.x, modelFleet.coordinate.y);
                }
            }
            id_ar.Add(fleetUnit.id);



        }


        if (id_ar.Count < GlobalConf.GetViewFleetList().Count)
        {

            addFleetMass(id_ar);

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


    }
    private void NormalizeFleet(GameObject fleet, float X, float Y)
    {
        fleet.transform.position = new UnityEngine.Vector3(X, 3, Y);
    }
    public static void CommandMovePlayer(object sender, EventArgs e)
    {
        PathMove pathMove = sender as PathMove;
       


        _strategChessView.MoveFleetAnimationState(pathMove);



        ControllerButton.EventCall(ControllerConstant.PathHero, ControllerConstant.PathHero, pathMove.ButtonEvent);


    }
    GameObject[] GetAllFleetMap()
    {
        return GameObject.FindGameObjectsWithTag("fleet");
    }
    public void MoveFleetAnimationState(PathMove pathMove)
    {
        //GameObject[] shipObj_ar = GameObject.FindGameObjectsWithTag("fleet");
        GameObject[] shipObj_ar = GetAllFleetMap();


        var fleetObj = GetFleetWithId(shipObj_ar, pathMove.FleetId);
        if (fleetObj != null)
        {
            Fleet fleetUnit = fleetObj.GetComponent<Fleet>();
            Debug.Log(pathMove.PathList.Count + " SpotX = " + fleetUnit.SpotX + " = tile  SpotY = " + fleetUnit.SpotY);
            List<Point> pathMoveList = pathMove.PathList;
            pathMoveList.RemoveAt(0);

           

            fleetUnit.StateMove = new StateMoveFleet(true, fleetUnit.SpotX, fleetUnit.SpotY, pathMoveList);
        }

    }
    float GetDistance(UnityEngine.Vector2 positionTile, UnityEngine.Vector2 positionUnit)
    {
        float dist = UnityEngine.Vector3.Distance(positionTile, positionUnit);
        return dist;
    }


    void addFleetMass(List<int> id_ar)
    {

        foreach (InfoFleet byFleet in GlobalConf.GetViewFleetList())
        {
            bool fleetYes = false;

            foreach (int use_id in id_ar)
            {

                if (use_id == byFleet.id)
                {

                    fleetYes = true;

                    continue;
                }




            }
            if (!fleetYes)
            {
                InstantiateCreateViewFleet(byFleet);
            }

        }

    }
    public static void attackPlanet(InfoFleet InnerSelectFleet, InfoPlanet InnerPlanet)
    {

        var I = new JSONClass();
        I["x"] = InnerSelectFleet.coordinate.x.ToString();
        I["y"] = InnerSelectFleet.coordinate.y.ToString();
        I["id"] = InnerSelectFleet.id.ToString();
        EventListeren.eventDispatchEvent(CommandState.PlanetLanding.ToString(), I.ToString());

        gotoPlanet(InnerPlanet.name, InnerPlanet.id, (int)InnerSelectFleet.coordinate.x, (int)InnerSelectFleet.coordinate.y, true);
    }
    private Fleet InstantiateCreateViewFleet(InfoFleet floorFleet)
    {
        
        GameObject strShip = Instantiate(StrategShipUnit, new UnityEngine.Vector3(floorFleet.coordinate.x, 3, floorFleet.coordinate.y), UnityEngine.Quaternion.identity);


        Fleet fleet = strShip.GetComponent<Fleet>();

        fleet.SetParam(floorFleet.id, floorFleet.player, floorFleet.name, new UnityEngine.Vector2(floorFleet.coordinate.x, floorFleet.coordinate.y), floorFleet.SpotX, floorFleet.SpotY);

        GlobalConf.StrategShip_ar.Add(strShip);

        return fleet;
    }
    private static void gotoPlanet(string name, int id, int x, int y, bool attack)
    {



        var textI = new JSONClass();
        textI["name"] = name;
        textI["idPlanet"] = id.ToString();
        textI["state"] = (attack).ToString();
        textI["x"] = ((int)x).ToString();
        textI["y"] = ((int)y).ToString();

        EventListeren.eventDispatchEvent(CommandState.PlanetPanel.ToString(), textI.ToString());

    }
    private void MouseActivity()
    {
        if (Input.GetMouseButtonDown(0))
        {

            LeftMouseClick();
        }
    }
    private void LeftMouseClick()
    {
        
        GameObject hitObject = FindHitObject();


        if (hitObject != null)
        {
            Fleet fleet = hitObject.GetComponent<Fleet>();

            

            if (fleet !=null)
            {
                Debug.Log("===== Target ==== === fleet ="+ fleet);
                //fleet.SetTarget();
                SetTargetOnlyOne(fleet);
                RotationSelectFleetOnTarget(fleet);
            }

            if (hitObject.name == "Tile(Clone)")
            {
                TilePath tileClass = hitObject.GetComponent<TilePath>();


                //clickTile((int)tileClass.coordinat.x, (int)tileClass.coordinat.y, tileClass.id);
            }
            if (hitObject.name == "Planet(Clone)")
            {
                InfoPlanet c = ModelGlobal.PlanetSelectCoordinate((int)hitObject.transform.position.x, (int)hitObject.transform.position.z);


                if (c.player)
                {
                    gotoPlanet(c.name, c.id, (int)hitObject.transform.position.x, (int)hitObject.transform.position.z, false);

                }
                else
                {

                    //Message.message("Это вражеская планета!");
                    var textI = new JSONClass();
                    textI["image"] = "planet";
                    textI[CommandState.Message.ToString()] = "Это вражеская планета!";
                    EventListeren.eventDispatchEvent(CommandState.Message.ToString(), textI.ToString());
                }
            }
        }

        UnityEngine.Cursor.visible = true;
    }
    void RotationSelectFleetOnTarget(Fleet targetFleetObj)
    {
        var fleetObj = GetFleetSceneWithId(BattlePlanetModel.GetSelectHeroId());
        Fleet fleetUnit = fleetObj.GetComponent<Fleet>();
        Debug.Log("d =    fleetUnit   First  Get modelFleet    First  GetState()  move ="  );

        fleetUnit.RotationFleet(new Point(targetFleetObj.SpotX, targetFleetObj.SpotY),360);
    }
    void SetTargetOnlyOne(Fleet fleet)
    {
        GameObject[] shipObj_ar = GetAllFleetMap();
        foreach(var itemFleet in shipObj_ar)
        {
            Fleet fleetClass = itemFleet.GetComponent<Fleet>();
            fleetClass.VisibleTarget(false);
        }
        fleet.VisibleTarget(true);
    }
    GameObject InstantiateCreatePathSelectMove(InfoFleet fleet, PathMove point, int id)
    {
        GameObject tile = (GameObject)Instantiate(TilePrefab, new UnityEngine.Vector3(point.PathLast.X, 3 + 0.1f, point.PathLast.Y), UnityEngine.Quaternion.identity);
        TilePath tileClass = tile.GetComponent<TilePath>();
        tileClass.SetParam(id, point);
        tileClass.SetCoordinate(new UnityEngine.Vector2(point.PathLast.X, point.PathLast.Y));


        return tile;
    }
    void ResetPathMoveList()
    {
        foreach (var item in this.pathMoveList)
        {
            Destroy(item);
        }
        this.pathMoveList.Clear();
    }








    private GameObject FindHitObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject;
        }
        return null;
    }
    /*
    void resetSelectFleet()
    {
        viewPortButton = false;
    }
    */
    public void selectFleet(InfoFleet InnerSelectFleet)
    {
        GameObject[] shipObj_ar = GameObject.FindGameObjectsWithTag("fleet");



        var fleetObj = GetFleetWithId(shipObj_ar, InnerSelectFleet.id);
        if (fleetObj != null)
        {
            Fleet fleet = fleetObj.GetComponent<Fleet>();

            fleet.SetColorFleet();


            var I = new JSONClass();
            I["id"] = InnerSelectFleet.id.ToString();
            EventListeren.eventDispatchEvent(CommandState.ClickFleet.ToString(), I.ToString());
        }
    }
    void Update()
    {
        DrawFleet();
        if (ViewGlobal.viewBombButton)
        {

            // visButton(1);
        }
        else
        {

            // visButton(0);

        }
        MoneyText.text = "money: " + GlobalConf.Money[0];
        MoveCamera();
        RotateCamera();
    }
    private void MoveCamera()
    {
        
        float xpos = Input.mousePosition.x;
        float ypos = Input.mousePosition.y;
        UnityEngine.Vector3 movement = new UnityEngine.Vector3(0, 0, 0);
        bool mouseScroll = false;

        //if (!blockScrollLever)
        // {
        // Блокировка от типа карты.

        // Тактическая карта.
        UnityEngine.Vector2 blockScreen_x = GlobalConf.BlockScreenScroll_ar[0].Position_x;
        UnityEngine.Vector2 blockScreen_z = GlobalConf.BlockScreenScroll_ar[0].Position_z;
        if (!Player._goBattle)
        {
            // Глобальная карта
            blockScreen_x = GlobalConf.BlockScreenScroll_ar[1].Position_x;
            blockScreen_z = GlobalConf.BlockScreenScroll_ar[1].Position_z;
        }
        if (GlobalConf.ModeStickBattle)
        {
            // Stick Battle
            blockScreen_x = GlobalConf.BlockScreenScroll_ar[2].Position_x;
            blockScreen_z = GlobalConf.BlockScreenScroll_ar[2].Position_z;
            ;
            //Camera.main.transform.eulerAngles = GlobalConf.StickBattleRotateCamera;
        }


        /////////
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("==========WWWWWWWWWWWW pressed.===============");
            movement.x += ResourceManager.ScrollSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("==========WWWWWWWWWWWW pressed.===============");
            movement.x -= ResourceManager.ScrollSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("==========WWWWWWWWWWWW pressed.===============");
            movement.z += ResourceManager.ScrollSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("==========WWWWWWWWWWWW pressed.===============");
            movement.z -= ResourceManager.ScrollSpeed;
        }
        ///////
        try
        {
            //horizontal camera movement
            if (xpos >= 0 && xpos < ResourceManager.ScrollWidth && Camera.main.transform.position.x > blockScreen_x.x)
            {

                if (GlobalConf.ModeStickBattle) { Camera.main.transform.eulerAngles = StickBattle.StickBattleRotateCamera; }

                // Движение камеры влево
                movement.x -= ResourceManager.ScrollSpeed;
                //SetCursorState(CursorState.PanLeft);
                mouseScroll = true;
            }
            //else if (CameraScrollRight(xpos, blockScreen_x))
            // {
            // if (GlobalConf.ModeStickBattle)
            //  { Camera.main.transform.eulerAngles = StickBattle.StickBattleRotateCamera; }

            // Движение камеры вправо
            //   movement.x += ResourceManager.ScrollSpeed;
            //SetCursorState(CursorState.PanRight);
            //   mouseScroll = true;


            // }
        }
        catch
        {
            Debug.LogWarning("horizontal camera movement");
        }
        try
        {
            //vertical camera movement
            if (ypos >= 0 && ypos < ResourceManager.ScrollWidth && Camera.main.transform.position.z > blockScreen_z.x)
            {
                movement.z -= ResourceManager.ScrollSpeed;
                // SetCursorState(CursorState.PanDown);
                mouseScroll = true;
            }
            else if (ypos <= Screen.height && ypos > Screen.height - ResourceManager.ScrollWidth - 40 && Camera.main.transform.position.z < blockScreen_z.y)
            {
                movement.z += ResourceManager.ScrollSpeed;
                //  SetCursorState(CursorState.PanUp);
                mouseScroll = true;

            }
        }
        catch
        {
            Debug.LogWarning("vertical camera movement");
        }
        //    }


        //make sure movement is in the direction the camera is pointing
        //but ignore the vertical tilt of the camera to get sensible scrolling
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0;

        //away from ground movement
        movement.y -= ResourceManager.ScrollSpeed * Input.GetAxis("Mouse ScrollWheel");

        //calculate desired camera position based on received input
        UnityEngine.Vector3 origin = Camera.main.transform.position;
        UnityEngine.Vector3 destination = origin;
        destination.x += movement.x;
        destination.y += movement.y;
        destination.z += movement.z;

        //limit away from ground movement to be between a minimum and maximum distance
        if (destination.y > ResourceManager.MaxCameraHeight)
        {
            destination.y = ResourceManager.MaxCameraHeight;
        }
        else if (destination.y < ResourceManager.MinCameraHeight)
        {
            destination.y = ResourceManager.MinCameraHeight;
        }

        //if a change in position is detected perform the necessary update
        if (destination != origin)
        {
            Camera.main.transform.position = UnityEngine.Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.ScrollSpeed);
        }




    }
    private void RotateCamera()
    {
        UnityEngine.Vector3 origin = Camera.main.transform.eulerAngles;
        UnityEngine.Vector3 destination = origin;

        //detect rotation amount if ALT is being held and the Right mouse button is down
        //if((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetMouseButton(1)) {
        if (Input.GetKey("down") || Input.GetMouseButton(1))
        {

            destination.x -= Input.GetAxis("Mouse Y") * ResourceManager.RotateAmount;
            destination.y += Input.GetAxis("Mouse X") * ResourceManager.RotateAmount;
        }

        //if a change in position is detected perform the necessary update
        if (destination != origin)
        {
            Camera.main.transform.eulerAngles = UnityEngine.Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.RotateSpeed);
        }
    }
}
