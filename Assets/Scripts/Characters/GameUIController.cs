using Assets.Scripts.Static;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

	[SerializeField]
	public GameObject HP1, HP2, HP3;
	[SerializeField]
	public GameObject Bomb;

	[SerializeField]
	public GameObject Gage, FlickerGage;

	[SerializeField]
	public GameObject PowerLevel;

	[SerializeField]
	public Sprite Lv1, Lv2, Lv3, Lv4, Lv5;

	[SerializeField]
	public GameObject PointFont;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		HP1.GetComponent<Image> ().fillAmount = Mathf.Max ( InGameParameter.CharacterHitPoint - 20, 0 ) / 10.0f;
		HP2.GetComponent<Image> ().fillAmount = Mathf.Max ( Mathf.Min ( InGameParameter.CharacterHitPoint - 10, 10 ), 0 ) / 10.0f;
		HP3.GetComponent<Image> ().fillAmount = Mathf.Max ( Mathf.Min ( InGameParameter.CharacterHitPoint, 10 ), 0 ) / 10.0f;

		Gage.GetComponent<Image> ().fillAmount = InGameParameter.CharacterChangeGage / 100.0f;

		FlickerGage.SetActive ( InGameParameter.CharacterChangeGage == 100 );
		Bomb.SetActive ( InGameParameter.CharacterHasBomb );

		Sprite powerLevelSprite = null;
		switch ( InGameParameter.CharacterPowerLevel )
		{
			case 1: powerLevelSprite = Lv1; break;
			case 2: powerLevelSprite = Lv2; break;
			case 3: powerLevelSprite = Lv3; break;
			case 4: powerLevelSprite = Lv4; break;
			case 5: powerLevelSprite = Lv5; break;
		}
		PowerLevel.GetComponent<SpriteRenderer> ().sprite = powerLevelSprite;

		PointFont.GetComponent<ShFont> ().Value = InGameParameter.CurrentPoint;
	}
}
