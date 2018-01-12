using UnityEngine;
using System.Collections;

public class InimigoControle : MonoBehaviour {

	private Rigidbody2D corpo;
	private Vector2 direcao;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		corpo = this.GetComponent<Rigidbody2D> ();
		direcao = new Vector2 (1, 0);
		sprite = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		corpo.AddForce (Vector2.zero);
		corpo.AddForce (direcao * 5);
		if(corpo.position.x > 10){
			direcao = new Vector2 (-1, 0);
			sprite.flipX = false;
		}
		if (corpo.position.x < 6) {
			direcao = Vector2.right;
			sprite.flipX = true;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Jogador") {
			coll.rigidbody.AddForce (Vector2.left * 5, ForceMode2D.Impulse);
		}
	}
}
