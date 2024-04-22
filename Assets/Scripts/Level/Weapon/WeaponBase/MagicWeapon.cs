using System;
using System.Collections.Generic;
using UnityEngine;

public class MagicWeapon : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;
    public MagicController controller;
    public static float currentDamage, currentSpeed, currentCooldownDuration;
    protected int currentPierce;

    private void Awake()
    {
        controller = FindAnyObjectByType<MagicController>();
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CoolDownDur;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    private void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            print("TRIGGERED");
            controller.initChainLightning(collision.gameObject);
            enemy.TakeDamage(currentDamage);
            ReducePierce();
        }
 
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