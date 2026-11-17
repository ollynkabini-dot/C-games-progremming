using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public Transform player;

    [Header("Spawn Settings")]
    public float spawnInterval = 2f;
    public float minSpawnInterval = 0.5f;
    public float intervalDecreasePerSpawn = 0.05f;

    [Header("Spawn Area")]
    public float spawnRangeX = 8f;
    public float spawnY = 8f;
    public float minDistanceFromPlayer = 3f;

    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = spawnInterval;
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentSpawnInterval);

            SpawnObject();

            currentSpawnInterval = Mathf.Max(
                minSpawnInterval,
                currentSpawnInterval - intervalDecreasePerSpawn
            );
        }
    }

    void SpawnObject()
    {
        if (objectPrefabs == null || objectPrefabs.Length == 0)
            return;

        int index = Random.Range(0, objectPrefabs.Length);

        float randomX = Random.Range(-spawnRangeX, spawnRangeX);

        if (player != null)
        {
            int attempts = 0;

            while (Mathf.Abs(randomX - player.position.x)
                   < minDistanceFromPlayer && attempts < 30)
            {
                randomX = Random.Range(-spawnRangeX, spawnRangeX);
                attempts++;
            }
        }

        Vector3 spawnPosition =
            new Vector3(randomX, spawnY, 0f);

        Instantiate(
            objectPrefabs[index],
            spawnPosition,
            Quaternion.identity
        );
    }
}