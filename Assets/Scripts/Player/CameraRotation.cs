using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    public Camera Camera;

	private Rigidbody rb;

	private InputAction _rotateAction;

	public float mouseSensitivity = 10f;

	private float xRotation = 0f;

	private float yRotation = 0f;

	private float yMinRotation = -45f;

	private float yMaxRotation = 45f;

	private void Start()
	{
		this._rotateAction = InputSystem.actions.FindAction("Look");
		this.rb = GetComponent<Rigidbody>();
		//Cursor.lockState = CursorLockMode.Locked;
	}

	private void FixedUpdate()
	{
		Vector2 inputVector = this._rotateAction.ReadValue<Vector2>();

		float mouseX = inputVector.x * mouseSensitivity * Time.deltaTime;
		float mouseY = inputVector.y * mouseSensitivity * Time.deltaTime;

		xRotation += mouseX;
		yRotation -= mouseY;

		yRotation = Math.Clamp(yRotation, yMinRotation, yMaxRotation);

		this.rb.transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
		this.Camera.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
	}
}
