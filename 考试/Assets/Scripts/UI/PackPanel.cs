using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PackPanel : MonoBehaviour {

    public Transform content;

    private UnityEngine.Object prefab;
	void Awake () {
        prefab = Resources.Load("Prefab/Grid");
	}

    void OnEnable()
    {
        LoadGrid();
    }

    void OnDisable()
    {
        foreach (Transform obj in content)
        {
            GameObject.Destroy(obj.gameObject);
        }
    }
    /// <summary>
    /// 加载金币
    /// </summary>
    void LoadGrid()
    {
        for (int i = 0; i < Data._instance.getGold; i++)
        {
            GameObject obj = Instantiate(prefab) as GameObject;
            obj.transform.SetParent(content);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
        }
    }
}
