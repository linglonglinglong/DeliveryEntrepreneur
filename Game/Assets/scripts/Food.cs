using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	public string type;
	public bool avail;
	public float time;
	public float appearTime;
	public float disappearTime;
	public GameObject outOfStock;

	private Collider coll;

	// Use this for initialization
	void Start () {
		coll = this.GetComponent<Collider> ();
		time = Random.Range (1, 5);
		if (time < 2) {
			avail = false;
			outOfStock.SetActive (true);
		} else {
			avail = true;
			outOfStock.SetActive (false);
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
			this.gameObject.GetComponent<Renderer> ().enabled = false;
			coll.enabled = false;
			outOfStock.SetActive (true);
		}
		else {
			time = appearTime;
			avail = true;
			this.gameObject.GetComponent<Renderer> ().enabled = true;
			coll.enabled = true;
			outOfStock.SetActive (false);
		}
	}
}
