using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is a class that will describe the questions in the game
 */
 [System.Serializable]
public class Question {

	public string fact; //the question that is either true or false
	public bool isTrue; //stores wheter the question is true or not
}
