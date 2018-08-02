﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

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
	public static int counter = 0;

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
		string variable = "{\"correct\":\""+ DraggingObjects.correctAnswers +"\"}";
		postResponse("https://mdchem-232a6.firebaseio.com/level1/6jhvBhSwEFaY5AP9OAxiODsdpyY2.json",variable,"6jhvBhSwEFaY5AP9OAxiODsdpyY2");
		Debug.Log(variable);
		Spawner.stop = true;
		yield return new WaitForSeconds(2);
		Spawner.stop = false;
		if((SceneManager.GetActiveScene().name == "Level1a") || (SceneManager.GetActiveScene().name == "Level1b") || (SceneManager.GetActiveScene().name == "Level1c")){
			if(counter == 0){
				SceneManager.LoadScene(3);
				Score.scoreValue = 0;
			}else if(counter == 1){
				SceneManager.LoadScene(4);
				Score.scoreValue  = 0;
			}else if(counter == 2){
				FindObjectOfType<AudioManager>().Stop("theme");
				if(PlayerPrefs.GetInt("levelReached") < 2){
					PlayerPrefs.SetInt("levelReached", 2);
				}
				
				Score.scoreValue  = 0;
				SceneManager.LoadScene("LevelSelect");
				
			}
		}else if((SceneManager.GetActiveScene().name == "Level2a") || (SceneManager.GetActiveScene().name == "Level2b") || (SceneManager.GetActiveScene().name == "Level2c")){
			if(counter == 0){
				SceneManager.LoadScene(6);
				Score.scoreValue = 0;
			}else if(counter == 1){
				SceneManager.LoadScene(7);
				Score.scoreValue  = 0;
			}else if(counter == 2){
				FindObjectOfType<AudioManager>().Stop("theme");
				if(PlayerPrefs.GetInt("levelReached") < 3){
					PlayerPrefs.SetInt("levelReached", 3);
				}
				Score.scoreValue  = 0;
				SceneManager.LoadScene("LevelSelect");	
				
			}
		}else if((SceneManager.GetActiveScene().name == "Level3a") || (SceneManager.GetActiveScene().name == "Level3b") || (SceneManager.GetActiveScene().name == "Level3c")){
			if(counter == 0){
				SceneManager.LoadScene(9);
				Score.scoreValue = 0;
			}else if(counter == 1){
				SceneManager.LoadScene(10);
				Score.scoreValue  = 0;
			}else if(counter == 2){
				FindObjectOfType<AudioManager>().Stop("theme");
				if(PlayerPrefs.GetInt("levelReached") < 4){
					PlayerPrefs.SetInt("levelReached", 4);
				}
				Score.scoreValue  = 0;
				SceneManager.LoadScene("LevelSelect");
			}
		}else if((SceneManager.GetActiveScene().name == "Level4a") || (SceneManager.GetActiveScene().name == "Level4b") || (SceneManager.GetActiveScene().name == "Level4c" )){
			if(counter == 0){
				SceneManager.LoadScene(12);
				Score.scoreValue = 0;
			}else if(counter == 1){
				SceneManager.LoadScene(13);
				Score.scoreValue  = 0;
			}else if(counter == 2){
				FindObjectOfType<AudioManager>().Stop("theme");
				if(PlayerPrefs.GetInt("levelReached") < 5){
					PlayerPrefs.SetInt("levelReached", 5);
				}
				Score.scoreValue  = 0;
				SceneManager.LoadScene("LevelSelect");
			}
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
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
		
	}


	    public void getResponse(string uid)
    {
        string url = "http://167.99.5.35:8080/API/get?uid=" + uid;
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
    }

    public void postResponse(string url, string data, string uid){
        //string url = "http://167.99.5.35:8080/API/save";
        //string data = "{\"name\":\"bob marley from unity test 2\"}";
        //string uid = "5XwCmxgUF3PY61vPclwcKoyiQJr1";

        StartCoroutine(PostRequest(url,data,uid));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    IEnumerator PostRequest(string url, string json, string uid)
    {
        var uwr = new UnityWebRequest(url, "PATCH");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.SetRequestHeader("uid", uid);


        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);

        }
    }
	

}