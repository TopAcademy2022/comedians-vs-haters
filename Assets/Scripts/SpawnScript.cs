using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
	public GameObject SpawnObjectFrefab;

	public int CountInstance;

	public float DistanceBetweenObjects;

	private Vector3 _spawnFieldSize;

	private void Awake()
	{
		this._spawnFieldSize = this.GetComponent<MeshFilter>().sharedMesh.bounds.size;
	}

	private List<Vector3> GetRandomPositions()
	{
		List<Vector3> result = new List<Vector3>();

		for (int i = 0; i < this.CountInstance; i++)
		{
			float leftXPos = this._spawnFieldSize.x / 2;
			float xStartPosition = Random.Range(this.transform.position.x - leftXPos, 
				this.transform.position.x + leftXPos);

			float leftZPos = this._spawnFieldSize.z / 2;
			float zStartPosition = Random.Range(this.transform.position.z - leftZPos,
				this.transform.position.z + leftZPos);

			Vector3 targetPos = new Vector3(xStartPosition, 1, zStartPosition);

			foreach (Vector3 position in result)
			{
				do
				{
					targetPos.x = Random.Range(this.transform.position.x - leftXPos,
				this.transform.position.x + leftXPos);
					targetPos.z = Random.Range(this.transform.position.z - leftZPos,
				this.transform.position.z + leftZPos);
				} while (Vector3.Distance(position, targetPos) < this.DistanceBetweenObjects);
			}

			result.Add(targetPos);
		}

		return result;
	}

	private void Start()
    {
		List<Vector3> randomPositions = this.GetRandomPositions();

		foreach (Vector3 randomPosition in randomPositions)
		{
			Instantiate(this.SpawnObjectFrefab, randomPosition, Quaternion.identity);
		}
	}
}
