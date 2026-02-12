using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject coinPrefab;

    public int initialPlatforms = 20;
    public float ySpacing = 1f;
    public float minX = -2f;
    public float maxX = 2f;

    private float highestY;

    void Start()
    {
        highestY = 0;

        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        if (Camera.main.transform.position.y + 10f > highestY)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, highestY);

        Instantiate(platformPrefab, spawnPos, Quaternion.identity);

        // 50% probabilidad de moneda
        if (Random.value > 0.5f)
        {
            Instantiate(coinPrefab, spawnPos + Vector2.up * 0.8f, Quaternion.identity);
        }

        highestY += ySpacing;
    }
}
