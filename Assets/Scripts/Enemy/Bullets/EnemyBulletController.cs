using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

	[SerializeField]
	public float Angle = 180;
	[SerializeField]
	public float Speed = 2f;
	[SerializeField]
	public int Damage = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = Quaternion.AngleAxis ( Angle, new Vector3 ( 0, 0, 1 ) );
		gameObject.transform.position += new Vector3 ( Mathf.Sin ( Angle / 180 * Mathf.PI ), Mathf.Cos ( Angle / 180 * Mathf.PI ) ) * Time.deltaTime * Speed;

		if ( gameObject.transform.position.y < -4.8 )
			Destroy ( gameObject );
	}

	void OnCollisionEnter2D ( Collision2D collision )
	{
		if ( collision.gameObject.tag == "Player" )
			Destroy ( gameObject );
	}
}
