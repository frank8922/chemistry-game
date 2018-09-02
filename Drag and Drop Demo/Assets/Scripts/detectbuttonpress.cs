using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class detectbuttonpress : MonoBehaviour {

	[SerializeField]
	public Sprite[] spriteArray;

	[SerializeField]
	public GameObject[] gameObjectArray;

	[SerializeField]
	public string[] questionArray;

	public Text questionText;

	


	void Start () 
	{
		int randomSpriteNumber = 0;
		int randomQuestionNumber = Random.Range(0,questionArray.Length);
		bool [] alreadyChecked = new bool[spriteArray.Length];
		for(int i = 0; i < gameObjectArray.Length; i++){

			
	
			bool condition = true;
			while(condition){
			if(alreadyChecked[randomSpriteNumber] == false){
				gameObjectArray[i].GetComponent<SpriteRenderer>().sprite = spriteArray[randomSpriteNumber];
				spriteArray[randomSpriteNumber].name.ToString();
				alreadyChecked[randomSpriteNumber] = true;
				condition = false;
			}
			else{
				randomSpriteNumber = Random.Range(0,spriteArray.Length);
			}
		}
		}
		questionText.text = questionArray[randomQuestionNumber];	
	}

	public void nextQuestion(){
		if(SceneManager.GetActiveScene().name == "Level6"){
			SceneManager.LoadScene("Level6");
		}else if(SceneManager.GetActiveScene().name == "Level7"){
			SceneManager.LoadScene("Level7");
		}
	}
	
	void Update () {


	
	}


}
