using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShFont : MonoBehaviour {

	public Sprite S_0, S_1, S_2, S_3, S_4, S_5, S_6, S_7, S_8, S_9;
	
	public int Value;
	int _lastValue;

	readonly GameObject [] innerObjects = new GameObject [ 8 ];

	// Use this for initialization
	void Start ()
	{
		string intToText = Value.ToString ().PadLeft ( 8, '0' );

		for ( int i = 0; i < 8; ++i )
		{
			var num = new GameObject ( i.ToString () );
			num.transform.Translate ( -1.76f / 2 + ( 0.22f * i ) + 0.22f / 2, 0, 0 );
			var component = num.AddComponent<SpriteRenderer> ();
			switch ( intToText [ i ] )
			{
				case '0': component.sprite = S_0; break;
				case '1': component.sprite = S_1; break;
				case '2': component.sprite = S_2; break;
				case '3': component.sprite = S_3; break;
				case '4': component.sprite = S_4; break;
				case '5': component.sprite = S_5; break;
				case '6': component.sprite = S_6; break;
				case '7': component.sprite = S_7; break;
				case '8': component.sprite = S_8; break;
				case '9': component.sprite = S_9; break;
			}
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
		for ( int i = 0; i < 8; ++i )
		{
			var component = innerObjects [ i ].GetComponent<SpriteRenderer> ();
			switch ( intToText [ i ] )
			{
				case '0': component.sprite = S_0; break;
				case '1': component.sprite = S_1; break;
				case '2': component.sprite = S_2; break;
				case '3': component.sprite = S_3; break;
				case '4': component.sprite = S_4; break;
				case '5': component.sprite = S_5; break;
				case '6': component.sprite = S_6; break;
				case '7': component.sprite = S_7; break;
				case '8': component.sprite = S_8; break;
				case '9': component.sprite = S_9; break;
			}
		}
	}
}
