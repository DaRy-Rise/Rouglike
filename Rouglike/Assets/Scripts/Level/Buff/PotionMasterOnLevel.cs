using System;
using UnityEngine;

public class PotionMasterOnLevel : MasterOnLevel
{
    [SerializeField]
    private GoodPotion goodPotion;
    [SerializeField]
    private GameObject potion;
    private int emptyGlass;
    private KeyCode keycode;
    private bool check;
    public static Action onQTE;
    public static KindOfGoodPotion kindOfPotion;

    protected override void Start()
    {
        base.Start();
        emptyGlass = GlobalStat.emptyGlass;
    }

    void FixedUpdate()
    {
        coolDown -= Time.deltaTime * speed;
        if (coolDown < 0)
        {
            if (emptyGlass >= GetCountOfNeededGlass() && !MasterBuffController.isActive)
            {
                GenerateBuff();
            }
            coolDown = standartCoolDown;
        }
        if (check)
        {
            CheckQTE();
        }
    }

    public void GenerateBuff()
    {
        MasterBuffController.isActive = true;
        int i = UnityEngine.Random.Range(0, 4);
        i = 2;
        switch (i)
        {
            case 0:
                keycode = KeyCode.H;
                kindOfPotion = KindOfGoodPotion.Health;
                break;
            case 1:
                keycode = KeyCode.F;
                kindOfPotion = KindOfGoodPotion.Speed;
                break;
            case 2:
                keycode = KeyCode.T;
                kindOfPotion = KindOfGoodPotion.Antidote;
                break;
            case 3:
                keycode = KeyCode.G;
                kindOfPotion = KindOfGoodPotion.Damage;
                break;
            default:
                break;
        }

        SpawnPotionPanel();
        check = true;
    }
    private void SpawnPotionPanel()
    {
        masterController.ShowPotionQTEPlate();
    }
    private void SpawnPotion()
    {
        potion.SetActive(true);
    }
    private void CheckQTE()
    {
        if (Input.GetKey(keycode))
        {
            check = false;
            SpawnPotion();
            onQTE?.Invoke();
        }
    }

    private int GetCountOfNeededGlass()
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