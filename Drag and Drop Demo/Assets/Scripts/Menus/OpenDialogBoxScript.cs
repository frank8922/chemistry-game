using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDialogBoxScript : MonoBehaviour {
	
	public Animator animator;
	public GameObject loginDialogObject;
	
	public void openDialog(){

		loginDialogObject.SetActive(true);
		animator.SetTrigger("OpenLoginDialog");
	}

	public void closeDialog(){
		animator.SetTrigger("CloseLoginDialog");
		
	}

	public void closeDialogTime1(){
		
		// Time.timeScale = 1;
		animator.SetTrigger("CloseLoginDialog");
		
	}

	public void openDialogTime0(){

		// loginDialogObject.SetActive(true);
		animator.SetTrigger("OpenLoginDialog");
		// Time.timeScale = 0;
		
	}

	void Start(){
		if(SceneManager.GetActiveScene().name == "Level1a"){
			openDialogTime0();
		}
		
	}

	

}
