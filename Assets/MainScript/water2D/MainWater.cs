using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.MainScript.water2D;

public class MainWater : MonoBehaviour
{
    public GameObject WaterCube;

    List<Cube> LandscapeList;
    Cube LeakCube;
    int indexFontain = 6;
    //List<int> CubeStoneList;
    //List<int> WaterCubeList;
    int xStart = -3;
    int yStart = -3;
    List<GameObject> GraphicList;
    void Start()
    {
        //CubeStoneList = new List<int>() { 0, 0, 1, 2, 3, 2, 1, 2, 3 };
        //WaterCubeList = new List<int>() { 1, 2, 3, 2, 1, 2, 3, 3, 3 };
        LandscapeList = new List<Cube>()
        {
            new Cube(0,1),
            new Cube(0,2),
            new Cube(1,3),
            new Cube(2,2),
            new Cube(3,1),
            new Cube(2,2),
            new Cube(3,1),
            new Cube(2,2),
            new Cube(1,3),
            new Cube(2,3),
            new Cube(3,3)
        };
        GraphicList = new List<GameObject>();
        DrawWater();
        //RemoveWater();

    }
    private void DrawWater()
    {
        int count = 0;
        foreach(var item in LandscapeList)
        {
            GameObject waterStone = Instantiate(WaterCube, new Vector2(xStart+ count, yStart), Quaternion.identity);
            waterStone.transform.localScale = new Vector3(1, item.Stone, 1);
            waterStone.transform.position = new Vector3(xStart + count, yStart+(float)item.Stone/2,1);
            waterStone.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
            GraphicList.Add(waterStone);
            //set water
            //if (WaterCubeList[count] > 0)
            //{
                GameObject waterCube = Instantiate(WaterCube, new Vector2(xStart + count, yStart), Quaternion.identity);
                waterCube.transform.localScale = new Vector3(1, item.Water, 1);
                //waterCube.transform.position = new Vector3(xStart + count, item  + .5f, 1);
                waterCube.transform.position = new Vector3(xStart + count, yStart+item.Stone + (float) item.Water/2, 1);
                GraphicList.Add(waterCube);
            //}
            count++;
        }
        //LeakWater();
    }
    void RemoveWater() {
        foreach(var item in GraphicList)
        {
            Destroy(item);
        }
        GraphicList.Clear();
    }
    bool LeakWater()
    {
        var sumWater = LandscapeList.Sum(a=>a.Water);
        if (5<sumWater)
        {
            //var t = WaterCubeList.Select((a, index) =>  new {height = CubeStoneList[index] + a,water=a}).Where().ToList();
            var list = LandscapeList.Where(a => a.Water > 0).OrderBy(a => a.Stone).ToList();
            Debug.Log(list[0].Stone+"========"+list.Last().Stone);
            LeakCube = list.First();
            return true;
        }
        return false;
    }
    List<int> CheckCubeList = new List<int>() { -1, 1 };
    void Update()
    {
        bool changeView=false;
        int count = 0;
        foreach (var item in LandscapeList)
        {
            if (item.Water > 0) {
                //var height = item.GetSum();
                foreach (var check in CheckCubeList)
                {
                    var checkCount = count + check;
                    if (0<=checkCount && LandscapeList.Count> checkCount)
                    {
                        if (LandscapeList[checkCount].GetSum() < item.GetSum())
                        {
                            //перенос
                            LandscapeList[count].Water -= 1;
                            LandscapeList[checkCount].Water += 1;
                            changeView = true;
                            break;
                        }
                    }
                }
            }
            count++;
        }
        if (LeakWater())
        {
            LeakCube.Water-=1;
            //LandscapeList[indexFontain].Water += 1;
        }

        if (changeView)
        {
            RemoveWater();
            DrawWater();
        }
        

        
    }
    /*
    private int GetHeightTotal(int Index) { 
        return LandscapeList[Index].Stone + LandscapeList[Index].Water;
    }
    */
}
