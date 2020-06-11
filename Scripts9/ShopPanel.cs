using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopPanel : MonoBehaviour {

    public Button[] shopBtns;

    public Button onBackBtn;

    public GameObject backPackPanel;
	void Awake () {
        foreach (var v in shopBtns)
        {
            v.onClick.AddListener(() => OnClick_Shop(v.GetComponent<UIShopItem>()));
        }
        onBackBtn.onClick.AddListener(OnClick_OnBack);        
	}

    private void OnClick_Shop(UIShopItem shop)
    {
        ItemManager.Instance.AddItem(shop.id, shop.count);
    }

    private void OnClick_OnBack()
    {
        backPackPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
