using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    private Transform trans;

    private Vector3 offset;

    public void SetTrans(Transform trans)
    {
        this.trans = trans;
        offset = transform.position - this.trans.position;
    }

    void LateUpdate()
    {
        transform.position = trans.position + offset;
    }
}
