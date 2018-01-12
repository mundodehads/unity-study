using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

    public GameObject bulletPrefab;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            GameObject go = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
            go.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(5, 15), ForceMode.Impulse);
        }
        
    }
}
