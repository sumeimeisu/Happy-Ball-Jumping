using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackObjectMover : MonoBehaviour {

	public float MovingUnit = 0.1f;
	public bool AllowTransparent = false;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 ( Random.Range ( -2.5f, 2.5f ), 5f, 0 );
		float scale = Random.Range ( 0.4f, 1.5f );
		gameObject.transform.localScale = new Vector3 ( scale, scale );
		if ( AllowTransparent )
			gameObject.GetComponent<SpriteRenderer> ().color = new Color ( 1, 1, 1, Random.Range ( 0.4f, 0.8f ) );
		MovingUnit = Random.Range ( 0.5f, 4f );
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position -= new Vector3 ( 0, MovingUnit * Time.deltaTime, 0 );
		if ( gameObject.transform.position.y < -5 )
			Destroy ( gameObject );
	}
}
