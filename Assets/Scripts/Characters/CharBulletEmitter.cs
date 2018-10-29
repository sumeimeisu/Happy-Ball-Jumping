using Assets.Scripts.Characters;
using Assets.Scripts.Static;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBulletEmitter : MonoBehaviour {

	[SerializeField]
	public float EmittionDistance = 0.2f;
	
	GameObject BulletLv1, BulletLv2, BulletLv3, BulletLv4, BulletLv5;
	float elapsedTime = 0;

	bool doBomb = false;
	float bombElapsedTime = 0;

	[SerializeField]
	public bool IsUltimateStatus = false;

	// Use this for initialization
	void Start () {
		switch ( InGameParameter.CharacterType )
		{
			case CharacterType.Remein:
				BulletLv1 = Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/RemeinBullet_Lv1" );
				BulletLv2 = Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/RemeinBullet_Lv2" );
				BulletLv3 = Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/RemeinBullet_Lv3" );
				BulletLv4 = Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/RemeinBullet_Lv4" );
				BulletLv5 = Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/RemeinBullet_Lv5" );
				break;

			case CharacterType.Airsell:
				BulletLv1 = Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/AirsellBullet_Lv1" );
				BulletLv2 = Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/AirsellBullet_Lv2" );
				BulletLv3 = Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/AirsellBullet_Lv3" );
				BulletLv4 = Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/AirsellBullet_Lv4" );
				BulletLv5 = Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/AirsellBullet_Lv5" );
				break;

			case CharacterType.Calix:
				BulletLv1 = BulletLv2 = BulletLv3 = BulletLv4 = BulletLv5
					= Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/CalixBullet_Lv1" );
				break;

			case CharacterType.Sentrik:
				BulletLv1 = BulletLv2 = BulletLv3 = BulletLv4 = BulletLv5
					= Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/SentrikBullet_Lv1" );
				break;

			case CharacterType.Gloria:
				BulletLv1 = BulletLv2 = BulletLv3 = BulletLv4 = BulletLv5
					= Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/GloriaBullet_Lv1" );
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if ( InGameParameter.CharacterHitPoint <= 0 )
			return;

		if ( doBomb )
		{
			bombElapsedTime += Time.deltaTime;
			if ( bombElapsedTime > 5 )
				doBomb = false;
		}

		elapsedTime += Time.deltaTime;
		if ( elapsedTime >= EmittionDistance )
		{
			bool dontEmitBullet = false;
			if ( doBomb )
			{
				switch ( InGameParameter.CharacterType )
				{
					case CharacterType.Remein:
						Instantiate ( BulletLv5 ).transform.position = gameObject.transform.position + new Vector3 ( -0.8f, 0.7f, 0 );
						Instantiate ( BulletLv5 ).transform.position = gameObject.transform.position + new Vector3 ( 0, 0.7f, 0 );
						Instantiate ( BulletLv5 ).transform.position = gameObject.transform.position + new Vector3 ( 0.8f, 0.7f, 0 );
						dontEmitBullet = true;
						break;

					case CharacterType.Airsell:
						Instantiate ( BulletLv5 ).transform.position = gameObject.transform.position + new Vector3 ( -1.2f, 0.7f, 0 );
						Instantiate ( BulletLv5 ).transform.position = gameObject.transform.position + new Vector3 ( 0, 0.7f, 0 );
						Instantiate ( BulletLv5 ).transform.position = gameObject.transform.position + new Vector3 ( 1.2f, 0.7f, 0 );
						dontEmitBullet = true;
						break;

					case CharacterType.Calix:
						var child = gameObject.transform.Find ( "CalixShield_Ultimate(Clone)" );
						if ( child != null )
							child.GetComponent<CalixBarrierController> ().HitPoint = 5;
						else
							Instantiate ( Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/CalixShield_Ultimate" ), gameObject.transform );

						doBomb = false;
						break;

					case CharacterType.Sentrik:
						Instantiate ( Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/SentrikDrone_Ultimate" ) )
							.transform.position = new Vector3 ( -1.2f, -4.4f, 0 );
						Instantiate ( Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/SentrikDrone_Ultimate" ) )
							.transform.position = new Vector3 ( 0, -4.4f, 0 );
						Instantiate ( Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/SentrikDrone_Ultimate" ) )
							.transform.position = new Vector3 ( 1.2f, -4.4f, 0 );
						doBomb = false;
						break;

					case CharacterType.Gloria:
						Instantiate ( Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/GloriaBullet_Ultimate" ) ).transform.position
							= gameObject.transform.position + new Vector3 ( 0, 0.7f, 0 );
						dontEmitBullet = true;
						break;
				}
			}

			if ( !dontEmitBullet )
			{
				int powerLevel = InGameParameter.CharacterPowerLevel;
				if ( InGameParameter.IsCharacterChanged )
					powerLevel = 5;

				Vector3 yOffset = gameObject.transform.position + new Vector3 ( 0, 0.7f, 0 );
				GameObject created = null;
				switch ( powerLevel )
				{
					case 1:
						created = Instantiate ( BulletLv1 );
						break;
					case 2:
						created = Instantiate ( BulletLv2 );
						break;
					case 3:
						created = Instantiate ( BulletLv3 );
						break;
					case 4:
						created = Instantiate ( BulletLv4 );
						break;
					case 5:
						created = Instantiate ( BulletLv5 );
						break;
				}
				created.transform.position = yOffset;

				if ( InGameParameter.CharacterType == CharacterType.Gloria )
				{
					switch ( powerLevel )
					{
						case 2:
							created.GetComponent<PlayerBulletController>().Angle += -15;
							created = Instantiate ( BulletLv2 );
							created.transform.position = yOffset;
							created.GetComponent<PlayerBulletController> ().Angle += 15;
							break;

						case 3:
							created = Instantiate ( BulletLv3 );
							created.transform.position = yOffset;
							created.GetComponent<PlayerBulletController> ().Angle += -20;
							created = Instantiate ( BulletLv3 );
							created.transform.position = yOffset;
							created.GetComponent<PlayerBulletController> ().Angle += 20;
							break;

						case 4:
							created.GetComponent<PlayerBulletController> ().Angle += -15;
							created = Instantiate ( BulletLv4 );
							created.transform.position = yOffset;
							created.GetComponent<PlayerBulletController> ().Angle += -5;
							created = Instantiate ( BulletLv4 );
							created.transform.position = yOffset;
							created.GetComponent<PlayerBulletController> ().Angle += 5;
							created = Instantiate ( BulletLv4 );
							created.transform.position = yOffset;
							created.GetComponent<PlayerBulletController> ().Angle += 15;
							break;

						case 5:
							created = Instantiate ( BulletLv5 );
							created.transform.position = yOffset;
							created.GetComponent<PlayerBulletController> ().Angle += -20;
							created = Instantiate ( BulletLv5 );
							created.transform.position = yOffset;
							created.GetComponent<PlayerBulletController> ().Angle += -10;
							created = Instantiate ( BulletLv5 );
							created.transform.position = yOffset;
							created.GetComponent<PlayerBulletController> ().Angle += 10;
							created = Instantiate ( BulletLv5 );
							created.transform.position = yOffset;
							created.GetComponent<PlayerBulletController> ().Angle += 20;
							break;
					}
				}
			}

			elapsedTime -= EmittionDistance;
		}
	}

	void DoBomb ()
	{
		if ( InGameParameter.CharacterHitPoint <= 0 )
			return;
		if ( !( InGameParameter.CharacterHasBomb || InGameParameter.IsCharacterChanged )
			|| doBomb )
			return;
		
		doBomb = true;
		bombElapsedTime = 0;

		InGameParameter.CharacterHasBomb = false;
	}
}
