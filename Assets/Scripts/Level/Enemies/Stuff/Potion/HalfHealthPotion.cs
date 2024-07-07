using UnityEngine;

public class HalfHealthPotion : ThrowEnemyWeapon
{
    HalfHealthPlayerEffect playerEffect;
    protected override void OnEnable()
    {
        base.OnEnable();
        playerEffect = FindAnyObjectByType<HalfHealthPlayerEffect>();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetEffect();
            Destroy(gameObject);
        }
    }

    private void GetEffect()
    {
        playerEffect.MakeEffect(currentDamage, 0);
    }
}