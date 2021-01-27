using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float minSpawnRate = 1;
    public float maxSpawnRate = 2;

    private float currentSpawnRate = 0;

    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);

        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(currentSpawnRate);

            currentSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);

            Debug.Log("Spawned object");

            Instantiate(obstaclePrefab, transform.position, Quaternion.identity, transform);
        }
    }
}
