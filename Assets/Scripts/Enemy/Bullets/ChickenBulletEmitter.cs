using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBulletEmitter : MonoBehaviour {

	GameObject bullet;
	float elapsedTime;

	// Use this for initialization
	void Start () {
		bullet = Resources.Load<GameObject> ( "Prefabs/Enemies/Bullets/ChickenBullet" );
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		if ( elapsedTime >= 0.5f )
		{
			Instantiate ( bullet );
			Instantiate ( bullet ).GetComponent<EnemyBulletController> ().Angle -= 25;
			Instantiate ( bullet ).GetComponent<EnemyBulletController> ().Angle += 25;

			elapsedTime -= 0.5f;
		}
	}
}
