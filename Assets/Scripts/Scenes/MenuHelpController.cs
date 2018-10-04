using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHelpController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Close ()
	{
		Transform menu = gameObject.transform.parent.GetChild ( 0 );
		for ( int i = 0; i < menu.childCount; ++i )
		{
			Transform child = menu.GetChild ( i );
			Image image = child.GetComponent<Image> ();
			if ( image == null ) continue;
			image.raycastTarget = true;
		}

		Destroy ( gameObject );
	}
}
