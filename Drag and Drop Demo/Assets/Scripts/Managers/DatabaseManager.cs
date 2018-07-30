using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class DatabaseManager : MonoBehaviour {

	public static DatabaseManager sharedInstance = null;

	void Awake(){
		if(sharedInstance == null){
			sharedInstance = this;
		}else if(sharedInstance != this){
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://mdchem-232a6.firebaseio.com/");


	}

	public void createNewPlayer(Player player, string uid){
		string playerJSON = JsonUtility.ToJson(player);
		Router.usersWithUID(uid).SetRawJsonValueAsync(playerJSON);

	}
	
}
