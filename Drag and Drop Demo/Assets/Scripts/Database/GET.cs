using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GET : MonoBehaviour {
    
    //GET
    public void get(string uid)
    {
        string url = "http://167.99.5.35:8080/API/get?uid=" + uid;
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    //POST

    public void post(string url, string data, string uid){
        //string url = "http://167.99.5.35:8080/API/save";
        //string data = "{\"name\":\"bob marley from unity test 2\"}";
        //string uid = "5XwCmxgUF3PY61vPclwcKoyiQJr1";
        StartCoroutine(PostRequest(url,data,uid));
    }

    IEnumerator PostRequest(string url, string json, string uid)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.SetRequestHeader("uid", uid);


        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);

        }
    }
}
