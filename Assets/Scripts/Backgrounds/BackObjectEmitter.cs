using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackObjectEmitter : MonoBehaviour {
	
	public float EmittionDistance = 0.3f;

	public GameObject EmittingSprite1;
	public GameObject EmittingSprite2;

	float elapsedTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( EmittingSprite1 == null && EmittingSprite2 == null )
			return;
		
		elapsedTime += Time.deltaTime;
		if ( elapsedTime >= EmittionDistance )
		{
			if ( gameObject.transform.childCount < 20 )
			{
				if ( EmittingSprite2 == null )
					Instantiate ( EmittingSprite1 );
				else
				{
					if ( Random.Range ( 0, 100 ) % 2 == 0 )
						Instantiate ( EmittingSprite2 );
					else
						Instantiate ( EmittingSprite1 );
				}
			}

			elapsedTime -= EmittionDistance;
		}

		var myColor = gameObject.GetComponent<SpriteRenderer> ().color;
		for ( int i = 0; i < gameObject.transform.childCount; ++i )
			gameObject.transform.GetChild ( 0 ).GetComponent<SpriteRenderer> ().color = myColor;
	}
}
