using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    /// <summary>
    /// 主摄像机
    /// </summary>
    public MainCameraController mainCameraController;
    /// <summary>
    /// 成功后，环绕角色的摄像机
    /// </summary>
    public PlayerCamera playerCamera;
    /// <summary>
    /// 出生点
    /// </summary>
    public Transform birthPoint;
    /// <summary>
    /// 背包面板
    /// </summary>
    public GameObject packPanel;

    private MainPlayer mainPlayer;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

	void Start () {
        InitMainPlayer();
        InitCamera();
	}
    /// <summary>
    /// 初始化角色
    /// </summary>
    private void InitMainPlayer()
    {
        UnityEngine.Object o = Resources.Load("Prefab/MainPlayer");
        GameObject obj = Instantiate(o) as GameObject;
        obj.transform.position = birthPoint.position;
        mainPlayer = obj.GetComponent<MainPlayer>();
    }
    /// <summary>
    /// 初始化相机
    /// </summary>
    private void InitCamera()
    {
        mainCameraController.SetFollower(mainPlayer.transform);
    }
	void Update () {

        if (mainPlayer.IsSuccess())
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            ///为false说明还没有执行
            if (playerCamera.gameObject.activeSelf == false)
            {
                mainCameraController.gameObject.SetActive(false);
                playerCamera.gameObject.SetActive(true);
                playerCamera.SetSurrounder(mainPlayer.transform);
            }
            return;
        }
        if (mainPlayer.IsFail())
        {
            ///死亡动画结束，重新开始
            if (mainPlayer.IsFailAnimatorOver())
            {
                mainPlayer.transform.position = birthPoint.position;
                mainPlayer.FailAfterStart();
                ///金币改为0
                Data._instance.getGold = 0;
                ///隐藏的金币显示
                foreach(GameObject obj in Data._instance.GetGolds()){
                    obj.SetActive(true);
                }
                ///清空
                Data._instance.ClearGolds();
            }
            return;
        }

        if (Input.GetAxis("Horizontal")!=0)
        {
            mainPlayer.DoMoveX(Input.GetAxis("Horizontal"));
        }
        if (Input.GetAxis("Vertical")>0)
        {
            mainPlayer.DoJump();
        }
        else if (Input.GetAxis("Vertical")<0)
        {
            mainPlayer.DoSlide();
        }		
	}

    /// <summary>
    /// 打开背包
    /// </summary>
    public void OnClick_OpenPackPanel()
    {
        packPanel.SetActive(true);
        mainPlayer.Suspend();
    }
    /// <summary>
    /// 关闭背包
    /// </summary>
    public void OnClick_ClosePackPanel()
    {
        packPanel.SetActive(false);
        mainPlayer.SuspendOver();
    }
}
