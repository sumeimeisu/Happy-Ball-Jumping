using Assets.Scripts.Characters;
using Assets.Scripts.Static;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelectButtonClick : MonoBehaviour {

	[SerializeField]
	public Sprite StandSpriteRemein;
	[SerializeField]
	public Sprite StandSpriteAirsell;
	[SerializeField]
	public Sprite StandSpriteCalix;
	[SerializeField]
	public Sprite StandSpriteSentrik;
	[SerializeField]
	public Sprite StandSpriteGloria;

	[SerializeField]
	public Sprite InfoTextSpriteRemein;
	[SerializeField]
	public Sprite InfoTextSpriteAirsell;
	[SerializeField]
	public Sprite InfoTextSpriteCalix;
	[SerializeField]
	public Sprite InfoTextSpriteSentrik;
	[SerializeField]
	public Sprite InfoTextSpriteGloria;

	[SerializeField]
	public RuntimeAnimatorController PreviewAnimationRemein;
	[SerializeField]
	public RuntimeAnimatorController PreviewAnimationAirsell;
	[SerializeField]
	public RuntimeAnimatorController PreviewAnimationCalix;
	[SerializeField]
	public RuntimeAnimatorController PreviewAnimationSentrik;
	[SerializeField]
	public RuntimeAnimatorController PreviewAnimationGloria;

	[SerializeField]
	public GameObject StandSpriteObject;
	[SerializeField]
	public GameObject InfoTextSpriteObject;
	[SerializeField]
	public GameObject PreviewAnimationSpriteObject;

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
		
		if ( Input.GetKeyUp ( KeyCode.Escape ) || Input.GetKeyUp ( KeyCode.Backspace ) )
			Initiate.Fade ( "Scenes/MenuScene", Color.black, 0.8f );
	}

	public void ClickStand ()
	{
		InGameParameter.CharacterType = ( CharacterType ) selectIndex;
		InGameParameter.Initialize ();
		Initiate.Fade ( "Scenes/IntroScene", Color.black, 0.8f );
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
		RuntimeAnimatorController previewAni = null;
		switch ( selectIndex )
		{
			case 0:
				updateStand = StandSpriteRemein;
				updateInfoText = InfoTextSpriteRemein;
				previewAni = PreviewAnimationRemein;
				break;

			case 1:
				updateStand = StandSpriteAirsell;
				updateInfoText = InfoTextSpriteAirsell;
				previewAni = PreviewAnimationAirsell;
				break;

			case 2:
				updateStand = StandSpriteSentrik;
				updateInfoText = InfoTextSpriteSentrik;
				previewAni = PreviewAnimationSentrik;
				break;

			case 3:
				updateStand = StandSpriteCalix;
				updateInfoText = InfoTextSpriteCalix;
				previewAni = PreviewAnimationCalix;
				break;

			case 4:
				updateStand = StandSpriteGloria;
				updateInfoText = InfoTextSpriteGloria;
				previewAni = PreviewAnimationGloria;
				break;
		}

		StandSpriteObject.GetComponent<SpriteRenderer> ().sprite = updateStand;
		InfoTextSpriteObject.GetComponent<SpriteRenderer> ().sprite = updateInfoText;
		PreviewAnimationSpriteObject.GetComponent<Animator> ().runtimeAnimatorController = previewAni;
	}
}
