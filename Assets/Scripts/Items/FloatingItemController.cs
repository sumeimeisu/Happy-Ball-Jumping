using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItemController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3 ( 0, -2, 0 ) * Time.deltaTime;
		if ( gameObject.transform.position.y < -4.4f )
		{
			Destroy ( gameObject );
		}
	}

	void OnCollisionEnter2D ( Collision2D collision )
	{
		if ( collision.gameObject.tag == "Player" )
		{
			Destroy ( gameObject );
		}
	}
}
