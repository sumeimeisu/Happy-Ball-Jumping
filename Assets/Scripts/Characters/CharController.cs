using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	public const float MovementUnit = 1.5f;

	public GameObject BoomEffect;

	// Use this for initialization
	void Start () {
		
	}

	Vector3 lastMousePos;
	
	// Update is called once per frame
	void Update () {
		Vector3 charMove = new Vector3 ();

		if ( Input.GetKey ( KeyCode.W ) || Input.GetKey ( KeyCode.UpArrow ) )
			charMove.y += MovementUnit;
		if ( Input.GetKey ( KeyCode.S ) || Input.GetKey ( KeyCode.DownArrow ) )
			charMove.y -= MovementUnit;
		if ( Input.GetKey ( KeyCode.A ) || Input.GetKey ( KeyCode.LeftArrow ) )
			charMove.x -= MovementUnit;
		if ( Input.GetKey ( KeyCode.D ) || Input.GetKey ( KeyCode.RightArrow ) )
			charMove.x += MovementUnit;

		if ( Input.touchCount > 0 )
		{
			var touchPoint = Input.GetTouch ( 0 );
			var tp = touchPoint.deltaPosition;
			charMove += new Vector3 ( tp.x, tp.y, 0 );
		}

		if ( Input.mousePresent )
		{
			if ( Input.GetMouseButtonDown ( 0 ) )
			{
				lastMousePos = Input.mousePosition;
			}

			if ( Input.GetMouseButton ( 0 ) )
			{
				Vector3 currentMousePos = Input.mousePosition;
				charMove += ( currentMousePos - lastMousePos );
				lastMousePos = currentMousePos;
			}
		}

		charMove *= Time.deltaTime;

		gameObject.transform.position += charMove;

		if ( gameObject.transform.position.x <= -2.3f )
			gameObject.transform.position = new Vector3 ( -2.3f, gameObject.transform.position.y );
		if ( gameObject.transform.position.x >= 2.3f )
			gameObject.transform.position = new Vector3 ( 2.3f, gameObject.transform.position.y );
		if ( gameObject.transform.position.y <= -3.8f )
			gameObject.transform.position = new Vector3 ( gameObject.transform.position.x, -3.8f );
		if ( gameObject.transform.position.y >= 3.8f )
			gameObject.transform.position = new Vector3 ( gameObject.transform.position.x, 3.8f );
	}
}
