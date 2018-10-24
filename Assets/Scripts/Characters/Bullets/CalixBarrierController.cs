using UnityEngine;

public class CalixBarrierController : MonoBehaviour
{
	public int HitPoint = 3;

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
			--HitPoint;
			if ( HitPoint == 0 )
				Destroy ( gameObject );
		}
	}
}