﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour {

	public Question[] questions;
	private static List<Question> unansweredQuestions;
	private Question currentQuestion;
	
	[SerializeField]
	public Button TrueButton,FalseButton;


	[SerializeField]
	private Text factText;

	[SerializeField]
	private float timeBetweenQuestions;

	[SerializeField]
	private Text trueAnswer;

	[SerializeField]
	private Text falseAnswer;

	[SerializeField]
	private Animator animator;

	public static int score = 0;
	public static int numWrong = 0;
	public SceneFader fader;
	public static int count = 0;

	private float timeThreshhold = 4.0f;

	//TODO IMPLEMENT THRESHHOLD OF 5 SECS FOR EACH QUESTION

	void Start()
	{
		if(count <= 0){
			FindObjectOfType<AudioManager>().Play("quizgamenoise");
		}
		count++;
		
		Debug.Log("Number Wrong " + numWrong);
		Debug.Log("Number Correct " + score);
		//move on to the next level
		if(score >= 15){
			if(PlayerPrefs.GetInt("levelReached") < 6)
			{
				PlayerPrefs.SetInt("levelReached", 6);
			}
			score = 0;
			count = 0;
			numWrong = 0;
			FindObjectOfType<AudioManager>().Stop("quizgamenoise");
			SceneManager.LoadScene("LevelSelect");
		}
		//show student animations for levels 1,2,3,4
		if(numWrong >= 6){
			if(SceneManager.GetActiveScene().name == "QuizGame"){
			score = 0;
			count = 0;
			numWrong = 0;
			Debug.Log("Student hasnt learned");
			FindObjectOfType<AudioManager>().Stop("quizgamenoise");
			SceneManager.LoadScene("VideoAnimationLevel1234");
			}else if(SceneManager.GetActiveScene().name == "Level8"){
			//load animations to rewatch remember to add the handle in the videoanimationdone script

			}
			
		}
		if(unansweredQuestions == null || unansweredQuestions.Count == 0)
		{
			unansweredQuestions = questions.ToList<Question>();
		}
		SetCurrentQuestion();
		Debug.Log(currentQuestion.fact + " is " + currentQuestion.isTrue);
		
	} 

	void Update(){
		StartCoroutine(TimedThreshHold());
		if(timeThreshhold <= 0){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		
	}

	void SetCurrentQuestion()
	{
		int randomQuestionIndex = Random.Range(0,unansweredQuestions.Count);
		currentQuestion = unansweredQuestions[randomQuestionIndex];

		factText.text = currentQuestion.fact;

		if(currentQuestion.isTrue){
			trueAnswer.text = "CORRECT!";
			trueAnswer.color = Color.green;
			falseAnswer.text = "INCORRECT!";
			falseAnswer.color = Color.red;

		}else{
			trueAnswer.text = "INCORRECT!";
			trueAnswer.color = Color.red;
			falseAnswer.text = "CORRECT!";
			falseAnswer.color = Color.green;
		}
		
	}
	IEnumerator TrasnsitionToNextQuestion(){
		unansweredQuestions.Remove(currentQuestion);
		yield return new WaitForSeconds(timeBetweenQuestions);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	IEnumerator TimedThreshHold()
	{
		while (true)
		{
			yield return new WaitForSeconds(timeThreshhold);
			timeThreshhold--;
		}
		
	}

	

	/*
	if need multiple question make single method instead of two make what the user selected into an integer
	to determine validity possible 

	make a temp var to store previous question and check it against current question so questions dont repeat
	 */
	public void UserSelectTrue(){
		animator.SetTrigger("True");
		if(currentQuestion.isTrue){
			FindObjectOfType<AudioManager>().Play("truenoise");
			score += 1;
			TrueButton.enabled = false;
			FalseButton.enabled = false;
			Debug.Log("CORRECT!");
			timeThreshhold = 4.0f;

			//play correct noise
		}else{
			FindObjectOfType<AudioManager>().Play("falsenoise");
			numWrong += 1;
			TrueButton.enabled = false;
			FalseButton.enabled = false;
			Debug.Log("INCORRECT!");
			timeThreshhold = 4.0f;
			//play incorrect noise
		}
		StartCoroutine(TrasnsitionToNextQuestion());
	}

	public void UserSelectFalse(){
		animator.SetTrigger("False");
		if(!currentQuestion.isTrue){
			FindObjectOfType<AudioManager>().Play("truenoise");
			score+=1;
			Debug.Log("CORRECT!");
			TrueButton.enabled = false;
			FalseButton.enabled = false;
			timeThreshhold = 5.0f;
			//play correct noise
		}else{
			FindObjectOfType<AudioManager>().Play("falsenoise");
			numWrong += 1;
			TrueButton.enabled = false;
			FalseButton.enabled = false;
			Debug.Log("INCORRECT!");
			timeThreshhold = 5.0f;
			//play incorrect noise
		}
		StartCoroutine(TrasnsitionToNextQuestion());
	}
}
