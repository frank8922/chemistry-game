using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;

public class AuthManager : MonoBehaviour {
	
	//Firebase API variables
	Firebase.Auth.FirebaseAuth auth;
	
	//Delegates
	public delegate IEnumerator AuthCallBack(Task<Firebase.Auth.FirebaseUser> task, string operation);
	
	//Event
	public event AuthCallBack authCallBack;
	

	void Awake(){
		//auth = FirebaseAuth.DefaultInstance;
	}

	void OnEnable(){
		auth = FirebaseAuth.DefaultInstance;
	}

	public void signUpNewUser(string email, string password){
		auth.CreateUserWithEmailAndPasswordAsync(email,password).ContinueWith(task => {
			StartCoroutine(authCallBack(task,"sign_up"));
		});
	}

	public void LoginExistingUser(string email, string password){
		auth.SignInWithEmailAndPasswordAsync(email,password).ContinueWith(task => {
			StartCoroutine(authCallBack(task,"login"));
		});
	}
}
