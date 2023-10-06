using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave 
    {
        public string waveName;
        public List<EnemyGroup> enemyGroup;
        public int numberOfEnemiesToSpawn;
        public float spawnInterval;
        public int spawnedCount;
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string name;
        public int enemyCount, spawnedCount; //1 количество врагов для спавна в волне. 2 количество уже заспавленных врагов
        public GameObject enemyPrefab;
    }

    public List<Wave> waves;
    public int currentWaveCount;

    [Header("Spawner attributes")]
    float spawnerTime;
    public int enemiesAlive, maxEnemiesAlive;
    public bool maxEnemiesReached = false;
    public float waveInterval;

    [Header("Spawner Positions")]
    public List<Transform> relativeSpawnPoints;

    Transform player;
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
        CalculateWaveQouta();
    }

    void Update()
    {
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnedCount == 0)
        {
            StartCoroutine(BeginNextWave());
        }
        spawnerTime += Time.deltaTime;
        if (spawnerTime >= waves[currentWaveCount].spawnInterval)
        {
            spawnerTime = 0f;
            SpawnEnemies();
        }
    }

    private void CalculateWaveQouta()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroup)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].numberOfEnemiesToSpawn = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }

    private void SpawnEnemies()
    {
        if (waves[currentWaveCount].spawnedCount < waves[currentWaveCount].numberOfEnemiesToSpawn && !maxEnemiesReached)
        {
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroup)
            {
                if (enemyGroup.spawnedCount < enemyGroup.enemyCount)
                {
                    if (enemiesAlive >= maxEnemiesAlive)
                    {
                        maxEnemiesReached = true;
                        return;
                    }
                    Instantiate(enemyGroup.enemyPrefab, player.transform.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);

                    enemyGroup.spawnedCount++;
                    waves[currentWaveCount].spawnedCount++;
                    enemiesAlive++;
                }
            }
        }
        if (enemiesAlive < maxEnemiesAlive)
        {
            maxEnemiesReached = false;
        }
    }

    IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);
        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQouta();
        }
    }
    public void OnEnemyKilled()
    {
        --enemiesAlive;
    }
}