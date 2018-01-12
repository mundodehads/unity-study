using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private AudioController ac;

	// Use this for initialization
	void Start () {
		this.ac = GameObject.Find ("AudioController").GetComponent<AudioController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1)) {
			Jump ();
		}
	}

	private void Jump () {
		ac.Play ("PlayerJump");
	}
}
