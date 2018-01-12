using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Pokeball")
        {
            GameManager.Instance.Victory();
        }

    }
}
