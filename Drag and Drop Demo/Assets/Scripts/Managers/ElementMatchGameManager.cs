using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ElementMatchGameManager : MonoBehaviour {
    [SerializeField]
    private Transform DragPanel, DropPanel;

	public static int count,countChildren = 0;

    [SerializeField]
    private Sprite[] spriteArray;

	[SerializeField]
	private GameObject[] slotArray;

	void Start()
	{
        count++;

        if (count <= 1)
        {
            FindObjectOfType<AudioManager>().Play("quizgamenoise");
        }

        if (SceneManager.GetActiveScene().name == "Level9")
        {
			if(count == 2)
			{
				for(int i = 0; i < slotArray.Length; i++){
					slotArray[i].GetComponent<Image>().sprite = spriteArray[i];
					slotArray[i].tag = spriteArray[i].name;
				}
			}
			
            for (int i = 0; i < DragPanel.childCount; i++)
            {
                DragPanel.GetChild(i).SetSiblingIndex(Random.Range(0, DragPanel.childCount));
				
            }

			for(int i = 0; i < DropPanel.childCount; i++)
			{
				DropPanel.GetChild(i).SetSiblingIndex(Random.Range(0, DropPanel.childCount));
			}
        }

	}

	void Update()
	{
		if(SceneManager.GetActiveScene().name == "Level9")
		{
			if(DropPanel.GetChild(0).childCount == 1 && DropPanel.GetChild(1).childCount == 1 && DropPanel.GetChild(2).childCount == 1 && DropPanel.GetChild(3).childCount == 1 && DropPanel.GetChild(4).childCount == 1 && count == 1)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}else if(DropPanel.GetChild(0).childCount == 1 && DropPanel.GetChild(1).childCount == 1 && DropPanel.GetChild(2).childCount == 1 && DropPanel.GetChild(3).childCount == 1 && DropPanel.GetChild(4).childCount == 1 && count == 2){
				if(PlayerPrefs.GetInt("levelReached") < 10)
				{
					PlayerPrefs.SetInt("levelReached", 10);
				}
				FindObjectOfType<AudioManager>().Stop("quizgamenoise");
				count = 0;
				SceneManager.LoadScene("LevelSelect");
			}

		}
	}

}
