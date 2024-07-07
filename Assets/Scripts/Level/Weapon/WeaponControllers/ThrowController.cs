using UnityEngine;

public class ThrowController : WeaponController
{
    private Projectile spawnedProjectile;
    private ObjectPoolManager objectPoolManager;
    protected override void Start()
    {
        base.Start();
        objectPoolManager = FindAnyObjectByType<ObjectPoolManager>();
    }

    protected override void StartAttack()
    {
        if (!PlayerStats.isKilled && isAttackAlowed)
        {
            base.StartAttack();
            Invoke("SpawnArrow", 0.25f);
        }
    }
    protected override void Update()
    {
        base.Update();
    }
    private void SpawnArrow()
    {
        spawnedProjectile = objectPoolManager.GetObject(weaponData.Prefab, transform.position);
        spawnedProjectile.GetComponent<ThrowBehavior>().DirectionChecker(playerMovement.lastMovedVector);
    }
}