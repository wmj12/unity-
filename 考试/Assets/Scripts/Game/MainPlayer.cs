using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    None=-1,
    OpenShow,
    Run,
    Jump,
    Slide,
    Idle,
    Success,
    Fail
}

public class MainPlayer : MonoBehaviour {

    private Animator animator;
    private CharacterController characterController;
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    /// <summary>
    /// 角色控制器原来的高度和中心
    /// </summary>
    private float characterHeight;
    private Vector3 characterCenter;

    private Vector3 speed;
    public float xSpeed;
    public float ySpeed;
    public float zSpeed;
    /// <summary>
    /// 重力
    /// </summary>
    public float gravity;
    /// <summary>
    /// 是否成功
    /// </summary>
    private bool isSuccess = false;
    /// <summary>
    /// 是否失败
    /// </summary>
    private bool isFail = false;
    /// <summary>
    /// 死亡后重新开始有2秒停留，用此判断
    /// 是否是死亡后重新开始
    /// </summary>
    private bool isFailRun = false;
    /// <summary>
    /// 死亡动画是否结束
    /// </summary>
    private bool isFailOver = false;
    /// <summary>
    /// 游戏是否暂停
    /// </summary>
    private bool isSuspend=false;
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        ///默认声音为跳起
        audioSource.clip = audioClips[0];
        animator=gameObject.GetComponent<Animator>();
        characterController = gameObject.GetComponent<CharacterController>();
        characterHeight = characterController.height;
        characterCenter = characterController.center;
        speed = Vector3.zero;
    }

    void Update()
    {
        speed.y -= gravity;
        if (isSuccess||isFail)
        {
            speed = Vector3.zero;
        }
        ///没有暂停时使用
        if(!isSuspend)
            characterController.Move(speed * Time.deltaTime);      
    }


    public void SetState(State s)
    {
        StartCoroutine(ISetState((int)s));
    }
    IEnumerator ISetState(int s)
    {
        animator.SetInteger("state",s);
        yield return null;
        animator.SetInteger("state", -1);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle")
        {
            isFail = true;
            isFailRun = true;
            SetState(State.Fail);
            animator.Update(0);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Win"&&!isSuccess)
        {
            if (Data._instance.getGold >= Data._instance.GetNeedGold())
            {
                isSuccess = true;
                SetState(State.Success);
                animator.Update(0);
            }
            else
            {
                isFail=true;
                isFailRun = true;
                SetState(State.Fail);
                animator.Update(0);
            }
        }
    }
    /// <summary>
    /// 播放跳起音效
    /// </summary>
    public void PlayJumpAudio()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }
    /// <summary>
    /// 播放下滑音效
    /// </summary>
    public void PlaySlideAudio()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }

    /// <summary>
    /// 左右移动
    /// </summary>
    /// <param name="dir"></param>
    public void DoMoveX(float dir)
    {
        ///为了使角色在初始状态不会左右移动
        if(speed.z>0)
            speed.x = xSpeed * dir;
    }
    /// <summary>
    /// RunScripts设置速度
    /// </summary>
    public void DoMoveZ()
    {
        if (isFailRun)
            StartCoroutine(IFailRun());
        else
            speed.z = zSpeed;
    }
    /// <summary>
    /// 如果是死亡从新开始，则两秒后开始前进
    /// </summary>
    /// <returns></returns>
    IEnumerator IFailRun()
    {
        yield return new WaitForSeconds(2.0f);
        speed.z = zSpeed;
    }
    /// <summary>
    /// 跳起
    /// </summary>
    public void DoJump()
    {
        SetState(State.Jump);
    }
    /// <summary>
    /// 从JumpScript中设置Y速度
    /// </summary>
    public void DoMoveY()
    {
        speed.y = ySpeed;
    }
    /// <summary>
    /// 判断是否在地面，JumpScript调用
    /// </summary>
    /// <returns></returns>
    public bool IsGround()
    {
        return speed.y < 0 && characterController.isGrounded;
    }
    /// <summary>
    /// 下滑
    /// </summary>
    public void DoSlide()
    {
        SetState(State.Slide);
    }

    public void StartChangeCharacter()
    {
        characterController.height = 1.3f;
        characterController.center = new Vector3(0,0.65f,0);
    }
    public void EndChangeCharacter()
    {
        characterController.height = characterHeight;
        characterController.center = characterCenter;
    }

    /// <summary>
    /// 是否胜利
    /// </summary>
    /// <returns></returns>
    public bool IsSuccess()
    {
        return isSuccess;
    }
    /// <summary>
    /// 是否死亡
    /// </summary>
    /// <returns></returns>
    public bool IsFail()
    {
        return isFail;
    }
    /// <summary>
    /// 死亡动画结束
    /// </summary>
    public void SetFailOver()
    {
        isFailOver = true;
    }
    /// <summary>
    /// 死亡动画是否结束
    /// </summary>
    /// <returns></returns>
    public bool IsFailAnimatorOver()
    {
        return isFailOver;
    }
    /// <summary>
    /// 死亡后重新开始，将变量改为初始值
    /// </summary>
    public void FailAfterStart()
    {
        isSuccess = false;
        isFail = false;
        isFailOver = false;
    }

    /// <summary>
    /// 游戏暂停
    /// </summary>
    public void Suspend()
    {
        isSuspend = true;
        animator.SetFloat("AnimSpeed", 0);
    }
    /// <summary>
    /// 暂停结束
    /// </summary>
    public void SuspendOver()
    {
        isSuspend = false;
        animator.SetFloat("AnimSpeed", 1.0f);
    }
}
