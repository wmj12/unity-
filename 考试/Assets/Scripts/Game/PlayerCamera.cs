using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    private Transform surrounder;

    public Vector3 offset;
    /// <summary>
    /// 旋转速度
    /// </summary>
    public float speed;
    /// <summary>
    /// 是否开始旋转
    /// </summary>
    private bool isRotate = false;
    public void SetSurrounder(Transform trans)
    {
        surrounder = trans;
        transform.position = offset + surrounder.position;
        isRotate = true;
    }
	
	
	void LateUpdate () {
        if (isRotate)
            transform.RotateAround(surrounder.position, Vector3.up, speed * Time.deltaTime);
	}
}
