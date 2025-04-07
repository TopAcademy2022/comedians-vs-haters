using UnityEngine;

public class HPSystem : MonoBehaviour
{
    private float _currentHp;

    private float _minHp;

	private void Awake()
	{
		this._currentHp = 100.0f;
		this._minHp = 0.0f;
	}

	public void GetDamage(float damage)
	{
		this._currentHp -= damage;

		if (this._currentHp < this._minHp)
		{
			Destroy(this.gameObject);
		}
	}
}
