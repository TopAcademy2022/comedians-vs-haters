using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private float _moveSpeed;

    private Rigidbody _rigidbody;

	private Transform _destinationTransform;

	private float _stopDistance;

	public EnemyMovement()
	{
		this._moveSpeed = 7.0f;
		this._stopDistance = 2.0f;
	}

	private void Awake()
	{
		this._rigidbody = GetComponent<Rigidbody>();
		this._destinationTransform = GameObject.FindWithTag("Player").transform;
	}

	private void MoveOnPoint()
	{
		Vector3 different = this._destinationTransform.position - transform.position;

		if (different.magnitude > this._stopDistance)
		{
			this._rigidbody.AddForce(different.normalized * this._moveSpeed, ForceMode.Acceleration);
		}
		else
		{
			this._rigidbody.linearVelocity = Vector3.zero;
		}
	}

	private void FixedUpdate()
	{
		this.MoveOnPoint();
	}
}
