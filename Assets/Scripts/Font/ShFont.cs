using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShFont : MonoBehaviour {
	
	Sprite [] font;
	
	public int Value;
	int _lastValue;

	readonly GameObject [] innerObjects = new GameObject [ 8 ];

	// Use this for initialization
	void Start ()
	{
		font = new Sprite [ 10 ];
		UnityEngine.Object [] loadedFontSprites = Resources.LoadAll ( "Texts/font" );
		foreach ( var fontElement in loadedFontSprites )
		{
			switch ( fontElement.name )
			{
				case "font_0": font [ 0 ] = fontElement as Sprite; break;
				case "font_1": font [ 1 ] = fontElement as Sprite; break;
				case "font_2": font [ 2 ] = fontElement as Sprite; break;
				case "font_3": font [ 3 ] = fontElement as Sprite; break;
				case "font_4": font [ 4 ] = fontElement as Sprite; break;
				case "font_5": font [ 5 ] = fontElement as Sprite; break;
				case "font_6": font [ 6 ] = fontElement as Sprite; break;
				case "font_7": font [ 7 ] = fontElement as Sprite; break;
				case "font_8": font [ 8 ] = fontElement as Sprite; break;
				case "font_9": font [ 9 ] = fontElement as Sprite; break;
			}
		}

		string intToText = Value.ToString ().PadLeft ( 8, '0' );
		for ( int i = 0; i < intToText.Length; ++i )
		{
			var num = new GameObject ( i.ToString () );
			num.name = "__FontOrder" + i;
			num.transform.Translate ( -1.76f / 2 + ( 0.22f * i ) + 0.22f / 2, 0, 0 );
			var component = num.AddComponent<SpriteRenderer> ();
			component.sprite = font [ intToText [ i ] - '0' ];
			component.sortingOrder = 32762;

			innerObjects [ i ] = Instantiate ( num, gameObject.transform );
			Destroy ( num );
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ( gameObject.transform.childCount == 0 || Value != _lastValue )
		{
			UpdateFontSprite ();
			_lastValue = Value;
		}
	}

	private void UpdateFontSprite ()
	{
		string intToText = Value.ToString ().PadLeft ( 8, '0' );
		for ( int i = 0; i < intToText.Length; ++i )
		{
			var component = innerObjects [ i ]?.GetComponent<SpriteRenderer> ();
			if ( component == null )
				component = ( innerObjects [ i ] = gameObject.transform.Find ( "__FontOrder" + i ).gameObject ).GetComponent<SpriteRenderer> ();
			component.sprite = font [ intToText [ i ] - '0' ];
		}
	}
}
