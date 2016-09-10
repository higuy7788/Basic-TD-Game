using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

	public bool firing;
	public Transform mon;
	public GameObject bulletPrefab;
	public bool running = true;

	public List<GameObject> enemyListInTower;

	// Use this for initialization
	void Start () {
		ScoreManager.score -= 100;
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
		if (co.GetComponent<Monster> () && co.transform == enemyListInTower[0].transform) 
		{
			enemyListInTower.RemoveAt(0);
		}

	}

	IEnumerator shoot(){
		while (running) { 
			if (enemyListInTower.Count > 0){
				GameObject b = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);
				b.GetComponent<Bullet> ().target = enemyListInTower[0].transform;
				yield return new WaitForSeconds (1.0f);
			}
			else
			{
				yield return new WaitForSeconds(0.1f);
			}
		}
	}

}
