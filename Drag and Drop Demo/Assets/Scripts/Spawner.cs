using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] elementSpawnees;
	public Vector2 spawnRangeValues;
	public float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
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
			Vector2 spawnPosition = new Vector2(Random.Range(-spawnRangeValues.x,spawnRangeValues.x),Random.Range(spawnRangeValues.y,spawnRangeValues.y));

			Instantiate(elementSpawnees[randSpawneeNumber],spawnPosition ,gameObject.transform.rotation);

			yield return new WaitForSeconds(spawnWait);
		}
	}
		
}
