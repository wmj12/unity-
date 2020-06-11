using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour {
    bool[] flags = { false, false };
    float _time = 0;

	void Update () {
        Exit();
	}

    void Exit()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _time = Time.time;
                flags[0] = true;
                flags[1] = false;
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                if (flags[0] == true && flags[1] == false&&Time.time-_time<2.0f)
                {
                    flags[1] = true;
                }
                else
                {
                    flags[0] = flags[1] = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                if (flags[0] == flags[1] == true && Time.time - _time <= 2.0f)
                {
                    Application.Quit();
                }
                else
                {
                    flags[0] = flags[1] = false;
                }
            }
            else
            {
                flags[0] = flags[1] = false;
            }
        }
    }
}
