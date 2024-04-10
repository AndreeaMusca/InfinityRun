using UnityEngine;

public class BonusGenerator : MonoBehaviour
{
    [SerializeField] private GameObject Bonus;

    [SerializeField] private float _SpawnZOffset = 80f;

    [SerializeField] public float _SpawnNegativeXOffset = -15f;
    [SerializeField] public float _SpawnPositiveXOffset = 15f;

    [SerializeField] public float _SpawnRateInSeconds = 15f;

    [SerializeField] public float _SpawnY = 6f;

    void Start()
    {
        InvokeRepeating(nameof(GenerateBonus), 0f, _SpawnRateInSeconds);
    }

    private float GenerateRandomXOffset()
    {
        return Random.Range(_SpawnNegativeXOffset, _SpawnPositiveXOffset);
    }

    private void GenerateBonus()
    {
        float xOffset = GenerateRandomXOffset();
        Vector3 obstaclePosition = new Vector3(xOffset, _SpawnY, transform.position.z + _SpawnZOffset);
        Instantiate(Bonus, obstaclePosition, Quaternion.identity);
    }
}
