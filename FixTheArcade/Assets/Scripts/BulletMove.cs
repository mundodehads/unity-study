using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

	//variaveis para o movimento de bala
	public float speed;
	public float distance;
	public bool Right;
	public bool Left;
	public bool Up;
	public bool Down;

	private Vector3 direction;
	// Use this for initialization
	void Start () {
		if (Right) 
			direction = Vector3.right;
		else if(Left)
			direction = Vector3.left;
		else if (Up)
			direction = Vector3.up;
		else if(Down)
			direction = Vector3.down;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += direction * speed * (Time.deltaTime);

		if (transform.position.x > distance && Right)
			Destroy (gameObject);
		if(transform.position.x < distance && Left)
			Destroy(gameObject);

		if (transform.position.y > distance && Up)
			Destroy (gameObject);

		if (transform.position.y < distance && Down)
			Destroy (gameObject);
		
	}
}
