using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour {

	public Canvas canva;
	public Canvas tuto;
	public Canvas message;
	public GameObject all_things;
	public Canvas map ;

	public Canvas tmb;



	public void camera () 
	{ 
	
	canva.enabled=false;
	all_things.SetActive(true);

        
	}

	public void reload_menu() { canva.enabled=true; all_things.SetActive(false);}

	public void close()
	{
		Application.Quit();
	}

	public void maap ()
	{ 
		map.enabled=true;
		canva.enabled=false;

	}

	
   public void tombola()
   {   int[] sum = new int[5];
       int created = PlayerPrefs.GetInt("iscreated");
       for( int i=0;i<5;i++) 
	   {
		   sum[i]=PlayerPrefs.GetInt("model"+i);
	   }

	//  if(Sum(sum)==5 && created!=1)
	//   { 
		   tmb.enabled=true;

	 //  }else{ dispaly_message();} 
	   

   }

   int Sum(int[] arr)
   { int s=0;
     foreach(int e in arr){ s+=e;}
	 return s;}

  void Start ()
  {   //all_things.SetActive(false);
     map.enabled=false;
	  message.enabled=false;
	  tmb.enabled=false;
	   if (PlayerPrefs.GetInt ("accepted") == 1)
         {
            Destroy (tuto);
         }

  }



public void quit_tuto()
{
      PlayerPrefs.SetInt ("accepted", 1);
	  Destroy (tuto);


}




public void dispaly_message()
{
	message.enabled=true;
}

public void Close_message()
{
	 message.enabled=false;
	 
}



}
