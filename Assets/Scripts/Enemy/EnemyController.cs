using Assets.Scripts.Static;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField]
	public bool NoRotation = false;
	[SerializeField]
	public float Angle = 180;
	[SerializeField]
	public float Speed = 1.2f;

	[SerializeField]
	public int OutRangeDamage = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( !NoRotation )
			gameObject.transform.rotation = Quaternion.AngleAxis ( Angle, new Vector3 ( 0, 0, 1 ) );
		gameObject.transform.position += new Vector3 ( Mathf.Sin ( Angle / 180 * Mathf.PI ), Mathf.Cos ( Angle / 180 * Mathf.PI ) ) * Time.deltaTime * Speed;

		if ( gameObject.transform.position.y < -4.6 )
		{
			Destroy ( gameObject );
			InGameParameter.CharacterHitPoint -= OutRangeDamage;
		}
	}

	void OnCollisionEnter2D ( Collision2D collision )
	{
		if ( collision.gameObject.tag == "Player Bullet" )
		{
			Instantiate ( Resources.Load<GameObject> ( "Prefabs/Effects/BoomEffect" ) ).transform.position = gameObject.transform.position;
			Destroy ( gameObject );
			InGameParameter.CurrentPoint += OutRangeDamage;
		}
	}
}
