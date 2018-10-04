using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundRandomSelector : MonoBehaviour {

	public GameObject Background1;
	public GameObject Background2;
	public GameObject Background3;
	public GameObject Background4;
	public GameObject Background5;
	public GameObject Background6;

	// Use this for initialization
	void Start () {
		GameObject background = null;
		switch ( Random.Range ( 0, 5 ) )
		{
			case 0: background = Background1; break;
			case 1: background = Background2; break;
			case 2: background = Background3; break;
			case 3: background = Background4; break;
			case 4: background = Background5; break;
			case 5: background = Background6; break;
		}
		Instantiate ( background, gameObject.transform );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
