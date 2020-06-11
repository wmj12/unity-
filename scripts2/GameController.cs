using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private GameObject obj;
	void Start () {
        obj = new GameObject("Boardcast");
        obj.AddComponent<Boardcast>();
	}
    void Update()
    {
        //第三题
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("D");
            if (gameObjects != null)
            {
            foreach (GameObject gam in gameObjects)
            {
                GameObject.Destroy(gam);

            }

            }
        }
     
    }    
}
