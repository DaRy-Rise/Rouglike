using System;
using UnityEngine;

public class SlowPotion : ThrowEnemyWeapon
{
    SlowPlayerEffect playerEffect;
    [SerializeField]
    private float duration;
    protected override void Start()
    {
        base.Start();
        playerEffect = FindAnyObjectByType<SlowPlayerEffect>();
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
        playerEffect.MakeEffect(currentDamage, duration);
    }
}
