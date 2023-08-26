using Assets.Script.Global.View.fleetStrateg;
using Assets.Script.strategChess;
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

    public GameObject GlobalGround;
    public GameObject PlanetIsland;
    public GameObject StrategShipUnit;
    public GameObject Tile;
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

    static strategChessView _strategChessView;
    private List<GameObject> _pathMoveList;

    void Start()
    {
        _strategChessView = this;
        // Ставим землю.
        var _globalGround = Instantiate(GlobalGround);

        // Раставляем планеты.
        foreach (InfoPlanet planet in GlobalConf.GetTownList())
        {

            GameObject strPlanet = (GameObject)Instantiate(PlanetIsland, new UnityEngine.Vector3(planet.coordinate.x, 2.95f, planet.coordinate.y), UnityEngine.Quaternion.identity);


            Fleet fleet = strPlanet.GetComponent<Fleet>();


            fleet.SetParam(planet.id, planet.player, planet.name, new UnityEngine.Vector2(planet.coordinate.x, planet.coordinate.y), 0, 0);
        }

        MainCamera.transform.position = new UnityEngine.Vector3(3.62f, 7.05f, -10.0f);

        ButtonTurn.onClick.AddListener(() => TurnStrateg());
        ButtonLeft.onClick.AddListener(() => UnitPlayerLeft());
        ButtonRight.onClick.AddListener(() => UnitPlayerRight());
        ButtonLanding.onClick.AddListener(() => TownLanding());

        RusticEventTile.HappyBirthday += new EventHandler(CommandMovePlayer);


        this._pathMoveList = new List<GameObject>();
    }

    void TurnStrateg()
    {
        EventListeren.eventDispatchEvent(CommandState.Turn.ToString(), "");
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
        List<PathMove> tilePathList = GetPathList();

        ButtonEvent buttonEvent = GetButtonEventHeoSelect();

        ControllerButton.EventCall(ControllerConstant.SelectHeroLeft, ControllerConstant.SelectHeroLeft, buttonEvent);

        changefleetRotation(buttonEvent.HeroFleet.GetId(), tilePathList);
        //ViewGlobal.selectFleetCount = 0;

        Debug.Log("===== =======   Gam ===============  id =" + GlobalConf.GetIdSelectUnit());
    }
    private ButtonEvent GetButtonEventHeoSelect()
    {
        int selectHeroId = BattlePlanetModel.GetSelectHeroId();
        GridFleet gridFleet = BattlePlanetModel.GetHeroWithId(MapWorldModel._prototypeHeroDemo.GetHeroFleet(), selectHeroId);
        ButtonEvent buttonEvent = new ButtonEvent();
        buttonEvent.HeroFleet = gridFleet;
        return buttonEvent;
    }

    public void changefleetRotation(int floorId, List<PathMove> tileLevelPathList)
    {

        ClickMouseShipPlayerInstantiatePath(floorId, tileLevelPathList);



    }
    public void ClickMouseShipPlayerInstantiatePath(int id, List<PathMove> tileLevelPathList)
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

                                    GameObject tile = InstantiateCreatePathSelectMove(fleet, point, id);
                                    this._pathMoveList.Add(tile);
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

    void UnitPlayerRight()
    {
        List<PathMove> tilePathList = GetPathList();

        ButtonEvent buttonEvent = GetButtonEventHeoSelect();
        ControllerButton.EventCall(ControllerConstant.SelectHeroRight, ControllerConstant.SelectHeroRight, buttonEvent);

        changefleetRotation(buttonEvent.HeroFleet.GetId(), tilePathList);

    }
    void TownLanding()
    {
        ViewGlobal._selectFleet.useLand = true;
        ViewGlobal._selectFleet.useBomb = true;
        ViewGlobal.viewBombButton = false;

        ViewGlobal._selectPlanet = ModelGlobal.getFleedAbovePlanet((int)ViewGlobal._selectFleet.coordinate.x, (int)ViewGlobal._selectFleet.coordinate.y);
        ViewGlobal.attackPlanet(ViewGlobal._selectFleet, ViewGlobal._selectPlanet);
    }

    GameObject GetFleetWithId(GameObject[] ship_ar, int IdFleet)
    {
        foreach (GameObject fleet in ship_ar)
        {

            Fleet fleetUnit = fleet.GetComponent<Fleet>();

            foreach (InfoFleet floor in GlobalConf.GetViewFleetList())
            {
                if (fleetUnit.id == IdFleet)
                {

                    return fleet;


                }
            }



        }
        return null;
    }

    // показываем каждый раз флот.
    void DrawFleet()
    {

        MouseActivity();

        // move ship
        GameObject[] shipObj_ar = GameObject.FindGameObjectsWithTag("fleet");
        List<int> id_ar = new List<int>();

        foreach (GameObject fleet in shipObj_ar)
        {

            Fleet fleetUnit = fleet.GetComponent<Fleet>();

            GameObject fleetObj = GetFleetWithId(shipObj_ar, fleetUnit.id);
            if (fleetObj == null)
            {
                Destroy(fleet);
                return;
            }
            InfoFleet modelFleet = GlobalConf.GetViewFleetList().Where(a => a.id == fleetUnit.id).FirstOrDefault();
            if (fleetUnit.GetStateMove())
            {
                fleetUnit.GetState().MoveX -= (fleetUnit.GetState().OldPoint.X - fleetUnit.GetState().GetFirstDestination().X) * 0.01f;
                fleetUnit.GetState().MoveY -= (fleetUnit.GetState().OldPoint.Y - fleetUnit.GetState().GetFirstDestination().Y) * 0.01f;

                float dist = GetDistance(new UnityEngine.Vector2(fleetUnit.GetState().MoveX, fleetUnit.GetState().MoveY),
                    new UnityEngine.Vector2(fleetUnit.GetState().GetFirstDestination().X, fleetUnit.GetState().GetFirstDestination().Y));

                Debug.Log("dist  = " + dist + "     StateMove id = " + fleetUnit.id + "  First  GetState().x= " + fleetUnit.GetState().GetFirstDestination().X + "  First  GetState().y=  " + fleetUnit.GetState().GetFirstDestination().Y + "  move =" + fleet.transform.position);
                //fleet.transform.position = new UnityEngine.Vector3(fleet.transform.position.x + fleetUnit.GetState().X*0.01f, 3, fleet.transform.position.y + fleetUnit.GetState().Y * 0.01f);
                fleet.transform.position = new UnityEngine.Vector3(fleetUnit.GetState().MoveX, 3, fleetUnit.GetState().MoveY);

                Debug.Log(dist + "     move  x " + fleetUnit.GetState().MoveX + " = ti move y = " + fleetUnit.GetState().MoveY);

                var aimRotation = UnityEngine.Quaternion.LookRotation(new UnityEngine.Vector3(fleetUnit.GetState().GetFirstDestination().X, 0, fleetUnit.GetState().GetFirstDestination().Y) - new UnityEngine.Vector3(fleetObj.transform.position.x, 0, fleetObj.transform.position.z));
                fleetObj.transform.rotation = UnityEngine.Quaternion.RotateTowards(fleetObj.transform.rotation, aimRotation, 10);

                fleetUnit.SetAnimation("gogo", 2, "gogo", 6);

                if (0.1f > dist)
                {
                    NormalizeFleet(fleet, fleetUnit.GetState().GetFirstDestination().X, fleetUnit.GetState().GetFirstDestination().Y);
                    if (fleetUnit.GetState().NextDestination() == false)
                    {
                        fleetUnit.ResetStateMove();
                    }


                    Debug.Log(" moveX = STOP  moveY = ");

                }

            }
            else
            {
                fleetUnit.SetAnimation("gogo", 1, "gogo", 5);
                NormalizeFleet(fleet, modelFleet.coordinate.x, modelFleet.coordinate.y);
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
        Debug.Log("!!!!!!!!!!!!! CommandPlayer = " + sender + "-  th PathLast.X =" + pathMove.PathLast.X + "==  PathLast.Y =" + pathMove.PathLast.Y + "    fleet id = " + pathMove.FleetId);


        _strategChessView.MoveFleetAnimationState(pathMove);



        ControllerButton.EventCall(ControllerConstant.PathHero, ControllerConstant.PathHero, pathMove.ButtonEvent);


    }
    public void MoveFleetAnimationState(PathMove pathMove)
    {
        GameObject[] shipObj_ar = GameObject.FindGameObjectsWithTag("fleet");



        var fleetObj = GetFleetWithId(shipObj_ar, pathMove.FleetId);
        Fleet fleetUnit = fleetObj.GetComponent<Fleet>();
        Debug.Log(pathMove.PathList.Count + " SpotX = " + fleetUnit.SpotX + " = tile  SpotY = " + fleetUnit.SpotY);
        List<Point> pathMoveList = pathMove.PathList;
        pathMoveList.RemoveAt(0);

        Debug.Log(pathMove.PathList.Count + " -- " + pathMoveList.Count + " Last   x" + pathMove.PathLast.X + " = Cl y = " + pathMove.PathLast.Y + "   name = " + fleetUnit.name);

        fleetUnit.StateMove = new StateMoveFleet(true, fleetUnit.SpotX, fleetUnit.SpotY, pathMoveList);


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

            if (hitObject.name == "GlobalGround(Clone)")
            {

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

    GameObject InstantiateCreatePathSelectMove(InfoFleet fleet, PathMove point, int id)
    {
        GameObject tile = (GameObject)Instantiate(Tile, new UnityEngine.Vector3(point.PathLast.X, 3 + 0.1f, point.PathLast.Y), UnityEngine.Quaternion.identity);
        TilePath tileClass = tile.GetComponent<TilePath>();
        tileClass.SetParam(id, point);
        tileClass.SetCoordinate(new UnityEngine.Vector2(point.PathLast.X, point.PathLast.Y));
        //tileClass.id = id;
        //tileClass.SetParam( id, point);

        return tile;
    }
    void ResetPathMoveList()
    {
        foreach (var item in this._pathMoveList)
        {
            Destroy(item);
        }
        this._pathMoveList.Clear();
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
    void resetSelectFleet()
    {
        viewPortButton = false;
    }
    public void selectFleet(InfoFleet InnerSelectFleet)
    {
        GameObject[] shipObj_ar = GameObject.FindGameObjectsWithTag("fleet");



        var fleetObj = GetFleetWithId(shipObj_ar, InnerSelectFleet.id);
        Fleet fleet = fleetObj.GetComponent<Fleet>();

        fleet.SetColorFleet();


        var I = new JSONClass();
        I["id"] = InnerSelectFleet.id.ToString();
        EventListeren.eventDispatchEvent(CommandState.ClickFleet.ToString(), I.ToString());
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
    }
}
