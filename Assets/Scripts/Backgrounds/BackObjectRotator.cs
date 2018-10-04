using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackObjectRotator : MonoBehaviour {

	public float RotationUnit = 0.12f;

	// Use this for initialization
	void Start () {
		gameObject.transform.Rotate ( 0, 0, Random.Range ( -360, 360 ) );
		RotationUnit = Random.Range ( -0.8f, 0.8f );
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate ( 0, 0, RotationUnit * ( Time.deltaTime * 10 ) );
	}
}
