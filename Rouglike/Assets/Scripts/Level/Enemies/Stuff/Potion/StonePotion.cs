using UnityEngine;

public class StonePotion : ThrowStuff
{
    StonePlayerEffect playerEffect;
    protected override void Start()
    {
        base.Start();
        playerEffect = FindAnyObjectByType<StonePlayerEffect>();
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
