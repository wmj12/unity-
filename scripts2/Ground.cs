using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
    private bool flag;
    private void Awake()
    {
        flag = true;   
    }
    private void Disappear()
    {
        flag = !flag;
        gameObject.SetActive(flag);
    }
}
