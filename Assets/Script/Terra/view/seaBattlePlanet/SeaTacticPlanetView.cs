using System.Collections;
using System.Collections.Generic;

using System;

public class SeaTacticPlanetView 
{
    /*
    // Start is called before the first frame update
    SetFieldArmyView _setFieldArmyView;
    public GameObject TileSand;
    public Sprite ShipSprite;
    public Sprite SelectAttack;
    public Sprite Hide;

    private List<GameObject> TileSandList;
    private List<GameObject> _shipSandList;


    public Button TurnButton;
    CommandStrategy _CommandStrategy;
    SeaAnimationMove _sesAnimationMove;
    SeaTactic _seaTactic;
    public GameObject ExplodePrefabs;
    public GameObject FleetShipTactic;
    public GameObject TextUnitPrefabs;

    List<ButtonEvent> _buttonEvent_ar;
    float _SlipX = -4;
    float _SlipY = -2;
    List<GameObject> _pathHeroGameObjectList;
    List<GameObject> _pathAttackHeroGameObjectList;
    BattlePlanetModel _battlePlanetModel;
    
    public List<GameObject> SceneList;
    
    Vector3 scaleSea = new Vector3(2.5f, 1, 1);


    void Start()
    {


        SetSpriteTile(Hide);


        // Debug tactic
        MockGlobalPlanet mockGlobalPlanet = new MockGlobalPlanet(true);
        //SceneList = new List<GameObject>();
        

        TurnButton.onClick.AddListener(() => TurnButtonMethod(TurnButton));
        _sesAnimationMove = new SeaAnimationMove();
        _setFieldArmyView = new SetFieldArmyView();

        _shipSandList = new List<GameObject>();

        int Width = 6;
        int Height = 6;
        bool test = true;

        if (test)
        {
            SetTestField(Width, Height, 6, GlobalParamView.widthPanelBattlePlanet, TileSand, _SlipX, _SlipY);
        }

        
        _seaTactic = new SeaTactic(MapWorldModel._prototypeHeroDemo.GetHeroFleet()[0], MapWorldModel._prototypeHeroDemo.GetHeroFleet()[1], 0);
    

        _setFieldArmyView.InitUnitToField(
                 Width,
                 GetHeightBattleField(Height),
                 null,//SeaTactic.GetPlayerFleet().GetShipName().get(SeaTactic.SelectShipPlayer),
                 true, GlobalParamView.widthPanelBattlePlanet,
                 true);



        SetFleetField(_SlipX, _SlipY);

        //Path
        
        

        SeaTactic.GetTactic()._seaChangeStateView = true;

        if (SeaTactic.GetTactic()._seaChangeStateView == true)
        {
ButtonEvent selectHero = new ButtonEvent();
            selectHero.IdHero = 97;
            _seaTactic.SeaSelectHero(selectHero);
            List<ButtonEvent> pathButtonEventList = GetButtonEventPathList(_seaTactic.GetSeaSelectHeroId());
            
            _buttonEvent_ar = pathButtonEventList;
            
            DrawPathHero(_SlipX, _SlipY, -5, _buttonEvent_ar);

        }
       
        // _sesAnimationMove.InitArrange( _setFieldArmyView, _seaTactic);


        //_buttonEvent_ar = GetButtonEventPathList(BattlePlanetModel.GetSelectHeroId());
        //Draw path Player
        //DrawPathHero(_SlipX, _SlipY, -5, _buttonEvent_ar);
    }

    private List<ButtonEvent> GetButtonEventPathList(int SeaSelectHeroId)
    {
        
        CreatePathHero _createPathHero = new CreatePathHero();
        _battlePlanetModel = new BattlePlanetModel();
        return _createPathHero.DrawPath(TileSandList,
                    _battlePlanetModel.GetPathSelectHero(
                        _seaTactic._prototypeHeroSea,
                                 _seaTactic.shoalSea_ar,
                                 new IslandDemoMemento(),
                                 _seaTactic.SeaGridTile_ar,
                                 ControllerConstant.PathHero,
                                 ControllerConstant.AttackHero,
                                 false,
                                 null,
                                 null,
                                 0,
                                 0,
                                 SeaSelectHeroId,
                                 //_seaTactic.GetSeaSelectHeroId(),
                                 0
                                 //BattlePlanetModel.FlagIdHero
                                 ),
                    0,
                    GlobalParamView.widthPanelBattlePlanet,
                    6, 6);
    }


    public void DrawPathHero(float SlipX, float SlipY, int Depth, List<ButtonEvent> buttonEvent_ar)
    {
        DestroyDrawPathHero();

        if (buttonEvent_ar != null)
        {
            int idPathHero = 0;
            foreach (ButtonEvent buttonEvent in buttonEvent_ar)
            {

                SetSpriteTile(Hide);
                GameObject hideTilePath = ReplaceTile(SlipX, SlipY, (int)buttonEvent.Point.X, (int)buttonEvent.Point.Y, idPathHero, Depth, false);
                /////
                //hideTilePath.transform.localScale = new Vector3(3, 3, 1);
                hideTilePath.transform.localScale =  scaleSea ;
                Point replaceCoordinate = GetReplaceCoordinate((int)buttonEvent.Point.X, (int)buttonEvent.Point.Y, SlipX, SlipY);
                hideTilePath.transform.position = new Vector3(replaceCoordinate.X, replaceCoordinate.Y,-1);
                /////
                
                TileSand tileSandScript = hideTilePath.GetComponent<TileSand>();
                tileSandScript.SetActionFunction(MouseDownPathActionFunction);

                _pathHeroGameObjectList.Add(hideTilePath);
                idPathHero++;
            }
        }
    }
    void DestroyDrawPathHero()
    {
        if (_pathHeroGameObjectList != null)
        {
            foreach (GameObject pathHero in _pathHeroGameObjectList)
            {
                Destroy(pathHero);
            }
        }
        _pathHeroGameObjectList = new List<GameObject>();
    }
    void MouseDownPathActionFunction(int IdPath)
    {
        

        int idPathHero = BattlePlanetModel.GetSelectHeroId();

        idPathHero = 0;
        foreach (ButtonEvent buttonEvent in _buttonEvent_ar)
        {

            
            if (idPathHero == IdPath)
            {
                
                ControllerButton.EventCall(ControllerConstant.SeaPathHero, ControllerConstant.SeaPathHero, buttonEvent);
                DestroyDrawPathHero();
            }
            idPathHero++;
        }
        // set select attack fiend hero.
        SetSelectAttackFiendHero();

        GetAttackSemiTarget(-2);
    }
    private List<GridFleet> GetAttackSemiTarget(int Depth)
    {
        
      
        //GridFleet gridFleet = BattlePlanetModel.GetHeroWithId(MapWorldModel._prototypeHeroDemo.GetHeroFleet(), _seaTactic.GetSeaSelectHeroId());

        GridFleet gridFleet = BattlePlanetModel.GetHeroWithId(_seaTactic._prototypeHeroSea.GetHeroFleet(), _seaTactic.GetSeaSelectHeroId());
        Debug.Log(_seaTactic.GetSeaSelectHeroId()+" = SS  on roFle ta  gridFleet = " + gridFleet);

        List<GridFleet> attackSemiTargetList = _battlePlanetModel.SelectHeroAttacSemikPath(gridFleet.GetRange(), gridFleet, _seaTactic._prototypeHeroSea,
        BattlePlanetModel.ShoalSeaBasa_ar);

Debug.Log("attackSemiTargetList.Count = " + attackSemiTargetList.Count+" @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@d = " + _seaTactic._prototypeHeroSea.GetHeroFleet().Count + " nMethod    = " + _seaTactic.GetSeaSelectHeroId());
Debug.Log(gridFleet.GetId()+"_____=@@T d   = " + _seaTactic.GetSeaSelectHeroId()+ "_______  attackSemiTargetList = " + attackSemiTargetList.Count);

        DeleteAttackSemiTarget();
        
        foreach (GridFleet fleet in attackSemiTargetList)
        {
            

            SetSpriteTile(SelectAttack);
            GameObject selectAttackTilePath = ReplaceTile(_SlipX, _SlipY, (int)fleet.SpotX, (int)fleet.SpotY, fleet.GetId(), Depth, false);
            
            //selectAttackTilePath.transform.localScale = new Vector3(2, 2, 1);
            selectAttackTilePath.transform.localScale = scaleSea;
Debug.Log("x= "+fleet.SpotX+"  y= " + fleet.SpotY + " id" + fleet .GetId()+ "  ==== ATT= "+ selectAttackTilePath.transform.position.x+ " =l=  " + selectAttackTilePath.transform.position.z + "   "  );
            //Point replaceCoordinate = GetReplaceCoordinate((int)fleet.SpotX, (int)fleet.SpotY, _SlipX, _SlipY);



            Point replaceCoordinate = GetReplaceCoordinate(fleet.SpotX, fleet.SpotY, _SlipX, _SlipY);
Debug.Log(replaceCoordinate.X+"    =  TileSand    = " + replaceCoordinate.Y);
            selectAttackTilePath.transform.position = new Vector3(replaceCoordinate.X, replaceCoordinate.Y, -1);

            Debug.Log(replaceCoordinate.X+"  = Fleet gridFleetSpeed i=  " + replaceCoordinate.Y);

            TileSand tileSandScript = selectAttackTilePath.GetComponent<TileSand>();
            tileSandScript.SetActionFunction(MouseDownAttackSemiTarget);

            

            _pathAttackHeroGameObjectList.Add(selectAttackTilePath);
        }

        return attackSemiTargetList;
    }
    private void SetSelectAttackFiendHero()
    {
        
        var buttonEvent_ar = GetButtonEventPathList(_seaTactic.GetSeaSelectHeroId());
        int count = 0;
Debug.Log(_seaTactic.GetSeaSelectHeroId()+" = SelectAttackFiend =  d = " + buttonEvent_ar.Count);
        foreach (var item in buttonEvent_ar)
        {

            count++;
        }
    }
    private void DeleteAttackSemiTarget()
    {
        if (_pathAttackHeroGameObjectList != null)
        {
            foreach (var item in _pathAttackHeroGameObjectList)
            {
                Destroy(item);
            }
        }
        _pathAttackHeroGameObjectList = new List<GameObject>();
    }
    void MouseDownAttackSemiTarget(int IdFiendFleet)
    {
        GridFleet gridFleet = BattlePlanetModel.GetHeroWithId(_seaTactic._prototypeHeroSea.GetHeroFleet(), IdFiendFleet);

        
        ButtonEvent buttonEvent = new ButtonEvent();
        buttonEvent.HeroFleet = gridFleet;
        buttonEvent.VictimFleet = _seaTactic._prototypeHeroSea.GetFleetWithId(IdFiendFleet);
        //range?? gridFleet.GetRange();

        Debug.Log(gridFleet+ "  c _____ MouseDown__IdFiendFleet = " + IdFiendFleet + " eaSelectHeroId = " + buttonEvent.VictimFleet);

        bool longRange = ModelStrategy.GetlongRangeDistance(new Point(gridFleet.SpotX, gridFleet.SpotY), new Point(buttonEvent.VictimFleet.SpotX, buttonEvent.VictimFleet.SpotY));
        buttonEvent.LongRange = longRange;



        ControllerButton.EventCall(ControllerConstant.SeaAttackHero, ControllerConstant.SeaAttackHero, buttonEvent);

    }
    private void SetSpriteTile(Sprite sprite)
    {
        GetSpriteTile().sprite = sprite;

    }
    private SpriteRenderer GetSpriteTile()
    {
        //TileSand.transform.localScale = new Vector3(.1f,1f,1f);
        return TileSand.GetComponent<SpriteRenderer>();
    }
    private GameObject ReplaceTile(float SlipX, float SlipY, int GridRow, int GridLine, int Id, int Depth, bool AddSceneList)
    {
        int widthTile = 1;
        TileSand.transform.localScale = new Vector3(1, 1, 1);
        var tileSandObj = Instantiate(TileSand, new Vector3(SlipX + GridRow * widthTile, SlipY + GridLine * widthTile, Depth), Quaternion.identity);
        TileSand tileSandScript = tileSandObj.GetComponent<TileSand>();
        tileSandScript.SpotX = GridRow;
        tileSandScript.SpotY = GridLine;
        tileSandScript.IdTileSand = Id;
        if (AddSceneList)
        {
            SceneList.Add(tileSandObj);
        }
        return tileSandObj;
        //gameObject.GetComponent<ScriptName>().variable;
    }











    void TurnButtonMethod(Button buttonPressed)
    {
        //move
        ControllerButton.EventCall(ControllerConstant.Move, null, null);
       
    }
    public void SetTestField(int widthStage, int HeightStage,
        int DividerField, float WidthPanelBattlePlanet, GameObject TileSand, float SlipX, float SlipY)
    {
        TileSandList = new List<GameObject>();

        //set field test
        for (int i = 0; i < DividerField; i++)
        {
            for (int z = 0; z < DividerField; z++)
            {

                

                GameObject tileSandObj = Instantiate(TileSand, new Vector3(0, 0, 0), Quaternion.identity);

                tileSandObj.transform.localScale = scaleSea;

                Point replaceCoordinate = GetReplaceCoordinate(i, z, SlipX, SlipY);

        
                tileSandObj.transform.position = new Vector3(replaceCoordinate.X, replaceCoordinate.Y);


                var TileSeaView = tileSandObj.GetComponent<TileSand>();
                TileSeaView.SpotX = i;
                TileSeaView.SpotY = z;

                TileSandList.Add(tileSandObj);
            }
        }
    }
    private Point GetReplaceCoordinate(int i, int z, float SlipX, float SlipY)
    {
        return new Point(i + SlipX - (i * 0.19f), z - SlipY - (z * 0.65f));
    }
    public void SetFleetField(float SlipX, float SlipY)
    {
        
        //model
        foreach (GameObject shipFleetGameObject in _shipSandList)
        {
            Destroy(shipFleetGameObject);
        }
        _shipSandList = new List<GameObject>();

        foreach (GridFleet gridFleet in SeaTactic.GetTactic().GetPrototypeHeroDemo().GetHeroFleet())
        {

            foreach (GameObject tileSeaObj in TileSandList)
            {

                //var tileSeaObj = TileSandList[item];
                TileSand tileSand = tileSeaObj.GetComponent<TileSand>();
                tileSand.SetActionFunction(SelectHero);
                if (gridFleet.SpotX == tileSand.SpotX && gridFleet.SpotY == tileSand.SpotY)
                {

                    _shipSandList.Add(ReplaceShipSea(SlipX, SlipY, tileSeaObj, gridFleet.GetId()));

                }
            }
        }
    }
    void SelectHero(int IdHero) {

        
        foreach (GridFleet hero in _seaTactic._prototypeHeroSea.GetHeroFleet())
        {
            
            if (hero.GetId() == IdHero)
            {
Debug.Log(hero.GetId() +"=0 yyyyyy  FLEET=" + IdHero);
                    ButtonEvent modelEvent = new ButtonEvent();
                //modelEvent.HeroFleet = hero;
                modelEvent.Point = new Point(0, 0);
                modelEvent.NameEvent = ControllerConstant.SeaSelectHero;
                modelEvent.IdHero = IdHero;
                ControllerButton.EventCall(ControllerConstant.SeaSelectHero, ControllerConstant.SeaSelectHero, modelEvent);
                //ButtonActorListerner.SetClickListenerBuilder(_groupActor, modelEvent, _groupActor.getName());
            }
        }
        _buttonEvent_ar = GetButtonEventPathList(_seaTactic.GetSeaSelectHeroId());
        DrawPathHero(_SlipX, _SlipY, -5, _buttonEvent_ar);
        GetAttackSemiTarget(0);
    }



    private GameObject ReplaceShipSea(float SlipX, float SlipY, GameObject tileSeaObj,int FleetId)
    {

        

        TileSand tileSeaView = tileSeaObj.GetComponent<TileSand>();
        tileSeaView.IdTileSand = FleetId;
     
        Point replaceCoordinate = GetReplaceCoordinate(tileSeaView.SpotX, tileSeaView.SpotY, SlipX, SlipY);

   
        GameObject tileSandFleetObj = Instantiate(FleetShipTactic, new Vector3(0, 0, 0), Quaternion.identity);


        SpriteRenderer tileSea = TileSand.GetComponent<SpriteRenderer>();
        tileSandFleetObj.transform.localScale = new Vector3((tileSea.sprite.textureRect.width / ShipSprite.textureRect.width) * 2.5f,
            tileSea.sprite.textureRect.height / ShipSprite.textureRect.height, 1);
        tileSandFleetObj.transform.position = new Vector3(replaceCoordinate.X, replaceCoordinate.Y);

        

TileSeaView tileSeaFleet = tileSandFleetObj.GetComponent<TileSeaView>();
        tileSeaFleet.IdTileSand = FleetId;

        return tileSandFleetObj;

    }
    private int GetHeightBattleField(int Height)
    {
        return 1;
        //return (int)(Height - GlobalParamView.widthPanelBattlePlanet);
    }
    public void SetExplodeFleet(int FleetId) {
        
        foreach (GameObject fleetObj in _shipSandList) {
            TileSeaView tileSeaView = fleetObj.GetComponent<TileSeaView>();
            
            
            if (tileSeaView.IdTileSand == FleetId) {

                
                GameObject explode = fleetObj.transform.GetChild(1).gameObject; ;
                
                var anim = explode.GetComponent<Animator>();
                anim.SetBool("play", true);

                SetTextFleetDamage(fleetObj, "77");

                return;
            }
            

            
        }
        //GameObject explodeFleet = Instantiate(ExplodePrefabs, new Vector3(0, 0, 0), Quaternion.identity);
        //var anim = explodeFleet.GetComponent<Animator>();
        //anim.SetBool("play", true);

    }
    private void SetTextFleetDamage(GameObject TileSandFleetObj,string Message)
    {
        //TextUnitPrefabs
       GameObject textUnit = Instantiate(TextUnitPrefabs, new Vector3(TileSandFleetObj.transform.position.x,
           TileSandFleetObj.transform.position.y, -2), Quaternion.identity);
        float scaleText = .15f;
        textUnit.transform.localScale = new Vector3(scaleText, scaleText, scaleText);
        textUnit.transform.SetParent(TileSandFleetObj.transform);
        textUnit.GetComponent<TextMesh>().text = Message;


        float step =  .1f * Time.deltaTime;

        
        textUnit.transform.position = Vector3.MoveTowards(
                new Vector3(TileSandFleetObj.transform.position.x, TileSandFleetObj.transform.position.y+1, 1),
                TileSandFleetObj.transform.position,
                step);
                
        Destroy(textUnit,4);

    }


    // Update is called once per frame
    void Update()
    {

        _CommandStrategy = _sesAnimationMove.AnimationCommand(_CommandStrategy,
                _tick, _setFieldArmyView, 0, 0, 0, _seaTactic, TileSandList, _shipSandList, ExplodePrefabs, SetExplodeFleet);

        if (_CommandStrategy != null)
        {
           // Debug.Log("@       _CommandStrategy != null");
            
            
        }
        else
        {
            
            //_sesAnimationMove.InitArrange(0,0, _setFieldArmyView);
            //remove
            SetFleetField(_SlipX, _SlipY);
        }
        _tick++;
    }
    */
}
