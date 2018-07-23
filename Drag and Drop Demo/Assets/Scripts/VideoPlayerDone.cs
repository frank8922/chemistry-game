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
		}else{
			videoPlayer.Prepare();
		}
	}
	void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
       	videoPlayer.Stop();
		FindObjectOfType<GameManager>().SwitchScene1a();
		
    }

}
