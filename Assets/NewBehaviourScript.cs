using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yey : MonoBehaviour {

	GameObject r1;
	GameObject r2;
	void Start () {
		r1 = GameObject.Find ("Rocket");
		r2 = GameObject.Find ("TargetPad");
	}
	// Update is called once per frame
	void Update () {
		trans ();
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.name == "TargetPad") {
			print ("change here");
		}
	}

	public void trans (){
		float x = Vector3.Distance (r1.transform.position, r2.transform.position);
		//print (x);
		while (x < 35f) {
			r2.GetComponent<Renderer> ().material.color = Color.yellow;
		}
	}
}
