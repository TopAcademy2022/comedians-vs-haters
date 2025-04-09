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

	public float GetMinHp()
	{
		return this._minHp;
	}

	public float GetCurrentHp()
	{
		return this._currentHp;
	}

	public void GetDamage(float damage)
	{
		this._currentHp -= damage;

		if (this._currentHp <= this._minHp)
		{
			Destroy(this.gameObject);
		}
	}
}
