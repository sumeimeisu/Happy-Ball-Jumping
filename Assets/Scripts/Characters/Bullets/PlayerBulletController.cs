using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour {

	public float Angle = 90;
	public bool Rotation = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		gameObject.transform.rotation = Quaternion.AngleAxis ( Angle - 90, new Vector3 ( 0, 0, 1 ) );

		float radian = Angle / 180 * Mathf.PI;
		gameObject.transform.position += new Vector3 ( Mathf.Cos ( radian ), Mathf.Sin ( radian ), 0 ) * 5 * Time.deltaTime;

		if ( Mathf.Abs ( gameObject.transform.position.y ) > 5 || Mathf.Abs ( gameObject.transform.position.x ) > 4 )
			Destroy ( gameObject );
	}

	void OnCollisionEnter2D ( Collision2D collision )
	{
		if ( collision.gameObject.tag == "Enemy" )
			Destroy ( gameObject );
	}
}
