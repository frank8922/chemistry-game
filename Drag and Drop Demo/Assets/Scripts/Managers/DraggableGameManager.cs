using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DraggableGameManager : MonoBehaviour
{

    [SerializeField]
    private Transform DragPanel, DropPanel;
    private static int count = 0;


    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Level6")
        {
            if (DropPanel.childCount == 5 && count == 1)
            {
                //user has finished this level6a
                Debug.Log("user has finished this level6a");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (DropPanel.childCount == 5 && count == 2)
            {
                //user has finished this level6b time to get back to levelselect
                //stop music 
                Debug.Log("user has finished this level6b time to get back to levelselect");
                SceneManager.LoadScene("LevelSelect");
                FindObjectOfType<AudioManager>().Stop("quizgamenoise");
            }

        }
        else if(SceneManager.GetActiveScene().name == "Level7")
        {
            if(DropPanel.childCount == 4 && count == 1)
            {
                Debug.Log("user has finished this level7a");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if(DropPanel.childCount == 3 && count == 2)
            {
                Debug.Log("user has finished this level7b");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if(DropPanel.childCount == 2 && count == 3){
                //user has finished this level6b time to get back to levelselect
                //stop music 
                Debug.Log("user has finished this level7c time to get back to levelselect");
                FindObjectOfType<AudioManager>().Stop("quizgamenoise");
                SceneManager.LoadScene("LevelSelect");
                
            }

        }

    }

    void Start()
    {

        count++;

        if (count <= 1)
        {
            FindObjectOfType<AudioManager>().Play("quizgamenoise");
        }

        if (SceneManager.GetActiveScene().name == "Level6" || SceneManager.GetActiveScene().name == "Level7")
        {
            for (int i = 0; i < DragPanel.childCount; i++)
            {
                DragPanel.GetChild(i).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
            }
        }

        if (SceneManager.GetActiveScene().name == "Level6")
        {
            if (count == 1)
            {
                //level 6a match the +1 elements
                //show user dialog of which elements need to be choosen
                DropPanel.tag = "+1";
            }
            else if (count == 2)
            {
                //level 6b match the +2 elements
                //show user dialog of which elements need to be choosen
                DropPanel.tag = "+2";
            }

        }
        else if (SceneManager.GetActiveScene().name == "Level7")
        {
            if (count == 1)
            {
                //level 7a match the -1 elements
                //show user dialog of which elements need to be choosen
                DropPanel.tag = "-1";
            }
            else if (count == 2)
            {
                //level 7b match the -2 elements
                //show user dialog of which elements need to be choosen
                DropPanel.tag = "-2";
            }
            else if (count == 3)
            {
                //level 7c match the -2 elements
                //show user dialog of which elements need to be choosen
                DropPanel.tag = "-3";

            }




        }



    }
}
