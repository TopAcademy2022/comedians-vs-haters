using UnityEngine;

public class AttackScript : MonoBehaviour
{
	private float _damage;

	public AttackScript()
	{
		this._damage = 110.0f;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			HPSystem playerHealth = other.GetComponent<HPSystem>();

			if (playerHealth != null)
			{
				playerHealth.GetDamage(this._damage);
			}
		}
	}
}
