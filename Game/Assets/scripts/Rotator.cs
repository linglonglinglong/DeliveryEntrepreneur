using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public Camera m_Camera;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		var n = m_Camera.transform.position - transform.position; 
		transform.rotation = Quaternion.LookRotation( n );
	}
}
