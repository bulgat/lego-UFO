using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewScene : MonoBehaviour {

    public GameObject Unit;

    Scene modelScene;


    // Use this for initialization
    void Start () {
 
        // Запускаем модель.
        modelScene = new Scene();
        modelScene.OnInit();

 
        foreach(Unit un in modelScene._unit_ar)
        {
            Instantiate(Unit);
            Unit.transform.position = new Vector3(un.GetTileX(), 4, un.GetTileY());
            Unit.tag = "chip";
   
            
        }

    }



    int tick = 0;
    // Update is called once per frame
    void Update () {
        tick++;
 
        if (tick % 2 == 0)
        {
           
            modelScene.Update();

            var chip_ar = GameObject.FindGameObjectsWithTag("chip");

            for (int i = 0; i < modelScene._unit_ar.Count; i++)
            {
                chip_ar[i].transform.position = new Vector3(modelScene._unit_ar[i].GetTileX() + ((float)modelScene._unit_ar[i].GetX() / 100), 4, modelScene._unit_ar[i].GetTileY() + ((float)modelScene._unit_ar[i].GetY() / 100));


                // Анимация. 
                modelScene._unit_ar[i].getAnimation();
            }
        }
    }

    

}
