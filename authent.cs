using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;




using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;
using System;

public class authent : MonoBehaviour {
	// Use this for initialization
	public TMPro.TMP_InputField usernameField;
	public TMPro.TMP_InputField  emailField;
	string email;
	string password;
	public Canvas tombola;
	public Canvas waitpage;


	public TMPro.TMP_Text text;
	public Canvas messagefirebase;
	DatabaseReference reference;
	void Start () {


  Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
  var dependencyStatus = task.Result;
  if (dependencyStatus == Firebase.DependencyStatus.Available) {
    
    Debug.Log("nice");
	 // Set up the Editor before calling into the realtime database.
    FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://cse-list.firebaseio.com/");

    // Get the root reference location of the database.
    reference = FirebaseDatabase.DefaultInstance.RootReference;
  } else {
    UnityEngine.Debug.LogError(System.String.Format(
      "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
    // Firebase Unity SDK is not safe to use here.
  }
})	;		
		messagefirebase.enabled=false;
		waitpage.enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void submitButton() {
		User user = new User(usernameField.text,emailField.text);
		waitpage.enabled=true;
		tombola.enabled=false;
		string userId = GetSha256FromString(usernameField.text+emailField.text);
		string json = JsonUtility.ToJson(user);
		 reference.Child("users").Child(userId).SetRawJsonValueAsync(json).ContinueWith(AR => 
		 {
			 if(AR.IsCanceled || AR.IsFaulted)
			 {
                 text.SetText("connexion failed , check your internet and try again");
                 waitpage.enabled=false;
				 messagefirebase.enabled=true;
				 return;
			 }
			 PlayerPrefs.SetInt("iscreated",1);
		     text.SetText( usernameField.text +" successfully signed in");
		     messagefirebase.enabled=true;

           waitpage.enabled=false;
		 });
		 
		
	}




	public static string GetSha256FromString(string strData)
    {
        var message = Encoding.ASCII.GetBytes(strData);
        SHA256Managed hashString = new SHA256Managed();
        string hex = "";

        var hashValue = hashString.ComputeHash(message);
        foreach (byte x in hashValue)
        {
            hex += String.Format("{0:x2}", x);
        }
        return hex;
    }


	




	public void click(){messagefirebase.enabled=false;}


	public class User {
    public string username;
    public string email;

    public User() {
    }

    public User(string username, string email) {
        this.username = username;
        this.email = email;
    }
}
}
