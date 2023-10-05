using UnityEngine;

public class BadPotion : ThrowStuff
{
    protected KindOfBuff effect;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats player = collision.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }
}
