using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestAPI : MonoBehaviour
{
    // Get("https://www.example.com");
    public void Get(string uri, Action onComplete = null)
    {
        StartCoroutine(GetRequest(uri, onComplete));
    }

    // Post("http://www.my-server.com/myform", new Dictionary<string, string> { { "myField", "myData" } });
    public void Post(string uri, Dictionary<string, string> post, Action onComplete = null)
    {
        WWWForm form = new WWWForm();

        foreach (KeyValuePair<string, string> postArg in post)
            form.AddField(postArg.Key, postArg.Value);

        StartCoroutine(PostRequest(uri, form, onComplete));
    }

    private IEnumerator GetRequest(string uri, Action callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                callback?.Invoke();
            }
        }
    }

    private IEnumerator PostRequest(string uri, WWWForm form, Action callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
                callback?.Invoke();
            }
        }
    }
}
