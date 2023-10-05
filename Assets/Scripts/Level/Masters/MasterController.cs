using UnityEngine;

public class MasterController : MonoBehaviour
{
    [SerializeField]
    private Master swordMasterPrefab, kataMasterPrefab, helperPrefab;
    [HideInInspector]
    public static int level;

    private void OnEnable()
    {
        Cage.onDestroy += SpawnMaster;
    }
    private void OnDisable()
    {
        Cage.onDestroy -= SpawnMaster;
    }
    private void SpawnMaster()
    {
        Instantiate(ChooseMaster(), CageController.cageSpawnPosition, Quaternion.identity);
    }
    public static void IncreaseMasters(KindOfMasters res)
    {
        switch (res)
        {
            case KindOfMasters.Sword:
                GlobalStat.swordMasCard++;
                break;
            case KindOfMasters.Kata:
                GlobalStat.kataMasCard++;
                break;
            default:
                break;
        }
    }
    private Master ChooseMaster()
    {
        if (level == 1 && GlobalStat.swordMas <= 0)
        {
            return swordMasterPrefab;
        }
        else if (level == 2 && GlobalStat.kataMas <= 0)
        {
            return kataMasterPrefab;
        }
        else
        {
            return helperPrefab;
        }
    }
}