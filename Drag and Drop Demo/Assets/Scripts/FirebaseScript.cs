using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using UnityEditor;

public class FirebaseScript : MonoBehaviour {

	public InputField EmailAddress, Password;

	public void LoginButtonPressed(){
		FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailAddress.text, Password.text).ContinueWith((obj) =>
		{
			SceneManager.LoadSceneAsync("Level1");
		});
	}

	public void LoginAnonymousButtonPressed(){
		FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync().ContinueWith((obj)=>
		{

			SceneManager.LoadSceneAsync("Level1");
		});
	}

	public void CreateNewUserButtonPressed()
	{
		FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(EmailAddress.text, Password.text).ContinueWith((obj) =>
		{
            if(Password.text.Length >= 6)
            {
                SceneManager.LoadSceneAsync("Level1");
            }
            else
            {
                Password.Select();
                EditorUtility.DisplayDialog("Password Length", "Password must be at least six characters.", "Change Password");
            }

            Debug.Log("Does not work!" + EmailAddress.text);
        });
	}
}
