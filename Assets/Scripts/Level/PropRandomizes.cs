using System.Collections.Generic;
using UnityEngine;

public class PropRandomizes : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> propSpawnPoints;
    private GameObject[] propPrefabs;

    void Start()
    {
        propPrefabs = Resources.LoadAll<GameObject>("Prefab/Props/Level1/Props");
        SpawnProps();
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
}