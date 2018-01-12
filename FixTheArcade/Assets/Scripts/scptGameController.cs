using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scptGameController : MonoBehaviour {

	private int CenaAtual;

	public void Start () {
		if (PlayerPrefs.HasKey("CenaAtual"))
		{
			this.CenaAtual = PlayerPrefs.GetInt("CenaAtual");
		}
		else
		{
			PlayerPrefs.SetInt("CenaAtual", 0);
		}


		DontDestroyOnLoad (this);
		StartCoroutine(LoadScreen(5));
	}

	IEnumerator LoadScreen (float seconds) {
		yield return new WaitForSeconds(seconds);
		ChangeScene ("MainMenu");
	}

	public void ChangeScene (string sceneName) {
		SceneManager.LoadScene (sceneName);
	}


	public void btnPlayEvent () {
		//tocar som
		setCenaAtual(PlayerPrefs.GetInt("CenaAtual"));
		SceneManager.LoadScene ("cena"+CenaAtual);
	}

	public void setCenaAtual (int scene) {
		this.CenaAtual = scene;
		PlayerPrefs.SetInt("CenaAtual", scene);
	}
}
