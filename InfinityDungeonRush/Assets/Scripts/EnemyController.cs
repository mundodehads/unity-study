using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public int atk;
	public int def;
	public int crit;
	public int hp;
	public int maxhp;
	public int exp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool InflictDamage (int damage) {
		int hpAux = hp - damage;
		if (hpAux <= 0) {
			Destroy (this);
			return true;
		} else {
			hp = hpAux;
		}
		return false;
	}

	public int GetDef () {
		return def;
	}

	public int GetAtk () {
		return def;
	}

	public int GetExp () {
		return exp;
	}

}
