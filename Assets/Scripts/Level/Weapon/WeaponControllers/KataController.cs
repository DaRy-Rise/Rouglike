using UnityEngine;

public class KataController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void StartAttack()
    {
        base.StartAttack();
        GameObject spawnedKatana = Instantiate(weaponData.Prefab);
        spawnedKatana.transform.position = transform.position;
        spawnedKatana.GetComponent<KataBehavior>().DirectionChecker(playerMovement.lastMovedVector);
    }
}
