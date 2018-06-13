using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawner : MonoBehaviour {
	
	//TODO: use less input from the variable and more built in things like the y position from the actual spawnerObject label everything better

	public GameObject[] elementSpawnees;
	public float spawnDomain,yPosition,spawnWait,spawnMostWait,spawnLeastWait;
	public int startWait;
	public static bool stop;
	private int randSpawneeNumber;
	private float aspectRatio;


	// Use this for initialization
	void Start () {
		aspectRatio = Camera.main.aspect;
	
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		StartCoroutine(waitSpawner());

	}
	
	// Update is called once per frame
	void Update () {
		spawnWait = Random.Range(spawnLeastWait,spawnMostWait);
		//Debug.Log(aspectRatio);
		if(aspectRatio >= 2){
			//18:9
			Debug.Log("18:9");
		} else if(aspectRatio >= 1.777778){
			//16:9
			Debug.Log("16:9");
		} else if(aspectRatio == 1.5f){
			//3:2
			Debug.Log("3:2");
		} else if(aspectRatio >= 1.333333){
			//4:3
			Debug.Log("4:3");
		} else{
			Debug.Log("Else statement is ran");
		}
	}

	//Co-routine
	IEnumerator waitSpawner()
	{
		yield return new WaitForSeconds(startWait);

		while (!stop)
		{
		
			
			randSpawneeNumber = Random.Range(0,elementSpawnees.Length);
			
			Vector2 spawnPosition = new Vector2(Random.Range(-spawnDomain,spawnDomain),Random.Range(yPosition,yPosition));

			Instantiate(elementSpawnees[randSpawneeNumber],spawnPosition ,gameObject.transform.rotation);
			FindObjectOfType<AudioManager>().Play("spawn");

			yield return new WaitForSeconds(spawnWait);
		}
	}
		
}
