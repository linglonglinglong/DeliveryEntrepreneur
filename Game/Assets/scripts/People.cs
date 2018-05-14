using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour {

	public float[] valueChart = new float[8];
	/*
   		valueChart:
   		0: fish
   		1: salad
   		2: coffee
   		3: ice cream
   		4: dim sum
   		5: hot dog
   		6: fruit
   		7: chicken
	*/
	public bool avail;
	public float time;
	public float appearTime;
	public float disappearTime;

	private Collider coll;

	// Use this for initialization
	void Start () {
		coll = this.GetComponent<Collider> ();

		time = Random.Range (1, 5);
		if (time < 2) {
			avail = false;
		} else {
			avail = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time < 0f) {
			ShowAndHide ();
		}
	}

	void ShowAndHide(){
		if (avail) {
			time = disappearTime;
			avail = false;
			this.gameObject.GetComponent<Renderer>().enabled = false;
			coll.enabled = false;
		}
		else {
			time = appearTime;
			avail = true;
			this.gameObject.GetComponent<Renderer>().enabled = true;
			coll.enabled = true;
		}
	}
}
