using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public GameObject PlayButton, OptionButton, HelpButton, ExitButton;

	public GameObject OptionPrefab, HelpPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DoPlay ()
	{

	}

	public void DoOption ()
	{
		PlayButton.GetComponent<Image> ().raycastTarget = false;
		OptionButton.GetComponent<Image> ().raycastTarget = false;
		HelpButton.GetComponent<Image> ().raycastTarget = false;
		ExitButton.GetComponent<Image> ().raycastTarget = false;

		Instantiate ( OptionPrefab, gameObject.transform.parent );
	}

	public void DoHelp ()
	{
		PlayButton.GetComponent<Image> ().raycastTarget = false;
		OptionButton.GetComponent<Image> ().raycastTarget = false;
		HelpButton.GetComponent<Image> ().raycastTarget = false;
		ExitButton.GetComponent<Image> ().raycastTarget = false;

		Instantiate ( HelpPrefab, gameObject.transform.parent );
	}

	public void DoExit ()
	{
		UnityEngine.Application.Quit ();
	}
}
