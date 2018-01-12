using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

    private void Update()
    {
        if(transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
