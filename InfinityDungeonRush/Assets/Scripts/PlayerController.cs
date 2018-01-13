using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private scptGameManager GM;

	//player variables
	private int atk;
	private int def;
	private int crit;
	private int hp;
	private int maxhp;
	private int lvl;
	private int exp;
	private int maxexp;

	//variables aux
	private bool OnAtk;
	private bool OnDef;

	// Use this for initialization
	void Start () {
		GM = GameObject.FindGameObjectWithTag ("GM").GetComponent<scptGameManager> ();

		OnAtk = false;
		OnDef = false;

		atk = 25;
		def = 10;
		crit = 10;
		hp = 50;
		maxhp = 50;
		lvl = 1;
		exp = 0;
		maxexp = 100;
	}
	
	// Update is called once per frame
	void Update () {

		if (this.transform.position.y < -5) {
			GM.GameOver ();
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.CompareTag ("Enemy")) {
			print ("oi");
			EnemyController Enemy = col.gameObject.GetComponent<EnemyController> ();
			if (OnAtk) {
				int atkAux = 0;
				if (Crit())
					atkAux = atk * 2;
				int damage = (int)(atkAux - Enemy.GetDef ());
				if (Enemy.InflictDamage (damage)) {
					exp += Enemy.GetExp ();
					LvlUp ();
				}
			} else if (OnDef) {
				int damage = (int)(Enemy.GetAtk() - def);
				InflictDamage (damage);
			} else {
				InflictDamage (Enemy.GetAtk ());
			}
		}
	}

	public void Atk () {
		OnDef = false;
		OnAtk = true;
	}

	public void Def () {
		OnAtk = false;
		OnDef = true;
	}

	public bool Crit () {
		int randomSort = Random.Range (1, 100);
		if (randomSort <= crit) {
			return true;
		}
		return false;
	}

	public void InflictDamage (int damage) {
		int hpAux = hp - damage;
		if (hpAux <= 0) {
			GM.GameOver ();
		} else {
			hp = hpAux;
		}
	}

	public void LvlUp () {
		if (exp >= maxexp) {
			lvl++;
			exp = 0;
			maxexp *= lvl;
		}
	}

}
