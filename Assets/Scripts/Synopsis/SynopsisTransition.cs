using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynopsisTransition : MonoBehaviour {

	float _elapsed = 0;
	bool _skipAnimation = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_elapsed += Time.deltaTime;

		if ( _elapsed >= 2f )
		{
			if ( !_skipAnimation )
			{
				_skipAnimation = true;
				Initiate.Fade ( "Scenes/GameScene", Color.black, 0.8f );
			}
		}
	}

	public void SkipAnimation ()
	{
		print ( "Skip" );
		if ( _skipAnimation ) return;
		_skipAnimation = true;
		Initiate.Fade ( "Scenes/GameScene", Color.black, 0.8f );
	}
}
