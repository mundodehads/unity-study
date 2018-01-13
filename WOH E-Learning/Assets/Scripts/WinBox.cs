using UnityEngine;
using System.Collections;

public class WinBox : MonoBehaviour {

	private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            LevelManager.Instance.Victory();
        }
    }

}
