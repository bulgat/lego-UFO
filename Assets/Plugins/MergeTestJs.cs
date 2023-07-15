using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MergeTestJs : MonoBehaviour
{
    public Button ButtonTest;
    public Button ButtonLaunch;
    public Text TextTest;
    public RawImage RawImageTest;

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void LaunchTest();

    [DllImport("__Internal")]
    private static extern void GetDataPlayer();


    void Start()
    {
        ButtonTest.onClick.AddListener(TestUnity);
        ButtonLaunch.onClick.AddListener(LaunchUnity);


    }

    void TestUnity()
    {
        Debug.Log("TestUnity =======  ");
        Hello();
        Debug.Log("Button  Coo  ");
        GetDataPlayer();
        Debug.Log("End Button Coo  ");
    }
    void LaunchUnity()
    {
        Debug.Log("000000 tUnity =======  ");
        LaunchTest();
    }
    public void SetName(string name)
    {
        Debug.Log("002======  "+ name);
        TextTest.text = name;
    }
    public void SetPhoto(string url)
    {
        Debug.Log("003======  "+ url);
        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("request.error = " + request.error);
        } else
        {
            RawImageTest.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
    void Update()
    {
        
    }
}
