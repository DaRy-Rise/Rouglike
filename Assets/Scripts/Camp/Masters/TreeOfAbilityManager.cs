using UnityEngine;

public class TreeOfAbilityManager : MonoBehaviour
{
    [SerializeField]
    private GameObject treeOfAbility, dialogBox;
    public static bool isTreeOpen;
    public GameObject[,] abilitiesPref = new GameObject[3,5]; 
    [SerializeField]
    private GameObject swordStaticPulsePrefab, swordPulsePrefab, swordDestroyedPrefab;
    [SerializeField]
    private GameObject magicStaticPulsePrefab, magicPulsePrefab, magicDestroyedPrefab;
    [SerializeField]
    private GameObject archerStaticPulsePrefab, archerPulsePrefab, archerDestroyedPrefab;
    public KindOfMasters kindOfMaster;

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
        kindOfMaster = kindOfMasters;
        isTreeOpen = true;
        DialogSystem.isBoxOpen = false;
        treeOfAbility.SetActive(true);
        switch (kindOfMaster)
        {
            case KindOfMasters.Sword:
                DrawAbility(0, GlobalStat.swordKick, swordStaticPulsePrefab, swordPulsePrefab, swordDestroyedPrefab);
                DrawAbility(1, GlobalStat.swordDash, swordStaticPulsePrefab, swordPulsePrefab, swordDestroyedPrefab);
                DrawAbility(2, GlobalStat.swordArea, swordStaticPulsePrefab, swordPulsePrefab, swordDestroyedPrefab);
                FindAnyObjectByType<AbilityInfoManager>().ParseSwordInfo();
                break;
            case KindOfMasters.Magic:
                DrawAbility(0, GlobalStat.magicChain, magicStaticPulsePrefab, magicPulsePrefab, magicDestroyedPrefab);
                DrawAbility(1, GlobalStat.magicShield, magicStaticPulsePrefab, magicPulsePrefab, magicDestroyedPrefab);
                DrawAbility(2, GlobalStat.magicArea, magicStaticPulsePrefab, magicPulsePrefab, magicDestroyedPrefab);
                FindAnyObjectByType<AbilityInfoManager>().ParseMagicInfo();
                break;
            case KindOfMasters.Throwing:
                DrawAbility(0, GlobalStat.archerPoison, archerStaticPulsePrefab, archerPulsePrefab, archerDestroyedPrefab);
                DrawAbility(1, GlobalStat.archerShurikens, archerStaticPulsePrefab, archerPulsePrefab, archerDestroyedPrefab);
                DrawAbility(2, GlobalStat.archerRain, archerStaticPulsePrefab, archerPulsePrefab, archerDestroyedPrefab);
                FindAnyObjectByType<AbilityInfoManager>().ParseArcherInfo();
                break;
            default:
                break;
        }

        GetComponentInChildren<AbilityBtnManager>().SetButtonState();
        
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
            abilitiesPref[n, 0] = Instantiate(pulse, treeOfAbility.transform.position + new Vector3(points[n, 0].X, points[n, 0].Y), Quaternion.identity, treeOfAbility.transform);
            abilitiesPref[n, 1] = Instantiate(destroyed, treeOfAbility.transform.position + new Vector3(points[n, 1].X, points[n, 1].Y) + treeOfAbility.transform.forward, Quaternion.identity, treeOfAbility.transform);
        }
        else
        {
            for (int i = 0; i < abilityValue; i++)
            {
                abilitiesPref[n, i] = (Instantiate(staticPulse, treeOfAbility.transform.position + new Vector3(points[n, i].X, points[n, abilityValue - 1].Y) + transform.forward, Quaternion.identity, treeOfAbility.transform));
            }
            if (abilityValue != 5)
            {
                abilitiesPref[n, abilityValue] = (Instantiate(pulse, treeOfAbility.transform.position + new Vector3(points[n, abilityValue].X, points[n, abilityValue].Y) + treeOfAbility.transform.forward, Quaternion.identity, treeOfAbility.transform));
            }
            if (abilityValue < 4)
            {
                abilitiesPref[n, abilityValue + 1] = (Instantiate(destroyed, treeOfAbility.transform.position + new Vector3(points[0, abilityValue + 1].X, points[n, abilityValue + 1].Y) + treeOfAbility.transform.forward, Quaternion.identity, treeOfAbility.transform));
            }
        }
    }
    private void DestroyAbility()
    {
        foreach (var item in abilitiesPref)
        {
            Destroy(item);
        }
    }
}