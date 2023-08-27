using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using RTS;
using SimpleJSON;
using UnityEngine.SceneManagement;
using Assets.Script.Global.Model.strateg;

public class StartGreetingPanel : MonoBehaviour {
	public Text title;
	public Text nameLeft;
	public Text nameRight;
	public Image imageLeft;
	public Image imageRight;

    public GameObject CustomBattlePanel;

    public Button FirstLevelButton;
	public Button SecondLevelButton;
    public Button ThreeLevelButton;
    public Button CustomButton;
    public Button StickButton;
    public Button ButtonFPS;
    public Button CloseButton;

    public GameObject StickLevelPanel;
    //public GameObject ControllerGlobal;

    // Use this for initialization
    void Start () {
        //FirstLevelButton.onClick.AddListener(() => FirstLevelMethod(0));
        //SecondLevelButton.onClick.AddListener(() => FirstLevelMethod(1));
        ThreeLevelButton.onClick.AddListener(() => FirstLevelMethod(2));
        //CustomButton.onClick.AddListener(() => CustomButtonMethod());
        //StickButton.onClick.AddListener(() => StickButtonMethod());
        //CloseButton.onClick.AddListener(() => CloseMethod());
        //ButtonFPS.onClick.AddListener(() => FPSMethod());



        EventListeren.eventDispatchEvent(CommandState.BlockScroll.ToString(), "I".ToString());
    }
    void CloseMethod()
    {
        Application.Quit ();

    }
    void FirstLevelMethod (int LevelId) {

        ControllerGlobal controllerGlobal = new ControllerGlobal();
        controllerGlobal.StartLevel(0);

    }
    
   
    

}
