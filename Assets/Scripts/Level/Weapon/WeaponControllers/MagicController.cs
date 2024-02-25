using UnityEngine;

public class MagicController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void StartAttack()
    {
        base.StartAttack();
        Instantiate(weaponData.Prefab);
    }
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!PlayerStats.isKilled && isAttackAlowed)
            {
                StartAttack();
            }
        }
    }
}