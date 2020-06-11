using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 持久化
/// </summary>
public class Persistence : MonoBehaviour {
    public Button persistBtn;
    public Text text;

    private int count;
    void Awake()
    {
        count = PlayerPrefs.GetInt("Count", 0);
        persistBtn.onClick.AddListener(OnClick_Count);
        text.text = count.ToString();
    }

    private void OnClick_Count()
    {
        count++;
        PlayerPrefs.SetInt("Count", count);
        text.text = count.ToString();
    }
	
}
