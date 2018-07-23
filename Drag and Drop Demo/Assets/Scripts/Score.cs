using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	
	//TODO: see if there is away to make this more efficient maybe better way to implement 
	//make a version of the current levels where the game is score driven instead of time along
	//with making a bar to keep track of score instead of a numerical value

	public static int scoreValue = 0;
	Text score;

	// Use this for initialization
	void Start () {
		score = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + scoreValue;
	}
}
