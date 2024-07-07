using System.Collections.Generic;
using UnityEngine;

public class PropRandomizes : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> propSpawnPoints, propTreeSpawnPoints;
    private GameObject[] propPrefabs;
    private GameObject[] treePropPrefabs;

    void Start()
    {
        propPrefabs = Resources.LoadAll<GameObject>("Prefab/Props/Level1/RandomProps");
        treePropPrefabs = Resources.LoadAll<GameObject>("Prefab/Props/Level1/RandomProps/tree");
        SpawnProps();
        if (propTreeSpawnPoints.Count > 0 )
        {
            SpawnTreeProps();
        }
    }

    private void SpawnProps()
    {
        foreach (GameObject sp in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Length);
            GameObject prop = Instantiate(propPrefabs[rand], sp.transform.position, Quaternion.identity);
            prop.transform.parent = sp.transform;
        }
    }
    private void SpawnTreeProps()
    {
        foreach (GameObject sp in propTreeSpawnPoints)
        {
            int rand = Random.Range(0, treePropPrefabs.Length);
            GameObject prop = Instantiate(treePropPrefabs[rand], sp.transform.position, Quaternion.identity);
            prop.transform.parent = sp.transform;
        }
    }
}