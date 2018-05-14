using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerControl : MonoBehaviour {

	public GameObject canvas;
	public GameObject foodCt;
	public GameObject cam;

	public float speed;
	private bool walking = true;
	private Vector3 spawnPoint;
	private int[] collectedFood = new int[8];
	/*
   		collectedFood:
   		0: fish
   		1: salad
   		2: coffee
   		3: ice cream
   		4: dim sum
   		5: hot dog
   		6: fruit
   		7: chicken
	*/

	// Use this for initialization
	void Start () {
		speed = 1f;

		spawnPoint = transform.position;
		for (int i = 0; i < collectedFood.Length; ++i) {
			collectedFood [i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//whenever falls down the plane, returns to the starting position.
		if (transform.position.y < -10f) {
			transform.position = spawnPoint;
		}

		//walking
		if (walking) {
			transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
			Vector3 pos = transform.position;
			pos.y = 0.2f;
			transform.position = pos;
		}

		//looking down->stop
		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (.5f, .5f, 0));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.name.Contains ("Plane")) {
				walking = false;
			} else {
				walking = true;
			}
		}

		//update number of collected food
		for (int i = 0; i < collectedFood.Length; ++i) {
			Text txt = foodCt.transform.GetChild(i).GetComponent<Text> ();
			txt.text = collectedFood [i].ToString ();
		}
			
		//speed down
		if (cam.transform.eulerAngles.z > 23 && cam.transform.eulerAngles.z < 180) {
			if (speed <= 0) {
				speed = 0;
			} else {
				speed -= 0.01f;
			}
		}
		//speed up
		if (cam.transform.eulerAngles.z > 180 && cam.transform.eulerAngles.z < 337) {
			if (speed >= 4) {
				speed = 4;
			} else {
				speed += 0.01f;
			}
		}
	}

	//When the player collects food or sells food
	void OnTriggerEnter(Collider other){
		//for food collection
		if(other.gameObject.CompareTag("food")){
			Food foodScript = other.GetComponent<Food> ();
			string foodType = foodScript.type;
			foodScript.avail = false;
			other.gameObject.GetComponent<Renderer>().enabled = false;
			GameObject outOfStock = foodScript.outOfStock;
			outOfStock.SetActive (true);
			foodScript.time = foodScript.disappearTime;
			switch (foodType)
			{
			case "fish":
				collectedFood [0] += 1;
				break;
			case "salad":
				collectedFood [1] += 1;
				break;
			case "coffee":
				collectedFood [2] += 1;
				break;
			case "ice":
				collectedFood [3] += 1;
				break;
			case "dim":
				collectedFood [4] += 1;
				break;
			case "hot":
				collectedFood [5] += 1;
				break;
			case "fruit":
				collectedFood [6] += 1;
				break;
			case "chicken":
				collectedFood [7] += 1;
				break;
			default:
				break;
			}
		}

		//for selling food
		if(other.gameObject.CompareTag("people")){
			//get money
			People peopleScript = other.GetComponent<People> ();
			CanvasControl canvasScript = canvas.GetComponent<CanvasControl> ();
			float[] values = peopleScript.valueChart;
			float earned = 0f;
			for (int i = 0; i < values.Length; ++i) {
				earned += collectedFood [i] * values [i];
			}
			canvasScript.earnedAmt += earned;
			for (int i = 0; i < collectedFood.Length; ++i) {
				collectedFood [i] = 0;
			}
		}
	}

}
