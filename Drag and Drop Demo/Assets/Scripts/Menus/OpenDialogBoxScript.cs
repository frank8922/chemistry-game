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

	void Start(){
		//if(SceneManager.GetActiveScene().name == "Level1a"){
			StartCoroutine("BringUpDialog");
		//}
		
		
	}

		IEnumerator BringUpDialog()
	{
			
		openDialog();
		yield return new WaitForSeconds(5);
		closeDialog();
			
	}

}
