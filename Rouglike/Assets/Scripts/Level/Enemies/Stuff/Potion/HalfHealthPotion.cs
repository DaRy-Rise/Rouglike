using UnityEngine;

public class HalfHealthPotion : ThrowStuff
{
    HalfHealthPlayerEffect playerEffect;
    protected override void Start()
    {
        base.Start();
        playerEffect = FindAnyObjectByType<HalfHealthPlayerEffect>();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetEffect();
        }
    }

    private void GetEffect()
    {
        playerEffect.MakeEffect(currentDamage);
    }
}