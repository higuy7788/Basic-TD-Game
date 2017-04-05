using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemiesText : MonoBehaviour {

	Text enemyText;
	
	
	// Use this for initialization
	void Start () {
		enemyText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		enemyText.text =  Spawn.enemiesSpawned + " Enemies";
	}
}
