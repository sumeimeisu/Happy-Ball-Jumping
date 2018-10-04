using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelectButtonClick : MonoBehaviour {

	public Sprite StandSpriteRemein;
	public Sprite StandSpriteAirsell;
	public Sprite StandSpriteCalix;
	public Sprite StandSpriteSentrik;
	public Sprite StandSpriteGloria;

	public Sprite InfoTextSpriteRemein;
	public Sprite InfoTextSpriteAirsell;
	public Sprite InfoTextSpriteCalix;
	public Sprite InfoTextSpriteSentrik;
	public Sprite InfoTextSpriteGloria;

	public GameObject StandSpriteObject;
	public GameObject InfoTextSpriteObject;

	int selectIndex = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyUp ( KeyCode.LeftArrow ) )
			ClickLeft ();
		if ( Input.GetKeyUp ( KeyCode.RightArrow ) )
			ClickRight ();
		if ( Input.GetKeyUp ( KeyCode.Space ) || Input.GetKeyUp ( KeyCode.Return ) )
			ClickStand ();
	}

	public void ClickStand ()
	{
		SceneManager.LoadSceneAsync ( "GameScene" );
	}

	public void ClickLeft ()
	{
		--selectIndex;
		if ( selectIndex < 0 )
			selectIndex = 4;
		UpdateStandAndInfo ();
	}

	public void ClickRight ()
	{
		++selectIndex;
		if ( selectIndex > 4 )
			selectIndex = 0;
		UpdateStandAndInfo ();
	}

	void UpdateStandAndInfo ()
	{
		Sprite updateStand = null, updateInfoText = null;
		switch ( selectIndex )
		{
			case 0:
				updateStand = StandSpriteRemein;
				updateInfoText = InfoTextSpriteRemein;
				break;

			case 1:
				updateStand = StandSpriteAirsell;
				updateInfoText = InfoTextSpriteAirsell;
				break;

			case 2:
				updateStand = StandSpriteSentrik;
				updateInfoText = InfoTextSpriteSentrik;
				break;

			case 3:
				updateStand = StandSpriteCalix;
				updateInfoText = InfoTextSpriteCalix;
				break;

			case 4:
				updateStand = StandSpriteGloria;
				updateInfoText = InfoTextSpriteGloria;
				break;
		}

		StandSpriteObject.GetComponent<SpriteRenderer> ().sprite = updateStand;
		InfoTextSpriteObject.GetComponent<SpriteRenderer> ().sprite = updateInfoText;
	}
}
