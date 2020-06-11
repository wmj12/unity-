using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Loader : MonoBehaviour {

    public delegate void LoadTextureAction(Texture2D texture);
    public LoadTextureAction loadTexture;

    public delegate void LoadSpriteAction(Sprite sprite);
    public LoadSpriteAction loadSprite;

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

    /// <summary>
    /// Texture
    /// </summary>
    /// <param name="url"></param>
    public void LoadTexture(string url)
    {
        StartCoroutine(ILoadTexture(url));
    }
    IEnumerator ILoadTexture(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("www.error" + www.error);
            yield break;
        }

        loadTexture(www.texture);
        www.Dispose();
    }

    /// <summary>
    /// Sprite
    /// </summary>
    /// <param name="url"></param>
    public void LoadSprite(string url)
    {
        StartCoroutine(ILoadSprite(url));
    }
    IEnumerator ILoadSprite(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("www.error" + www.error);
            yield break;
        }
        Texture2D texture = www.texture;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        loadSprite(sprite);
        www.Dispose();
    }

    /// <summary>
    /// Json，xml
    /// </summary>
    /// <param name="url"></param>
    public void LoadText(string url)
    {
        StartCoroutine(ILoadText(url));
    }
    IEnumerator ILoadText(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("www.error" + www.error);
            yield break;
        }
        loadText(www.text);
        www.Dispose();
    }




}
