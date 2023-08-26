using System.Collections;
using System.Collections.Generic;

using System;
using System.Linq;


public class ViewTerra : PlanetTurnView
{
    /*
    public GameObject TileSand;
    public GameObject TextUnit;
    public GameObject UnitHero;
    public GameObject TownIsland;

    public List<Sprite> TileClayList;
    public List<Sprite> TileIslandList;
    public List<Sprite> TileUnitList;
    public List<GameObject> SceneList;
    public Sprite SadIsland;
    public Sprite SelectAttack;
    public Sprite Hide;
    public List<Sprite> ShieldList;
    private int SadIslandId = 9999;
    private int SelectAttackId = 99991;
    //public CommandStrategy _CommandStrategy = null;
    BattlePlanetView _battlePlanetView;
    BattlePlanetModel _battlePlanetModel;
    private List<GameObject> _unitHeroGameObjectList;
    ViewTerraAnimMove _ViewTerraAnimMove;

      AnimationMove _animationMove;
  //long _tick = 0;
    List<ButtonEvent> _buttonEvent_ar;
    List<GameObject> _pathHeroGameObjectList;
    List<GameObject> _pathAttackHeroGameObjectList;

    float _SlipX = -4;
    float _SlipY = -4;

    public static List<Sprite> UnitSpriteList;

    protected Joystick joystick;
   // protected JoyButton joybutton;
    public Slider _Slider;

    public Camera _Camera;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        _ViewTerraAnimMove = GetComponent<ViewTerraAnimMove>();

        UnitSpriteList = TileUnitList;
        _battlePlanetView =  BattlePlanetView.GetBattlePlanetViewSingleton();

        //BattlePlanetView battlePlanetView = new BattlePlanetView();
        SceneList = new List<GameObject>();


        CreateTileMap(_SlipX, _SlipY, 0);
        
        // island.
        DrawIsland(_SlipX, _SlipY, -1);

        // button Hero
        DrawHero(_SlipX, _SlipY, -1);

        CreateSadIsland(_SlipX, _SlipY, -3);
        CreateSelectAttack(_SlipX, _SlipY, -4);
       
        CreatePathHero _createPathHero = new CreatePathHero();
      
        _battlePlanetModel = BattlePlanetModel.GetBattlePlanetModelSingleton();
        
        
       
        _buttonEvent_ar = GetButtonEventPathList(BattlePlanetModel.GetSelectHeroId());
                //Draw path Player
                DrawPathHero(_SlipX, _SlipY, -5,_buttonEvent_ar);

        
    }

    private List<ButtonEvent> GetButtonEventPathList(int SelectHeroId) {
        
        return _battlePlanetModel.GetPathSelectHero(
                                MapWorldModel._prototypeHeroDemo,
                               //  SelectHeroId,
            //BattlePlanetModel.GetSelectHeroId(), 
                                 BattlePlanetModel.ShoalSeaBasa_ar,
                                 MapWorldModel._islandDemoMemento,
                                 BattlePlanetModel.GridTile_ar,
                                 ControllerConstant.PathHero,
                                 ControllerConstant.AttackHero,
                                 false,
                                 null, 
                                 null,
                                 0,
                                 0,
                                 BattlePlanetModel.GetSelectHeroId(),
                                 BattlePlanetModel.FlagIdHero
                                 );
    }
    private void CreateTileMap(float SlipX, float SlipY, int Depth)
    {



        List<GridTileBar> Grid_ar = BattlePlanetModel.GridTile_ar;

        for (int GridRow = 0; GridRow < Grid_ar[Grid_ar.Count - 1].SpotX + 1; GridRow++)
        {
            for (int GridLine = 0; GridLine < Grid_ar[Grid_ar.Count - 1].SpotY + 1; GridLine++)
            {
                GridTileBar gridTileBar = ModelStrategy.GetOneGrid(Grid_ar, GridRow, GridLine);
                int shoal = gridTileBar.Shoal == true ? 1 : 0;
                // road
                if (gridTileBar.Terrain == 3)
                {
                    shoal = 3;
                }
                // mountain
                if (gridTileBar.Terrain == 2)
                {
                    shoal = 2;

                }
                // sea
                if (gridTileBar.Terrain == 4)
                {
                    shoal = 5;


                }

 

                SetSpriteTile(TileClayList[shoal]);

            

                //imageTile

                ReplaceTile(SlipX, SlipY,GridRow ,GridLine,0, Depth,true);

        

            }
        }

    }
    private GameObject ReplaceTile(float SlipX, float SlipY,int GridRow,int GridLine,int Id,int Depth, bool AddSceneList) {
        int widthTile = 1;
        TileSand.transform.localScale = new Vector3(1, 1, 1);
        var tileSandObj = Instantiate(TileSand, new Vector3(SlipX + GridRow * widthTile, SlipY + GridLine * widthTile, Depth), Quaternion.identity);
        TileSand tileSandScript =  tileSandObj.GetComponent<TileSand>();
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
    private void SetSpriteTile(Sprite sprite) {
        GetSpriteTile().sprite = sprite;
        
    }
    private SpriteRenderer GetSpriteTile() {
        return TileSand.GetComponent<SpriteRenderer>();
    }

    public void DrawIsland(float SlipX, float SlipY, int Depth) 
    {
        List<Island> Island_ar = MapWorldModel._islandDemoMemento.GetIslandArray();

        

        foreach (Island isl in Island_ar)
        {
            //TownIsland;
            GameObject townIsland = Instantiate(TownIsland, new Vector3(0, 0, Depth), Quaternion.identity) as GameObject;
            var townObj = townIsland.transform.GetChild(0);
            var townSprite = townObj.GetComponent<SpriteRenderer>();
            if (isl.Race == 0)
            {
                if (isl.Castle)
                {

                    //islandImage = SuperCastle1;
                    //SetSpriteTile(TileIslandList[2]);
                    townSprite.sprite = TileIslandList[2];
                }
                else
                {

                    //SetSpriteTile(TileIslandList[0]);
                    townSprite.sprite = TileIslandList[0];

                }

            }
            if (isl.Race >= 0)
            {
                if (isl.Castle)
                {

                    //islandImage = SuperCastle1;
                   // SetSpriteTile(TileIslandList[3]);
                    townSprite.sprite = TileIslandList[3];
                }
                else
                {

                    //SetSpriteTile(TileIslandList[1]);
                    townSprite.sprite = TileIslandList[1];
                }

            }

            var shieldObj = townIsland.transform.GetChild(0);
            var shieldSprite = shieldObj.GetComponent<SpriteRenderer>();
            
            shieldSprite.sprite = ShieldList[GetFlag(isl.GetFlagId())];

            int widthTile = 1;
            townIsland.transform.position = new Vector3(SlipX + isl.SpotX * widthTile, SlipY + isl.SpotY * widthTile, -1);
            TileSand tileSandScript = townIsland.GetComponent<TileSand>();

            //GameObject imageTown =  ReplaceTile(SlipX, SlipY, isl.SpotX, isl.SpotY, isl.Id, Depth,false);
            //TileSand tileSandScript = imageTown.GetComponent<TileSand>();
            tileSandScript.SetActionFunction(MouseDownTownActionFunction);
        }
     }
    private void MouseDownTownActionFunction(int IdIsland) {
        
        new CallTownIsland();

    }

    public void DrawPathHero(float SlipX, float SlipY, int Depth, List<ButtonEvent> buttonEvent_ar) {
        DestroyDrawPathHero();
       
        if (buttonEvent_ar != null)
        {
            int idPathHero = 0;
            foreach (ButtonEvent buttonEvent in buttonEvent_ar)
            {
                
                SetSpriteTile(Hide);
                GameObject hideTilePath = ReplaceTile(SlipX, SlipY, (int)buttonEvent.Point.X, (int)buttonEvent.Point.Y, idPathHero, Depth,false);

                hideTilePath.transform.localScale = new Vector3(3,3,1);

                TileSand tileSandScript = hideTilePath.GetComponent<TileSand>();
                tileSandScript.SetActionFunction(MouseDownPathActionFunction);

                _pathHeroGameObjectList.Add(hideTilePath);
                idPathHero++;
            }
        }
     }
    void DestroyDrawPathHero() {
        if (_pathHeroGameObjectList!=null)
        {
            foreach(GameObject pathHero in _pathHeroGameObjectList)
            {
                Destroy(pathHero);
            }
        }
        _pathHeroGameObjectList = new List<GameObject>();
    }
    void MouseDownPathActionFunction(int IdPath) {

       
        int idPathHero = BattlePlanetModel.GetSelectHeroId();

        idPathHero = 0;
        foreach (ButtonEvent buttonEvent in _buttonEvent_ar)
        {

           
            if (idPathHero == IdPath)
            {

                ControllerButton.EventCall(ControllerConstant.PathHero, ControllerConstant.PathHero, buttonEvent);
                DestroyDrawPathHero();
            }
            idPathHero++;
        }
        // set select attack fiend hero.
        SetSelectAttackFiendHero();

        GetAttackSemiTarget();
    }
    private void SetSelectAttackFiendHero() {
       
        var buttonEvent_ar = GetButtonEventPathList(BattlePlanetModel.GetSelectHeroId());
        int count=0;
        foreach (var item in buttonEvent_ar) { 
         
            count++;
        }
    }

    public void DrawHero(float SlipX, float SlipY, int Depth)
    {
        _unitHeroGameObjectList = new List<GameObject>();
        List<GridFleet> HeroFleetList = MapWorldModel._prototypeHeroDemo.GetHeroFleet();

        foreach (GridFleet hero in HeroFleetList)
        {
            int numUnitImage = GetFirstUnitIdHero(hero);
            GameObject heroFleet = Instantiate(UnitHero, new Vector3(0, 0, Depth), Quaternion.identity) as GameObject;

            var HeroFleetObj = heroFleet.transform.GetChild(1);
            var HeroFleetSprite = HeroFleetObj.GetComponent<SpriteRenderer>();
            HeroFleetSprite.sprite = TileUnitList[numUnitImage];

            var shieldObj = heroFleet.transform.GetChild(0);
            var shieldSprite = shieldObj.GetComponent<SpriteRenderer>();
            
            shieldSprite.sprite = ShieldList[GetFlag(hero.GetFlagId())];
            //shieldObj.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);

            int countUnit = ModelStrategy.GetHeroShipFirstCount(hero);
            var HeroFleetTextObj = heroFleet.transform.GetChild(2);
            HeroFleetTextObj.GetComponent<TextMesh>().text = countUnit.ToString();

            TileSand tileSandScript = heroFleet.GetComponent<TileSand>();
            tileSandScript.SpotX = hero.SpotX;
            tileSandScript.SpotY = hero.SpotY;
            tileSandScript.IdTileSand = hero.GetId();
            tileSandScript.SetActionFunction(SelectHero);

            int widthTile = 1;
            heroFleet.transform.position = new Vector3(SlipX + hero.SpotX * widthTile, SlipY + hero.SpotY * widthTile, Depth);

            _unitHeroGameObjectList.Add(heroFleet);
            


        }
    }
    public static int GetFlag(int flagId)
    {
        int imageFlag = 0;
        foreach (Country country in BattlePlanetModel.DispositionCountry_ar)
        {
            if (country.IdCountry == flagId)
            {
                imageFlag = country.FlagImage;
            }
        }

        return imageFlag;
    }
    private void SetNumberUnit(GameObject textUnit, int countUnit) {
        TextMesh t = (TextMesh)textUnit.GetComponent(typeof(TextMesh));
        t.text = countUnit.ToString();
    }

    void SelectHero(int IdHero)
    {
       
        //DestroyDrawPathHero();

        foreach (GridFleet hero in MapWorldModel._prototypeHeroDemo.GetHeroFleet())
        {
            Point pointHero = new Point(hero.SpotX, hero.SpotY);
            if (hero.GetId() == IdHero) {
                ButtonEvent modelEvent = new ButtonEvent();
                modelEvent.HeroFleet = hero;
                modelEvent.Point = pointHero;
                modelEvent.NameEvent = ControllerConstant.SelectHero;
                //ControllerConstant.SelectHero
                ControllerButton.EventCall(ControllerConstant.SelectHero, ControllerConstant.SelectHero, modelEvent);
                //return;
            }
        }
        
        _buttonEvent_ar = GetButtonEventPathList(BattlePlanetModel.GetSelectHeroId());
       
        
        //Draw path Player
        DrawPathHero(-4, -4, -5, _buttonEvent_ar);


        GetAttackSemiTarget();


    }
    private void DeleteAttackSemiTarget() {
        if (_pathAttackHeroGameObjectList != null)
        {
            foreach (var item in _pathAttackHeroGameObjectList)
            {
                Destroy(item);
            }
        }
        _pathAttackHeroGameObjectList = new List<GameObject>();
    }
    private List<GridFleet> GetAttackSemiTarget() {
        int Depth = -6;
        GridFleet gridFleet = BattlePlanetModel.GetHeroWithId(MapWorldModel._prototypeHeroDemo.GetHeroFleet(), BattlePlanetModel.GetSelectHeroId());

        List<GridFleet> attackSemiTargetList = _battlePlanetModel.SelectHeroAttacSemikPath(gridFleet.GetRange(), gridFleet, MapWorldModel._prototypeHeroDemo,
        BattlePlanetModel.ShoalSeaBasa_ar);
        

        DeleteAttackSemiTarget();

        foreach (GridFleet fleet in attackSemiTargetList) {
            
            SetSpriteTile(SelectAttack);
            GameObject selectAttackTilePath = ReplaceTile(_SlipX, _SlipY, (int)fleet.SpotX, (int)fleet.SpotY, fleet.GetId(), Depth, false);
            selectAttackTilePath.transform.localScale = new Vector3(2,2,1);

            TileSand tileSandScript = selectAttackTilePath.GetComponent<TileSand>();
            tileSandScript.SetActionFunction(MouseDownAttackSemiTarget);

            _pathAttackHeroGameObjectList.Add(selectAttackTilePath);
        }

        return attackSemiTargetList;
    }
    void MouseDownAttackSemiTarget(int IdFiendFleet)
    {
        GridFleet gridFleet = BattlePlanetModel.GetHeroWithId(MapWorldModel._prototypeHeroDemo.GetHeroFleet(), BattlePlanetModel.GetSelectHeroId());

        Debug.Log("   NEW   opment      andStrategy  = " + IdFiendFleet);
        ButtonEvent buttonEvent = new ButtonEvent();
        buttonEvent.HeroFleet = gridFleet;
        buttonEvent.VictimFleet = MapWorldModel._prototypeHeroDemo.GetFleetWithId(IdFiendFleet);
        //range?? gridFleet.GetRange();
        bool longRange = ModelStrategy.GetlongRangeDistance(new Point(gridFleet.SpotX, gridFleet.SpotY), new Point(buttonEvent.VictimFleet.SpotX, buttonEvent.VictimFleet.SpotY));
        buttonEvent.LongRange = longRange;



        ControllerButton.EventCall(ControllerConstant.AttackHero, ControllerConstant.AttackHero, buttonEvent);

        }
        public void CreateSadIsland(float SlipX, float SlipY, int Depth)
    {
        SetSpriteTile(SadIsland);
        ReplaceTile(SlipX, SlipY, 0, 0, SadIslandId, Depth,true);
    }
    public void CreateSelectAttack(float SlipX, float SlipY, int Depth)
    {
        SetSpriteTile(SelectAttack);
        ReplaceTile(SlipX, SlipY, 0, 0, SelectAttackId, Depth,true);
    }
    public static int GetFirstUnitIdHero(GridFleet hero)
    {
        return GetUnitArrayIdHero(hero)[0].GetUnit();
    }
    private static List<ArmUnit> GetUnitArrayIdHero(GridFleet hero)
    {
        return hero.GetShipName().GetArmUnitArray();
    }


   
    
    // Update is called once per frame
    void Update()
    {
        
        _Camera.orthographicSize= 5f+3f* _Slider.value;
        float joystickCoef = 0.1f;
        _Camera.transform.position = new Vector3(_Camera.transform.position.x+joystick.Horizontal* joystickCoef+Input.GetAxis("Horizontal")* joystickCoef, 
            _Camera.transform.position.y + joystick.Vertical* joystickCoef + Input.GetAxis("Vertical") * joystickCoef, 
            _Camera.transform.position.z);


        List<GridFleet> heroList = MapWorldModel._prototypeHeroDemo.GetHeroFleet();
        foreach (GridFleet hero in heroList)
        {
            //SetNumberUnit(textUnit, countUnit);
        }
        foreach (GameObject heroGameObject in _unitHeroGameObjectList)
        {
            var TextMesh = heroGameObject.GetComponentInChildren<TextMesh>();

            TileSand HeroTileSand = heroGameObject.GetComponent<TileSand>();
            var hero = heroList.Where(a => a.GetId()== HeroTileSand.IdTileSand).FirstOrDefault();
            int countUnit = ModelStrategy.GetHeroShipFirstCount(hero);
            
            //TextMesh t = (TextMesh)textUnit.GetComponent(typeof(TextMesh));
            TextMesh.text = countUnit.ToString();
        }
            


        // animation move.

       
        AnimCaptureIsland _animCaptureIsland = new AnimCaptureIsland();
        CreateHero _createHero = new CreateHero();

        _ViewTerraAnimMove.AnimationCommand(_battlePlanetView,100, _tick,
         _battlePlanetView.GetCommandStrategy(),
         100, _animCaptureIsland, _createHero,
        -4, -4,
        BattlePlanetModel.GetBasaPurchaseUnitScience(),
        SceneList, SadIslandId, SelectAttackId,  _unitHeroGameObjectList);
     
        _tick++;
    }
   */
}
