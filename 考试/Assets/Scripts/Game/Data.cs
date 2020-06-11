using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    public static Data _instance;
    /// <summary>
    /// 金币
    /// </summary>
    private JsonData data;
    /// <summary>
    /// 获得金币数
    /// </summary>
    public int getGold=0;
    /// <summary>
    /// 需要金币数
    /// </summary>
    private int needGold=0;
    /// <summary>
    /// json地址
    /// </summary>
    private string jsonUrl;
    /// <summary>
    /// 将隐藏的金币放在list里，以便死亡后重新开始，再次加载出来
    /// </summary>
    public List<GameObject> golds;

    void Awake()
    {
        _instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
        jsonUrl = "file://" + Application.streamingAssetsPath + "/Task.json";
        Loader.Instance.LoadText(jsonUrl,LoadJson);
        golds = new List<GameObject>();
    }
    /// <summary>
    /// 获取json中总金币数目
    /// </summary>
    /// <param name="json"></param>
    private void LoadJson(string json)
    {
        data=JsonUtility.FromJson<JsonData>(json);
        foreach (LevelList level in data.levelList)
        {
            if (level.type.Equals("gold"))
            {
                needGold = level.num;
                return;
            }
        }
    }
    /// <summary>
    /// 供外界获取
    /// </summary>
    public int GetNeedGold()
    {
        return needGold;
    }
    /// <summary>
    /// 向list里添加数据
    /// </summary>
    public void AddGold(GameObject obj)
    {
        golds.Add(obj);
    }
    /// <summary>
    /// 获得被隐藏的list
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetGolds()
    {
        return golds;
    }

    /// <summary>
    /// 将所有金币显示后，清空
    /// </summary>
    public void ClearGolds()
    {
        golds.Clear();
    }

    [System.Serializable]
    public class JsonData
    {
        public string gameName;
        public string version;
        public LevelList[] levelList;
    }

    [System.Serializable]
    public class LevelList
    {
        public string type;
        public int num;
    }
}
