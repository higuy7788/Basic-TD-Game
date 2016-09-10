using UnityEngine;
using System.Collections;

public class SpawnFire : MonoBehaviour {

	public GameObject toSpawn;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnMouseDown(){
		if (ScoreManager.score >= 150) {
			GameObject s = Instantiate (toSpawn);
			s.transform.position = Builplace.loacationToSpawn;
			Destroy(this.gameObject);
			Destroy(GameObject.Find("DefaultTower(Clone)"));
			Destroy(GameObject.Find("ElectricTower(Clone)"));
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * 35, Space.World);
	}
}
