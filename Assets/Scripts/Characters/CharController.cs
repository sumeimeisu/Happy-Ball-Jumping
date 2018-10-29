using Assets.Scripts.Characters;
using Assets.Scripts.Static;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	[SerializeField]
	public GameObject InGamePopupMenu;

	public const float MovementUnit = 1.5f;

	// Use this for initialization
	void Start () {
		SetCharacterAnimation ();
	}

	private void SetCharacterAnimation ()
	{
		Animator animator = gameObject.GetComponent<Animator> ();

		switch ( InGameParameter.CharacterType )
		{
			case CharacterType.Remein:
				animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ( "Characters/remein/remein_normal" );
				break;

			case CharacterType.Airsell:
				animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ( "Characters/airsell/airsell_normal" );
				break;

			case CharacterType.Calix:
				animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ( "Characters/calix/calix_normal" );
				break;

			case CharacterType.Sentrik:
				animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ( "Characters/sentrik/sentrik_normal" );
				break;

			case CharacterType.Gloria:
				animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ( "Characters/gloria/gloria_normal" );
				break;
		}
	}

	Vector3 lastMousePos;
	
	// Update is called once per frame
	void Update () {

		if ( Input.GetKeyUp ( KeyCode.Backspace ) || Input.GetKeyUp ( KeyCode.Escape ) )
		{
			if ( Time.timeScale == 0 )
				return;

			Instantiate ( InGamePopupMenu, GameObject.Find ( "UIFrame" ).transform );

			Time.timeScale = 0;
			return;
		}

		Vector3 charMove = new Vector3 ();

		if ( Input.GetKey ( KeyCode.W ) || Input.GetKey ( KeyCode.UpArrow ) )
			charMove.y += MovementUnit;
		if ( Input.GetKey ( KeyCode.S ) || Input.GetKey ( KeyCode.DownArrow ) )
			charMove.y -= MovementUnit;
		if ( Input.GetKey ( KeyCode.A ) || Input.GetKey ( KeyCode.LeftArrow ) )
			charMove.x -= MovementUnit;
		if ( Input.GetKey ( KeyCode.D ) || Input.GetKey ( KeyCode.RightArrow ) )
			charMove.x += MovementUnit;

		if ( Input.touchCount > 0 )
		{
			var touchPoint = Input.GetTouch ( 0 );
			var tp = touchPoint.deltaPosition;
			charMove += new Vector3 ( tp.x, tp.y, 0 );
		}

		if ( Input.mousePresent )
		{
			if ( Input.GetMouseButtonDown ( 0 ) )
			{
				lastMousePos = Input.mousePosition;
				lastMousePos.x = lastMousePos.x / Screen.currentResolution.width;
				lastMousePos.y = lastMousePos.y / Screen.currentResolution.height;
				lastMousePos *= 600;
			}

			if ( Input.GetMouseButton ( 0 ) )
			{
				Vector3 currentMousePos = Input.mousePosition;
				currentMousePos.x = currentMousePos.x / Screen.currentResolution.width;
				currentMousePos.y = currentMousePos.y / Screen.currentResolution.height;
				currentMousePos *= 600;
				charMove += ( currentMousePos - lastMousePos );
				lastMousePos = currentMousePos;
			}
		}

		charMove *= Time.deltaTime;

		gameObject.transform.position += charMove;

		if ( gameObject.transform.position.x <= -2.3f )
			gameObject.transform.position = new Vector3 ( -2.3f, gameObject.transform.position.y );
		if ( gameObject.transform.position.x >= 2.3f )
			gameObject.transform.position = new Vector3 ( 2.3f, gameObject.transform.position.y );
		if ( gameObject.transform.position.y <= -3.8f )
			gameObject.transform.position = new Vector3 ( gameObject.transform.position.x, -3.8f );
		if ( gameObject.transform.position.y >= 3.8f )
			gameObject.transform.position = new Vector3 ( gameObject.transform.position.x, 3.8f );

		if ( InGameParameter.IsCharacterChanged )
		{
			InGameParameter.CharacterChangeGage -= 6 * Time.deltaTime;
			if ( InGameParameter.CharacterChangeGage <= 0 )
			{
				SetCharacterAnimation ();
				InGameParameter.CharacterChangeGage = 0;
				InGameParameter.IsCharacterChanged = false;
				Instantiate ( Resources.Load<GameObject> ( "Prefabs/Effects/ChangeEffect" ) ).transform.position = gameObject.transform.position;
			}
		}
	}

	void DoChange ()
	{
		if ( InGameParameter.CharacterChangeGage < 100 ) return;
		if ( InGameParameter.IsCharacterChanged ) return;
		
		Animator animator = gameObject.GetComponent<Animator> ();

		switch ( InGameParameter.CharacterType )
		{
			case CharacterType.Remein:
				animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ( "Characters/remein/remein_changed" );
				break;

			case CharacterType.Airsell:
				animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ( "Characters/airsell/airsell_changed" );
				break;

			case CharacterType.Calix:
				animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ( "Characters/calix/calix_changed" );
				break;

			case CharacterType.Sentrik:
				animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ( "Characters/sentrik/sentrik_changed" );
				break;

			case CharacterType.Gloria:
				animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ( "Characters/gloria/gloria_changed" );
				break;
		}

		Instantiate ( Resources.Load<GameObject> ( "Prefabs/Effects/ChangeEffect" ) ).transform.position = gameObject.transform.position;

		InGameParameter.IsCharacterChanged = true;
	}
}
