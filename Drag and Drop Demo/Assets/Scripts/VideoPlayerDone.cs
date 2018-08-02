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
			SceneManager.LoadScene("Level1a");
			FindObjectOfType<AudioManager>().Play("theme");
			Timer.counter = 0;
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel2"){
			SceneManager.LoadScene("Level2a");
			FindObjectOfType<AudioManager>().Play("theme");
			Timer.counter = 0;
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel3"){
			SceneManager.LoadScene("Level3a");
			FindObjectOfType<AudioManager>().Play("theme");
			Timer.counter = 0;
		}else if(SceneManager.GetActiveScene().name == "VideoAnimationLevel4"){
			SceneManager.LoadScene("Level4a");
			FindObjectOfType<AudioManager>().Play("theme");
			Timer.counter = 0;
		}else{
			Debug.Log("This is the else statement of the endreached event");
		}
		
    }

}
