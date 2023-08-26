using System.Collections.Generic;
using ZedAngular.Model.Terra;

public class TacticPlanetView { 
    /*
    public GameObject CosmosFon;
    public Sprite CosmosFonSprite;

    public GameObject DesertFon;
    public GameObject DesertTown;

    public Sprite DesertFonSprite;
    public List<Sprite> TextureUnit_ar;
    public GameObject ImageObject;
   // public static GameObject ImageObjectStat;
    public static GameObject ImageTankStat;
    private List<GameObject> UnitList;
    FieldArmyView _fieldArmyView;
    private float _countFrame;
    BattlePlanetView _battlePlanetView;
    public Image LongRange;
    public Image BonusEmblemLeft;
    public Image BonusEmblemRight;

    private Vector2 CameraScale()
    {
        float cameraHeight = Camera.main.orthographicSize * 2;
        return new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
    }
    private Vector2 ImageScale(Vector2 spriteSize)
    {
        Vector2 cameraSize = CameraScale();
        Vector2 scale = transform.localScale;
        if (cameraSize.x >= cameraSize.y)
        { // Landscape (or equal)
            scale *= cameraSize.x / spriteSize.x;
        }
        else
        { // Portrait
            scale *= cameraSize.y / spriteSize.y;
        }

        return scale;
    }
    private void TransformGameObj(GameObject GameObj, Vector2 Scale)
    {
        GameObj.transform.position = Vector2.zero; // Optional
        GameObj.transform.localScale = Scale;
    }
    void LateUpdate()
    {
       
    }
    void Start()
    {
        

         UnitList = new List<GameObject>();

        // Debug tactic
        MockGlobalPlanet mockGlobalPlanet = new MockGlobalPlanet(true);
        //BattlePlanetView battlePlanetView = new BattlePlanetView();
        _battlePlanetView = BattlePlanetView.GetBattlePlanetViewSingleton();
        //MapWorldModel.StartGame();
        

        //new Tactic(MapWorldModel._prototypeHeroDemo.GetHeroFleet()[0], MapWorldModel._prototypeHeroDemo.GetHeroFleet()[1], true, false);
        //new Tactic(MapWorldModel._prototypeHeroDemo.GetFleetWithId(3), MapWorldModel._prototypeHeroDemo.GetFleetWithId(2), true, false);
        //var kol = MapWorldModel._prototypeHeroDemo.GetFleetWithId(4);
        
        //End Debug tactic


        Vector2 scale = ImageScale(CosmosFonSprite.bounds.size);

        TransformGameObj(CosmosFon, scale);


        DrawTownIsland(scale);


        //var ttt = ImageObject.transform.Find("UnitTactic");
        //var kkk = ImageObject.transform.Find("Tank");
        // var ccc = ttt.transform.Find("Tank");

        //ImageObjectStat = ccc;
        //ImageObjectStat = ImageObject;
        // ImageObjectStat = ccc as GameObject;

        // heroArmy 
        _fieldArmyView = new FieldArmyView();
        _fieldArmyView.FieldArmyViewSet(this, CameraScale().x, CameraScale().y, _countFrame);



        //List<GridCrewScience> basaPurchaseUnitScienceList = BattlePlanetModel.GetBasaPurchaseUnitScience();

        // addhero
  

        

        LongRange.enabled = Tactic.GetTactic().LongRange;

       var playerBonus =  BattlePlanetModel.GetIslandWithGridFleet(MapWorldModel._islandDemoMemento.GetIslandArray(), Tactic.GetTactic().GetPlayerFleet());
        var fiendBonus = BattlePlanetModel.GetIslandWithGridFleet(MapWorldModel._islandDemoMemento.GetIslandArray(), Tactic.GetTactic().GetPlayerFleet());
        

        BonusEmblemLeft.enabled = (playerBonus != null);
        BonusEmblemRight.enabled = (fiendBonus != null);
        
    }
    private void DrawTownIsland(Vector2 scale) {
        // desert
        GridFleet playerFleet = Tactic.GetTactic().GetPlayerFleet();
        GridFleet fiendFleet = Tactic.GetTactic().GetFiendFleet();

        IslandTacticLandscapeModel islandLandscapeModel
        = GetIslandTacticLandscape.GetIslandTacticLandscapeResult(MapWorldModel._islandDemoMemento,
                playerFleet, fiendFleet);

        DesertTown.SetActive(false);
        scale = ImageScale(DesertFonSprite.bounds.size);
        TransformGameObj(DesertFon, scale);
        //TransformGameObj(DesertTown, -scale);



        if (islandLandscapeModel.PlayerIsland != null)
        {
            DesertTown.SetActive(true);
            //DrawTown(true, DesertFon);
            TransformGameObj(DesertTown, new Vector2(scale.x, scale.y));
        }
        if (islandLandscapeModel.FiendIsland != null)
        {
            DesertTown.SetActive(true);
            // DrawTown(false, DesertFon);
            TransformGameObj(DesertTown, new Vector2(-scale.x, scale.y));
        }
    } 
    private void DrawTown(
            bool playerIsland, GameObject desertFon)
    {
        // town

        if (playerIsland == false)
        {
            // fiend in town
            //townDesert.setWidth(width / 2);
            desertFon.transform.localScale = new Vector3(1,1,1);
        }
        else
        {
            // player in town
            //townDesert.setWidth(-width / 2);
            desertFon.transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    public void SetGameObject(int ImageId, int idUnit)
    {
        //var sprite = ImageObjectStat.GetComponent<SpriteRenderer>();
        //sprite.sprite = TextureUnit_ar[ImageId];
        //var kol = ImageObjectStat.transform.Find("UnitTactic");
        //UnitInfo unitInfoScr = kol.GetComponent<UnitInfo>();
       
        //var sprite = GetSprite(unitInfoScr.MainUnit, ImageId);
        //var sprite = GetSprite(ImageObjectStat,ImageId);

        GameObject tileSandObj = Instantiate(ImageObject, new Vector3(0, 0, 0), Quaternion.identity);

        UnitInfo unitInfoScript = GetUnitScript(tileSandObj);
  

        //UnitInfo unitInfoScript = tileSandObj.GetComponent<UnitInfo>();



        var sprite = GetSprite(unitInfoScript.MainUnit, ImageId);

        unitInfoScript.ImageId = ImageId;
        unitInfoScript.UnitId = idUnit;
        UnitList.Add(tileSandObj);

    }
    private SpriteRenderer GetSprite(GameObject imageObjectStat,int ImageId) {
        SpriteRenderer sprite = imageObjectStat.GetComponent<SpriteRenderer>();
        sprite.sprite = TextureUnit_ar[ImageId];

        //Renderer i = imageObjectStat.GetComponent<Renderer>();
        //i.material.color = Color.red;


        return sprite;
    }
    private UnitInfo GetUnitScript(GameObject tileSandObj) {
        var unitInfoGameObject = tileSandObj.transform.Find("UnitTactic");
        return unitInfoGameObject.GetComponent<UnitInfo>();
    }

    public void SetGameObjectPosition(int UnitId, float sizeUnitX, float startWidthRandom, float YPosition,
        float Quad, float Size, float scaleUnit, bool PlayerLeft, bool Infantery)
    {
        foreach (GameObject itemUnit in UnitList)
        {
            UnitInfo unitInfoScript = GetUnitScript(itemUnit);



            if (unitInfoScript.UnitId == UnitId)
            {
                //float kol = Camera.main.pixelWidth/65;
                //itemUnit.transform.position = new Vector3(-(startWidthRandom + Quad) + kol, YPosition / 15 - 4, 0);

                
                float kol = Screen.width/65;
               

                itemUnit.transform.position = new Vector3(-(startWidthRandom + Quad)+ kol , YPosition / 15 - 4, 0);

               

                float scaleUnitX = scaleUnit;
                if (PlayerLeft)
                {
                    scaleUnitX *= -1;
                }

                itemUnit.transform.localScale = new Vector3(scaleUnitX, scaleUnit, 0);
    
                
            }
            if (Infantery)
            {
                
                unitInfoScript.MainUnit.SetActive(false);
            }
            else {
                unitInfoScript.Infantery.SetActive(true);
            }
        }
    }
    void Update()
    {
        _countFrame += Time.deltaTime;
        Draw(_countFrame);
    }
    public void Draw(float CountFrame)
    {
        // Animation
        int DamageAnimCoef = 99;
        UnitResultTactic unitResultTactic = _fieldArmyView.DrawFieldUnit(
                DamageAnimCoef,
                _fieldArmyView._battleTactic_ar,
                Tactic.GetTactic().GetResultTacticBattle(),
                CountFrame,
                this
                );

        
        foreach (GameObject itemUnit in UnitList)
        {
         
        }
        
    }
    public void MoveByUnit(float Speed, int UnitId, bool Player, bool Dead, bool Fire,int Damage)
    {
        

        foreach (GamoObject itemUnit in UnitList)
        {
           // UnitInfo unitInfoScript = itemUnit.GetComponent<UnitInfo>();
            UnitInfo unitInfoScript = GetUnitScript(itemUnit);
            if (unitInfoScript.UnitId == UnitId)
            {
                if (Player)
                {
                    Speed *= -1;
                }
                //itemUnit.transform.position = new Vector3(itemUnit.transform.position.x + 0.1f, itemUnit.transform.position.y, itemUnit.transform.position.z);
                itemUnit.transform.position = new Vector3(itemUnit.transform.position.x + Speed/2, itemUnit.transform.position.y, itemUnit.transform.position.z);

                if (Dead)
                {

                    //dead
                    if (unitInfoScript.Explode.activeSelf == false)
                    {
                       // unitInfoScript.Explode.SetActive(true);
                    }
                    

                    var anim = unitInfoScript.Explode.GetComponent<Animator>();
                    anim.SetBool("play", true);
 //anim.Play("ExplodeAnimation");
                    //var animExplode = anim.GetCurrentAnimatorStateInfo(0).IsName("ExplodeAnimation");
                    //var stopExplode = anim.GetCurrentAnimatorStateInfo(0).IsName("StopState");
                    //ExplodeAnimation
                    //StopState
                    
                  //  if (stopExplode == true)
                   // {
                        //unitInfoScript.Explode.SetActive(false);
                  //  }

                    SpriteRenderer sprite = unitInfoScript.MainUnit.GetComponent<SpriteRenderer>();
                    //SpriteRenderer sprite = itemUnit.GetComponent<SpriteRenderer>();
                    sprite.sprite = TextureUnit_ar[unitInfoScript.ImageId + 2];
                    unitInfoScript.SetDeadInfantry();
                    unitInfoScript.Damage = Damage;


                }
                else
                {
                    if (Fire)
                    {

                        unitInfoScript.SetAttackInfantry();

                        //SpriteRenderer sprite = itemUnit.GetComponent<SpriteRenderer>();
                        SpriteRenderer sprite = unitInfoScript.MainUnit.GetComponent<SpriteRenderer>();
                        sprite.sprite = TextureUnit_ar[unitInfoScript.ImageId + 1];
                    }
                }
                }
        }
    }
    */
}
