using System;
using UnityEngine;

public class ThrowEnemyWeapon : MonoBehaviour
{
    [SerializeField]
    protected float currentSpeed, currentDamage;
    protected Transform player;
    protected Vector3 direction;

    protected virtual void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
        direction = (player.position - transform.position).normalized;
        Destroy(gameObject, 3);

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    protected void FixedUpdate()
    {
        transform.position += direction * currentSpeed * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("BASE COLLIDE");
        if (collision.CompareTag("Player"))
        {
            PlayerStats player = collision.GetComponent<PlayerStats>();
            Destroy(gameObject);
            player.TakeDamage(currentDamage);
        }
    }
}