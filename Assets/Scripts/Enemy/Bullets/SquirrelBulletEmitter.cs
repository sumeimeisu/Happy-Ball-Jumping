using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelBulletEmitter : MonoBehaviour {

	GameObject bullet;
	float elapsedTime;
	float angle;

	// Use this for initialization
	void Start () {
		bullet = Resources.Load<GameObject> ( "Prefabs/Enemies/Bullets/SquirrelBullet" );
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		if ( elapsedTime >= 0.2f )
		{
			Instantiate ( bullet ).GetComponent<EnemyBulletController> ().Angle = angle;
			angle += 10;
			elapsedTime -= 0.2f;
		}
	}
}
