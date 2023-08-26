using RTS;
using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlanetNewPanel: MonoBehaviour
{
    public Button CloseButton;
    public Image imageButton_1;
    public Image imageButton_2;
    public Image imageButton_3;
    public Image imageButton_4;

    public Button buyButton_1;
    public Button buyButton_2;
    public Button buyButton_3;
    public Button buyButton_4;

    public Text textMoney;

    public string namePlanet;
    public int planetX;
    public int planetY;

    void Start()
    {
        CloseButton.onClick.AddListener(() => CloseMethod());

        buyButton_1.onClick.AddListener(() => BuyMethod_1());
        buyButton_2.onClick.AddListener(() => BuyMethod_2());
        buyButton_3.onClick.AddListener(() => BuyMethod_3());
        buyButton_4.onClick.AddListener(() => BuyMethod_4());

        imageButton_1.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.peasant.ToString()).First();
        imageButton_2.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.sword.ToString()).First();
        imageButton_3.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.crossbow.ToString()).First();
        imageButton_4.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.knight.ToString()).First();
        textMoney.text = namePlanet + " money: "+GlobalConf.Money[0].ToString();

        EventListeren.eventDispatchEvent(CommandState.BlockScroll.ToString(), "");
    }
    void CloseMethod()
    {
        EventListeren.eventDispatchEvent(CommandState.unBlockScroll.ToString(), "");
        Destroy(this.transform.gameObject);

    }
    void BuyMethod_1() {
        purshaseUnit(1,0);
    }
    void BuyMethod_2() {
        purshaseUnit(4,1);
    }
    void BuyMethod_3()
    {
        purshaseUnit(3, 2);
    }
    void BuyMethod_4()
    {
        purshaseUnit(10, 3);
    }
    void purshaseUnit(int costUnit,int typeUnit) {
        //int costUnit = 1;
        if (GlobalConf.Money[0] - costUnit >= 0)
        {
            GlobalConf.Money[0] -= costUnit;

            //closePlanet ();
            var I = new JSONClass();
            I["x"] = planetX.ToString();
            I["y"] = planetY.ToString();
            I["type"] = typeUnit.ToString();
            EventListeren.eventDispatchEvent(CommandState.BuyShip.ToString(), I.ToString());

            var textI = new JSONClass();
            textI[CommandState.Message.ToString()] = "Куплен "+ GlobalConf.UnitConfig_ar[typeUnit].Name + ". Money = " + GlobalConf.Money[0] + " Cost = " + costUnit;
            textI["image"] = "money";
            EventListeren.eventDispatchEvent(CommandState.Message.ToString(), textI.ToString());
        }
        else
        {

            var textI = new JSONClass();
            textI[CommandState.Message.ToString()] = "Недостаточно денег. Money = " + GlobalConf.Money[0] + " Cost = " + costUnit;
            textI["image"] = "noMoney";
            EventListeren.eventDispatchEvent(CommandState.Message.ToString(), textI.ToString());

        }
        textMoney.text = namePlanet+" money: " + GlobalConf.Money[0].ToString();
    }
}

