using UnityEngine;

public class PoisonPotion : ThrowStuff
{
    PoisonPlayerEffect playerEffect;
    protected override void Start()
    {
        base.Start();
        playerEffect = FindAnyObjectByType<PoisonPlayerEffect>();  
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
