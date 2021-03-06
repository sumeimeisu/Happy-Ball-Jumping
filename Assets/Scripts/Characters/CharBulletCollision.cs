﻿using Assets.Scripts.Static;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent ( typeof ( Rigidbody2D ) )]
public class CharBulletCollision : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	private void OnCollisionEnter2D ( Collision2D collision )
	{
		if ( collision.gameObject.tag == "Enemy Bullet" )
		{
			if ( Options.TurnOnAudio )
				GetComponent<AudioSource> ().Play ();
#if UNITY_ANDROID || UNITY_IOS
			if ( Options.TurnOnVibration )
				Handheld.Vibrate ();
#elif UNITY_STANDALONE
			
#endif

			InGameParameter.DiscountPoint ( collision.gameObject.GetComponent<EnemyBulletController> ().Damage );
			Instantiate ( Resources.Load<GameObject> ( "Prefabs/Effects/BoomEffect" ) ).transform.position = gameObject.transform.position;
		}
	}
}
