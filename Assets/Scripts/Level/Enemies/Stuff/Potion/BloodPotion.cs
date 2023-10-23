using UnityEngine;

public class BloodPotion : ThrowEnemyWeapon
{
    BloodlyPlayerEffect playerEffect;
    [SerializeField]
    private float duration;

    protected override void Start()
    {
        base.Start();
        playerEffect = FindAnyObjectByType<BloodlyPlayerEffect>();
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