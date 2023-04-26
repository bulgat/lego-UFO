using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.MainScript.water2D;

public class MainWater : MonoBehaviour
{
    public GameObject WaterCube;

    List<Cube> Landscape_List;
    Dictionary<string,Cube> LandscapeDictionary;
    Cube LeakCube;
    Point indexFontain = new Point(6,0);

    int xStart = -3;
    int yStart = -3;
    List<GameObject> GraphicList;
    void Start()
    {

        Landscape_List = new List<Cube>()
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

        LandscapeDictionary = new Dictionary<string, Cube>();
        for (int i= 0; i < 11; i++)
        {
            Point p = new Point(i, 0);
            LandscapeDictionary.Add(p.ToString(), Landscape_List[i]);
            
        }
        


        GraphicList = new List<GameObject>();
        DrawWater();

    }
    private void DrawWater()
    {
        int count = 0;
        foreach(var item in LandscapeDictionary)
        {
            GameObject waterStone = Instantiate(WaterCube, new Vector2(xStart+ count, yStart), Quaternion.identity);
            waterStone.transform.localScale = new Vector3(1, item.Value.Stone, 1);
            waterStone.transform.position = new Vector3(xStart + count, yStart+(float)item.Value.Stone/2,1);
            waterStone.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
            GraphicList.Add(waterStone);

                GameObject waterCube = Instantiate(WaterCube, new Vector2(xStart + count, yStart), Quaternion.identity);
                waterCube.transform.localScale = new Vector3(1, item.Value.Water, 1);

                waterCube.transform.position = new Vector3(xStart + count, yStart+item.Value.Stone + (float)item.Value.Water/2, 1);
                GraphicList.Add(waterCube);

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
    bool LeakWater()
    {
        
        var sumWater = LandscapeDictionary.Values.ToList().Sum(a=>a.Water);
        if (5<sumWater)
        {

            var list = LandscapeDictionary.Values.Where(a => a.Water > 0).OrderBy(a => a.Stone).ToList();
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
        foreach (var item in LandscapeDictionary)
        {
            if (item.Value.Water > 0) {

                foreach (var check in CheckCubeList)
                {
                    var checkCount = count + check;
                    Point checkPoint = new Point(checkCount, 0);
                    if (0<=checkCount && LandscapeDictionary.Count> checkCount)
                    {
                        Debug.Log("check = "+ checkPoint.x+"-"+ checkPoint.z);
                        if (LandscapeDictionary[checkPoint.ToString()].GetSum() < item.Value.GetSum())
                        {
                            //перенос
                            item.Value.Water -= 1;
                            LandscapeDictionary[checkPoint.ToString()].Water += 1;
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
            //LandscapeDictionary[indexFontain.ToString()].Water += 1;
        }

        if (changeView)
        {
            RemoveWater();
            DrawWater();
        }
        

        
    }

}
