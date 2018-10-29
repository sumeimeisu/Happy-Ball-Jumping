using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptionController : MonoBehaviour {

	public GameObject AudioOptionSpriteObject;

	public GameObject VibOptionSpriteObject;
	public Sprite VibOptionOnSprite, VibOptionOffSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		AudioOptionSpriteObject.SetActive ( Options.TurnOnAudio );

		if ( Options.TurnOnVibration )
			VibOptionSpriteObject.GetComponent<SpriteRenderer> ().sprite = VibOptionOnSprite;
		else
			VibOptionSpriteObject.GetComponent<SpriteRenderer> ().sprite = VibOptionOffSprite;
	}

	public void ToggleAudio ()
	{
		Options.TurnOnAudio = !Options.TurnOnAudio;
	}

	public void TurnOnVib ()
	{
		Options.TurnOnVibration = true;
	}

	public void TurnOffVib ()
	{
		Options.TurnOnVibration = false;
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

		Options.Save ();

		Destroy ( gameObject );
	}
}
