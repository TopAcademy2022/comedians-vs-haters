using UnityEngine;
using UnityEngine.InputSystem;

public class RTSPlayerMovement : MonoBehaviour
{
	private Camera _camera;

	private float _moveSpeed;

	private float _jumpPower;

    private Rigidbody _rigidbody;

	private InputAction _mouseAction;

	private InputAction _jumpAction;

	private Vector3 _destinationPoint;

	public RTSPlayerMovement()
	{
		this._moveSpeed = 10.0f;
		this._jumpPower = 5.0f;
		this._destinationPoint = Vector3.zero;
	}

	private void Awake()
	{
		this._camera = GetComponent<Camera>();
		this._rigidbody = GetComponent<Rigidbody>();
		this._mouseAction = InputSystem.actions.FindAction("Attack");
		this._jumpAction = InputSystem.actions.FindAction("Jump");
	}

	private bool IsGrounded()
	{
		return this._rigidbody.linearVelocity.y == 0;
	}

	private void MoveOnPoint()
	{
		if (this._destinationPoint != Vector3.zero)
		{
			// TODO: Use radius, and movespeed / 2
			if (this._rigidbody.transform.position != this._destinationPoint)
			{
				Vector3 different = this._rigidbody.transform.position - this._destinationPoint;
				this._rigidbody.AddForce(different.normalized * -1 * this._moveSpeed, ForceMode.Acceleration);
			}
		}
	}

	private void FixedUpdate()
	{
		this.MoveOnPoint();

		if (this._mouseAction.IsPressed())
		{
			// TODO: rewrite
			Vector2 mouseClickPosition = Mouse.current.position.ReadValue();

			Ray cameraRay = Camera.main.ScreenPointToRay(mouseClickPosition);
			RaycastHit rayInfo;

			if (Physics.Raycast(cameraRay, out rayInfo))
			{
				// this._destinationPoint = rayInfo.point;
				this._destinationPoint = new Vector3(10f, 1f, 10f);

				Debug.Log("Mouse clicked at: " + this._destinationPoint);
			}
		}
		// TODO: use jumpAction.trigerred
		if (this._jumpAction.IsPressed() && this.IsGrounded())
		{
			this._rigidbody.AddForce(this._rigidbody.transform.up * this._jumpPower, ForceMode.Impulse);
		}
	}
}
