using UnityEngine;

public class ThrowController : WeaponController
{
    private GameObject spawnedProjectile;
    protected override void Start()
    {
        base.Start();
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
        spawnedProjectile = Instantiate(weaponData.Prefab);
        spawnedProjectile.transform.position = transform.position;
        spawnedProjectile.GetComponent<ThrowBehavior>().DirectionChecker(playerMovement.lastMovedVector);
    }
}