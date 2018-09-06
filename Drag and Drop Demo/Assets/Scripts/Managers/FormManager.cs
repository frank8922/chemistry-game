using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using System;

public class FormManager : MonoBehaviour {

	public TMPro.TMP_InputField emailInput;
	public TMPro.TMP_InputField passwordInput;
	public Button signUpButton;
	public Button loginButton;
	public TMPro.TMP_Text statusText;
	public AuthManager authManager;
	private string professorName;
	private string fullName;
	private string email;
	private string password;
	private bool validEmail = false;
	private bool validPassword = false;


	void Awake() { 
		authManager.authCallBack += HandleAuthCallBack; 
		}

	void OnEnable(){ initButtons(); }

	public void ValidateEmail(){
		if(emailInput){
			email = emailInput.text;
			checkEmail();
		}
	}

	public void ValidatePassword(){
		if(passwordInput){
			password = passwordInput.text;
			if(password.Length >= 6){
				validPassword = true;
			}else{
				validPassword = false;
			}
		}
	}

	public void OnSignUp() {
		UpdateStatus("");
		if(!validPassword){
			UpdateStatus("Password must be at least 6 characters");
		}else{
			authManager.auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
			authManager.signUpNewUser(emailInput.text,passwordInput.text);
			Debug.Log("in OnSignUp");
		}
	}

	public void OnLogin() {
		authManager.LoginExistingUser(emailInput.text,passwordInput.text);
		Debug.Log ("Login");
	}

	IEnumerator HandleAuthCallBack(Task<Firebase.Auth.FirebaseUser> task, string operation){
			if(task.IsFaulted || task.IsCanceled){
				 foreach( Firebase.FirebaseException i in task.Exception.InnerExceptions){
					 	UpdateStatus(GetErrorMessage((AuthError)i.ErrorCode));
				 }

			}
			else if(task.IsCompleted){
				if(operation == "sign_up"){
					Firebase.Auth.FirebaseUser newPlayer = task.Result;
					Debug.Log("In HandleAuthCallback");
					createNewUser(newPlayer);
				}
				
				// loadLevelSelectScene();
				SceneManager.LoadScene("LevelSelect");
				yield return new WaitForSeconds(1.5f);

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

	void OnDestroy(){RemoveCallBack();}

	public void RemoveCallBack(){authManager.authCallBack -= HandleAuthCallBack;}

	private void ToggleButtonStates(bool toState) {
		
		if(loginButton){
		loginButton.gameObject.SetActive(toState);
		loginButton.interactable = toState;
		}

		if(signUpButton){
			signUpButton.gameObject.SetActive(toState);
			signUpButton.interactable = toState;
		}
	}

	private void UpdateStatus(string message) {
		statusText.text = message;
	}

	private void createNewUser(FirebaseUser newPlayer){
		//create a new player on firebase database
		Player player = new Player(newPlayer.Email,0,1,professorName,fullName);
		DatabaseManager.sharedInstance.createNewPlayer(player, newPlayer.UserId);
	}


	public void checkEmail(){
		var regexPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

		if (email != "" && Regex.IsMatch(email, regexPattern)) {
			validEmail = true;
			signUpButton.interactable = true;
			//Debug.Log("toggle button state true");
		} else {
			validEmail = false;
			signUpButton.interactable = false;
		}
	}

	private void loadLevelSelectScene(){ 	}

	private void initButtons(){
		if(signUpButton){ signUpButton.interactable = false;}

		if(loginButton){loginButton.interactable = false; }
	}
}
