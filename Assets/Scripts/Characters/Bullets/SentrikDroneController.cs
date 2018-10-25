using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SentrikDroneController : MonoBehaviour {

	[SerializeField]
	public float EmittionDistance = 0.2f;

	GameObject BulletPrefab;
	float elapsedTime = 0;

	void Start () {
		BulletPrefab = Resources.Load<GameObject> ( "Prefabs/Characters/Bullets/SentrikDrone_Bullet" );
	}

	void Update () {

		gameObject.transform.position += new Vector3 ( 0, 1, 0 ) * 1.5f * Time.deltaTime;
		if ( gameObject.transform.position.y > 4.4f )
			Destroy ( gameObject );

		elapsedTime += Time.deltaTime;

		if ( elapsedTime > EmittionDistance )
		{
			Instantiate ( BulletPrefab ).transform.position = gameObject.transform.position + new Vector3 ( 0, 0.7f, 0 );

			elapsedTime -= EmittionDistance;
		}
	}
}
