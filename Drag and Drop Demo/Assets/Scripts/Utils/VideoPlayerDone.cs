using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerDone : MonoBehaviour {

	/*
	This script handles the VideoPlayer it waits for the video to be prepared and starts the 
	video once it is finished it stops and moves on to the next scene which is the game.
	 */

	private VideoPlayer videoPlayer;
	
	void Start () 
	{
		videoPlayer = GetComponent<VideoPlayer>( );
		videoPlayer.isLooping = false;
		videoPlayer.waitForFirstFrame = true;
		videoPlayer.loopPointReached += EndReached;
	}
	
	// Update is called once per frame
	void Update () {
		if(videoPlayer.isPrepared){
			videoPlayer.Play();
			//Debug.Log("The video is playing");
		}else{
			videoPlayer.Prepare();
		}
	}
	void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
		Debug.Log("End of the video animation");
       	videoPlayer.Stop();
		if(SceneManager.GetActiveScene().name == "VideoAnimationLevel1"){
			FindObjectOfType<AudioManager>().Play("theme");
			Timer.counter = 0;
			SceneManager.LoadScene("Level1a");
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel2"){
			FindObjectOfType<AudioManager>().Play("theme");
			Timer.counter = 0;
			SceneManager.LoadScene("Level2a");
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel3"){
			FindObjectOfType<AudioManager>().Play("theme");
			Timer.counter = 0;
			SceneManager.LoadScene("Level3a");
			
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel4"){
			FindObjectOfType<AudioManager>().Play("theme");
			Timer.counter = 0;
			SceneManager.LoadScene("Level4a");
			
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel1234"){
			QuizManager.score = 0;
			QuizManager.numWrong = 0;
			QuizManager.count = 0;
			SceneManager.LoadScene("Level5");
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel6"){
			SceneManager.LoadScene("Level6");
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel7"){
			SceneManager.LoadScene("Level7");
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel8"){
			QuizManager.score = 0;
			QuizManager.numWrong = 0;
			QuizManager.count = 0;
			SceneManager.LoadScene("Level8");
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel9"){
			SceneManager.LoadScene("Level9");
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel10"){
			SceneManager.LoadScene("Level10");
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel11"){
			SceneManager.LoadScene("Level10");
		}
		
    }

}
