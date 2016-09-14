using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

	public GameObject[] monsterPrefabs;
	public float spawnAmount = 5f;
	public float difficulty = 1f;
	public float spawnInterval = 1f;
	public float spawnAmountModifier = 1.2f;
	public float difficultyModifier = 1.1f;
	public float spawnIntervalModifier = 0.95f;
	public static int wave = 1;
	public static int enemiesSpawned;

	IEnumerator spawnNext(){

		if ((float) monsterPrefabs.Length < difficulty - 1) difficulty = monsterPrefabs.Length;
		int waveCalc = Mathf.FloorToInt(spawnAmount * (difficulty % 1));
		
		for (int i = 0; i < spawnAmount; i++) {

			if (waveCalc > 0 && enemiesSpawned == Mathf.FloorToInt(spawnAmount/2) ){
				Instantiate (monsterPrefabs [(int) Mathf.Ceil(difficulty - 1)], transform.position, Quaternion.identity);
				waveCalc--;
				enemiesSpawned++;
				yield return new WaitForSeconds(spawnInterval);
			}
			else{
				Instantiate (monsterPrefabs [(int) Mathf.Floor(difficulty - 1)], transform.position, Quaternion.identity);
				enemiesSpawned++;
				yield return new WaitForSeconds(spawnInterval);
			}


		}
	}


	public void waveMaker(){
		int Waveint = wave % 10;
		if (Waveint != 0){
			if (Waveint % 3 == 0){
				spawnInterval *= spawnIntervalModifier;
			}
			else if (Waveint % 2 == 0) {
				difficulty *= difficultyModifier;
			}
			else {
				spawnAmount *= spawnAmountModifier;
				difficulty *= difficultyModifier;

			}
		}
		else {
			Debug.Log("It's a boss wave! YAY!");
		}

		enemiesSpawned = 0;
		wave++;//this makes the wave move
		StartCoroutine (spawnNext ());

	}

}
