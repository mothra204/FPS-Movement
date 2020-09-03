using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController controller;

	public float speed = 12f; // Tốc độ di chuyển
	public float gravity = -9.81f; // Tốc độ rơi
	public float jumpHeight = 3f; // Nhảy cao 3f


	public Transform groundCheck; // Kiểm tra Ground
	public float groundDistance = 0.4f; // Khoản cách Ground
	public LayerMask groundMask; // Bề mặt Ground

	Vector3 velocity;
	bool isGrounded;

	// Update is called once per frame
	void Update () {

		isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance, groundMask);
		if(isGrounded && velocity.y <0)
        {
			velocity.y = -2f;
        }

		float z = Input.GetAxis("Horizontal"); //di qua trái và phải
		float x = Input.GetAxis("Vertical"); // đi thẳng

		Vector3 move = transform.right * z + transform.forward * x; // Đi chuyển

		controller.Move(move * speed * Time.deltaTime); // tốc độ di chuyển

		if(Input.GetButtonDown("Jump") && isGrounded)
        {
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
	}
}
