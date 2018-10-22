using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelBulletEmitter : MonoBehaviour {

	GameObject bullet;
	float elapsedTime;
	float angle = 45;

	// Use this for initialization
	void Start () {
		bullet = Resources.Load<GameObject> ( "Prefabs/Enemies/Bullets/SquirrelBullet" );
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		if ( elapsedTime >= 0.3f )
		{
			Instantiate ( bullet ).GetComponent<EnemyBulletController> ().Angle = angle;
			Instantiate ( bullet ).GetComponent<EnemyBulletController> ().Angle = angle + 90;
			Instantiate ( bullet ).GetComponent<EnemyBulletController> ().Angle = angle + 180;
			Instantiate ( bullet ).GetComponent<EnemyBulletController> ().Angle = angle + 270;

			angle -= 200 * Time.deltaTime;
			if ( angle < 0 )
				angle += 360;

			elapsedTime -= 0.3f;
		}
	}
}
