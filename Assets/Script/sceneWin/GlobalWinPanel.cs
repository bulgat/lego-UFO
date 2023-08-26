using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using RTS;
using SimpleJSON;
using UnityEngine.SceneManagement;
using System;

public class GlobalWinPanel : MonoBehaviour {

	public Button CloseButton;
    public bool playerWin = false;
    public Image imageWin;

    // Use this for initialization
    void Awake () {
        
        CloseButton.onClick.AddListener(() => CloseMethod());
        try
        {
            if (playerWin)
            {
                imageWin.sprite = UserInput.HUD_UserInput.imageBigBack_ar.Where(a => a.name == ImageBigBible.win.ToString()).First();
            }
            else
            {
                imageWin.sprite = UserInput.HUD_UserInput.imageBigBack_ar.Where(a => a.name == ImageBigBible.unwin.ToString()).First();
            }
        }
        catch (Exception e) {
            Debug.LogWarning(" Exception libraly =" + e);
        }
    }
	void CloseMethod () {
        
        if (GlobalConf.GetStateStrategGame())
        {
            SceneManager.LoadScene("StrategChess");
        }
        else
        {
            SceneManager.LoadScene("basic");
            EventListeren.eventDispatchEvent(CommandState.DestroyGameLevel.ToString(), "Istart".ToString());
        }
        
        //Destroy(this.transform.gameObject);
        

    }
    

}
