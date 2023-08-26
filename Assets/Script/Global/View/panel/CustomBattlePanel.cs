using RTS;
using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using Assets.Script.Global;
using Assets.Script.Global.Model.strateg;

public class CustomBattlePanel : MonoBehaviour
{
    public static int TypeUnitSelect = 1;

    public Button CloseButton;
    public Button ClearButton;


    public Image ButtonBuyImage_1;
    public Image ButtonBuyImage_2;
    public Image ButtonBuyImage_3;
    public Image ButtonBuyImage_4;
    public Image ButtonBuyImage_5;

    public Button ButtonBuy_1;
    public Button ButtonBuy_2;
    public Button ButtonBuy_3;
    public Button ButtonBuy_4;
    public Button ButtonBuy_5;


    public Image SampleImage;

    public GameObject Slot;
    public GameObject leftPanel;
    public GameObject RightPanel;

    private List<GameObject> panelLeft_ar = new List<GameObject>();
    private List<GameObject> panelRight_ar = new List<GameObject>();
    private int summQuad = 72;

    void Start()
    {


        CloseButton.onClick.AddListener(() => CloseMethod());
        ClearButton.onClick.AddListener(() => ClearMethod());
        ButtonBuy_1.onClick.AddListener(() => BuyMethod_1());
        ButtonBuy_2.onClick.AddListener(() => BuyMethod_2());
        ButtonBuy_3.onClick.AddListener(() => BuyMethod_3());
        ButtonBuy_4.onClick.AddListener(() => BuyMethod_4());
        ButtonBuy_5.onClick.AddListener(() => BuyMethod_5());

        ButtonBuyImage_1.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.peasant.ToString()).First();
        ButtonBuyImage_2.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.sword.ToString()).First();
        ButtonBuyImage_3.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.crossbow.ToString()).First();
        ButtonBuyImage_4.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.knight.ToString()).First();
        ButtonBuyImage_5.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.longSword.ToString()).First();

        for (int i = 0; i < summQuad; i++)
        {
            GameObject cust = Instantiate(Slot) as GameObject;

            cust.transform.SetParent(leftPanel.transform);

            panelLeft_ar.Add(cust);

            GameObject custRight = Instantiate(Slot) as GameObject;
            //cust.name = cust.name;

            custRight.transform.SetParent(RightPanel.transform);

            panelRight_ar.Add(custRight);



        }

        SetSamleImage(1);
    }

    void BuyMethod_1()
    {
        TypeUnitSelect = 1;
        SetSamleImage(TypeUnitSelect);
    }
    void BuyMethod_2()
    {
        TypeUnitSelect = 2;
        SetSamleImage(TypeUnitSelect);
    }
    void BuyMethod_3()
    {
        TypeUnitSelect = 3;
        SetSamleImage(TypeUnitSelect);
    }
    void BuyMethod_4()
    {
        TypeUnitSelect = 4;
        SetSamleImage(TypeUnitSelect);
    }
    void BuyMethod_5()
    {
        TypeUnitSelect = 9;
        SetSamleImage(TypeUnitSelect);
    }
    void SetSamleImage(int typeUnit)
    {
        var scriptImage = SampleImage.GetComponent<CustomBattleButton>();
        scriptImage.SetTypeUnit(typeUnit);
        scriptImage.SetNoChangeColor(typeUnit);
    }
    void ClearMethod()
    {

        foreach (var item in panelLeft_ar)
        {
            var scriptImage = item.GetComponent<CustomBattleButton>();
            scriptImage.Reset();

        }
        foreach (var item in panelRight_ar)
        {
            var scriptImage = item.GetComponent<CustomBattleButton>();
            scriptImage.Reset();

        }
    }



    void CloseMethod()
    {
        new CreateLevel().InitGameLevel(0);

        List<int> panelLeftId_ar = new List<int>();
        List<int> panelRightId_ar = new List<int>();
        foreach (GameObject item in panelLeft_ar)
        {
            CustomBattleButton scriptImage = item.GetComponent<CustomBattleButton>();
            if (scriptImage.TypeUnit > 0)
            {
                
                panelLeftId_ar.Add(scriptImage.TypeUnit);
                
            }
        }
        foreach (GameObject item in panelRight_ar)
        {
            CustomBattleButton scriptImage = item.GetComponent<CustomBattleButton>();
            if (scriptImage.TypeUnit > 0)
            {
                panelRightId_ar.Add(scriptImage.TypeUnit);
            }

        }
        Debug.Log(panelLeftId_ar.Count + "  = Method      start    Click = " + panelRightId_ar.Count);

        TypeUnitSend typeUnitSendLeft = new TypeUnitSend() { unitArray = panelLeftId_ar };
        TypeUnitSend typeUnitSendRight = new TypeUnitSend() { unitArray = panelRightId_ar };

        CustomBattleParam.panelLeft_ar = panelLeftId_ar;
        CustomBattleParam.panelRight_ar = panelRightId_ar;

        Debug.Log(CustomBattleParam.panelLeft_ar.Count + " =  WorldModel._prototypeHeroDemo.GetHero = " + CustomBattleParam.panelRight_ar.Count);
        Debug.Log("  idFleet L=" + GlobalConf.GetViewFleetList().Count);

        InfoFleet firstFleet = GlobalConf.GetViewFleetList().First();

        Debug.Log(" = Global .fleet   =" + firstFleet.id);
        firstFleet.ship_ar = new List<NewUnit>() { new NewUnit() { uid =2} };

        SceneManager.LoadScene("BattleField");
    }



}

