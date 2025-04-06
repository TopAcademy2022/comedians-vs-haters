using UnityEngine;
using UnityEngine.InputSystem;

public class FPSPlayerMovement : MonoBehaviour
{
	private float moveSpeed = 10.0f;

	public float maxMoveSpeed = 100.0f;

	private float jumpPower = 5.0f;

    private Rigidbody rb;

	private InputAction moveAction;

	private InputAction jumpAction;

	private void Awake()
	{
		this.rb = GetComponent<Rigidbody>();
		this.moveAction = InputSystem.actions.FindAction("Move");
		this.jumpAction = InputSystem.actions.FindAction("Jump");
	}

	bool IsGrounded()
	{
		return this.rb.linearVelocity.y == 0;
	}

	private void FixedUpdate()
	{
		// TODO: Add friction, set min speed
		// TODO: Check max speed
		Vector3 maxVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxMoveSpeed);
		float distanceVelocity = Vector3.Distance(rb.linearVelocity, maxVelocity);

		// Debug.Log($"Vector3 = {maxVelocity}, d = {distanceVelocity}");

		if (distanceVelocity == 0 || distanceVelocity > maxMoveSpeed)
		{
			if (moveAction.IsPressed())
			{
				rb.AddForce(this.rb.transform.forward * moveSpeed, ForceMode.Acceleration);
			}
		}
		// TODO: use jumpAction.trigerred
		if (this.jumpAction.IsPressed() && this.IsGrounded())
		{
			this.rb.AddForce(this.rb.transform.up * jumpPower, ForceMode.Impulse);
		}
	}
}
