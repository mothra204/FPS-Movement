using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public float mouseSensitivity = 100f; //Độ nhạy của chuột
	
	public Transform playerBody;

	float xRotation = 0f;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; /*Mouse di chuyển theo hướng X */
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; /*Mouse di chuyển theo hướng Y */

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);//Body player di chuyển theo trục X
	}
}
