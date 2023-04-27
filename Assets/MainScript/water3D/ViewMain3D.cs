using Assets.MainScript.water2D;
using Assets.MainScript.water3D;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewMain3D : MonoBehaviour
{
    public GameObject WaterColumn;
    List<List<Column>> Landscape_List;
    Dictionary<string, Column> LandscapeDictionary;
    int xStart = -3;
    int yStart = -3;
    List<GameObject> GraphicList;
    List<Point> CheckCubeList = new List<Point>() { 
        new Point(0,1),
        new Point(-1,0),
        new Point(1,0),
        new Point(-1,0)
    };
    int SizeMap = 29;
    Column LeakCube;
    Point indexFontain = new Point(3, 3);
    
    void Start()
    {
        Landscape_List = new List<List<Column>>();
        for(int i=0;i< SizeMap; i++)
        {
            List<Column> xList = new List<Column>();
            for (int z = 0; z < SizeMap; z++)
            {
                xList.Add(new Column(1, 1));
            }
            Landscape_List.Add(xList);
               
        }
     
        Landscape_List[1][0] = new Column(2, 1);
        Landscape_List[1][1] = new Column(3, 1);
            Landscape_List[1][2] = new Column(2, 1);

       
     
        LandscapeDictionary = new Dictionary<string, Column>();
        int countX = 0;
        foreach(List<Column> firstList in Landscape_List)
        {
            int countY = 0;
            foreach (Column secondColumn in firstList)
            {
                
                Point p = new Point(countX, countY);
                secondColumn.Position = p;
                LandscapeDictionary.Add(p.ToString(), secondColumn);
                countY++;
            }
            countX++;
        }
        GraphicList = new List<GameObject>();
        DrawWater();
    }

    void DrawWater()
    {
        //int count = 0;
        foreach (var item in LandscapeDictionary)
        {
Debug.Log("========"+ item.Value);
            GameObject waterStone = Instantiate(WaterColumn, new Vector2(xStart + item.Value.Position.x, yStart), Quaternion.identity);
            waterStone.transform.localScale = new Vector3(1, item.Value.Stone, 1);
            waterStone.transform.position = new Vector3(xStart + item.Value.Position.x, yStart + (float)item.Value.Stone / 2, item.Value.Position.z);
            waterStone.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
            GraphicList.Add(waterStone);

            GameObject waterCube = Instantiate(WaterColumn, new Vector2(xStart + item.Value.Position.x, yStart), Quaternion.identity);
            waterCube.transform.localScale = new Vector3(1, item.Value.Water, 1);

            waterCube.transform.position = new Vector3(xStart + item.Value.Position.x, yStart + item.Value.Stone + (float)item.Value.Water / 2, item.Value.Position.z);
            GraphicList.Add(waterCube);

        }
    }
    void RemoveWater()
    {
        foreach (var item in GraphicList)
        {
            Destroy(item);
        }
        GraphicList.Clear();
    }
    // Update is called once per frame
    void Update()
    {
        bool changeView = false;
        foreach (var item in LandscapeDictionary)
        {
            if (item.Value.Water > 0)
            {
                var checkCubeList = GradeColumn(item.Value);
                foreach (var checkColumn in checkCubeList)
                {
                    /*
                    Point checkCount = new Point(item.Value.Position.x  + check.x, item.Value.Position.z + check.z);
                    //Point checkPoint = check;
                    if (0 <= checkCount.x && SizeMap > checkCount.x)
                    {
                        if (0 <= checkCount.z && SizeMap > checkCount.z)
                        {
                            if (LandscapeDictionary[checkCount.ToString()].GetSum() < item.Value.GetSum())
                            {
                    */
                                //перенос
                                item.Value.Water -= 1;
                    //LandscapeDictionary[checkCount.ToString()].Water += 1;
                    checkColumn.Water += 1;
                    changeView = true;
                                break;
                    /*
                            }
                         }
                    }*/
                }
            }
        }
        if (LeakWater())
        {
            LeakCube.Water -= 1;
            LandscapeDictionary[indexFontain.ToString()].Water += 1;
        }
        if (changeView)
        {
            RemoveWater();
            DrawWater();
        }
    }
    List<Column> GradeColumn(Column item)
    {
        List<Column> gradeList = new List<Column>();
        foreach (var check in CheckCubeList)
        {
            Point checkCount = new Point(item.Position.x + check.x, item.Position.z + check.z);
            //Point checkPoint = check;
            if (0 <= checkCount.x && SizeMap > checkCount.x)
            {
                if (0 <= checkCount.z && SizeMap > checkCount.z)
                {
                    if (LandscapeDictionary[checkCount.ToString()].GetSum() < item.GetSum())
                    {
                        gradeList.Add(LandscapeDictionary[checkCount.ToString()]);
                    }
                }
            }
        }
        return gradeList.OrderBy(a=>a.GetSum()).ToList();
    }
    bool LeakWater()
    {

        var sumWater = LandscapeDictionary.Values.ToList().Sum(a => a.Water);
        if (5 < sumWater)
        {

            var list = LandscapeDictionary.Values.Where(a => a.Water > 0).OrderBy(a => a.Stone).ToList();
            int rnd = Random.Range(0, list.Count);
            LeakCube = list[rnd];
            return true;
        }

        return false;
    }
}
