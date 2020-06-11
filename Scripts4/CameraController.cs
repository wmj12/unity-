using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Transform follower;

    private Vector3 offset;
    public void SetFollower(Transform trans){
        follower=trans;
        offset=transform.position-follower.position;
    }

	void LateUpdate () {
		transform.position=follower.position+offset;
	}
}
