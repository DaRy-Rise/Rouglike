using UnityEngine;

public class Fireball : ThrowEnemyWeapon
{
    FirePlayerEffect playerEffect;
    [SerializeField]
    private float duration;

    protected override void Start()
    {
        base.Start();
        playerEffect = FindAnyObjectByType<FirePlayerEffect>();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetEffect();
            //Destroy(gameObject);
            Release();
        }
    }

    private void GetEffect()
    {
        playerEffect.MakeEffect(currentDamage, duration);
    }
}
