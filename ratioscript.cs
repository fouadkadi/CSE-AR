using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ratioscript : MonoBehaviour {

    
	// Use this for initialization
	public Camera cam ;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		cam.aspect=Screen.height/Screen.width;

	}
}
