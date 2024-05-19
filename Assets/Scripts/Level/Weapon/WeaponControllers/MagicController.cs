using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : WeaponController
{
    public float chainRadius = 2f;
    public int maxChainCount = 5;
    public LayerMask enemyLayers;
    public GameObject chainLightningEffect;
    protected List<int> affectedId = new List<int>();
    private GameObject spawnedProjectile;
    Collider2D[] enemiesInRange;

    protected override void Start()
    {
        base.Start();
        InputReader.Instance.AttackEvent += StartAttack;
    }

    protected override void StartAttack()
    {
        if (!PlayerStats.isKilled && isAttackAlowed)
        {
            base.StartAttack();
            Invoke("SpawnLightBall", 0.25f);
        }
    }
    protected override void Update()
    {
        base.Update();
    }
    private void SpawnLightBall()
    {
        spawnedProjectile = Instantiate(weaponData.Prefab);
        spawnedProjectile.transform.position = transform.position;
        spawnedProjectile.GetComponent<MagicBehaviour>().DirectionChecker(playerMovement.lastMovedVector);
    }
    public void InitChainLightning(GameObject enemy)
    {
        Vector3 pos = enemy.transform.position;
        affectedId.Add(enemy.GetInstanceID());
        StartCoroutine(CreateChainLightning(enemy, enemy.transform.position));
    }
    private IEnumerator CreateChainLightning(GameObject startEnemy, Vector3 startPos)
    {
        affectedId.Add(startEnemy.gameObject.GetInstanceID());
        GameObject enemy1 = startEnemy;
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
                        GameObject lightning;
                        if (enemy1.gameObject != null)
                        {
                            lightning = Instantiate(chainLightningEffect, enemy1.transform.position, Quaternion.identity);
                            startPos = enemy1.transform.position;
                        } else
                        {
                            lightning = Instantiate(chainLightningEffect, startPos, Quaternion.identity);
                        }
                        lightning.GetComponent<ChainLightning>().TheStart(enemy1, enemy.gameObject, startPos, endPos);
                        lightning.transform.position = (startPos + endPos) / 2;
                        Vector3 direction = endPos - startPos;
                        lightning.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
                        lightning.GetComponent<SpriteRenderer>().size = new Vector2(0.08f, direction.magnitude);
                        EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
                        affectedId.Add(enemy.gameObject.GetInstanceID());
                        startPos = endPos;
                        enemy1 = enemy.gameObject;
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