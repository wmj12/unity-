using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackPackPanel : MonoBehaviour {

    public Transform content;

    public Button closeBtn;

    public GameObject shopPanel;

    private UnityEngine.Object prefab=null;
	void Awake () {
        prefab = Resources.Load("Prefab/Grid");

        closeBtn.onClick.AddListener(OnClick_Close);
	}

    void OnEnable()
    {
        RefreshGrids();
    }

    void OnDisable()
    {
        foreach (Transform trans in content)
            GameObject.Destroy(trans.gameObject);
    }

    private void RefreshGrids()
    {
        foreach (Item item in ItemManager.Instance.GetItems())
        {
            GameObject obj = GameObject.Instantiate(prefab) as GameObject;
            obj.transform.SetParent(content);
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = Vector3.zero;

            Grid grid=obj.GetComponent<Grid>();
            grid.Init(item.Count, Data._instance.ItemColor(item.Id));
        }
    }

    private void OnClick_Close()
    {
        shopPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
