using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : WeaponController
{
    public float chainRadius = 2f;
    public int maxChainCount = 20;
    public LayerMask enemyLayers;
    public GameObject chainLightningEffect;
    public int currentDamage = 1;
    protected List<int> affectedId = new List<int>();

    Collider2D[] enemiesInRange;

    protected override void Start()
    {
        base.Start();
    }

    protected override void StartAttack()
    {
        base.StartAttack();
        GameObject spawnedProjectile = Instantiate(weaponData.Prefab);
        spawnedProjectile.transform.position = transform.position;
        spawnedProjectile.GetComponent<MagicBehaviour>().DirectionChecker(playerMovement.lastMovedVector);
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
    public void InitChainLightning(GameObject enemy)
    {
        Vector3 pos = enemy.transform.position;
        affectedId.Add(enemy.GetInstanceID());
        StartCoroutine(CreateChainLightning(enemy.transform.position));
    }
    private IEnumerator CreateChainLightning(Vector3 startPos)
    {
        for (int i = 0; i < maxChainCount; i++)
        {
            enemiesInRange = Physics2D.OverlapCircleAll(startPos, chainRadius, enemyLayers);


            FindClosestEnemies(startPos);
            foreach (Collider2D enemy in enemiesInRange)
            {
                if (enemy != null && enemy.CompareTag("Enemy"))
                {
                    if (!affectedId.Contains(enemy.gameObject.GetInstanceID()))
                    {
                        Vector3 endPos = enemy.transform.position;
                        GameObject lightning = Instantiate(chainLightningEffect, startPos, Quaternion.identity);
                        lightning.transform.position = (startPos + endPos)/2;
                        Vector3 direction = endPos - startPos;
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        lightning.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
                        lightning.transform.localScale = new Vector3(1f, direction.magnitude, 1f);
                        EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
                        affectedId.Add(enemy.gameObject.GetInstanceID());
                        startPos = endPos;
                        enemyStats.TakeDamage(currentDamage);
                        yield return new WaitForSeconds(0.2f);
                        break;
                    }
                }
            }
        }
        affectedId.Clear();
        yield break;
    }

    private Collider2D[] FindClosestEnemies(Vector3 position)
    {
        Array.Sort(enemiesInRange, (a, b) => Vector3.Distance(position, a.transform.position).CompareTo(Vector3.Distance(position, b.transform.position)));
        return enemiesInRange;
    }
}