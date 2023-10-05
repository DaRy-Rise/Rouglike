using UnityEngine;

public class KataMasterOnLevel : MasterOnLevel
{
    private int hair;
    [SerializeField]
    private GameObject kata;

    protected override void Start()
    {
        base.Start();
        kata.SetActive(true);
        hair = GlobalStat.hair;
        masterController = FindObjectOfType<MasterBuffController>();
    }
    private void FixedUpdate()
    {
        coolDown -= Time.deltaTime * speed;
        if (coolDown < 0)
        {
            if (hair >= GetCountOfNeededWool() && !MasterBuffController.isActive)
            {
                GenerateBuff();
            }
            coolDown = standartCoolDown;
        }
    }
    public void GenerateBuff()
    {
        MasterBuffController.isActive = true;
        int i = Random.Range(0, 1);
        switch (i)
        {
            case 0:
                KataBehavior.currentDamage++;
                levelOfBuff++;
                masterController.ShowImprovePlate(KindOfMasters.Kata, KindOfBuff.Damage);
                break;
            case 1:
                KataBehavior.currentSpeed++;
                levelOfBuff++;
                masterController.ShowImprovePlate(KindOfMasters.Kata, KindOfBuff.Speed);
                break;
            default:
                break;
        }
    }

    private int GetCountOfNeededWool()
    {
        switch (levelOfBuff)
        {
            case 0: return 10;
            case 1: return 20;
            default:
                return -1;
        }
    }
}