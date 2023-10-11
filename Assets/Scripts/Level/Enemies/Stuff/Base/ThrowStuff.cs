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
        direction = player.transform.position; 
        Destroy(gameObject, 3);
    }

    protected void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, currentSpeed * Time.deltaTime);
        if (transform.position == direction)
        {
            Destroy(gameObject);
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats player = collision.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }
}