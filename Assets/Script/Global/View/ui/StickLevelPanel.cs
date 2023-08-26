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
using Assets.Global;

public class StickLevelPanel: MonoBehaviour
{


    public Button StartButton;
    public Button CloseButton;

    public Image Shield_0;
    public Image Shield_1;
    public Image Shield_2;
    public Image Shield_3;

    public Image LionKnight;
    void Start()
    {
        StartButton.onClick.AddListener(() => StartMethod());
        CloseButton.onClick.AddListener(() => CloseMethod());

        List<Image> shield_ar = new List<Image>() { Shield_0, Shield_1, Shield_2, Shield_3 };
        for (int i = 0; i < StickBattle.Level; i++)
        {
            LionKnight.transform.position = shield_ar[i].transform.position;
            Destroy(shield_ar[i]);
        }


    }
    void StartMethod()
    {
        dispathEvent(99);
        EventListeren.eventDispatchEvent(CommandState.InitStickGameLevel.ToString(), "Istart".ToString());

        // Блокируем скролл.

        // Блокируем скролл.
        //Destroy(this.transform.parent.gameObject);


        Destroy(this.transform.gameObject);
        //imageMessage.sprite = HUD.imageMessage_ar[0].image;

    }
    void CloseMethod()
    {
        
        GlobalConf.ModeStickBattle = false;
print("CloseMethod ПОВЕРЖЕН.     DeleteAllTacticMap ");
        EventListeren.eventDispatchEvent(CommandState.GreetingPlayerMenu.ToString(), "Istart".ToString());
        Destroy(this.transform.gameObject);
    }
    private void dispathEvent(int select)
    {
        var I = new JSONClass();
        I[CommandState.InitGameLevel.ToString()] = select.ToString();
        EventListeren.eventDispatchEvent(CommandState.InitGameLevel.ToString(), I.ToString());

        // Блокируем скролл.
        EventListeren.eventDispatchEvent(CommandState.unBlockScroll.ToString(), "I".ToString());
    }


    void Update() {
      
    }

   

}

