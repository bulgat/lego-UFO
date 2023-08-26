using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel: MonoBehaviour
{
    public Button CloseButton;
    public Text title;
    public static string infoTitle;
    public static string spriteImage;
    public Image imageMessage;

    void Start()
    {
        CloseButton.onClick.AddListener(() => CloseMethod());
        imageMessage.sprite = UserInput.HUD_UserInput.imageMessage_ar.Where(a => a.name == spriteImage).First();
    }
    void CloseMethod()
    {
        Destroy(gameObject);
        //imageMessage.sprite = HUD.imageMessage_ar[0].image;
        
    }

    void Update()
    {
         title.text = infoTitle;
        //imageMessage.sprite = spriteImage;
        
    }
}
