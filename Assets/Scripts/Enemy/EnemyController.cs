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
	public float Speed = 1f;

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
		float radian = Angle / 180 * Mathf.PI;
		gameObject.transform.position += new Vector3 ( Mathf.Sin ( radian ), Mathf.Cos ( radian ), 0 ) * Speed * Time.deltaTime;

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
			InGameParameter.CharacterChangeGage += 4;
		}
	}
}
