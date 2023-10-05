using UnityEngine;

public class DevilLava : MonoBehaviour
{
    private int damage = 5;
    private void Awake()
    {
        Destroy(gameObject, 5);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().WakeUp();
        if (collision.tag == "Player")
        {
            PlayerStats player = collision.GetComponent<PlayerStats>();
            player.TakeDamage(damage);
        }
        else if (collision.tag == "Master")
        {
            Master master = collision.GetComponent<Master>();
            master.TakeDamage(damage);
        }
    }
}