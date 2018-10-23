using Assets.Scripts.Static;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharItemCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D ( Collision2D collision )
	{
		if ( collision.gameObject.tag == "Item" )
		{
			switch ( collision.gameObject.name )
			{
				case "BombItem":
				case "BombItem(Clone)":
					InGameParameter.CharacterHasBomb = true;
					break;

				case "LvUpItem":
				case "LvUpItem(Clone)":
					++InGameParameter.CharacterPowerLevel;
					if ( InGameParameter.CharacterPowerLevel > 5 )
						InGameParameter.CharacterPowerLevel = 5;
					break;

				case "HpUpItem":
				case "HpUpItem(Clone)":
					InGameParameter.CharacterHitPoint += 10;
					if ( InGameParameter.CharacterHitPoint > 30 )
						InGameParameter.CharacterHitPoint = 30;
					break;
			}
			InGameParameter.EncountPoint ( 0, 5 );
		}
	}
}
