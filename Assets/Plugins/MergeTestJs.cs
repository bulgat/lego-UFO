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
    public Button ButtonAuth;
    public Text TextTest;
    public RawImage RawImageTest;
    public UserData user;

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void LaunchTest();

    [DllImport("__Internal")]
    private static extern void GetDataPlayer();

    [DllImport("__Internal")]
    private static extern void AuthenticateUser();

    [DllImport("__Internal")]
    private static extern void GetUserData();

    void Start()
    {
        ButtonTest.onClick.AddListener(TestUnity);
        ButtonLaunch.onClick.AddListener(LaunchUnity);
        ButtonAuth.onClick.AddListener(AuthUnity);

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
    void AuthUnity()
    {
        AuthenticateUser();
        GetUserData();


        Debug.Log("000100 tUnity =======  "+user.name);
        Debug.Log("000101 tUnity =======  " + user.id);
        Debug.Log("000102 tUnity =======  " + user.avatarUrlSmall);
    }

    public void SetName(string name)
    {
        Debug.Log("∆дем очень-очень 002   SetName======  " + name);
        TextTest.text = name;
    }
    public void SetPhoto(string url)
    {
        Debug.Log("003   SetPhoto======  " + url);
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
    void Auth()
    {
        Debug.Log("0023456789   ======  " );
    }
    void SetAuth(string non)
    {
        Debug.Log("0023456789   ======  "+ non);
    }
}
public struct UserData
{
    public string id;
    public string name;
    public string avatarUrlSmall;
    public string avatarUrlMedium;
    public string avatarUrlLarge;
}
