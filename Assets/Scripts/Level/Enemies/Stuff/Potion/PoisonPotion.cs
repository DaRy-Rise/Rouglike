using UnityEngine;

public class PoisonPotion : ThrowEnemyWeapon
{
    PoisonPlayerEffect playerEffect;
    [SerializeField]
    private float duration;
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
            Destroy(gameObject);
        }
    }

    private void GetEffect()
    {
        playerEffect.MakeEffect(currentDamage, duration);
    }
}
