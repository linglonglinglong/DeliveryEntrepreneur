using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeCameraControl : MonoBehaviour {

	public GameObject countdown;
	public GameObject button;
	private float time;
	private Text timerText;
	private Image buttonColor;
	private bool ready;
	private bool stayOnButton;

	// Use this for initialization
	void Start () {
		timerText = countdown.GetComponent<Text> ();
		buttonColor = button.GetComponent<Image> ();
		ready = false;
		stayOnButton = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ready) {
			buttonColor.color = Color.red;
			if (!stayOnButton) {
				stayOnButton = true;
				time = 5.0f;
			}
			timerText.text = "Game start in " + time.ToString ("f0") + " seconds";
			countdown.SetActive (true);
			time -= Time.deltaTime;
			if (time < 0f) {
				SceneManager.LoadScene (1);
			}
		} else {
			buttonColor.color = Color.white;
			countdown.SetActive (false);
		}

		ready = false;

		//look at start button
		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (.5f, .5f, 0));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.name.Contains ("Cube")) {
				ready = true;
			} 
		} else {
			stayOnButton = false;
		}
	}
}
