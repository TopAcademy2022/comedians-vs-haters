using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private float _moveSpeed;

    private Rigidbody _rigidbody;

	private Transform _destinationTransform;

	private float _stopDistance;

	private float rayLength = 30.0f;

	private Color rayColor = Color.red;

	private bool _isSee = false;

	private float maxTime = 15.0f;

	private float currentTime;

	private void Awake()
	{
		this._moveSpeed = 300.0f;
		this._stopDistance = 1.0f;
		currentTime = maxTime;

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

	private void DetectSee()
	{
		Ray ray = new Ray(transform.position, transform.forward);

		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, rayLength))
		{
			if (hit.collider.CompareTag("Player"))
			{
				_isSee = true;
			}
		}

		Debug.DrawRay(ray.origin, ray.direction * rayLength, rayColor);
	}

	private void FixedUpdate()
	{
		DetectSee();

		if (currentTime > 0.0f && _isSee)
		{
			this.MoveOnPoint();
			currentTime -= Time.deltaTime;
		}
		else
		{
			_isSee = false;
			currentTime = maxTime;
		}
	}
}
