using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomBattleButton: MonoBehaviour, IPointerDownHandler, IPointerEnterHandler,IPointerExitHandler
{
    public int TypeUnit = 0;
    private bool NoChangeColor = false;

    void Start()
    {
        

    }
	public void SetNoChangeColor(int TypeUnit) {
		NoChangeColor = true;
		//SetTypeUnit(TypeUnit);
		//GetComponent<ImageSampleColor>().color = Color.red;
	}
    public void OnPointerEnter(PointerEventData eventData) {
        if (NoChangeColor==false){
			if (TypeUnit == 0)
			{
				GetComponent<Image>().color = Color.green;
			}
		}
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (NoChangeColor==false){
			if (TypeUnit == 0)
			{
				DefaultImage();
				
			}
		}
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        TypeUnit = CustomBattlePanel.TypeUnitSelect;
        SetTypeUnit(TypeUnit);

    }
    public void SetTypeUnit(int TypeUnit) {
        if (TypeUnit==1) {
            GetComponent<Image>().color = Color.red;
        }
        if (TypeUnit == 2) {
            GetComponent<Image>().color = Color.blue;
        }
        if (TypeUnit == 3)
        {
            GetComponent<Image>().color = Color.cyan;
        }
        if (TypeUnit == 4)
        {
            GetComponent<Image>().color = Color.magenta;
        }
    }

    private void DefaultImage()
    {
        GetComponent<Image>().color = Color.white;
        TypeUnit = 0;
    }
    public void Reset() {
        //Debug.Log( " --------------Was Clicked.   OnPointerDown 0");
        DefaultImage();
    }




}

