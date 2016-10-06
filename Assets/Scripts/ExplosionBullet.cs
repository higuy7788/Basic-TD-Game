using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionBullet : MonoBehaviour {

	public float speed = 10f;
	public Transform target;
	public List<GameObject> explosionRadius;

	void Update(){
		if (transform.position.x - target.transform.position.x < 1 && transform.position.z - target.transform.position.z < 1 && transform.position.y - target.transform.position.y < 1){
			for (int x = 0; x <= explosionRadius.Count - 1; x++) {
				explosionRadius [x].GetComponentInChildren<Health> ().decrease();

				if (x == explosionRadius.Count - 1) {
					Destroy (gameObject);
				}
			}
		}
	}

	void FixedUpdate(){
		if (target) {
			Vector3 dir = target.position - transform.position;
			GetComponent<Rigidbody>().velocity = dir.normalized * speed;
		} else {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider co){
		if (co.GetComponent<Monster> ()){
			explosionRadius.Add(co.gameObject);
		}
	}

	void OnTriggerExit(Collider co){
		for (int x = 0; x <= explosionRadius.Count - 1; x++) {
			if (co.GetComponent<Monster> () && co.transform == explosionRadius [x].transform) {
				explosionRadius.RemoveAt (x);
			}
		}
	}



}
