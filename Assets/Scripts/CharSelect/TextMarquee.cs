using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMarquee : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3 ( -1 * Time.deltaTime, 0, 0 );
		if ( gameObject.transform.position.x < -12 )
			Destroy ( gameObject );
	}
}
