using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	/*
	This scripts represents a game manager and simply emcapsulates a bunch of stuff like restarting and switching levels
	in one object.
	 */

	bool gameHasEnded = false;
	public float restartDelay = 1f;

	public void EndGame(){

		if(gameHasEnded == false){
			gameHasEnded = true;
			Invoke("Restart",restartDelay);
		}

	}

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void SwitchAnimationForLevel1(){
		SceneManager.LoadScene(0);
	}
	public void SwitchScene1a(){
		FindObjectOfType<AudioManager>().Play("theme");
		SceneManager.LoadScene(1);
	}

	public void SwitchScene1b(){
		SceneManager.LoadScene(2);
	}

	public void SwitchScene1c(){
		SceneManager.LoadScene(3);
	}

	//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

}
