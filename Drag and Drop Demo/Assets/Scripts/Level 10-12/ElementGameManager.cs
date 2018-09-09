using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ElementGameManager : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private Transform DropPanel;
    
    private static int count = 0;

    void Update(){
        if(DropPanel.childCount >= 2){
            button.gameObject.SetActive(true);
        }
    }
    

    void Start(){
        button.gameObject.SetActive(false);
        if(count <= 0){
            FindObjectOfType<AudioManager>().Play("quizgamenoise");
        }
        count++;
    }

    /*
    If the submit button was pressed this method should run and check to see if the student 
    has entered the correct formula which corresponds with the Droppanel.name
     */
    public void onButtonSubmit()
    {

        if (DropPanel.name == "NaCl")
        {
            if (DropPanel.GetChild(0).name == "Na+" && DropPanel.GetChild(1).name == "Cl-")
            {
                //restart the scene and load a different formula
                //they got the right formula and right order of ions
                //DropPanel.GetChild(0).SetSiblingIndex(1);
                FindObjectOfType<AudioManager>().Play("truenoise");
                FindObjectOfType<AudioManager>().Stop("quizgamenoise");
                SceneManager.LoadScene("LevelSelect");
            }
            else
            {
                Debug.Log("The formula put together is incorrect");
                //if they put in the wrong formula restart the scene
                FindObjectOfType<AudioManager>().Play("falsenoise");
                FindObjectOfType<AudioManager>().Stop("quizgamenoise");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if (DropPanel.name == "2NaO")
        {

        }
    }
}
