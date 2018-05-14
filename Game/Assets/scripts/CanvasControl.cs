using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasControl : MonoBehaviour {

	public int level;
	public float targetAmt;
	public float earnedAmt;
	public bool timeup;
	public GameObject levelObj;
	public GameObject targetObj;
	public GameObject earnedObj;
	private Text levelTxt;
	private Text targetTxt;
	private Text earnedTxt;

	// Use this for initialization
	void Start () {
		level = 0;
		targetAmt = 10;
		earnedAmt = 0;
		timeup = false;
		levelTxt = levelObj.GetComponent<Text> ();
		targetTxt = targetObj.GetComponent<Text> ();
		earnedTxt = earnedObj.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		levelTxt.text = "Level: " + level.ToString ();
		targetTxt.text = "Target Amount: $" + targetAmt.ToString ("f2");
		earnedTxt.text = "Amount Earned: $" + earnedAmt.ToString ("f2");

		if (timeup) {
			if (earnedAmt > targetAmt) {
				timeup = false;
				level += 1;
				targetAmt = targetAmt * 1.28f;
				earnedAmt = 0;
			} else {
				SceneManager.LoadScene (0);
			}
		}
	}
}
