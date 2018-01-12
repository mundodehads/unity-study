using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scptPlayerControl : MonoBehaviour {

	//variaveis de movimentacao pelo mapa
	private scptGameManager gameManager;
	private Vector2 touchPosition;
	private float swipeResistence = 200.0f;

	//players variables
	private Rigidbody playerBody;
	public GameObject Bala;
	private GameObject skin;
	private float jumpForce;
	private bool grounded;
	private int balas;
	private float recargaTime;
	private float pistaTime;
	private int moedasPerdidas;
	private int expObtida;
	private int numberOfJump;
	private int jumpCount;

	//tipos de controle
	private bool teclado;
	private bool mouse;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<scptGameManager>();
		skin = GameObject.FindGameObjectWithTag("PlayerSkin");
		playerBody = this.GetComponent<Rigidbody>();
		jumpForce = 8;
		grounded = false;
		balas = 2;
		recargaTime = 5;
		pistaTime = 5;
		moedasPerdidas = 10;
		expObtida = 1;
		numberOfJump = 1;
		jumpCount = 0;

		teclado = true;
		mouse = false;
	}

	// Update is called once per frame
	void Update () {
		//deixar o player sempre em movimento, correção do bug de objetos sem movimento não se colidem
		playerBody.AddForce(Vector3.right * 0.1f);

		if (mouse) {
			if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
			{

				touchPosition = Input.mousePosition;

				if (touchPosition.x < 640) {
					if (balas > 0) {
						//print (balas);
						balas--;
						Instantiate(Bala,
							new Vector3(transform.position.x + 1, transform.position.y, transform.position.z),
							Quaternion.identity);
						if(balas <=0) StartCoroutine (RecarregarTime ());
					}
				}

				if (grounded && touchPosition.x > 640)
				{
					playerBody.velocity = new Vector3(playerBody.velocity.x, jumpForce, playerBody.velocity.z);
					grounded = false;
					gameManager.addExp (expObtida);
				}

			}

			//fazer se mover entre plataformas
			if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
			{
				float swipeForce = touchPosition.y - Input.mousePosition.y;
				if (Mathf.Abs(swipeForce) > swipeResistence)
				{
					if (swipeForce < 0) //cima
					{
						if(transform.position.z == 0 && gameManager.getPistaCimaLiberada())
						{
							transform.position = new Vector3(-7, -1.6f, 3);
							//skin.transform.position = new Vector3 (skin.transform.position.x, (skin.transform.position.z + 0.5f), skin.transform.position.z);
							gameManager.BloquearPistas ();
							StartCoroutine(PistaTime ());
						}
						/*else if(transform.position.z == 3)
					{
						transform.position = new Vector3(-7, -2, 0);
					}*/
					}
					else //baixo
					{
						if (transform.position.z == 0 && gameManager.getPistaBaixoLiberada())
						{
							transform.position = new Vector3(-7, -1.6f, -3);
							//skin.transform.position = new Vector3 (skin.transform.position.x, (skin.transform.position.z - 1.5f), skin.transform.position.z);
							gameManager.BloquearPistas ();
							StartCoroutine(PistaTime ());
						}
						/*else if (transform.position.z == -3)
					{
						transform.position = new Vector3(-7, -2, 0);
					}*/
					}
				}

			}
		}

		if (teclado) {
			if (grounded && Input.GetKeyDown (KeyCode.Space)) {
				playerBody.velocity = new Vector3(playerBody.velocity.x, jumpForce, playerBody.velocity.z);
				grounded = false;
				gameManager.addExp (expObtida);
			}

			if (Input.GetKeyUp (KeyCode.X)) {
				if (balas > 0) {
					//print (balas);
					balas--;
					Instantiate(Bala,
						new Vector3(transform.position.x + 1, transform.position.y, transform.position.z),
						Quaternion.identity);
					if(balas <=0) StartCoroutine (RecarregarTime ());
				}
			}

			if(Input.GetKeyUp(KeyCode.UpArrow)) {
				if(transform.position.z == 0 && gameManager.getPistaCimaLiberada())
				{
					transform.position = new Vector3(-7, -1.6f, 3);
					//skin.transform.position = new Vector3 (0, 0.5f, 0);
					gameManager.BloquearPistas ();
					StartCoroutine(PistaTime ());
				}
			}

			if(Input.GetKeyUp(KeyCode.DownArrow)){
				if (transform.position.z == 0 && gameManager.getPistaBaixoLiberada())
				{
					transform.position = new Vector3(-7, -1.6f, -3);
					//skin.transform.position = new Vector3 (0, -1.5f, 0);
					gameManager.BloquearPistas ();
					StartCoroutine(PistaTime ());
				}
			}
		}

	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.CompareTag("Ground"))
		{
			grounded = true;
		}

		if (col.gameObject.CompareTag("Coin"))
		{
			gameManager.addMoeda (1);
			Destroy(col.gameObject);
			//print ("Colide with Coin");
		}

		if (col.gameObject.CompareTag("Enemy"))
		{
			gameManager.lostMoeda (moedasPerdidas);
			Destroy(col.gameObject);
			//print ("Colide with Enemy");
			if(gameManager.getNoite()) {
				gameManager.GameOver();
			}
		}
	}

	IEnumerator PistaTime()
	{
		yield return new WaitForSeconds (pistaTime);
		transform.position = new Vector3(-7, -1.6f, 0);
		//skin.transform.position = new Vector3 (0, 0.5f, 0);
	}

	IEnumerator RecarregarTime()
	{
		yield return new WaitForSeconds (recargaTime);
		balas = 3;
	}
		
}
