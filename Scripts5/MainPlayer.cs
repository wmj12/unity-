using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour {

    public enum State
    {
        None=-1,
        OpeningShow,
        Idle,
        Run,
        Jump,
        Success,
        Fail,
        Slide
    }

    private State state = State.None;

    private readonly string OpeningShow = "ATM_openingShow";
    private readonly string Idle = "ATM_idle";
    private readonly string Run = "ATM_run";
    private readonly string Jump = "ATM_jump";
    private readonly string Slide = "ATM_xiahua";
    private readonly string Success = "ATM_shengli"; 
    private readonly string Fail = "ATM_shibai"; 

    private Animation animation;
    private CharacterController characterController;

    private Vector3 speed=Vector3.zero;
    public float xSpeed;
    public float ySpeed;
    public float zSpeed;

    public float gravity;

    void Awake()
    {
        animation=GetComponent<Animation>();
        characterController=GetComponent<CharacterController>();
    }
	
	void Update () {
        speed.y -= gravity;
        CheckAniPlayOver();
        characterController.Move(speed * Time.deltaTime);

	}

    public void SetState(State s)
    {
        if (s == state)
            return;
        state = s;
        if (state == State.OpeningShow)
        {
            speed = Vector3.zero;
            PlayAnimation(OpeningShow, WrapMode.Once);
        }
        else if (state == State.Run)
        {
            speed.z = zSpeed;
            PlayAnimation(Run, WrapMode.Loop);
        }
        else if (state == State.Jump)
        {
            speed.y = ySpeed;
            PlayAnimation(Jump, WrapMode.ClampForever);
        }
        else if (state == State.Slide)
        {
            PlayAnimation(Slide, WrapMode.Once);
        }
        else if (state == State.Fail)
        {
            speed = Vector3.zero;
            PlayAnimation(Fail, WrapMode.Once);
        }
        else if (state == State.Success)
        {
            speed = Vector3.zero;
            PlayAnimation(Success, WrapMode.Once);
        }
        else if (state == State.Idle)
        {
            speed = Vector3.zero;
            PlayAnimation(Idle, WrapMode.Loop);
        }
    }
    //动画结束后切换
    private void CheckAniPlayOver()
    {
        if (state == State.OpeningShow&&!animation.IsPlaying(OpeningShow)){
            SetState(State.Run);
        }
        else if (state == State.Slide && !animation.IsPlaying(Slide))
        {
            SetState(State.Run);
        }
        else if (IsJumpOver())
        {
            SetState(State.Run);
        }
    }
    //左右移动
    public void DoMoveX(float dir)
    {
        speed.x = xSpeed * dir;
    }
    //跳起
    public void DoJump()
    {
        if (state != State.Run)
            return;
        SetState(State.Jump);
    }
    //下滑
    public void DoSlide()
    {
        if (state != State.Run)
            return;
        SetState(State.Slide);
    }
    //判断跳起是否结束
    private bool IsJumpOver()
    {
        if (state == State.Jump && characterController.isGrounded && speed.y < 0)
        {
            animation.Stop(Jump);
            return true;
        }
        return false;
    }

    //是否失败
    public bool IsStateFail()
    {
        if (state == State.Fail && !animation.IsPlaying(Fail))
            return true;
        return false;
    }

    public bool IsStateSuccess()
    {
        if (state == State.Success)
            return true;
        return false;
    }

    public bool IsStateSuccessOver()
    {
        if (state == State.Success && !animation.IsPlaying(Success))
            return true;
        return false;
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle")
        {
            SetState(State.Fail);
        }
        //此处加上&&是为了角色在地面上
        if (hit.gameObject.tag == "WinPoint"&&state==State.Run)
        {
            SetState(State.Success);
        }
    }

    //播放动画
    private void PlayAnimation(string name, WrapMode wrapMode)
    {
        animation[name].wrapMode = wrapMode;
        animation.Play(name);
    }
}
