using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

	[SerializeField]
	public float Angle = 270;
	[SerializeField]
	public float Speed = 2f;
	[SerializeField]
	public int Damage = 5;
	[SerializeField]
	public bool FollowPlayer = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( FollowPlayer )
		{
			Vector3 posDiff = GameObject.FindGameObjectWithTag ( "Player" ).transform.position - gameObject.transform.position;
			float angle = Mathf.Atan2 ( posDiff.y, posDiff.x ) / Mathf.PI * 180;
			if ( Mathf.Abs ( Angle - angle ) < 5 )
			{
				Angle = angle;
			}
		}
		gameObject.transform.rotation = Quaternion.AngleAxis ( Angle - 90, new Vector3 ( 0, 0, 1 ) );
		float radian = Angle / 180 * Mathf.PI;
		gameObject.transform.position += new Vector3 ( Mathf.Cos ( radian ), Mathf.Sin ( radian ), 0 ) * Speed * Time.deltaTime;

		if ( gameObject.transform.position.y < -4.8 || gameObject.transform.position.y > 4.8
			|| gameObject.transform.position.x < -2.4 || gameObject.transform.position.x > 2.4 )
			Destroy ( gameObject );
	}

	void OnCollisionEnter2D ( Collision2D collision )
	{
		if ( collision.gameObject.tag == "Player" )
			Destroy ( gameObject );
	}
}
