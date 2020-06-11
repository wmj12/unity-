using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

    public float moveSpeed;

    private AudioSource audioSource;

    private Vector3 displacement=Vector3.zero;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

	void Update () {
        transform.Translate(displacement);
        AudioControl();
	}

    public void MoveHorizontal(float direction,float time)
    {
        displacement=new Vector3(moveSpeed*direction*time,displacement.y,displacement.z);
    }
    public void MoveVertical(float direction, float time)
    {
        displacement = new Vector3(displacement.x, displacement.y, moveSpeed * direction * time);
    }
    public void MoveStop()
    {
        displacement = Vector3.zero;
    }

    private void AudioControl(){
        if (displacement != Vector3.zero && !audioSource.isPlaying)
        {
            Debug.Log("播放音乐");
            audioSource.Play();
        }
        if (displacement == Vector3.zero && audioSource.isPlaying)
        {
            Debug.Log("停止音乐");
            audioSource.Stop();
        }
    }
}
