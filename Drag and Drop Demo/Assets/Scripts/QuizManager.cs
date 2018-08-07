using System.Collections;
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

	void Start()
	{
		Debug.Log("Number Wrong " + numWrong);
		Debug.Log("Number Correct " + score);
		//do something at a certain score
		if(score == 4){
			Debug.Log("4 correct answers");
		}
		//do something at a certain incorrect score
		if(numWrong == 4){
			Debug.Log("4 wrong answers");
			PlayerPrefs.SetInt("levelReached", 1);
			fader.FadeTo("LevelSelect");
			
		}
		if(unansweredQuestions == null || unansweredQuestions.Count == 0)
		{
			unansweredQuestions = questions.ToList<Question>();
		}
		SetCurrentQuestion();
		Debug.Log(currentQuestion.fact + " is " + currentQuestion.isTrue);
		
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

	/*
	if need multiple question make single method instead of two make what the user selected into an integer
	to determine validity possible 

	make a temp var to store previous question and check it against current question so questions dont repeat
	 */
	public void UserSelectTrue(){
		animator.SetTrigger("True");
		if(currentQuestion.isTrue){
			score += 1;
			Debug.Log("CORRECT!");
			//play correct noise
		}else{
			numWrong += 1;
			Debug.Log("INCORRECT!");
			//play incorrect noise
		}
		StartCoroutine(TrasnsitionToNextQuestion());
	}

	public void UserSelectFalse(){
		animator.SetTrigger("False");
		if(!currentQuestion.isTrue){
			score+=1;
			Debug.Log("CORRECT!");
			//play correct noise
		}else{
			numWrong += 1;
			Debug.Log("INCORRECT!");
			//play incorrect noise
		}
		StartCoroutine(TrasnsitionToNextQuestion());
	}
}
