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
        FirstLevelButton.onClick.AddListener(() => FirstLevelMethod(0));
        SecondLevelButton.onClick.AddListener(() => FirstLevelMethod(1));
        ThreeLevelButton.onClick.AddListener(() => FirstLevelMethod(2));
        CustomButton.onClick.AddListener(() => CustomButtonMethod());
        StickButton.onClick.AddListener(() => StickButtonMethod());
        CloseButton.onClick.AddListener(() => CloseMethod());
        //ButtonFPS.onClick.AddListener(() => FPSMethod());



        EventListeren.eventDispatchEvent(CommandState.BlockScroll.ToString(), "I".ToString());
    }
    void CloseMethod()
    {
        Application.Quit ();
        //Application.LoadLevel ("basic");
    }
    void FirstLevelMethod (int LevelId) {

        ControllerGlobal controllerGlobal = new ControllerGlobal();
        controllerGlobal.StartLevel(0);

    }
    /*
    void SecondLevelMethod() {
        ControllerGlobal controllerGlobal = new ControllerGlobal();
        controllerGlobal.StartLevel(1);

       // Destroy(this.transform.parent.gameObject);
    }
    void ThreeLevelMethod()
    {
        ControllerGlobal controllerGlobal = new ControllerGlobal();
        controllerGlobal.StartLevel(2);

       // Destroy(this.transform.parent.gameObject);
    }
    */
    void CustomButtonMethod() {

        //CustomBattlePanel;
        //Instantiate(ViewGlobal._ViewGlobalModel.CustomBattlePanel);
       


        Instantiate(CustomBattlePanel);

        Destroy(this.transform.parent.gameObject);

        // Блокируем скролл.
        //EventListeren.eventDispatchEvent(CommandState.unBlockScroll.ToString(), "I".ToString());
    }
    //FPSMethod
    /*
    void FPSMethod() {
        print("FPS");

        SceneManager.LoadScene("ShooterFPS", LoadSceneMode.Single);
    }
    */
    void StickButtonMethod()
    {
        Instantiate(StickLevelPanel);

        // Блокируем скролл.
        Destroy(this.transform.parent.gameObject);
    }
    private void dispathEvent(int select) {
        var I = new JSONClass();
        I[CommandState.InitGameLevel.ToString()] = select.ToString();
        EventListeren.eventDispatchEvent(CommandState.InitGameLevel.ToString(), I.ToString());

        // Блокируем скролл.
        EventListeren.eventDispatchEvent(CommandState.unBlockScroll.ToString(), "I".ToString());
    }

}
