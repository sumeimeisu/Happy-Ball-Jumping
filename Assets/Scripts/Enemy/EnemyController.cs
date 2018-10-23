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
			gameObject.transform.rotation = Quaternion.AngleAxis ( Angle - 90, new Vector3 ( 0, 0, 1 ) );
		float radian = Angle / 180 * Mathf.PI;
		gameObject.transform.position += new Vector3 ( Mathf.Cos ( radian ), Mathf.Sin ( radian ), 0 ) * Speed * Time.deltaTime;

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
			
			if ( Random.Range ( 0, 100 ) % 7 == 0 )
			{
				switch ( Random.Range ( 0, 10 ) % 3 )
				{
					case 0:
						Instantiate ( Resources.Load<GameObject> ( "Prefabs/Items/BombItem" ) ).transform.position = gameObject.transform.position;
						break;

					case 1:
						Instantiate ( Resources.Load<GameObject> ( "Prefabs/Items/HpUpItem" ) ).transform.position = gameObject.transform.position;
						break;

					case 2:
						Instantiate ( Resources.Load<GameObject> ( "Prefabs/Items/LvUpItem" ) ).transform.position = gameObject.transform.position;
						break;
				}
			}

			Destroy ( gameObject );
			InGameParameter.EncountPoint ( 4, OutRangeDamage );
		}
	}
}
