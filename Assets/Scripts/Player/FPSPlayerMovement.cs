using UnityEngine;
using UnityEngine.InputSystem;

public class FPSPlayerMovement : MonoBehaviour
{
	private float moveSpeed = 10.0f;

	private float maxMoveSpeed = 100.0f;

	private float jumpPower = 5.0f;

    private Rigidbody rb;

	private InputAction moveAction;

	private InputAction jumpAction;

	private Animator _animator;

    private bool IsGrounded()
    {
        return this.rb.linearVelocity.y == 0;
    }

	private void Jump()
	{
        if (this.IsGrounded())
        {
            this.rb.AddForce(this.rb.transform.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void OnEnable()
	{
		this.jumpAction.Enable();
        this.moveAction.Enable();
    }

    private void OnDisable()
    {
        this.jumpAction.Disable();
        this.moveAction.Disable();
    }

    private void Awake()
	{
		this.rb = GetComponent<Rigidbody>();
		this._animator = GetComponent<Animator>();
		this.moveAction = InputSystem.actions.FindAction("Move");
		this.jumpAction = InputSystem.actions.FindAction("Jump");

		this.jumpAction.performed += ievent => Jump();

		this.moveAction.performed += ievent => this._animator.SetBool("IsMove", true);
		this.moveAction.canceled += ievent => this._animator.SetBool("IsMove", false);
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
				Vector2 input = moveAction.ReadValue<Vector2>();
                Vector3 direction = transform.forward * input.y + transform.right * input.x;
                
				rb.AddForce(direction.normalized * moveSpeed, ForceMode.Acceleration);
			}
		}
	}
}
