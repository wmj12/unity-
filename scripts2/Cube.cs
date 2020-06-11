using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    private Renderer render;

    void Awake()
    {
        render = gameObject.GetComponent<Renderer>();
    }

    void OnEnable()
    {
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                {
                    render.material.color = Color.red;
                    break;
                }
            case 1:
                {
                    render.material.color = Color.green;
                    break;
                }
            case 2:
                {
                    render.material.color = Color.blue;
                    break;
                }
            default:
                Debug.Log("随机数错误");
                break;
        }
    }
    

        

}
