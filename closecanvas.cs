using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closecanvas : MonoBehaviour {

	// Use this for initialization
	public Canvas discription ;
	public GameObject mod ;
	
	void Start()
	{}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			mod.SetActive(true);
		    discription.enabled=false;
		}
	}

	public void close()
	{   
		mod.SetActive(true);
		discription.enabled=false;
	}
}
