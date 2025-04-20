using UnityEngine;

public class VisorAI : MonoBehaviour
{
	private float _currentRelationship;

	private float _maxRelationship;

	private float _decrease;

	private float _viewDistance;

	private float _fieldOfView;

	private int _rayCounts;

	private float _rayDistance;

	private delegate bool ViewHandler();

	private event ViewHandler ViewEventHandle;

	private void Awake()
	{
		this._decrease = 1.0f;
		this._maxRelationship = 100.0f;

		this._currentRelationship = Random.Range(50.0f, this._maxRelationship);
		this._viewDistance = 20.0f;
		this._fieldOfView = 60.0f;
		this._rayCounts = 30;

		this._rayDistance = (this._fieldOfView / 2) / this._rayCounts; // 2 - is left or right
	}

	private void RenderSeeField()
	{
		Ray ray = new Ray(transform.position, transform.forward);

		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, this._viewDistance))
		{
			if (hit.collider.CompareTag("Player"))
			{
				Debug.Log("Player is see more one plus method han");
				ViewEventHandle?.Invoke();
			}
		}

		for (int i = 0; i < this._rayCounts; i++)
		{
			Vector3 leftIndent = transform.forward;
			leftIndent.x += this._viewDistance / 2 - i * this._rayCounts;

			Ray ray2 = new Ray(transform.position, leftIndent);
			
			RaycastHit hit2;
			if (Physics.Raycast(ray2, out hit2, this._viewDistance))
			{
				if (hit.collider.CompareTag("Player"))
				{
					Debug.Log("Player is see more one plus method han");
					ViewEventHandle?.Invoke();
				}
			}
		}
	}

	private bool CheckAttackSee()
	{
		return false;
	}

	private void DecreaseRelation()
	{
		if (CheckAttackSee())
		{
			this._currentRelationship -= this._decrease;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 20f);

		float rayDistance = 60.0f / 2 / 30;

		for (int i = 0; i < 30; i++)
		{
			Vector3 f = transform.forward * 20f;
			f.x += 60.0f / 2 - i * rayDistance;
			Gizmos.DrawLine(transform.position, transform.position + f);
		}

		for (int i = 0; i < 30; i++)
		{
			Vector3 f = transform.forward * 20f;
			f.x -= 60.0f / 2 - i * rayDistance;
			Gizmos.DrawLine(transform.position, transform.position + f);
		}
	}

	private void FixedUpdate()
	{
		this.RenderSeeField();
		this.DecreaseRelation();
	}
}
