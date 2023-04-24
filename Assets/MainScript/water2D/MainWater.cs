using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MainWater : MonoBehaviour
{
    public GameObject WaterCube;
    List<int> CubeStoneList;
    List<int> WaterCubeList;
    int xStart = -3;
    int yStart = -3;
    List<GameObject> GraphicList;
    void Start()
    {
        CubeStoneList = new List<int>() { 0, 0, 1, 2, 3, 2, 1, 2, 3 };
        WaterCubeList = new List<int>() { 1, 2, 3, 2, 1, 2, 3, 3, 3 };
        GraphicList = new List<GameObject>();
        DrawWater();
        //RemoveWater();

    }
    private void DrawWater()
    {
        int count = 0;
        foreach(var item in CubeStoneList)
        {
            GameObject waterStone = Instantiate(WaterCube, new Vector2(xStart+ count, yStart), Quaternion.identity);
            waterStone.transform.localScale = new Vector3(1, item, 1);
            waterStone.transform.position = new Vector3(xStart + count, yStart+(float)item/2,1);
            waterStone.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
            GraphicList.Add(waterStone);
            //set water
            if (WaterCubeList[count] > 0)
            {
                GameObject waterCube = Instantiate(WaterCube, new Vector2(xStart + count, yStart), Quaternion.identity);
                waterCube.transform.localScale = new Vector3(1, WaterCubeList[count], 1);
                //waterCube.transform.position = new Vector3(xStart + count, item  + .5f, 1);
                waterCube.transform.position = new Vector3(xStart + count, yStart+item + (float) WaterCubeList[count]/2, 1);
                GraphicList.Add(waterCube);
            }
            count++;
        }
        
    }
    void RemoveWater() {
        foreach(var item in GraphicList)
        {
            Destroy(item);
        }
        GraphicList.Clear();
    }
    void LeakWater()
    {
        var sumWater = WaterCubeList.Sum();
        if (5<sumWater)
        {
           // var t = WaterCubeList.Select((a, index) =>  new {height = CubeStoneList[index] + a,water=a}).Where().ToList();
        }
    }
    List<int> CheckCubeList = new List<int>() { -1, 1 };
    void Update()
    {
        bool changeView=false;
        int count = 0;
        foreach (var item in CubeStoneList)
        {
            if (WaterCubeList[count] > 0) {
                var height = GetHeightTotal(count);
                foreach (var check in CheckCubeList)
                {
                    var checkCount = count + check;
                    if (0<=checkCount && CubeStoneList.Count> checkCount)
                    {
                        if (GetHeightTotal(checkCount) < height)
                        {
                            //перенос
                            WaterCubeList[count] -= 1;
                            WaterCubeList[checkCount] += 1;
                            changeView = true;
                            break;
                        }
                    }
                }
            }
            count++;
        }
        if (changeView)
        {
            RemoveWater();
            DrawWater();
        }
        

        
    }
    private int GetHeightTotal(int Index) { 
        return CubeStoneList[Index] + WaterCubeList[Index];
    }
}
