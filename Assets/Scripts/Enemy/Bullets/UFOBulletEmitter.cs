using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBulletEmitter : MonoBehaviour {

	Queue<Type> components;
	float elapsedTime;

	MonoBehaviour currentComponent;

	// Use this for initialization
	void Start () {
		components = new Queue<Type> ( new []
		{
			typeof ( SquirrelBulletEmitter ),
			typeof ( SharkBulletEmitter ),
			typeof ( SpiderBulletEmitter ),
			typeof ( KomodoBulletEmitter ),
			typeof ( ChickenBulletEmitter ),
		} );
		currentComponent = gameObject.AddComponent<ChickenBulletEmitter> ();
	}
	
	// Update is called once per frame
	void Update () {

		elapsedTime += Time.deltaTime;

		if ( elapsedTime > 10 )
		{
			Destroy ( currentComponent );

			var nextComponent = components.Dequeue ();
			currentComponent = gameObject.AddComponent ( nextComponent ) as MonoBehaviour;
			components.Enqueue ( nextComponent );

			elapsedTime -= 10;
		}
	}
}
