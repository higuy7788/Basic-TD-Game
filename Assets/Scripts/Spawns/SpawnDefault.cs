using UnityEngine;
using System.Collections;

public class SpawnDefault : MonoBehaviour {

	public GameObject toSpawn;

	// Use this for initialization
	void Start () {

	}

	void OnMouseDown(){
		if (ScoreManager.score >= 100) {
			GameObject s = Instantiate (toSpawn);
			s.transform.position = Builplace.loacationToSpawn;
			Destroy(this.gameObject);
			Destroy(GameObject.Find("ElectricTower(Clone)"));
			Destroy(GameObject.Find("FireTower(Clone)"));
		}
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * 35, Space.World);
	}
}
