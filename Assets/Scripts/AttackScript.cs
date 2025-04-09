using UnityEngine;

public class AttackScript : MonoBehaviour
{
	private float _damage;

	public AttackScript()
	{
		this._damage = 10.0f;
	}

	private void OnCollisionStay(Collision collisionInfo)
	{
		Debug.Log("YES!");
		//if (other.CompareTag("Player"))
		//{
		//	HPSystem playerHealth = other.GetComponent<HPSystem>();

		//	if (playerHealth != null)
		//	{
		//		playerHealth.GetDamage(this._damage);
		//	}
		//}
	}
}
