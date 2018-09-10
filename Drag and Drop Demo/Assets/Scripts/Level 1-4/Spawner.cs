using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawner : MonoBehaviour {
	
	/*
	This script handles the spawner which spawn the DraggingObjects
	 */
	
	public GameObject[] elementSpawnees;
	public float yPosition,spawnMostWait,spawnLeastWait;
	public int startWait;
	public static bool stop;
	private int randSpawneeNumber;
	public static float spawnDomain;

	private float spawnWait;


	void Awake(){
		//whenever the spawner is in a scene it needs to default to this
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		
	}

	void Start () {
		StartCoroutine(waitSpawner());
	}

	void Update () {
		
		spawnWait = Random.Range(spawnLeastWait,spawnMostWait);
	}

	//This function is what handles all the spawning. Unless the spawner is told to stop it will choose a random number from
	//zero to the last index in the array. Then chooses a random position along a set domain to move and then spawn the object
	IEnumerator waitSpawner()
	{
		yield return new WaitForSeconds(startWait);

		while (!stop)
		{
			randSpawneeNumber = Random.Range(0,elementSpawnees.Length);

			
			Vector2 spawnPosition = new Vector2(Random.Range(-spawnDomain,spawnDomain),Random.Range(yPosition,yPosition));

			Instantiate(elementSpawnees[randSpawneeNumber],spawnPosition, gameObject.transform.rotation);
			FindObjectOfType<AudioManager>().Play("spawn");

			yield return new WaitForSeconds(spawnWait);
		}
	}
		
}
