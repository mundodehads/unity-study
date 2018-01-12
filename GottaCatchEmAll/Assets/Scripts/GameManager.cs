using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { set; get; }

	private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        ChangeScene("Menu");
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Victory()
    {
        ChangeScene("Menu");
    }
}
