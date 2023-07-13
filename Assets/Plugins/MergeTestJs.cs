using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class MergeTestJs : MonoBehaviour
{
    public Button ButtonTest;


    [DllImport("__Internal")]
    private static extern void Hello();


    void Start()
    {
        ButtonTest.onClick.AddListener(TestUnity);
        
    }

    void TestUnity()
    {
        Debug.Log("TestUnity =======  ");
Hello();
        Debug.Log("  Coord  ");
    }
    void Update()
    {
        
    }
}
