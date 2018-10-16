using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyUp ( KeyCode.Backspace ) || Input.GetKeyUp ( KeyCode.Escape ) )
			ReturnToGame ();
	}

	public void ReturnToGame ()
	{
		Destroy ( gameObject );
		Time.timeScale = 1;
	}

	public void ExitGame ()
	{
		Time.timeScale = 1;
		Initiate.Fade ( "MenuScene", Color.black, 0.8f );
	}
}
