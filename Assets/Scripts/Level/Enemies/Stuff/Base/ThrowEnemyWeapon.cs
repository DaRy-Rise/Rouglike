using System;
using UnityEngine;

public class ThrowEnemyWeapon : MonoBehaviour
{
    [SerializeField]
    protected float currentSpeed, currentDamage;
    protected Transform player;
    protected Vector3 direction;
    protected ObjectPoolManager objectPoolManager;

    protected virtual void Awake()
    {
        objectPoolManager = FindAnyObjectByType<ObjectPoolManager>();
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }
    protected virtual void OnEnable()
    {
        SetDirectOptions();
        Invoke("ReturnToPool", 3);
        PlayerStats.onKilled += ReturnToPool;
    }
    private void OnDisable()
    {
        PlayerStats.onKilled -= ReturnToPool;
    }
    public void SetDirectOptions()
    {
        direction = (player.position - transform.position).normalized;
        if (player.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }

        var direc = player.transform.position - transform.position;
        var rot = Quaternion.LookRotation(direc, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rot.z, rot.w);
    }
    protected void ReturnToPool()
    {
        if (gameObject.activeSelf)
        {
            objectPoolManager.ReturnObject(gameObject.GetComponent<ThrowEnemyWeapon>());
        }

    }
    private void OnBecameInvisible()
    {
        ReturnToPool();
    }
    protected void FixedUpdate()
    {
        transform.position += direction * currentSpeed * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&collision.isTrigger)
        {
            PlayerStats player = collision.GetComponent<PlayerStats>();
            ReturnToPool();
            print("ENEMY WEAPON DAMAGE");

            player.TakeDamage(currentDamage);
        }
    }
}