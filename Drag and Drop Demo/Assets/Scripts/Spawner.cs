using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	
	//TODO: use less input from the variable and more built in things like the y position from the actual spawnerObject label everything better

	public GameObject[] elementSpawnees;
	public float spawnDomain,yPosition,spawnWait,spawnMostWait,spawnLeastWait;
	public int startWait;
	public bool stop;
	private int randSpawneeNumber;


	// Use this for initialization
	void Start () {
		StartCoroutine(waitSpawner());

	}
	
	// Update is called once per frame
	void Update () {
		spawnWait = Random.Range(spawnLeastWait,spawnMostWait);
	
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

			yield return new WaitForSeconds(spawnWait);
		}
	}
		
}
