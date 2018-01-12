using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void OnPlayButtonClick()
    {
        GameManager.Instance.ChangeScene("Game");
    }
}
