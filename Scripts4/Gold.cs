using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

    private AudioSource audioSource;
	
	void Awake () {
		audioSource=GetComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            audioSource.Play();
            Destroy(gameObject.GetComponent<MeshRenderer>());
            StartCoroutine(IDestroy());
        }
    }

    IEnumerator IDestroy()
    {
        yield return new WaitForSeconds(1f);
        gameObject.AddComponent<MeshRenderer>();
        gameObject.SetActive(false);
    }
	
}
