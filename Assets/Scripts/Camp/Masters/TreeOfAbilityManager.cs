using System.Collections.Generic;
using UnityEngine;

public class TreeOfAbilityManager : MonoBehaviour
{
    [SerializeField]
    private GameObject treeOfAbility, dialogBox;
    public static bool isTreeOpen;
    private List<GameObject> abilitiesPrefabs = new List<GameObject>();
    [SerializeField]
    private GameObject staticPulsePrefab, pulsePrefab, destroyedPrefab;

    private Point[,] points = 
    { 
        {
            new Point(-4.384f, 2.978f),
            new Point(-1.712f, 2.978f),
            new Point(0.9629997f, 2.978f),
            new Point(3.635f, 2.978f),
            new Point(6.307f, 2.978f)
        },
        {
            new Point(-4.384f, 0.026f),
            new Point(-1.712f, 0.026f),
            new Point(0.9629997f, 0.026f),
            new Point(3.635f, 0.026f),
            new Point(6.307f, 0.026f)
        },
        {
            new Point(-4.384f, -2.85f),
            new Point(-1.712f, -2.85f),
            new Point(0.9629997f, -2.85f),
            new Point(3.635f, -2.85f),
            new Point(6.307f, -2.85f)
        }
    };

    void Start()
    {
        treeOfAbility.SetActive(false);
    }
    public void OpenTreeOfAbility(KindOfMasters kindOfMasters)
    {
        isTreeOpen = true;
        DialogSystem.isBoxOpen = false;
        treeOfAbility.SetActive(true);
        DrawAbility();
    }
    public void CloseTree()
    {
        DialogSystem.isBoxOpen = true;
        isTreeOpen = false;
        DestroyAbility();
        treeOfAbility.SetActive(false);
    }
    private void DrawAbility()
    { 
        if (GlobalStat.swordDash == 0)
        {
            abilitiesPrefabs.Add(Instantiate(pulsePrefab, treeOfAbility.transform.position + new Vector3(points[0, 0].X, points[0, GlobalStat.swordDash].Y), Quaternion.identity, treeOfAbility.transform));
            abilitiesPrefabs.Add(Instantiate(destroyedPrefab, treeOfAbility.transform.position + new Vector3(points[0, 1].X, points[0, GlobalStat.swordDash + 1].Y) + treeOfAbility.transform.forward, Quaternion.identity, treeOfAbility.transform));
        }
        else
        {
            for (int i = 0; i < GlobalStat.swordDash; i++)
            {
                abilitiesPrefabs.Add(Instantiate(staticPulsePrefab, treeOfAbility.transform.position + new Vector3(points[0, i].X, points[0, GlobalStat.swordDash - 1].Y) + transform.forward, Quaternion.identity, treeOfAbility.transform));
            }
        }
        if (GlobalStat.swordDash != 5)
        {
            abilitiesPrefabs.Add(Instantiate(pulsePrefab, treeOfAbility.transform.position + new Vector3(points[0, GlobalStat.swordDash].X, points[0, GlobalStat.swordDash].Y) + treeOfAbility.transform.forward, Quaternion.identity, treeOfAbility.transform));
        }
        if (GlobalStat.swordDash < 4)
        {
            abilitiesPrefabs.Add(Instantiate(destroyedPrefab, treeOfAbility.transform.position + new Vector3(points[0, GlobalStat.swordDash].X, points[0, GlobalStat.swordDash].Y) + treeOfAbility.transform.forward, Quaternion.identity, treeOfAbility.transform));
        }
    }
    private void DestroyAbility()
    {
        foreach (var item in abilitiesPrefabs)
        {
            Destroy(item);
        }
    }
}