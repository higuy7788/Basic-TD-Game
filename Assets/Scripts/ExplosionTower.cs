using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionTower : MonoBehaviour {

	public bool firing;
	public Transform mon;
	public GameObject bulletPrefab;
	public bool running = true;

	public List<GameObject> enemyListInTower;

	// Use this for initialization
	void Start () {
		ScoreManager.score -= 150;
		StartCoroutine (shoot ());
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * 35, Space.World);
		if (enemyListInTower.Count > 0) {
			if (enemyListInTower [0] == null) {
				enemyListInTower.RemoveAt (0);
			}
		}
	}

	void OnTriggerEnter(Collider co){
		if (co.GetComponent<Monster> ())
		{
			enemyListInTower.Add(co.gameObject);
		}
	}

	void OnTriggerExit(Collider co){
		for (int x = 0; x <= enemyListInTower.Count - 1; x++) {
			if (co.GetComponent<Monster> () && co.transform == enemyListInTower [x].transform) {
				enemyListInTower.RemoveAt (x);
			}
		}
	}

	GameObject closestEnemy(){
		GameObject currentHigh = enemyListInTower [0];
		for (int x = 0; x <= enemyListInTower.Count - 1; x++) {
			if (Vector3.Distance(enemyListInTower [x].transform.position, this.transform.position) < Vector3.Distance(currentHigh.transform.position, this.transform.position)) {
				currentHigh = enemyListInTower [x];
			}
			if (x == enemyListInTower.Count - 1)
				return currentHigh;
		}
		return null;
	}

	IEnumerator shoot(){
		while (running) { 
			if (enemyListInTower.Count > 0){
				GameObject b = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);
				b.GetComponent<ExplosionBullet> ().target = closestEnemy().transform;
				yield return new WaitForSeconds (2.0f);
			}
			else
			{
				yield return new WaitForSeconds(0.001f);
			}
		}
	}

}