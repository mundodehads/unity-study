using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private float speed;
	private float jumpSpeed;
	private float gravity;
	private Vector3 moveDirection;

	private Vector2 touchPosition;
	private float swipeResistence;

	void Start () {
		speed = 6.0f;
		jumpSpeed = 11.0f;
		gravity = 20.0f;
		moveDirection = Vector3.zero;

		swipeResistence = 200.0f;
	}

	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(0, 0, 1);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
			{
				touchPosition = Input.mousePosition;
			}
			//swipe
			if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
			{
				float swipeYForce = touchPosition.y - Input.mousePosition.y;
				float swipeXForce = touchPosition.x - Input.mousePosition.x;
				if (Mathf.Abs (swipeYForce) > swipeResistence) { // vertical
					if (swipeYForce < 0) { //cima
						this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
					} else { //baixo
						this.transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
					}
				} else if (Mathf.Abs (swipeXForce) > swipeResistence) { //horizontal
					if (swipeXForce < 0) { //direita
						this.transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));
					} else { //esquerda
						this.transform.rotation = Quaternion.Euler (new Vector3 (0, -90, 0));
					}
				}else { //pulo
					if (Input.mousePosition.x < 300 && Input.mousePosition.y < 300) {
					}
					else {
						moveDirection.y = jumpSpeed;
					}
				}

			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
