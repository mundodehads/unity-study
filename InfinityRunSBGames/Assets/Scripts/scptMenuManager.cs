using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scptMenuManager : MonoBehaviour {

	public void btnPlay_OnClick () {
		SceneManager.LoadScene ("GameScene");
	}


}
