using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

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

	public void SwitchScene1a(){
		SceneManager.LoadScene(0);
	}

	public void SwitchScene1b(){
		SceneManager.LoadScene(1);
	}

	public void SwitchScene1c(){
		SceneManager.LoadScene(2);
	}

}
