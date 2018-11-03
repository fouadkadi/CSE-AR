using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back : MonoBehaviour {

	// Use this for initialization
	public Canvas cv;
	public Canvas waiting_page;

    public Canvas map ;
	public Canvas menu;
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			cv.enabled=false;
			waiting_page.enabled=false;
			map.enabled=false;
			menu.enabled=true;
		}
	}
}
