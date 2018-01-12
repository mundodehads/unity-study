using UnityEngine;
using System.Collections;

public class MovimentoBala : MonoBehaviour {

	private Rigidbody2D corpo;

	// Use this for initialization
	void Start () {
		corpo = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		corpo.AddForce (Vector2.right * 15, ForceMode2D.Impulse);
		if (corpo.position.x > 30 || corpo.position.x < -15) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Inimigo") {
			Destroy (this.gameObject);
			Destroy (coll.gameObject);
		}
	}
}
