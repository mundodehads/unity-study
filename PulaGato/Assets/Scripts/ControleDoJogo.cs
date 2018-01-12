using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleDoJogo : MonoBehaviour {

	private Text tempo;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		tempo = GameObject.Find ("txtMelhorTempo").GetComponent<Text> ();
		if (PlayerPrefs.HasKey ("tempo")) {
			tempo.text = PlayerPrefs.GetFloat ("tempo").ToString();
		} else {
			PlayerPrefs.SetFloat ("tempo", 999999);
			tempo.text = "Primeira vez";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void btnJogar () {
		SceneManager.LoadScene ("jogo");
	}
}
