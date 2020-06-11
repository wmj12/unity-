using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour {
    public GameObject[] objs;
	// Use this for initialization
	void Start () {
        StartCoroutine(IHide());
	}
	
   IEnumerator IHide()
    {
        yield return new WaitForSeconds(3.0f);
        foreach(GameObject obj in objs)
        {
            if (obj.activeSelf&&obj.layer == LayerMask.NameToLayer("CoroutineTest"))
            {
                obj.SetActive(false);
            }
        }
        yield return new WaitForSeconds(2.0f);
        foreach (GameObject obj in objs)
        {
            if (!obj.activeSelf && obj.layer == LayerMask.NameToLayer("CoroutineTest"))
            {
                obj.SetActive(true);
            }
        }
    }
}
