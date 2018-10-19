using Assets.Scripts.Static;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBulletEmitter : MonoBehaviour {

	[SerializeField]
	public float EmittionDistance = 0.2f;
	[SerializeField]
	public GameObject BulletLv1, BulletLv2, BulletLv3, BulletLv4, BulletLv5;

	float elapsedTime = 0;

	// Use this for initialization
	void Start () {
		
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
