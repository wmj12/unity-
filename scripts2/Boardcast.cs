using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boardcast : MonoBehaviour {

    private GameObject ground;

    float _time;
	void Start () {
        ground = GameObject.Find("Ground");
        _time = 0;
	}
	
	void Update () {
        _time += Time.deltaTime;
        if(_time>=2.0f)
        {
            if (ground.activeSelf)
            {             
                ground.SendMessage("Disappear");
            }
            _time = 0;
        }
	}
}
