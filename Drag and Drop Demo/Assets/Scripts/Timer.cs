using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	//TODO: see if there is away to make this more efficient maybe better way to implement 
	float timeLeft = 30;
	Text countdownText;
	static int counter = 0;
	
	// Use this for initialization
	void Start()
	{
		countdownText = GetComponent<Text>();
		StartCoroutine("LoseTime");

	}

	// Update is called once per frame b
	void Update()
	{
		countdownText.text = ("Time Left: " + timeLeft);

		if (timeLeft <= 0)
		{
			StopCoroutine("LoseTime");
			countdownText.text = "Times Up!";
			StartCoroutine("ChangeSceneController");
			
		}
		
	}

	IEnumerator ChangeSceneController()
	{
		//will be bonus time for like 5 seconds more or less
		Spawner.stop = true;
		yield return new WaitForSeconds(4);
		Spawner.stop = false;
			if(counter == 0){
				SceneManager.LoadScene(1);
				
			}else if(counter == 1){
				SceneManager.LoadScene(2);
			}else if(counter == 2){
				SceneManager.LoadScene(3);
			}
			//Debug.Log("Hello World" + counter++);
			timeLeft = 30; 
			counter++;
			StopCoroutine("ChangeSceneController");
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
		
	}

	


}