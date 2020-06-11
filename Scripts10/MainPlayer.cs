using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour {

    private Animator animator;

    private readonly string AnimSpeed = "AnimSpeed";
    private readonly string IdleTrigger = "IdleTrigger";
    private readonly string FailTrigger = "FailTrigger";
    private readonly string SuccessTrigger = "SuccessTrigger";
    private readonly string JumpTrigger = "JumpTrigger";
    private readonly string SlideTrigger = "SlideTrigger";
    private readonly string Jump = "Jump";

    string animName;
    void Awake()
    {
        animator=gameObject.GetComponent<Animator>();
        animName = AnimName();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            KeyDownEvent();
       
        }
    }
    /// <summary>
    /// 获得当前播放动画的名字
    /// </summary>
    /// <returns></returns>
    private string AnimName()
    {
        string animName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        return animName;
    }

    private void KeyDownEvent()
    {
        animName = AnimName();
        if (Input.GetKeyDown(KeyCode.W)&&animName.Equals("Run"))
        {
            animator.SetTrigger(JumpTrigger);
        }
        else if (Input.GetKeyDown(KeyCode.S) && animName.Equals("Run"))
        {
            animator.SetTrigger(SlideTrigger);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger(SuccessTrigger);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger(FailTrigger);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger(IdleTrigger);
        }
        

    }
}
