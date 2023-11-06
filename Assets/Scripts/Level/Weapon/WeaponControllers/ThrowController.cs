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
}