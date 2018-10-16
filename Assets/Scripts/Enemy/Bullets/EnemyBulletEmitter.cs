using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletEmitter : MonoBehaviour {

	public float EmittionDistance = 1f;
	public float BulletSpeed = 2f;

	float elapsedTime = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		elapsedTime += Time.deltaTime;
		if ( elapsedTime >= EmittionDistance )
		{
			GameObject created = Instantiate ( Resources.Load<GameObject> ( "Prefabs/Enemies/Bullets/EnemyBullet" ) );
			created.transform.position = gameObject.transform.position + new Vector3 ( 0, -0.5f, 0 );
			created.GetComponent<EnemyBulletController> ().Speed = BulletSpeed;
			elapsedTime -= EmittionDistance;
		}
	}
}
