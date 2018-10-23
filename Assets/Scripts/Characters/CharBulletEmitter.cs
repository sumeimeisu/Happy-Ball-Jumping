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
		elapsedTime += Time.deltaTime;
		if ( elapsedTime >= EmittionDistance )
		{
			GameObject created = null;
			switch ( InGameParameter.CharacterPowerLevel )
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
			created.transform.position = gameObject.transform.position + new Vector3 ( 0, 0.7f, 0 );
			elapsedTime -= EmittionDistance;
		}
	}
}
