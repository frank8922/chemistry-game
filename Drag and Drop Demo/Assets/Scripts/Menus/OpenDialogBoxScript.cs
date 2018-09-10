using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDialogBoxScript : MonoBehaviour
{

    public Animator animator;
    public GameObject loginDialogObject;
	
    public TextMeshProUGUI textMesh;
    public void openDialog()
    {

        loginDialogObject.SetActive(true);
        animator.SetTrigger("OpenLoginDialog");
    }

    public void closeDialog()
    {
        animator.SetTrigger("CloseLoginDialog");

    }

    public void closeDialogTime1()
    {

        animator.SetTrigger("CloseLoginDialog");

    }

    public void openDialogTime0()
    {

        animator.SetTrigger("OpenLoginDialog");

    }

    void Awake()
    {
        /*
        decision struct is horrid but gets job change must change
        only show the rules when a new game type comes up or is necessary for right now
         */

        if (SceneManager.GetActiveScene().name == "Level1a")
        {
            openDialogTime0();
			
        }

		if(SceneManager.GetActiveScene().name == "Level6" && DraggableGameManager.count == 0){
            textMesh.text = "Drag and drop all the +1 ions above.";
            openDialogTime0();
		}else if(SceneManager.GetActiveScene().name == "Level6" && DraggableGameManager.count == 1){
            textMesh.text = "Drag and drop all the +2 ions above.";
            openDialogTime0();
        }

        if(SceneManager.GetActiveScene().name == "Level7" && DraggableGameManager.count == 0){
            textMesh.text = "Drag and drop all the -1 ions above.";
			openDialogTime0();

		}else if(SceneManager.GetActiveScene().name == "Level7" && DraggableGameManager.count == 1){
            textMesh.text = "Drag and drop all the -2 ions above.";
            openDialogTime0();
        }else if(SceneManager.GetActiveScene().name == "Level7" && DraggableGameManager.count == 2){
            textMesh.text = "Drag and drop all the -3 ions above.";
            openDialogTime0();
        }

		if(SceneManager.GetActiveScene().name == "Level9" && ElementMatchGameManager.count == 0){
			openDialogTime0();
		}

		if(SceneManager.GetActiveScene().name == "Level10" && ElementGameManager.count == 0){
			openDialogTime0();
		}

		if(SceneManager.GetActiveScene().name == "Level5" && QuizManager.count == 0){
			openDialogTime0();
		}

    }



}
