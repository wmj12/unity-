using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainPanel : MonoBehaviour {
    
    public Text goldCount;

	void Update () {
        goldCount.text = string.Format("{0}/{1}",
            Data._instance.getGold,Data._instance.GetNeedGold());
	}
}
