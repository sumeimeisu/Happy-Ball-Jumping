﻿using Assets.Scripts.Static;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	[SerializeField]
	public float StoppingPosition = 2;
	[SerializeField]
	public int HitPoint = 100;

	// Use this for initialization
	void Start () {

		if ( Options.TurnOnAudio )
			GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if ( gameObject.transform.position.y > StoppingPosition )
			gameObject.transform.position -= new Vector3 ( 0, 4, 0 ) * Time.deltaTime;
		else
		{

		}
	}

	void OnCollisionEnter2D ( Collision2D collision )
	{
		if ( collision.gameObject.tag == "Player Bullet" )
		{
			Instantiate ( Resources.Load<GameObject> ( "Prefabs/Effects/BoomEffect" ) ).transform.position = collision.transform.position;
			
			InGameParameter.EncountPoint ( 1, 2 );

			int powerLevel = InGameParameter.CharacterPowerLevel;
			if ( InGameParameter.IsCharacterChanged )
				powerLevel = 5;
			HitPoint -= powerLevel;
			if ( HitPoint <= 0 )
				Destroy ( gameObject );
		}
	}
}
