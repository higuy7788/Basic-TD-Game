using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	TextMesh tm;
	public int health;

	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.forward = Camera.main.transform.forward;
		tm.text = health.ToString ();
	}

	public void decrease() {
		if (health > 1)
			health -= 1;
		else {
			Destroy (this.gameObject);
			OnDestroy ();
		}
	}

	void OnDestroy (){
		ScoreManager.score = ScoreManager.score + 10;
		Spawn.enemiesSpawned--;
	}

}