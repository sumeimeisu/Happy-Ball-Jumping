﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBulletEmitter : MonoBehaviour {

	GameObject bullet;
	float elapsedTime;

	// Use this for initialization
	void Start () {
		bullet = Resources.Load<GameObject> ( "Prefabs/Enemies/Bullets/SpiderBullet" );
	}
	
	// Update is called once per frame
	void Update () {

		elapsedTime += Time.deltaTime;

		if ( elapsedTime >= 0.5f )
		{
			Vector3 posDiff = GameObject.FindGameObjectWithTag ( "Player" ).transform.position - gameObject.transform.position;
			float angle = Mathf.Atan2 ( posDiff.y, posDiff.x ) / Mathf.PI * 180;

			Instantiate ( bullet ).GetComponent<EnemyBulletController> ().Angle = angle;
			Instantiate ( bullet ).GetComponent<EnemyBulletController> ().Angle = angle - 45;
			Instantiate ( bullet ).GetComponent<EnemyBulletController> ().Angle = angle + 45;

			elapsedTime -= 0.5f;
		}
	}
}
