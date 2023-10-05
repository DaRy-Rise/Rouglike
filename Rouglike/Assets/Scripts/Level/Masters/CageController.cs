using System.Collections.Generic;
using UnityEngine;

public class CageController : MonoBehaviour
{
    [SerializeField]
    private Cage cagePrefab;

    [Header("Spawner Positions")]
    public List<Transform> relativeSpawnPoints;

    public static Vector3 cageSpawnPosition;
    Transform player;
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }
    private void OnEnable()
    {
        PlayerStats.onNextLevel += SpawnCage;
    }
    private void OnDisable()
    {
        PlayerStats.onNextLevel -= SpawnCage;
    }
    private void SpawnCage()
    {
        MasterController.level = PlayerStats.level;
        cageSpawnPosition = player.transform.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position;
        Instantiate(cagePrefab, cageSpawnPosition, Quaternion.identity);
    }
}