using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scptGameManager : MonoBehaviour {

	private GameObject StartPanel;
	private GameObject GamePanel;
	private float SavedTimeScale;

	private PlayerController Player;

	private int delayTime;
	private bool btnClicked;

	// Use this for initialization
	void Awake () {
		Time.timeScale = 0;
		StartPanel = GameObject.FindGameObjectWithTag ("StartPanel");
		GamePanel = GameObject.FindGameObjectWithTag ("GamePanel");
		GamePanel.SetActive (false);

		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();

		delayTime = 2;
		btnClicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame () {
		Time.timeScale = 1;
		StartPanel.SetActive (false);
		GamePanel.SetActive (true);
	}

	public void GameOver () {
		SceneManager.LoadScene ("GameScene");
	}

	public void PauseGame () {
		AudioListener.pause = true;
		SavedTimeScale = Time.timeScale;
		Time.timeScale = 0;
	}

	public void UnPauseGame () {
		AudioListener.pause = false;
		Time.timeScale = SavedTimeScale;
	}

	public void btnAtk () {
		if (!btnClicked) {
			btnClicked = true;
			Player.Atk ();
			StartCoroutine (btnDelay ());
		}
	}

	public void btnDef () {
		if (!btnClicked) {
			btnClicked = true;
			Player.Def ();
			StartCoroutine (btnDelay ());
		}
	}

	IEnumerator btnDelay () {
		yield return new WaitForSeconds (delayTime);
		btnClicked = false;
	}
		
}
