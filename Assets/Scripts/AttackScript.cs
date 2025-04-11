using UnityEngine;

public class AttackScript : MonoBehaviour
{
	private float _damage;

	public AttackScript()
	{
		this._damage = 10.0f;
	}

	private void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.CompareTag("Player"))
		{
			HPSystem playerHealth = collisionInfo.collider.GetComponent<HPSystem>();

			if (playerHealth != null)
			{
				playerHealth.GetDamage(this._damage);
			}
		}
	}
}
