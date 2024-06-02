using System;
using UnityEngine;

public class ThrowEnemyWeapon : MonoBehaviour
{
    [SerializeField]
    protected float currentSpeed, currentDamage;
    protected Transform player;
    protected Vector3 direction;
    public ObjectPoolManager objectPoolManager;

    protected virtual void Start()
    {
        objectPoolManager = FindAnyObjectByType<ObjectPoolManager>();
        player = FindAnyObjectByType<PlayerMovement>().transform;
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
        //Destroy(gameObject, 3);
        Invoke("Release", 3);

    }
    protected void Release()
    {
        objectPoolManager.ReturnObject(gameObject.GetComponent<ThrowEnemyWeapon>());
    }
    private void OnBecameInvisible()
    {
        //Destroy(gameObject);
        Release();
    }
    protected void FixedUpdate()
    {
        if (PlayerStats.isKilled)
        {
            //Destroy(gameObject);
            Release();
        }
        transform.position += direction * currentSpeed * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats player = collision.GetComponent<PlayerStats>();
            //Destroy(gameObject);
            Release();
            player.TakeDamage(currentDamage);
        }
    }
}