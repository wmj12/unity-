using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoolTime : MonoBehaviour {

    public GameObject getIT;

    public float coolTime;

    private long startTime;

    private float _time;

    private Text reckonTime;

    void Awake()
    {
        startTime = DateTime.Now.Ticks; 
        _time = coolTime;
    }

	void Start () {
        reckonTime = transform.Find("ReckonTime").GetComponent<Text>();
	}

	
	void Update () {
        _time = coolTime - (DateTime.Now.Ticks - startTime) / 10000000;
        if (_time > 0)
        {
            int hour = (int)_time / 3600;
            int minute = (int)_time % 3600 / 60;
            int second = (int)_time % 3600 % 60;
            reckonTime.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
        }
        else if (_time <= 0)
        {
            gameObject.SetActive(false);
            getIT.SetActive(true);
        }
        
	}

    public void Play()
    {
        startTime = DateTime.Now.Ticks;
        _time = coolTime;
    }
}
