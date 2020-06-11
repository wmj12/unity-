using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {
    //旋转中心
    public Transform rotationAxis;
    //速度
    public float speed;
    //是否旋转
    private bool isRotation;

    public void SetRotationAxis(Transform trans)
    {
        rotationAxis = trans;
        //为了让角色在摄像头的中间
        transform.position = new Vector3(rotationAxis.position.x, transform.position.y, transform.position.z);
    }

    void OnEnable()
    {
        isRotation = true;
        StartCoroutine(IStopRotation());
    }
	void Update () {
        if (rotationAxis != null&&isRotation)
        {
            transform.RotateAround(rotationAxis.position, Vector3.up, speed * Time.deltaTime);
        }
	}
    //一圈后停下
    IEnumerator IStopRotation()
    {
        yield return new WaitForSeconds(360f / speed);
        Debug.Log(360f/speed);
        isRotation = false;
    }
}
