using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	public float distanceTraveled;

	private NavMeshAgent NMA;

	// Use this for initialization
	void Start () {

		NMA = GetComponent<NavMeshAgent> ();

		GameObject castle = GameObject.Find("Castle");
			if (castle)
			NMA.destination = castle.transform.position;
	}

	void Update(){
		distanceTraveled = NMA.remainingDistance;
	}

	void OnTriggerEnter(Collider co) {
		if (co.name == "Castle") {
			co.GetComponentInChildren<Health>().decrease();
			Destroy(gameObject);
		}
	}

}
