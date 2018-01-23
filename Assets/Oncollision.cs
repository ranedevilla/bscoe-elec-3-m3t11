using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oncollision : MonoBehaviour {

	GameObject r1;
	public float landing_pad = 20f;

	void Start () {
		r1 = GameObject.Find ("Rocket_1");
	}
	
	// Update is called once per frame
	void Update () {
		trans ();
	}


	public void trans (){
		float x = Vector3.Distance (r1.transform.position, transform.position);
		//print (x);
		if (x < landing_pad) {
			GetComponent<Renderer> ().material.color = Color.yellow;
		} else {
			GetComponent<Renderer> ().material.color = Color.red;
		}
	}
}
