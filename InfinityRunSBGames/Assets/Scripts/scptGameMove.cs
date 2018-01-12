using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scptGameMove : MonoBehaviour {

	private float speed;

	// Use this for initialization
	void Start () {
		speed = 6;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * speed * (Time.deltaTime);

		if(transform.position.x < -10)
		{
			Destroy(gameObject);
		}
	}

	public void setSpeed (float newSpeed) {
		speed = newSpeed;
	}
}
