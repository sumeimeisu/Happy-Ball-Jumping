using UnityEngine;

public class CalixBarrierController : MonoBehaviour
{
	public int HitPoint = 5;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnCollisionEnter2D ( Collision2D collision )
	{
		if ( collision.gameObject.tag == "Enemy Bullet" )
		{
			Instantiate ( Resources.Load<GameObject> ( "Prefabs/Effects/BoomEffect" ) ).transform.position = collision.transform.position;
			//gameObject.GetComponent<SpriteRenderer>().color = Color.
			--HitPoint;
			if ( HitPoint == 0 )
				Destroy ( gameObject );
		}
	}
}