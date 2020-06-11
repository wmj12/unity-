using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour {

    Animation animation;
	void Awake () {
        animation = GetComponent<Animation>();
        animation["tiao"].wrapMode = WrapMode.Loop;
        animation.Play("tiao");
	}
}
