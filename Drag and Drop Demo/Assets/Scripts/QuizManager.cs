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

	void Start()
	{
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
			falseAnswer.text = "WRONG!";

		}else{
			trueAnswer.text = "WRONG!";
			falseAnswer.text = "CORRECT!";
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
		if(currentQuestion.isTrue){
			Debug.Log("CORRECT!");
		}else{
			Debug.Log("WRONG!");
		}
		StartCoroutine(TrasnsitionToNextQuestion());
	}

	public void UserSelectFalse(){
		if(!currentQuestion.isTrue){
			Debug.Log("CORRECT!");
		}else{
			Debug.Log("WRONG!");
		}
		StartCoroutine(TrasnsitionToNextQuestion());
	}
}
