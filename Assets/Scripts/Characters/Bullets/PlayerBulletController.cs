using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3 ( 0, 1, 0 ) * 5 * Time.deltaTime;

		if ( gameObject.transform.position.y > 5 )
			Destroy ( gameObject );
	}

	void OnTriggerEnter2D ( Collider2D collision )
	{
		if ( collision.tag == "Enemy" )
			Destroy ( gameObject );
	}
}
