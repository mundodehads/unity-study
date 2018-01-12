using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void btnPlay () {
		SceneManager.LoadScene("Game_0");
	}

	public void btnExit () {
		Application.Quit();
	}
}
