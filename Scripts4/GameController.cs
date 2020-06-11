using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private MainPlayer mainPlayer;
    //出生地
    public Vector3 birthPlace;

    private CameraController cameraController;

    private AudioSource winAudioSource;

    void Awake()
    {
        winAudioSource=GetComponent<AudioSource>();
    }

	void Start () {
        InitMainPlayer();
        cameraController=Camera.main.GetComponent<CameraController>();
        cameraController.SetFollower(mainPlayer.transform);
	}

    private void InitMainPlayer()
    {
        GameObject obj = GameObject.Find("MainPlayer");
        mainPlayer=obj.GetComponent<MainPlayer>();
        mainPlayer.SetState(MainPlayer.State.Idle);
        obj.transform.position = birthPlace;
    }
	
	void Update () {
        if (mainPlayer.IsFail())
        {
            mainPlayer.SetState(MainPlayer.State.Idle);
            mainPlayer.transform.position = birthPlace;
        }
        if (mainPlayer.IsSuccess())
        {
            if(!winAudioSource.isPlaying)
                winAudioSource.Play();
        }
        mainPlayer.DoMoveX(Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainPlayer.DoJump();
        }
	}
}
