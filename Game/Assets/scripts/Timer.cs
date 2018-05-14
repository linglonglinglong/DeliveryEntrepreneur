using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	public float countdown;
	public GameObject canvas;
	private float time;
	private Text timerText;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
		time = countdown;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		timerText.text = "Time Left: " + time.ToString ("f0");
		if (time < 0) {
			time = countdown;
			CanvasControl canvasScript = canvas.GetComponent<CanvasControl> ();
			canvasScript.timeup = true;
		}
	}
}
