using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using System;

public class FormManager : MonoBehaviour {

	// UI objects linked from the inspector
	public TMPro.TMP_InputField emailInput;
	public TMPro.TMP_InputField passwordInput;

	public Button signUpButton;
	public Button loginButton;


	public TMPro.TMP_Text statusText;

	public AuthManager authManager;

	public static string userid,username;


	void Awake() {
		//Auth Deglegate subscriptions
		authManager.authCallBack += HandleAuthCallBack;
	}

	void OnEnable(){
		ToggleButtonStates (false);
		Debug.Log("in OnEnable");
		
	}


	/// <summary>
	/// Validates the email input
	/// </summary>
	public void ValidateEmail() {
		if(emailInput){
		string email = emailInput.text;
		
		//Debug.Log(email);
		var regexPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

		if (email != "" && Regex.IsMatch(email, regexPattern)) {
			ToggleButtonStates (true);
			//Debug.Log("toggle button state true");
		} else {
			ToggleButtonStates (false);
		}
	}
	}

	
	// Firebase methods
	public void OnSignUp() {
		authManager.signUpNewUser(emailInput.text,passwordInput.text);
		Debug.Log ("Sign Up");
	}

	public void OnLogin() {
		authManager.LoginExistingUser(emailInput.text,passwordInput.text);
		Debug.Log ("Login");
	}

	IEnumerator HandleAuthCallBack(Task<Firebase.Auth.FirebaseUser> task, string operation){
			if(task.IsFaulted || task.IsCanceled){
				 Debug.Log("In HandleCallBack: Task.faulted");
				 foreach( Firebase.FirebaseException i in task.Exception.InnerExceptions){
					 	UpdateStatus(GetErrorMessage((AuthError)i.ErrorCode));
				 }

			}
			else if(task.IsCompleted){
				
				if(operation == "sign_up"){
					Firebase.Auth.FirebaseUser newPlayer = task.Result;
					
					//create a new player
					Player player = new Player(newPlayer.Email,0,1);
					DatabaseManager.sharedInstance.createNewPlayer(player, newPlayer.UserId);
					

				}
				
				Firebase.Auth.FirebaseUser returningPlayer = task.Result;
				userid = returningPlayer.UserId;
				username = returningPlayer.Email;
				Debug.Log(userid + " IS " + username);

				UpdateStatus("Loading the game scene");
				SceneManager.LoadScene("LevelSelect");
				
				yield return new WaitForSeconds(1.5f);
				//SceneManager.LoadScene("Player List");

			}

	}

	private static string GetErrorMessage(AuthError errorCode)
{
    var message = "";
    switch (errorCode)
    {
        case AuthError.AccountExistsWithDifferentCredentials:
            message = "Account exists already with different credientials";
            break;
        case AuthError.MissingPassword:
            message = "Missing password";
            break;
        case AuthError.WeakPassword:
            message = "Password is to weak, password must be 6 characters or greater";
            break;
        case AuthError.WrongPassword:
            message = "Incorrect password";
            break;
        case AuthError.EmailAlreadyInUse:
            message = "Email already in use";
            break;
        case AuthError.InvalidEmail:
            message = "Invalid email";
            break;
        case AuthError.MissingEmail:
            message = "Missing email";
            break;
		case AuthError.InvalidAppCredential:
			message = "Invalid Credentials";
			break;
		case AuthError.UserNotFound:
			message = "User not found";
			break;
		case AuthError.NetworkRequestFailed:
			message = "Request failed, check internet connection";
			break;
        default:
            message = "Error occured";
            break;
    }
    return message;
}


	
	void OnDestroy(){}

	public void RemoveCallBack(){authManager.authCallBack -= HandleAuthCallBack;}


	// Utilities
	private void ToggleButtonStates(bool toState) {
		
		if(loginButton){
		loginButton.interactable = toState;
		loginButton.enabled = toState;
		}

		if(signUpButton){
			signUpButton.enabled = toState;
			signUpButton.interactable = toState;
		}
	}

	private void UpdateStatus(string message) {
		statusText.text = message;
	}
}
