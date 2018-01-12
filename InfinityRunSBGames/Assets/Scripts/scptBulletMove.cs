using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scptBulletMove : MonoBehaviour {

	private float bulletForce;
	private int quantMoedas;
	private float bulletDist;
	private Rigidbody bulletBody;
	private scptGameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<scptGameManager>();
		bulletForce = 400;
		quantMoedas = 2;
		bulletDist = 10;
		bulletBody = this.GetComponent<Rigidbody>();
		bulletBody.AddForce(Vector3.right * bulletForce);
	}
	
	// Update is called once per frame
	void Update () {
		//bulletBody.AddForce(Vector3.right * speed);

		if(transform.position.x > bulletDist)
		{
			Destroy(gameObject);
		}	
	}

	public void setbulletForce (float newbulletForce) {
		bulletForce = newbulletForce;
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.CompareTag("Enemy"))
		{
			Destroy (gameObject);
			Destroy(col.gameObject);
		}

		if (col.gameObject.CompareTag("Coin"))
		{
			gameManager.addMoeda (quantMoedas);
			Destroy (gameObject);
			Destroy(col.gameObject);
		}
	}
}
