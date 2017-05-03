using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float speed; // How fast the tank moves forward and back.
	public float m_TurnSpeed; // How fast the tank turns in degrees per second.

	void Start() {
		rb = GetComponent<Rigidbody>();
	}
		
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = transform.forward * moveVertical * speed * Time.deltaTime;
		rb.MovePosition(rb.position + movement);


		float turnValue = moveHorizontal * m_TurnSpeed * Time.deltaTime;
		Quaternion turn = Quaternion.Euler(0f, turnValue, 0f);
		rb.MoveRotation(rb.rotation * turn);
	}
}
