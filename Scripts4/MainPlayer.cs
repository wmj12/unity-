using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour {

    public enum State
    {
        None,
        Idle,
        Move,
        Fail,
        Success
    }

    private State state;

    public float xSpeed;
    public float ySpeed;
    public float zSpeed;
    public float gravity;
    private Vector3 speed=Vector3.zero;

    CharacterController characterController;
    void Awake()
    {
        state = State.None;
        characterController = GetComponent<CharacterController>();
    }

	
	void Update () {
        speed.y -= gravity;
        if (state == State.Move)
        {
            characterController.Move(speed * Time.deltaTime);
        }
	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle")
        {
            SetState(State.Fail);
        }
        if (hit.gameObject.tag == "WinPoint")
        {
            SetState(State.Success);
        }
    }

    public bool IsFail()
    {
        return state == State.Fail;
    }

    public bool IsSuccess()
    {
        return state == State.Success;
    }

    public void SetState(State s)
    {
        if (s == state)
            return;
        state = s;
        if (state == State.Idle)
        {
            StartCoroutine(IIdle2Move());
        }
        if (state == State.Move)
        {
            speed.z = zSpeed;
        }
    }

    IEnumerator IIdle2Move()
    {
        yield return new WaitForSeconds(3.0f);
        SetState(State.Move);
    }

    public void DoMoveX(float direction)
    {
        speed.x = direction * xSpeed;
    }

    public void DoJump()
    {
        if (IsGround())
        {
            speed.y = ySpeed;
        }
    }

    private bool IsGround()
    {
        return characterController.isGrounded && speed.y < 0;
    }
}
