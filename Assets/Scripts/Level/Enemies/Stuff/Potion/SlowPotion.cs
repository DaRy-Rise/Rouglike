using UnityEngine;

public class SlowPotion : ThrowStuff
{
    SlowPlayerEffect playerEffect;
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
        }
    }

    private void GetEffect()
    {
        playerEffect.MakeEffect(currentDamage);
    }
}
