using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cena0BulletMove : MonoBehaviour {

	public float speed;
	public float distance;
	private scptGameController Controller;

	void Start () {
		Controller = GameObject.Find ("GameController").GetComponent<scptGameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += Vector3.up * speed * (Time.deltaTime);

		if (transform.position.y > distance) {
			Controller.setCenaAtual (1);
			Controller.ChangeScene ("cena1");
		}

	}
}
