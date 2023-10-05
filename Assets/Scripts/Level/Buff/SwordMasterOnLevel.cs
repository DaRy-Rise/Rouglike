using UnityEngine;

public class SwordMasterOnLevel : MasterOnLevel
{
    private int wool;
    private SwordBehaviour swordController;
    protected override void Start()
    {
        base.Start();
        wool = GlobalStat.wool;
        swordController = FindAnyObjectByType<SwordBehaviour>();
    }

    private void FixedUpdate()
    {
        coolDown -= Time.deltaTime * speed;
        if (coolDown < 0)
        {
            if (wool >= GetCountOfNeededWool() && !MasterBuffController.isActive)
            {
                GenerateBuff();              
            }
            coolDown = standartCoolDown;
        }
    }
    public void GenerateBuff()
    {
        MasterBuffController.isActive = true;
        int i = Random.Range(0, 2);
        switch (i)
        {
            case 0:
                swordController.currentDamage++;
                levelOfBuff++;
                masterController.ShowImprovePlate(KindOfMasters.Sword, KindOfBuff.Damage);
                break;
            case 1:
                swordController.currentSpeed++;
                levelOfBuff++;
                masterController.ShowImprovePlate(KindOfMasters.Sword, KindOfBuff.Speed);
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