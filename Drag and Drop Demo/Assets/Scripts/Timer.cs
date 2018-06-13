using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class Timer : MonoBehaviour
{
	//TODO: see if there is away to make this more efficient maybe better way to implement 
	
	public static int timeLeft = 60;
	Text countdownText;

	// Use this for initialization
	void Start()
	{
		countdownText = GetComponent<Text>();
		StartCoroutine("LoseTime");
	}

	// Update is called once per frame
	void Update()
	{
		countdownText.text = ("Time Left: " + timeLeft);

		if (timeLeft <= 0)
		{
			StopCoroutine("LoseTime");
			countdownText.text = "Times Up!";
			Spawner.stop = true;
			FindObjectOfType<GameManager>().EndGame();
		}
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}
}