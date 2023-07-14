using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MergeTestJs : MonoBehaviour
{
    public Button ButtonTest;
    public Text TextTest;
    public RawImage RawImageTest;

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void GetDataPlayer();


    void Start()
    {
        ButtonTest.onClick.AddListener(TestUnity);
        
    }

    void TestUnity()
    {
        Debug.Log("TestUnity =======  ");
        Hello();
        Debug.Log("  Coord  ");
        GetDataPlayer();
    }
    public void SetName(string name)
    {
        TextTest.text = name;
    }
    public void SetPhoto(string url)
    {
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
