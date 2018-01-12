using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class JogadorControle : MonoBehaviour {

	private float velocidade;
	private float forcaPulo;
	private Rigidbody2D corpo;
	private bool nochao;
	public GameObject municao;
	private Animator anim;
	private SpriteRenderer sprite;

	//stats do jogador
	private int hp;
	private int maxHp;
	private float tempo;
	private float tempoInicio;

	//controle da arma
	private int bala;

	//variaveis HUD
	private Text txtHp;
	private Text txtTempo;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		sprite = this.GetComponent<SpriteRenderer> ();
		velocidade = 5;
		forcaPulo = 10;
		corpo = this.GetComponent<Rigidbody2D> ();
		nochao = false;

		maxHp = 3;
		hp = maxHp;

		bala = 3;
		tempo = 0;
		tempoInicio = Time.time;

		txtHp = GameObject.Find ("txtHp").GetComponent<Text> ();
		txtTempo = GameObject.Find ("txtTempo").GetComponent<Text> ();

		txtHp.text = hp+"/"+maxHp;
			
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		tempo = (float) Math.Round((double)(Time.time - tempoInicio),1);
		txtTempo.text = tempo.ToString();

		if (corpo.position.y < -7) {
			GameOver ();
		}

		float direcao = Input.GetAxis ("Horizontal");
		if (direcao > 0) {
			sprite.flipX = false;
			anim.SetBool ("running", true);
		} else if (direcao < 0) {
			sprite.flipX = true;
			anim.SetBool ("running", true);
		} else {
			anim.SetBool ("running", false);
		}
		Vector2 movimento = new Vector2 (direcao,0);

		if (Input.GetKeyDown (KeyCode.Space)) {
			Pulo ();
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			Disparar ();
		}

		corpo.AddForce (movimento * velocidade);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Chao") {
			nochao = true;
			anim.SetBool ("noChao", true);
		}
		if (coll.gameObject.tag == "Inimigo") {
			hp--;
			txtHp.text = hp+" / "+maxHp;
			if (hp <= 0) {
				GameOver();
			}
		}
		if (coll.gameObject.tag == "Fim") {
			GameOver ();
		}
	}

	void Pulo (){
		if (nochao) {
			nochao = false;
			anim.SetBool ("noChao", false);
			corpo.AddForce (Vector2.up * forcaPulo, ForceMode2D.Impulse);
		}
	}

	void GameOver () {
		MelhorTempo ();
		SceneManager.LoadScene ("main");
	}

	void MelhorTempo () {
		if (tempo < PlayerPrefs.GetFloat ("tempo")) {
			PlayerPrefs.SetFloat ("tempo", tempo);
		}
	}

	void Disparar () {
		if (bala > 0) {
			bala--;
			Instantiate (municao,
				new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z),
				Quaternion.identity);
			if(bala <= 0)
				StartCoroutine (Recarregar ());
		}
	}

	IEnumerator Recarregar (){
		yield return new WaitForSeconds (3);
		bala = 3;
	}
}
