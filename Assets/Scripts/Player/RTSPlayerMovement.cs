using UnityEngine;
using UnityEngine.InputSystem;

public class RTSPlayerMovement : MonoBehaviour
{
	private float _moveSpeed;

	private float _jumpPower;

    private Rigidbody _rigidbody;

	private InputAction _jumpAction;

	private Vector3? _destinationPoint;

	private float _stopDistance;

	public RTSPlayerMovement()
	{
		this._moveSpeed = 10.0f;
		this._jumpPower = 5.0f;
		this._destinationPoint = null;
		this._stopDistance = 5.0f;
	}

	private void Awake()
	{
		this._rigidbody = GetComponent<Rigidbody>();
		this._jumpAction = InputSystem.actions.FindAction("Jump");
	}

	private bool IsGrounded()
	{
		return this._rigidbody.linearVelocity.y == 0;
	}

	private void MoveOnPoint()
	{
		if (this._destinationPoint.HasValue)
		{
			Vector3 different = this._destinationPoint.Value - transform.position;
			
			if (different.magnitude > this._stopDistance)
			{
				this._rigidbody.AddForce(different.normalized * this._moveSpeed, ForceMode.Acceleration);
			}
			else
			{
				this._rigidbody.linearVelocity = Vector3.zero;
				this._destinationPoint = null;
			}
		}
	}

	private void FixedUpdate()
	{
		this.MoveOnPoint();

		if (Mouse.current.leftButton.wasPressedThisFrame)
		{
			Vector2 mouseClickPosition = Mouse.current.position.ReadValue();

			Ray cameraRay = Camera.main.ScreenPointToRay(mouseClickPosition);
			RaycastHit rayInfo;

			if (Physics.Raycast(cameraRay, out rayInfo))
			{
				this._destinationPoint = rayInfo.point;
			}
		}
		// TODO: use jumpAction.trigerred
		if (this._jumpAction.IsPressed() && this.IsGrounded())
		{
			this._rigidbody.AddForce(this._rigidbody.transform.up * this._jumpPower, ForceMode.Impulse);
		}
	}
}
