using UnityEngine;

public class RamSpec2 : EnemyStats
{
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        Destroy(gameObject, 0.2f);
    }
}
