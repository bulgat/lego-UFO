using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewScene : MonoBehaviour {

    public GameObject Unit;

    Scene modelScene;

   public FixedJoystick Joystick;
    public Camera Camera;

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



    //int tick = 0;
    // Update is called once per frame
    void Update () {

        Debug.Log("========" + Joystick.Horizontal + "_____" + Joystick.Vertical);
        //tick+=20;
 
       // if (tick % 2 == 0)
       // {
           
            modelScene.Update();

            var chip_ar = GameObject.FindGameObjectsWithTag("chip");

            for (int i = 0; i < modelScene._unit_ar.Count; i++)
            {
                chip_ar[i].transform.position = new Vector3(modelScene._unit_ar[i].GetTileX() + ((float)modelScene._unit_ar[i].GetX() / 100), 4, modelScene._unit_ar[i].GetTileY() + ((float)modelScene._unit_ar[i].GetY() / 100));


                // Анимация. 
                modelScene._unit_ar[i].getAnimation();
            }
        //}

        Camera.transform.position = new Vector3(
            Camera.transform.position.x+Joystick.Horizontal,
            Camera.transform.position.y+Joystick.Vertical,
            Camera.transform.position.z);

    }

    

}
