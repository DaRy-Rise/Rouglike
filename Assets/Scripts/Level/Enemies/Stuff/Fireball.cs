using UnityEngine;

public class Fireball : ThrowEnemyWeapon
{
    FirePlayerEffect playerEffect;
    [SerializeField]
    private float duration;

    protected override void Awake()
    {
        base.Awake();
        playerEffect = FindAnyObjectByType<FirePlayerEffect>();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetEffect();
            ReturnToPool();
        }
    }

    private void GetEffect()
    {
        playerEffect.MakeEffect(currentDamage, duration);
    }
}
