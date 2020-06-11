using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

    private AudioSource audioSource;
    /// <summary>
    /// 是否被吃到
    /// </summary>
    private bool state = false;
    /// <summary>
    /// 原来大小
    /// </summary>
    private Vector3 scale;
	void Awake () {
        audioSource = gameObject.GetComponent<AudioSource>();

        scale = transform.localScale;
	}

	void OnTriggerEnter (Collider other) {
        //与角色接触，且之前未被吃到
        if (other.gameObject.tag == "Player"&&!state)
        {
            audioSource.Play();
            Data._instance.getGold++;
            state = true;
            transform.localScale = Vector3.zero;
            StartCoroutine(IHide());
        }
	}

    IEnumerator IHide()
    {
        Data._instance.AddGold(gameObject);
        yield return new WaitForSeconds(1.0f);
        state = false;
        transform.localScale = scale;
        gameObject.SetActive(false);
    }
}
