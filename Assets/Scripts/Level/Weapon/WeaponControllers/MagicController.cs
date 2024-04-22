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
    public void initChainLightning(GameObject enemy)
    {
        Vector3 pos = enemy.transform.position;
        affectedId.Add(enemy.GetInstanceID());
        //if (enemy == null)
       // {
          //  StartCoroutine(CreateChainLightning(pos));
        //}
       // else
        //{
            StartCoroutine(CreateChainLightning(enemy.transform.position));
       // }
    }
    private IEnumerator CreateChainLightning(Vector3 startPos)
    {
        print("FUCK " + maxChainCount);
        for (int i = 0; i < maxChainCount; i++)
        {
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(startPos, chainRadius, enemyLayers);
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
                        //Invoke("DelayedChainLightning", 1f);
                        yield return new WaitForSeconds(0.2f);
                        break;
                    }
                }
            }
        }
        affectedId.Clear();
        yield break;
    }
}