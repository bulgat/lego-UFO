using System.Collections;
using System.Collections.Generic;

public class IslandHarborView 

{
    /*
    public Button CloseButton;
    public Button BuyButton;
    public Text MoneyText;
    public Image BackGroundFon;
    public Sprite Spaceport0;
    public Sprite Spaceport1;
    public GameObject TileSand;

    public GameObject Canvas;
    public GameObject CardGamePrefabs;
    public List<Sprite> AllTankUnit;
    public List<Sprite> AllRangeUnitList;
    private List<GameObject> _unitGarrisonList;

    public GameObject CanvasAlert;
    public Button CanvasAlertClose;
    void Start()
    {
        CloseButton.onClick.AddListener(() => CloseButtonMethod(CloseButton));
        CanvasAlertClose.onClick.AddListener(() => CloseCanvasAlert(CanvasAlertClose));

        IslandModel islandModel = new IslandModel();

        bool seaHarbor = islandModel.GetTypeIslandSea();

       // ReplaceCardGame();

        if (seaHarbor) {
        BackGroundFon.sprite = Spaceport1;
        } else {
            BackGroundFon.sprite = Spaceport0;
        }

        MockGlobalPlanet mockGlobalPlanet = new MockGlobalPlanet(false);

        GridFleet gridFleet = BattlePlanetModel.GetHarrisonGridFleetHarborPort();
        //List<ArmUnit> crew_ar = BattlePlanetModel.GetHarrisonHarborPort();

 BuyButton.onClick.AddListener(() => BuyButtonMethod(BuyButton, gridFleet));
        
        



        DrawUnitIsland( 100, 100);

        CanvasAlert.SetActive(false);
        // var tileSandObj = Instantiate(UnitImage, new Vector3(0, 0, 0), Quaternion.identity);
        // kol.sp
    }
    private void ReplaceCardGame()
    {
        for (int i = 0; i < 5; i++)
        {
           // CardGamePrefabs.GetComponent<SpriteRenderer>().sprite = AllTankUnit[4+i];
 Image m_Image = CardGamePrefabs.GetComponent<Image>();
           // Debug.Log(" == MouseDow     = IdPa = "+ m_Image);
            m_Image.sprite = AllTankUnit[4+i];
            var cardBomberObject = Instantiate(CardGamePrefabs, new Vector3(-150 + (i * 80), -130, 0), Quaternion.identity);

           

           cardBomberObject.transform.SetParent(Canvas.transform, false);
            
            //var sprite = cardBomberObject.GetComponent<SpriteRenderer>();
            //sprite.sprite = AllTankUnit[4];
            //var cubeRenderer = CardBomberObject.GetComponent<Renderer>();

            //Call SetColor using the shader property name "_Color" and setting the color to red
            //cubeRenderer.material.SetColor("_Color", Color.red);
        }
    }
    private void DestroyDrawUnitIsland()
    {
        if (_unitGarrisonList != null)
        {
            foreach (GameObject item in _unitGarrisonList)
            {
                Destroy(item);
            }
        }
        _unitGarrisonList = new List<GameObject>();
    }
        private void DrawUnitIsland( int width, int height)
    {
        DestroyDrawUnitIsland();

        List<ArmUnit> crew_ar = BattlePlanetModel.GetHarrisonHarborPort();
        List<GridCrewScience> BasaPurchaseUnitScience_ar = BattlePlanetModel.GetBasaPurchaseUnitScience();
        int count = 0;
        foreach (ArmUnit armUnit in crew_ar)
        {
            int unitImageId = armUnit.GetUnit();

            Image m_Image = CardGamePrefabs.GetComponent<Image>();

           // CreateHero.GetImageUnit(armUnit.GetUnit(), BasaPurchaseUnitScience_ar);
            // Debug.Log(" == MouseDow     = IdPa = "+ m_Image); 
          //  armUnit.GetImageCoefId();

            m_Image.sprite = AllTankUnit[unitImageId+(unitImageId*2)];
            float coefShift = Canvas.GetComponent<RectTransform>().rect.width / 2.47f;

        

           GameObject cardBomberObject = Instantiate(CardGamePrefabs, new Vector3(((Canvas.GetComponent<RectTransform>().rect.width) / crew_ar.Count * count)- coefShift, -130, 0), Quaternion.identity) as GameObject;



            cardBomberObject.transform.SetParent(Canvas.transform, false);

            

            // Image level = cardBomberObject.GetComponentInChildren<Image>(); 
            Transform level = cardBomberObject.transform.GetChild(0);
            

            
            //Level =3;
Image rangeLevel = level.GetComponent<Image>();
            if (armUnit.Level == 0)
            {
                level.gameObject.SetActive(false);
            }
            else {
                 
                rangeLevel.sprite = AllRangeUnitList[5];
            }

            //UnitManageActor unitIcon = new UnitManageActor();
            //InitUnit(width / 12,  armUnit.GetUnit(), armUnit.Level, BasaPurchaseUnitScience_ar);
            // int setHeightUnitPanel = width / 12 * 2;

            //iconActor.setY(setHeightUnitPanel);
            //iconActor.setX((height - width / 12) / crew_ar.size() * count);


            //armUnit.Level=3;
            // range
            _unitGarrisonList.Add(cardBomberObject);
            count++;
        }
    }
    public void InitUnit(int widthDivide,  int armUnitNum,
            int Level, List<GridCrewScience> BasaPurchaseUnitScience_ar)
    {
    
        //var kol = ViewTerra.UnitSpriteList;
       
      



    }
    void CloseButtonMethod(Button buttonPressed)
    {
        //ControllerConstant.CloseIsland
        
        ControllerButton.EventCall(ControllerConstant.CloseIsland, ControllerConstant.CloseIsland, null);
    }
    void BuyButtonMethod(Button buttonPressed, GridFleet gridFleet)
    {

        

        //ControllerConstant.BuyIslandPurchaseUnit
        ButtonEvent buttonEvent = new ButtonEvent();
        buttonEvent.NameEvent = ControllerConstant.BuyIslandPurchaseUnit;
        buttonEvent.HeroFleet = gridFleet;
        buttonEvent.UnitId = 2;

        if (MapWorldModel.EnoughMoneyUnit(buttonEvent.HeroFleet.GetFlagId(), buttonEvent.UnitId))
        {
            
            ControllerButton.EventCall(ControllerConstant.BuyIslandPurchaseUnit, ControllerConstant.BuyIslandPurchaseUnit, buttonEvent);

            DrawUnitIsland(100, 100);
        }
        else
        {
            CanvasAlert.SetActive(true);
            
        }
    }
    public void CloseCanvasAlert(Button buttonPressed) {
    Debug.Log("=0   unit g Alarm t . =  ");
        CanvasAlert.SetActive(false);
    }
        // Update is called once per frame
        void Update()
    {
        // money
        Country country = ContactStateProceeding.GetDispositionCountry(BattlePlanetModel.DispositionCountry_ar,
                BattlePlanetModel.FlagIdHero);
        if (country != null)
        {
            MoneyText.text = "spice: " + country.Money;
        }
    }
*/
}
