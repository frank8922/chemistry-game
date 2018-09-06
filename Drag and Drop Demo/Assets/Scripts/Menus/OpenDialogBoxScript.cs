using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
