using System.Collections;
using System.Collections.Generic;


public class CanvasLead 
{
    /*
    public Button TownButton;
    public Button TurnButton;

    public Button SelectLeftButton;
    public Button SelectRightButton;
    public Text MoneyText;
    // Start is called before the first frame update
    void Start()
    {
TownButton.onClick.AddListener(() => TownMethod(TownButton));
        TurnButton.onClick.AddListener(() => TurnMethod(TurnButton));
        
        SelectLeftButton.onClick.AddListener(() => SelectLeftMethod(SelectLeftButton));
        SelectRightButton.onClick.AddListener(() => SelectRightMethod(SelectRightButton));
       

    }
    void TownMethod(Button buttonPressed)
    {
        new CallTownIsland();
    }
  void TurnMethod(Button buttonPressed)
    {
        // On Click, load the first level.
        // "Stage1" is the name of the first scene we created.
        
        ControllerButton.EventCall(ControllerConstant.Turn, ControllerConstant.Turn,null);
    }
    void SelectLeftMethod(Button buttonPressed)
    { 
    
    }
    void SelectRightMethod(Button buttonPressed)
    {
    
    }

  
    // Update is called once per frame
    void Update()
    {
        //TownButton.interactable = true;
        ButtonEvent buttonIslandEvent = BattlePlanetModel.VisButtonHarborPort();
        if (buttonIslandEvent == null)
        {
            TownButton.interactable = false;
            //TownButton.enabled = false;
            // Debug.Log("0000 commandStrategy  003 i 9 AttackFleet = ");
        }
        else
        {
            TownButton.interactable = true;
            //TownButton.enabled = true;
            //Debug.Log("1111 commandStrategy  003 i 9 AttackFleet = ");
        }

        // money
        Country country = ContactStateProceeding.GetDispositionCountry(BattlePlanetModel.DispositionCountry_ar,
                BattlePlanetModel.FlagIdHero);
        MoneyText.text = "spice: "+ country.Money;
    }
    */
}
