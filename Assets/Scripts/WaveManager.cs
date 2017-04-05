using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveManager : MonoBehaviour {

	Text waveText;
	
	
	// Use this for initialization
	void Start () {
		waveText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		waveText.text = "Current Wave: " + (Spawn.wave - 1).ToString ();
	}
}
