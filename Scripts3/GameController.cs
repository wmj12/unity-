using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private MainCharacter mainCharacter;

    private MainCamera mainCamera;
	void Start () {
        InitMainObject();
	}

    private void InitMainObject()
    {
        GameObject obj = GameObject.Find("MainCharacter");
        mainCharacter = obj.GetComponent<MainCharacter>();

        mainCamera = Camera.main.GetComponent<MainCamera>();
        mainCamera.SetTrans(obj.transform);
    }
	void Update () {
        MainCharacterMove();
	}

    private void MainCharacterMove(){
        if (Input.GetAxis("Horizontal") != 0)
        {
            mainCharacter.MoveHorizontal(Input.GetAxis("Horizontal"), Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            mainCharacter.MoveVertical(Input.GetAxis("Vertical"), Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            mainCharacter.MoveStop();
        }
    }
}
