using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWeapon : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;
    public float chainRadius = 2f;
    public int maxChainCount = 5;
    public LayerMask enemyLayers;
    public GameObject chainLightningEffect;
    public static float currentDamage, currentSpeed, currentCooldownDuration;
    protected int currentPierce;

    private void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CoolDownDur;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void Start()
    {
       // Destroy(gameObject, destroyAfterSeconds);
        print("FUCKKK ");
    }

    private void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
           // Destroy(gameObject);
            print("FUCKK ");
        }
    }
    public bool test = false;
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !test)
        {
            
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
           // enemy.TakeDamage(currentDamage);
            ReducePierce();
            test = true;
            StartCoroutine(CreateChainLightning(collision.transform.position, maxChainCount));
            print("FUCK2 " + collision.name + collision.GetInstanceID());
        }
 
    }
    private IEnumerator CreateChainLightning(Vector3 startPos, int remainingChainCount)
    {

        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(startPos, chainRadius, enemyLayers);
        foreach (Collider2D enemy in enemiesInRange)
        {
            if (enemy.CompareTag("Enemy"))
            {
                print("FUCK " + enemiesInRange.Length);
                Vector3 endPos = enemy.transform.position;
                GameObject lightning = Instantiate(chainLightningEffect, startPos, Quaternion.identity);
                lightning.transform.position = startPos;
                Vector3 direction = endPos - startPos;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                lightning.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                lightning.transform.localScale = new Vector3(direction.magnitude, 1f, 1f);
                remainingChainCount--;
                EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
                //enemyStats.TakeDamage(currentDamage);
                if (remainingChainCount <= 0)
                {
                    
                    yield break;
                }
                //Invoke("DelayedChainLightning", 1f);
                yield return new WaitForSeconds(0.4f);
                print("FUCK3");
            }
        }
        //yield break;
    }

    private void DelayedChainLightning()
    {
        print("Delayed");
       // Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, chainRadius, enemyLayers);
       // foreach (Collider2D enemy in enemiesInRange)
       // {
       //     if (enemy.CompareTag("Enemy"))
       //     {
       //         CreateChainLightning(enemy.transform.position, maxChainCount - 1);
       //         break;
       //     }
       // }
    }
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirX < 0 && dirY == 0) //left
        {
            scale.x *= -1;
            scale.y *= -1;
        }
        else if (dirX == 0 && dirY < 0) //down
        {
            rotation.z = -90f;
        }
        else if (dirX == 0 && dirY > 0) //up
        {
            rotation.z = 90f;
        }
        else if (dirX > 0 && dirY > 0) //RUp
        {
            rotation.z = 45f;
        }
        else if (dirX > 0 && dirY < 0) //RDown
        {
            rotation.z = -45f;
        }
        else if (dirX < 0 && dirY > 0) //LUp
        {
            scale.x *= -1;
            scale.y *= -1;
            rotation.z = -45f;
        }
        else if (dirX < 0 && dirY < 0) //LDown
        {
            scale.x *= -1;
            scale.y *= -1;
            rotation.z = 45f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }
}