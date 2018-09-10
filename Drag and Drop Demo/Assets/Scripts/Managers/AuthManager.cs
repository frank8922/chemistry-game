using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;

public class AuthManager : MonoBehaviour {
	
	//Firebase API variables
	public Firebase.Auth.FirebaseAuth auth;
	
	//Delegates
	public delegate IEnumerator AuthCallBack(Task<Firebase.Auth.FirebaseUser> task, string operation);
	
	//Event
	public event AuthCallBack authCallBack;
	

	 void Awake(){
		 FindObjectOfType<AudioManager>().Play("levelselectnoise");
		 auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
		 
	 }

	

	public void signUpNewUser(string email, string password){
		auth.CreateUserWithEmailAndPasswordAsync(email,password).ContinueWith(task => {
			StartCoroutine(authCallBack(task,"sign_up"));
			FindObjectOfType<AudioManager>().Stop("levelselectnoise");
			Debug.Log("In signUpNewUser");
		});
	}

	public void LoginExistingUser(string email, string password){
		auth.SignInWithEmailAndPasswordAsync(email,password).ContinueWith(task => {
			StartCoroutine(authCallBack(task,"login"));
			FindObjectOfType<AudioManager>().Stop("levelselectnoise");
			Debug.Log("In Login");
		});
	}
}
