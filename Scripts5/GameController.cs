using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Vector3 birthPlace;

    private MainPlayer mainPlayer;

    private GameObject mainCamera;
    private MainCameraController mainCameraController;

    private GameObject rotateCamera;
    private RotateCamera rotateCameraController;

	void Start () {
        InitMainPlayer();
        InitCamera(mainPlayer.transform);
	}
    /// <summary>
    /// 实例化角色
    /// </summary>
    private void InitMainPlayer()
    {
        UnityEngine.Object o = Resources.Load("Prefab/MainPlayer");
        GameObject obj = GameObject.Instantiate(o) as GameObject;
        mainPlayer=obj.GetComponent<MainPlayer>();
        mainPlayer.transform.position = birthPlace;
        mainPlayer.SetState(MainPlayer.State.OpeningShow);        
    }
    /// <summary>
    /// 实例化摄像机
    /// </summary>
    /// <param name="trans"></param>
    private void InitCamera(Transform trans)
    {
        mainCamera = GameObject.Find("Main Camera");
        mainCameraController = mainCamera.GetComponent<MainCameraController>();
        mainCameraController.SetFollower(trans);

        rotateCamera = GameObject.Find("RotateCamera");
        rotateCameraController=rotateCamera.GetComponent<RotateCamera>();
        rotateCamera.SetActive(false);
    }
	
	
	void Update () {

        if (mainPlayer.IsStateSuccess())
        {
            mainCamera.SetActive(false);
            if (!rotateCamera.activeSelf)
            {
                rotateCamera.SetActive(true);
                rotateCameraController.SetRotationAxis(mainPlayer.transform);
            }
        }
        if (mainPlayer.IsStateSuccessOver())
        {
            mainPlayer.SetState(MainPlayer.State.Idle);
        }

        if (mainPlayer.IsStateFail())
        {
            mainPlayer.transform.position = birthPlace;
            mainPlayer.SetState(MainPlayer.State.OpeningShow);
        }

        mainPlayer.DoMoveX(Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.W) || Input.GetMouseButton(0))
        {
            mainPlayer.DoJump();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetMouseButton(1))
        {
            mainPlayer.DoSlide();
        }
	}
}
