using UnityEngine;

public class ThrowController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void StartAttack()
    {
        base.StartAttack();
        GameObject spawnedProjectile = Instantiate(weaponData.Prefab);
        spawnedProjectile.transform.position = transform.position;
        spawnedProjectile.GetComponent<ThrowBehavior>().DirectionChecker(playerMovement.lastMovedVector);
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