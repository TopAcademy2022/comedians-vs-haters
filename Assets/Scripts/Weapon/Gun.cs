using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
	private Vector3 _spawnBulletPoint;

	private GameObject _bulletPrefab;

	private List<GameObject> _bullets;

	private InputAction _attackAction;

	private float _bulletPower = 3000.0f;

	private void Awake()
	{
		this._bulletPrefab = Resources.Load<GameObject>("Bullet");
		this._bullets = new List<GameObject>();
		this._attackAction = InputSystem.actions.FindAction("Attack");
	}

	private void OnEnable()
	{
		this._attackAction.Enable();
		this._attackAction.performed += ievent => Shoot();
	}

	private void OnDisable()
	{
		this._attackAction.Disable();
	}

	private void Shoot()
	{
		// Get current gun position
		this._spawnBulletPoint = this.GetComponent<Transform>().position;

		// Spawn bullet in scene
		GameObject bullet = Instantiate(this._bulletPrefab, this._spawnBulletPoint, Quaternion.identity);
		this._bullets.Add(bullet);
		
		// Add force to bullet
		bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * this._bulletPower, ForceMode.Force);
	}
}
