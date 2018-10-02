using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSelfDestroyer : MonoBehaviour {

	float elapsedTime;
	float aniLength;

	// Use this for initialization
	void Start () {
		aniLength = GetComponent<Animator> ().GetCurrentAnimatorStateInfo ( 0 ).length;
	}

	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		if ( elapsedTime >= aniLength )
			Destroy ( gameObject );
	}
}
