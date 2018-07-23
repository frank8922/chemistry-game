using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

/*
This script handles the timer as soon as the game starts the timer starts counting
dependent on the time the game will branch out to various events foo.
The game mode is a hybrid of time driven and score as the time is constantly counting down 
but you have to meet the threshold of 100 score inorder to progress to the next sublevel
 */

public class Timer : MonoBehaviour
{ 
	float timeLeft = 30;
	Text countdownText;
	static int counter = 0;

	void Start()
	{
		countdownText = GetComponent<Text>();
		StartCoroutine("SubtractTime");
	}
	void Update()
	{
		countdownText.text = ("Time Left: " + timeLeft);

		if (timeLeft <= 0)
			{
			if(Score.scoreValue < 100){
				timeLeft = 15;
			}
			else
			{
			//once this point is reached this means the player has reached the threshold of 100 points
			//therefore they may progress to the next sublevel
			StopCoroutine("SubtractTime");
			countdownText.text = "Times Up!";
			StartCoroutine("ChangeScene");
			}
		}
	}

	/*
	Once the thresh holds of time and score is reached the game needs to change the scene but we want to wait a couple 
	of seconds to let the player finish. It also sets up the next scene and keeps track of the which scenes have been played. 
	 */
	 //TODO: dependent on the level selection and flow of the general ui this may need to be tweaked and played with 
	 //also maybe load the next scene asynchrously in the background, maybe a loading screen inbetween the loads
	 //the way of keeping track of the level maybe better suited with enumerators

	IEnumerator ChangeScene()
	{
		Spawner.stop = true;
		yield return new WaitForSeconds(2);
		Spawner.stop = false;
			if(counter == 0){
				SceneManager.LoadScene(2);
				Score.scoreValue = 0;
			}else if(counter == 1){
				SceneManager.LoadScene(3);
				Score.scoreValue  = 0;
			}else if(counter == 2){
			}
			timeLeft = 30; 
			counter++;
			StopCoroutine("ChangeScene");
	}


	/*
	This is what keeps track of the time. For each second that passes it takes one away from the current time
	This function runs in parallel with the Update();
	 */
	IEnumerator SubtractTime()
	{
		while (true)
		{
			Debug.Log("This is the couroutine for subtracting the time");
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
		
	}
}