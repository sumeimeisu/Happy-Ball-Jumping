using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBulletSpecializer : MonoBehaviour {

	float elapsedTime;
	int level = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		if ( elapsedTime >= 1)
		{
			if ( level > 0 )
			{
				GameObject b1 = Instantiate ( gameObject );
				b1.transform.position = gameObject.transform.position;
				b1.GetComponent<EnemyBulletController> ().Angle = gameObject.GetComponent<EnemyBulletController> ().Angle - 25;
				--b1.GetComponent<ChickenBulletSpecializer> ().level;
				GameObject b2 = Instantiate ( gameObject );
				b2.transform.position = gameObject.transform.position;
				b2.GetComponent<EnemyBulletController> ().Angle = gameObject.GetComponent<EnemyBulletController> ().Angle + 25;
				--b1.GetComponent<ChickenBulletSpecializer> ().level;
			}

			Destroy ( gameObject );
		}
	}
}
