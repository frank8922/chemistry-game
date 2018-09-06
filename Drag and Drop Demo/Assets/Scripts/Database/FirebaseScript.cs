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
    public Text LoginInformation;

   static public string username,uuid;

	public void LoginButtonPressed(){
		FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailAddress.text, Password.text).ContinueWith((task) =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            else if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                //EditorUtility.DisplayDialog("Incorrect Login", "Password or email is incorrect.", "Fix it.");
                //Password.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Login incorrect.";
                LoginInformation.text = "Login incorrect.";
                return;
            }
            else
            {
                Firebase.Auth.FirebaseUser newUser = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})",newUser.DisplayName, newUser.UserId);
                username = newUser.DisplayName;
                uuid = newUser.UserId;
                SceneManager.LoadScene(1);
            }
		});

        
    }
	public void LoginAnonymousButtonPressed(){
		FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync().ContinueWith((obj)=>
		{

			SceneManager.LoadScene(1);
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
                LoginInformation.text = "Password must be 6 characters.";

                Password.Select();
            }

            Debug.Log("Does not work!" + EmailAddress.text);
        });
	}
}
