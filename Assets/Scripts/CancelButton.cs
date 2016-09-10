using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CancelButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(Vector3.right * Time.deltaTime * 35, Space.World);
    }
}
