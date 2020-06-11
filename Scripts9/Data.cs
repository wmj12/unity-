using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    public static Data _instance;

    void Awake()
    {
        _instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private List<ItemAttribute> itemAttributes;


    public int MaxCount(int id)
    {
        foreach (var v in itemAttributes)
        {
            if (v.id == id)
            {
                return v.maxCount;
            }
        }
        return 0;
    }
    public string Name(int id)
    {
        foreach (var v in itemAttributes)
        {
            if (v.id == id)
            {
                return v.name;
            }
        }
        return "";
    }
    public Color ItemColor(int id)
    {
        foreach (var v in itemAttributes)
        {
            if (v.id == id)
            {
                return v.color;
            }
        }
        return Color.white;
    }

    [System.Serializable]
    public class ItemAttribute
    {
        public int id;
        public string name;
        public int maxCount;
        public Color color;
    }
}
