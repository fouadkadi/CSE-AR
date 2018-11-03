using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gobacktomenu : MonoBehaviour {

	// Use this for initialization
	public GameObject all_things;
	public Canvas menu;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			menu.enabled=true; all_things.SetActive(false);
		}
		
	}
}
