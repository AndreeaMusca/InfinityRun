using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
	[SerializeField] private GameObject[] _Obstacles;

	[SerializeField] private float _SpawnZOffset = 80f;

	[SerializeField] public float _SpawnNegativeXOffset = -15f;
	[SerializeField] public float _SpawnPositiveXOffset = 15f;

	[SerializeField] public float _SpawnRateInSeconds = 2f;

	[SerializeField] public float _SpawnY = 6f;

	void Start()
	{
		InvokeRepeating(nameof(GenerateObstacle), 0f, _SpawnRateInSeconds);
	}

	private float GenerateRandomXOffset()
	{
		return Random.Range(_SpawnNegativeXOffset, _SpawnPositiveXOffset);
	}

	private void GenerateObstacle()
	{
		float xOffset = GenerateRandomXOffset();
		int obstacleNumber = Random.Range(0, _Obstacles.Length - 1);
		Vector3 obstaclePosition = new Vector3(xOffset, _SpawnY, transform.position.z + _SpawnZOffset);

		Instantiate(_Obstacles[obstacleNumber], obstaclePosition, Quaternion.identity);
	}

}
