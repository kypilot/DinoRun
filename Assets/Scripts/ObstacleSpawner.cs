using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float minSpawnRate = 1;
    public float maxSpawnRate = 2;

    public float spawnSpeedModifier = 3;

    public GameObject obstaclePrefab;
    public Player player;

    private float currentSpawnRate = 0;
    private float startModifier = 0;

    // Start is called before the first frame update
    void Start()
    {
        startModifier = spawnSpeedModifier;
        currentSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);

        StartCoroutine(SpawnLoop());
    }

    private void Update()
    {
        spawnSpeedModifier = startModifier - (player.GetScore() / 1000f);
        spawnSpeedModifier = Mathf.Clamp(spawnSpeedModifier, minSpawnRate, startModifier);
    }

    private IEnumerator SpawnLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(currentSpawnRate * spawnSpeedModifier);

            currentSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);

            Debug.Log("Spawned object");

            Instantiate(obstaclePrefab, transform.position, Quaternion.identity, transform);
        }
    }
}
