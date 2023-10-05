using UnityEngine;

public class WitchSpec : ThrowingEnemies
{
    GameObject[] potions;
    protected override void Start()
    {
        base.Start();
        potions = Resources.LoadAll<GameObject>("Prefab/Enemies/Stuff/Potions");
    }

    protected override void StartAttack()
    {
        weaponPrefab = ChoosePotion();
        base.StartAttack();
    }
    private GameObject ChoosePotion()
    {
        return potions[Random.Range(0, potions.Length)];
    }
}