using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class scptAudioController : MonoBehaviour {
	

	private AudioSource audSour;
	private AudioClip[,] khz;
	private int[] dbMin;
	private int[] dbMax;
	int khzSort;
	int dbSort;
	int posSort;

	private string[] test;
	//private int testDB;

	private float Audio_tempoatual;
	private float Audio_tempospaw;

	private scptGameManager GM;

	//att 26/06 - text e lista
	private string path = "Assets/Resources/Resultado.txt";
	private List<int> listaKHZ;

	// Use this for initialization
	void Start () {
		Audio_tempoatual = 5;
		Audio_tempospaw = Random.Range (8, 12);
		audSour = GetComponent<AudioSource> ();
		GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<scptGameManager>();
		dbMin = new int[6];
		dbMax = new int[6];
		test = new string[6];
		listaKHZ = new List<int> ();
		for (int i = 0; i < 6; i++) {
			dbMin [i] = 0;
			dbMax [i] = 7;
			test [i] = null;
			listaKHZ.Add (i);
		}

		khz = new AudioClip[6,11];

		khz [0, 0] = Resources.Load<AudioClip> ("250Hz-48dB");
		khz [0, 1] = Resources.Load<AudioClip> ("250Hz-45dB");
		khz [0, 2] = Resources.Load<AudioClip> ("250Hz-42dB");
		khz [0, 3] = Resources.Load<AudioClip> ("250Hz-39dB");
		khz [0, 4] = Resources.Load<AudioClip> ("250Hz-36dB");
		khz [0, 5] = Resources.Load<AudioClip> ("250Hz-30dB");
		khz [0, 6] = Resources.Load<AudioClip> ("250Hz-24dB");
		khz [0, 7] = Resources.Load<AudioClip> ("250Hz-18dB");
		khz [0, 8] = Resources.Load<AudioClip> ("250Hz-12dB");
		khz [0, 9] = Resources.Load<AudioClip> ("250Hz-6dB");
		khz [0, 10] = Resources.Load<AudioClip> ("250Hz-0dB");

		khz [1, 0] = Resources.Load<AudioClip> ("500Hz-48dB");
		khz [1, 1] = Resources.Load<AudioClip> ("500Hz-45dB");
		khz [1, 2] = Resources.Load<AudioClip> ("500Hz-42dB");
		khz [1, 3] = Resources.Load<AudioClip> ("500Hz-39dB");
		khz [1, 4] = Resources.Load<AudioClip> ("500Hz-36dB");
		khz [1, 5] = Resources.Load<AudioClip> ("500Hz-30dB");
		khz [1, 6] = Resources.Load<AudioClip> ("500Hz-24dB");
		khz [1, 7] = Resources.Load<AudioClip> ("500Hz-18dB");
		khz [1, 8] = Resources.Load<AudioClip> ("500Hz-12dB");
		khz [1, 9] = Resources.Load<AudioClip> ("500Hz-6dB");
		khz [1, 10] = Resources.Load<AudioClip> ("500Hz-0dB");

		khz [2, 0] = Resources.Load<AudioClip> ("1kHz-48dB");
		khz [2, 1] = Resources.Load<AudioClip> ("1kHz-45dB");
		khz [2, 2] = Resources.Load<AudioClip> ("1kHz-42dB");
		khz [2, 3] = Resources.Load<AudioClip> ("1kHz-39dB");
		khz [2, 4] = Resources.Load<AudioClip> ("1kHz-36dB");
		khz [2, 5] = Resources.Load<AudioClip> ("1kHz-30dB");
		khz [2, 6] = Resources.Load<AudioClip> ("1kHz-24dB");
		khz [2, 7] = Resources.Load<AudioClip> ("1kHz-18dB");
		khz [2, 8] = Resources.Load<AudioClip> ("1kHz-12dB");
		khz [2, 9] = Resources.Load<AudioClip> ("1kHz-6dB");
		khz [2, 10] = Resources.Load<AudioClip> ("1kHz-0dB");

		khz [3, 0] = Resources.Load<AudioClip> ("2kHz-48dB");
		khz [3, 1] = Resources.Load<AudioClip> ("2kHz-45dB");
		khz [3, 2] = Resources.Load<AudioClip> ("2kHz-42dB");
		khz [3, 3] = Resources.Load<AudioClip> ("2kHz-39dB");
		khz [3, 4] = Resources.Load<AudioClip> ("2kHz-36dB");
		khz [3, 5] = Resources.Load<AudioClip> ("2kHz-30dB");
		khz [3, 6] = Resources.Load<AudioClip> ("2kHz-24dB");
		khz [3, 7] = Resources.Load<AudioClip> ("2kHz-18dB");
		khz [3, 8] = Resources.Load<AudioClip> ("2kHz-12dB");
		khz [3, 9] = Resources.Load<AudioClip> ("2kHz-6dB");
		khz [3, 10] = Resources.Load<AudioClip> ("2kHz-0dB");

		khz [4, 0] = Resources.Load<AudioClip> ("4kHz-48dB");
		khz [4, 1] = Resources.Load<AudioClip> ("4kHz-45dB");
		khz [4, 2] = Resources.Load<AudioClip> ("4kHz-42dB");
		khz [4, 3] = Resources.Load<AudioClip> ("4kHz-39dB");
		khz [4, 4] = Resources.Load<AudioClip> ("4kHz-36dB");
		khz [4, 5] = Resources.Load<AudioClip> ("4kHz-30dB");
		khz [4, 6] = Resources.Load<AudioClip> ("4kHz-24dB");
		khz [4, 7] = Resources.Load<AudioClip> ("4kHz-18dB");
		khz [4, 8] = Resources.Load<AudioClip> ("4kHz-12dB");
		khz [4, 9] = Resources.Load<AudioClip> ("4kHz-6dB");
		khz [4, 10] = Resources.Load<AudioClip> ("4kHz-0dB");

		khz [5, 0] = Resources.Load<AudioClip> ("8kHz-48dB");
		khz [5, 1] = Resources.Load<AudioClip> ("8kHz-45dB");
		khz [5, 2] = Resources.Load<AudioClip> ("8kHz-42dB");
		khz [5, 3] = Resources.Load<AudioClip> ("8kHz-39dB");
		khz [5, 4] = Resources.Load<AudioClip> ("8kHz-36dB");
		khz [5, 5] = Resources.Load<AudioClip> ("8kHz-30dB");
		khz [5, 6] = Resources.Load<AudioClip> ("8kHz-24dB");
		khz [5, 7] = Resources.Load<AudioClip> ("8kHz-18dB");
		khz [5, 8] = Resources.Load<AudioClip> ("8kHz-12dB");
		khz [5, 9] = Resources.Load<AudioClip> ("8kHz-6dB");
		khz [5, 10] = Resources.Load<AudioClip> ("8kHz-0dB");
	}
	
	// Update is called once per frame
	void Update () {
		Audio_tempoatual += Time.deltaTime;
		if (Audio_tempoatual >= Audio_tempospaw) {
			PlaySound ();
			Audio_tempoatual = 0;
			Audio_tempospaw = Random.Range (8, 12);
		}

		if (test [0] != null && test [1] != null && test [2] != null && test [3] != null
		   && test [4] != null && test [5] != null) {
			print ("fim do teste");
			StreamWriter writer = new StreamWriter (path, true);
			writer.WriteLine ("Resultado:");
			for (int i = 0; i < 6; i++) {
				writer.WriteLine(test [i]);
			}
			//writer.WriteLine (NivelAudicao(resultado));
			writer.WriteLine ("");
			writer.Close ();
			GM.GameOver ();
		}
	}

	private void PlaySound (){
		posSort = Random.Range (0, listaKHZ.Count);
		khzSort = listaKHZ [posSort];
		dbSort = Random.Range (dbMin [khzSort], dbMax [khzSort]);
		audSour.PlayOneShot (khz[khzSort, dbSort]);
		GM.LiberarPistas ();
	}

	public void Ouviu () {
		print ("Ouviu: "+khz [khzSort, dbSort].name);
		if (dbSort < dbMax[khzSort])
			dbMax[khzSort] = dbSort;
		if(dbMax[khzSort] == dbMin[khzSort]){
			test [khzSort] = khz [khzSort, dbMax [khzSort]].name;
			listaKHZ.Remove (khzSort);
		}
	}

	public void NaoOuviu () {
		print ("Nao ouviu: "+khz [khzSort, dbSort].name);
		if (dbSort > dbMin [khzSort])
			dbMin [khzSort] = dbSort;
		if (dbMin [khzSort] == dbMax [khzSort]) {
			dbMax [khzSort]++;
			if (dbMax [khzSort] > 10) {
				dbMax [khzSort] = 10;
				test [khzSort] = khz [khzSort, dbMax [khzSort]].name;
				listaKHZ.Remove (khzSort);
			}
		}
	}
		
}
