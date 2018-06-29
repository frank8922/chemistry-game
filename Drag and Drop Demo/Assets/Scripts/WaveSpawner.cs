using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public enum SpawnState{  SPAWNING, WAITING, COUNTING};

	[System.Serializable]
	public class Wave
	{
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;

	public float timeBetweenWaves = 5f;
	private float waveCountDown = 0;

	private SpawnState state = SpawnState.COUNTING;

	void Start()
	{
		waveCountDown = timeBetweenWaves;

	}

	void Update(){
		if(waveCountDown <= 0)
		{
			if(state != SpawnState.SPAWNING)
			{
				StartCoroutine(SpawnWave(waves[nextWave]));
			}
			else
			{
				waveCountDown -= Time.deltaTime;
			}
		}
	}

	IEnumerator SpawnWave(Wave _wave)
	{
		state = SpawnState.SPAWNING;
		
		for(int i = 0; i < _wave.count; i++)
		{
			SpawnEnemy(_wave.enemy);
		}

		state = SpawnState.WAITING;

		yield break;

	}

	void SpawnEnemy(Transform _enemy){
		//spawn enemy
		Debug.Log("Spawning Enemy:" + _enemy.name);

	}

}
