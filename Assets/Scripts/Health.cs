using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	TextMesh tm;
	
	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.forward = Camera.main.transform.forward;
	}

	public int current() {
		return tm.text.Length;
	}

	public void decrease() {
		if (current() > 1)
			tm.text = tm.text.Remove(tm.text.Length - 1);
		else
			Destroy(FindParentWithTag(this.gameObject, "Enemy"));
	}

	public static GameObject FindParentWithTag(GameObject childObject, string tag)
	{
		Transform t = childObject.transform;
		while (t.parent != null)
		{
			if (t.parent.tag == tag)
			{
				return t.parent.gameObject;
			}
			t = t.parent.transform;
		}
		return null;
	}

	void OnDestroy (){
		ScoreManager.score = ScoreManager.score + 10;
		Spawn.enemiesSpawned--;
	}

}