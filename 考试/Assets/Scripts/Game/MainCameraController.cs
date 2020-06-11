using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

    private Transform follower;

    public Vector3 offset;

    public void SetFollower(Transform trans)
    {
        follower = trans;
    }
	
	void LateUpdate () {
        transform.position = follower.position + offset;
	}
}
