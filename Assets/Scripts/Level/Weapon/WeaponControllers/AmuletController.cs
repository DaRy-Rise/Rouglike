using UnityEngine;

public class AmuletController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void StartAttack()
    {
        base.StartAttack();
        GameObject spawnedAmulet = Instantiate(weaponData.Prefab);
        spawnedAmulet.transform.position = transform.position;
        spawnedAmulet.transform.parent = transform;
    }
}