using System.Collections.Generic;
using UnityEngine;

public class TreeOfAbilityManager : MonoBehaviour
{
    [SerializeField]
    private GameObject treeOfAbility, dialogBox;
    public static bool isTreeOpen;
    private List<GameObject> abilitiesPrefabs = new List<GameObject>();
    [SerializeField]
    private GameObject swordStaticPulsePrefab, swordPulsePrefab, swordDestroyedPrefab;
    [SerializeField]
    private GameObject magicStaticPulsePrefab, magicPulsePrefab, magicDestroyedPrefab;
    [SerializeField]
    private GameObject archerStaticPulsePrefab, archerPulsePrefab, archerDestroyedPrefab;

    private Point[,] points = 
    { 
        {
            new Point(-4.08f, 2.729f),
            new Point(-1.62f, 2.729f),
            new Point(0.84f, 2.729f),
            new Point(3.3f, 2.729f),
            new Point(5.76f, 2.729f)
        },
        {
            new Point(-4.08f, 0.026f),
            new Point(-1.62f, 0.026f),
            new Point(0.84f, 0.026f),
            new Point(3.3f, 0.026f),
            new Point(5.76f, 0.026f)
        },
        {
            new Point(-4.08f, -2.67f),
            new Point(-1.62f, -2.67f),
            new Point(0.84f, -2.67f),
            new Point(3.3f, -2.67f),
            new Point(5.76f, -2.67f)
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

        switch (kindOfMasters)
        {
            case KindOfMasters.Sword:
                DrawAbility(0, GlobalStat.swordKick, swordStaticPulsePrefab, swordPulsePrefab, swordDestroyedPrefab);
                DrawAbility(1, GlobalStat.swordDash, swordStaticPulsePrefab, swordPulsePrefab, swordDestroyedPrefab);
                DrawAbility(2, GlobalStat.swordArea, swordStaticPulsePrefab, swordPulsePrefab, swordDestroyedPrefab);
                break;
            case KindOfMasters.Magic:
                DrawAbility(0, GlobalStat.magicChain, magicStaticPulsePrefab, magicPulsePrefab, magicDestroyedPrefab);
                DrawAbility(1, GlobalStat.magicShield, magicStaticPulsePrefab, magicPulsePrefab, magicDestroyedPrefab);
                DrawAbility(2, GlobalStat.magicArea, magicStaticPulsePrefab, magicPulsePrefab, magicDestroyedPrefab);
                break;
            case KindOfMasters.Throwing:
                DrawAbility(0, GlobalStat.archerPoison, archerStaticPulsePrefab, archerPulsePrefab, archerDestroyedPrefab);
                DrawAbility(1, GlobalStat.archerShurikens, archerStaticPulsePrefab, archerPulsePrefab, archerDestroyedPrefab);
                DrawAbility(2, GlobalStat.archerRain, archerStaticPulsePrefab, archerPulsePrefab, archerDestroyedPrefab);
                break;
            default:
                break;
        }
    }
    public void CloseTree()
    {
        DialogSystem.isBoxOpen = true;
        isTreeOpen = false;
        DestroyAbility();
        treeOfAbility.SetActive(false);
    }
    private void DrawAbility(int n, int abilityValue, GameObject staticPulse, GameObject pulse, GameObject destroyed)
    { 
        if (abilityValue == 0)
        {
            abilitiesPrefabs.Add(Instantiate(pulse, treeOfAbility.transform.position + new Vector3(points[n, 0].X, points[n, 0].Y), Quaternion.identity, treeOfAbility.transform));
            abilitiesPrefabs.Add(Instantiate(destroyed, treeOfAbility.transform.position + new Vector3(points[n, 1].X, points[n, 1].Y) + treeOfAbility.transform.forward, Quaternion.identity, treeOfAbility.transform));
        }
        else
        {
            for (int i = 0; i < abilityValue; i++)
            {
                abilitiesPrefabs.Add(Instantiate(staticPulse, treeOfAbility.transform.position + new Vector3(points[n, i].X, points[n, abilityValue - 1].Y) + transform.forward, Quaternion.identity, treeOfAbility.transform));
            }
            if (abilityValue != 5)
            {
                abilitiesPrefabs.Add(Instantiate(pulse, treeOfAbility.transform.position + new Vector3(points[n, abilityValue].X, points[n, abilityValue].Y) + treeOfAbility.transform.forward, Quaternion.identity, treeOfAbility.transform));
            }
            if (abilityValue < 4)
            {
                abilitiesPrefabs.Add(Instantiate(destroyed, treeOfAbility.transform.position + new Vector3(points[0, abilityValue + 1].X, points[n, abilityValue + 1].Y) + treeOfAbility.transform.forward, Quaternion.identity, treeOfAbility.transform));
            }
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