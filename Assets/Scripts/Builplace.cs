using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Builplace : MonoBehaviour {
	
	public static Vector3 loacationToSpawn;
	public GameObject norm;
	public GameObject fire;
	public GameObject electric;

	private bool beenClicked = false;

	void OnMouseUpAsButton() {
		if (!beenClicked && Spawn.enemiesSpawned == 0) {

			//Insantiates the towers to be spawned at locations
			GameObject n = Instantiate(norm);
			n.transform.position = new Vector3(-3, (float)17, -15);

			GameObject f = Instantiate(fire);
			f.transform.position = new Vector3(0, (float)17, -15);

			GameObject e = Instantiate(electric);
			e.transform.position = new Vector3(3, (float)17, -15);

			// Where the tower is going to be spawned
			Builplace.loacationToSpawn = transform.position + Vector3.up;
			beenClicked = true;
		}
	}

}