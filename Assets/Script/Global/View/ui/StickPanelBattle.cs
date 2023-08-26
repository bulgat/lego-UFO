using RTS;
using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class StickPanelBattle: MonoBehaviour
{
    public Button ButtonBuy_0;
    public Button ButtonBuy_1;
    public Button ButtonBuy_2;
    public Button ButtonBuy_3;
    public Button ButtonBuy_4;

    public Text ButtonText_0;
    public Text ButtonText_1;
    public Text ButtonText_2;
    public Text ButtonText_3;
    public Text ButtonText_4;

    public Image ButtonImage_0;
    public Image ButtonImage_1;
    public Image ButtonImage_2;
    public Image ButtonImage_3;
    public Image ButtonImage_4;

    public Button ButtonAttack;
    public Image ImageAttack;

    public Button ButtonDefence;
    public Image ImageDefence;

    public Text TextMoney;

    void Start()
    {
        ButtonText_0.text = "Копейщик "+ GlobalConf.UnitConfig_ar.Where(a => a.Name == NameUnit.pikeman.ToString()).FirstOrDefault().Cost;
        ButtonText_1.text = "Мечник " + GlobalConf.UnitConfig_ar.Where(a => a.Name == NameUnit.sword.ToString()).FirstOrDefault().Cost;
        ButtonText_2.text = "Арбалетчик " + GlobalConf.UnitConfig_ar.Where(a => a.Name == NameUnit.crossbow.ToString()).FirstOrDefault().Cost;
        ButtonText_3.text = "Pыцарь " + GlobalConf.UnitConfig_ar.Where(a => a.Name == NameUnit.horse.ToString()).FirstOrDefault().Cost;
        ButtonText_4.text = "Рабочий " + GlobalConf.UnitConfig_ar.Where(a => a.Name == NameUnit.labor.ToString()).FirstOrDefault().Cost;

        ButtonImage_0.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.peasant.ToString()).FirstOrDefault();
        ButtonImage_1.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.sword.ToString()).FirstOrDefault();
        ButtonImage_2.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.crossbow.ToString()).FirstOrDefault();
        ButtonImage_3.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.knight.ToString()).FirstOrDefault();
        ButtonImage_4.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == ImageBible.worker.ToString()).FirstOrDefault();

        ButtonBuy_0.onClick.AddListener(() => BuyMethod_0());
        ButtonBuy_1.onClick.AddListener(() => BuyMethod_1());
        ButtonBuy_2.onClick.AddListener(() => BuyMethod_2());
        ButtonBuy_3.onClick.AddListener(() => BuyMethod_3());
        ButtonBuy_4.onClick.AddListener(() => BuyMethod_4());
        ButtonAttack.onClick.AddListener(() => AttackMethod());
        ButtonDefence.onClick.AddListener(() => DefenceMethod());

        ImageAttack.sprite = UserInput.HUD_UserInput.imageDuty_ar.Where(a => a.name == ImageDuty.swordGold.ToString()).FirstOrDefault();
        ImageDefence.sprite = UserInput.HUD_UserInput.imageDuty_ar.Where(a => a.name == ImageDuty.shieldGold.ToString()).FirstOrDefault();

        StartCoroutine(AddTacticMoneyTime());
    }
    IEnumerator AddTacticMoneyTime()
    {
        bool k = true;
        while (k)
        {
            yield return new WaitForSeconds(3.5f);
            GlobalConf.Money[0] += 1;
            GlobalConf.Money[1] += GlobalConf.FiendOne.profit;
            StartCoroutine(AddTacticMoneyTime());
            k = false;
       }

    }
    void BuyMethod_0()
    {
        //print(" wwwwwQQQQ t r PLAYER BuyUnitStickBattle =  ");
        //EventListeren.eventDispatchEvent(CommandState.BuyUnitStickBattle.ToString(), "textI");
        Buy(NameUnit.pikeman.ToString());
    }


    void BuyMethod_1()
    {
        Buy(NameUnit.sword.ToString());
    }
    void BuyMethod_2()
    {
        Buy(NameUnit.crossbow.ToString());
    }
    void BuyMethod_3()
    {
        Buy(NameUnit.horse.ToString());
    }
    void BuyMethod_4()
    {
        Buy(NameUnit.labor.ToString());
    }
    void AttackMethod() {
        
        EventListeren.eventDispatchEvent(CommandState.StickPlayerAttackBase.ToString(), "If".ToString());
    }
    void DefenceMethod() {
        Debug.Log("  ака !!!!!!!!!  @@@@@@@@@@@@@@@StickPlayerDefenceBase ) ");
        EventListeren.eventDispatchEvent(CommandState.StickPlayerDefenceBase.ToString(), "If".ToString());
    }

    void Update() {
        TextMoney.text = "Money = " + GlobalConf.Money[0];
    }

    void Buy(string typeUnitName)
    {
        var typeUnit = GlobalConf.UnitConfig_ar.Where(a => a.Name == typeUnitName).FirstOrDefault();

        if (GlobalConf.Money[0] - typeUnit.Cost >= 0)
        {
            GlobalConf.Money[0] -= typeUnit.Cost;
            var I = new JSONClass();
            I[CommandSend.typeUnit.ToString()] = typeUnit.Id.ToString();
            EventListeren.eventDispatchEvent(CommandState.BuyUnitStickBattle.ToString(), I.ToString());
        }
    }

}

