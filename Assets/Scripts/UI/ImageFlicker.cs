using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFlicker : MonoBehaviour {

	const float FLICKER_TIME = 0.5f;

	float elapsedTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		if ( elapsedTime >= FLICKER_TIME )
		{
			var imageComp = gameObject.GetComponent<Image> ();
			imageComp.color = new Color ( 1, 1, 1,
				Mathf.Abs ( 1 - imageComp.color.a ) <= float.Epsilon ? 0 : 1 );

			elapsedTime -= FLICKER_TIME;
		}
	}
}
