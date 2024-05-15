using System.Collections.Generic;
using UnityEngine;

public class ChestRandomizer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> chestSpawnPoints;
    private GameObject chestPrefab;
    private int ChanceOfChestSpawn = 100;

    void Start()
    {
        chestPrefab = Resources.Load<GameObject>("Prefab/Props/Level1/chest/chest_open1");
        CheckChestSpawnChance();
    }
    protected void CheckChestSpawnChance()
    {
        int i = Random.Range(1, 101);
        
        if (i <= ChanceOfChestSpawn)
        {
            SpawnPrefabs();
        }
    }

    private void SpawnPrefabs()
    {
        
        int rand = Random.Range(0, chestSpawnPoints.Count);
        GameObject market = Instantiate(chestPrefab, chestSpawnPoints[rand].transform.position, Quaternion.identity);
        market.transform.parent = chestSpawnPoints[rand].transform;
    }
}
