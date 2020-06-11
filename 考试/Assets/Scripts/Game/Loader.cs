using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;


public class Loader : MonoBehaviour {

    public delegate void LoadTextAction(string text);
    public LoadTextAction loadText;

    private static Loader _instance;
    public static Loader Instance
    {
        get
        {
            if (null == _instance)
            {
                GameObject obj = new GameObject("Loader");
                _instance = obj.AddComponent<Loader>();
                GameObject.DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public void LoadText(string url,LoadTextAction action)
    {
        StartCoroutine(ILoadText(url,action));
    }
    IEnumerator ILoadText(string url, LoadTextAction action)
    {
        WWW www = new WWW(url);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("www.error" + www.error);
            yield break;
        }
        action(www.text);
        www.Dispose();
    }
}
