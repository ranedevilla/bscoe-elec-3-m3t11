using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class COde : MonoBehaviour {
	Rigidbody _rb;
	public float mainThrust = 1000f;
	public float rcsThrust = 500f;
	AudioSource _as;
	bool _isPlaying = false;
	Scene scene;
	bool letterO = true;
	int ctr = 0;
	string scene_name;
	GameObject target;
	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody> ();
		_as = GetComponent<AudioSource> ();
		scene = SceneManager.GetActiveScene ();
		target = GameObject.Find ("TargetPad");
	}

	// Update is called once per frame
	void Update () {
		scene_name = scene.name;
		ProcessInput ();
	}

	void OnCollisionEnter (Collision col){
		if (letterO) {
			if (col.gameObject.name != "TargetPad" && col.gameObject.name != "Start") {
				SceneManager.LoadScene ("v1");
				print ("aw");
			}	 
		}
		if (col.gameObject.name == "TargetPad"){
			if (scene_name == "v1") {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
			} else if (scene_name == "SC01") {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
			} else if (scene_name == "SC02") {
				target.GetComponent<Renderer> ().material.color = Color.green;
			}
		}
	}

	public void ProcessInput ()
	{
		if (Input.GetKey (KeyCode.Space)) {
			_rb.AddRelativeForce (Vector3.up*mainThrust*Time.deltaTime);

			if (!_isPlaying) {
				_as.Play ();
				_isPlaying = true;
			} else {
				_as.Stop ();
				_isPlaying = false;
			}
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (Vector3.left * rcsThrust*Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D	)) {
			transform.Rotate (Vector3.right * rcsThrust*Time.deltaTime);
		}
		if (Input.GetKeyDown (KeyCode.O)) {
			if (letterO) {
				letterO = false;
			} else {
				letterO = true;
			}
		}
	}

}
