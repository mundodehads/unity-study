using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scptGameManager : MonoBehaviour {

	private GameObject Player;
	private scptAudioController audioManager;

	//lista da UI
	private Text UI_txtMoedas;
	private Text UI_txtExp;
	private Text UI_txtLvl;
	private Text UI_txtKm;

	//variaveis da UI
	private int UI_Moedas;
	private int UI_exp;
	private int UI_maxExp;
	private int UI_lvl;
	private float UI_km;

	//variaveis do mapa
	private bool pistaCimaLiberada;
	private bool pistaBaixoLiberada;
	private bool noite;

	//variaveis da Moeda
	public GameObject Moeda;
	private float Moeda_tempoatual;
	private float Moeda_tempospaw;

	//variaveis do Enemy
	public GameObject Enemy;
	private float Enemy_tempoatual;
	private float Enemy_tempospaw;

	void Start () {
		audioManager = GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<scptAudioController> ();
		Player = GameObject.FindGameObjectWithTag("Player");
		pistaCimaLiberada = false;
		pistaBaixoLiberada = false;
		noite = false;
		UI_txtKm = GameObject.Find ("txtKm").GetComponent<Text> ();
		UI_km = 0;
		Moeda_tempoatual = 0;
		Moeda_tempospaw = 1;
		Enemy_tempoatual = 0;
		Enemy_tempospaw = 4;
		LoadGame ();
	}

	// Update is called once per frame
	void Update () {
		UI_km += Time.deltaTime;
		UI_txtKm.text = ((int)UI_km).ToString();
		//Spaw de Moedas e Inimigos
		Moeda_tempoatual += Time.deltaTime;
		Enemy_tempoatual += Time.deltaTime;
		if (Moeda_tempoatual >= Moeda_tempospaw) {
			SpawGameObject(Moeda, new Vector3(14, Random.Range(-1, 4), Player.transform.position.z), Quaternion.identity);
			Moeda_tempoatual = 0;
		}
		if (Enemy_tempoatual >= Enemy_tempospaw) {
			SpawGameObject(Enemy, new Vector3(Random.Range(14, 18), -1.7f, 0), Quaternion.identity);
			Enemy_tempoatual = 0;
			Enemy_tempospaw = Random.Range (2, 4);
		}
	}

	public void SpawGameObject (GameObject obj, Vector3 pos, Quaternion rot)
	{
		Instantiate(obj, pos, rot);
	}

	private void LoadGame () {
		if (PlayerPrefs.HasKey ("Moedas")) {
			UI_txtMoedas = GameObject.Find ("txtMoedas").GetComponent<Text> ();
			UI_Moedas = PlayerPrefs.GetInt ("Moedas");
			UI_txtMoedas.text = UI_Moedas.ToString();
			//maxExp
			UI_maxExp = PlayerPrefs.GetInt ("MaxExp");
			//Exp
			UI_txtExp = GameObject.Find ("txtExp").GetComponent<Text> ();
			UI_exp = PlayerPrefs.GetInt ("Exp");
			UI_txtExp.text = UI_exp.ToString() +" / "+ UI_maxExp.ToString();
			//Lvl
			UI_txtLvl = GameObject.Find ("txtLvl").GetComponent<Text> ();
			UI_lvl = PlayerPrefs.GetInt ("Lvl");
			UI_txtLvl.text = UI_lvl.ToString();
		} else {
			UI_txtMoedas = GameObject.Find ("txtMoedas").GetComponent<Text> ();
			PlayerPrefs.SetInt ("Moedas", 0);
			UI_Moedas = 0;
			UI_txtMoedas.text = "0";
			UI_txtExp = GameObject.Find ("txtExp").GetComponent<Text> ();
			PlayerPrefs.SetInt("Exp", 0);
			UI_exp = 0;
			UI_txtExp.text = "0 / 10";
			PlayerPrefs.SetInt("MaxExp", 10);
			UI_maxExp = 10;
			UI_txtLvl = GameObject.Find ("txtLvl").GetComponent<Text> ();
			PlayerPrefs.SetInt("Lvl", 0);
			UI_lvl = 0;
			UI_txtLvl.text = "0";
		}
	}

	public void SaveGame () {
		PlayerPrefs.SetInt ("Moedas", UI_Moedas);
		PlayerPrefs.SetInt("Exp", UI_exp);
		PlayerPrefs.SetInt("MaxExp", UI_maxExp);
		PlayerPrefs.SetInt("Lvl", UI_lvl);
	}

	public void GameOver () {
		SaveGame ();
		SceneManager.LoadScene ("MenuScene");
	}

	public bool getPistaCimaLiberada ()
	{
		return pistaCimaLiberada;
	}

	public bool getPistaBaixoLiberada()
	{
		return pistaBaixoLiberada;
	}

	public bool getNoite ()
	{
		return noite;
	}
		
	public void addMoeda (int quantMoedas) {
		UI_Moedas += quantMoedas;
		UI_txtMoedas.text = UI_Moedas.ToString();
	}

	public void addExp (int expObtida) {
		UI_exp += expObtida;
		UI_txtExp.text = UI_exp.ToString() +" / "+ UI_maxExp.ToString();

		if (UI_exp >= UI_maxExp) {
			UI_lvl++;
			UI_txtLvl.text = UI_lvl.ToString ();
			UI_maxExp = UI_lvl * 10;
			UI_exp = 0;
			UI_txtExp.text = UI_exp.ToString() +" / "+ UI_maxExp.ToString();
		}
	}

	public void lostMoeda (int moedasPerdidas) {
		UI_Moedas -= moedasPerdidas;
		if (UI_Moedas <= 0)
			UI_Moedas = 0;
		UI_txtMoedas.text = UI_Moedas.ToString();
		//
	}

	public void LiberarPistas() {
		pistaCimaLiberada = true;
		pistaBaixoLiberada = true;
		StartCoroutine (PistaTime ());
	}

	public void BloquearPistas (){
		pistaCimaLiberada = false;
		pistaBaixoLiberada = false;
	}

	IEnumerator PistaTime()
	{
		yield return new WaitForSeconds (2);
		if (!pistaCimaLiberada) {
			audioManager.Ouviu ();
		} else {
			audioManager.NaoOuviu ();
			BloquearPistas ();
		}
	}

}
