using System.Collections.Generic;
using UnityEngine;

public class SellerRandomizer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> sellerSawnPoints;
    private GameObject marketPrefab;
    private int ChanceOfSellerSpawn = 10;

    void Start()
    {
        marketPrefab = Resources.Load<GameObject>("Prefab/Props/Level1/seller/Market");
        CheckSellerSpawnChance();
    }
    protected void CheckSellerSpawnChance()
    {
        int i = Random.Range(1, 101);
        
        if (i <= ChanceOfSellerSpawn)
        {
            SpawnPrefabs();
        }
    }

    private void SpawnPrefabs()
    {
        
        int rand = Random.Range(0, sellerSawnPoints.Count);
        GameObject market = Instantiate(marketPrefab, sellerSawnPoints[rand].transform.position, Quaternion.identity);
        market.transform.parent = sellerSawnPoints[rand].transform;
    }
}
