using UnityEngine;

public class Fireball : ThrowEnemyWeapon
{
    [SerializeField]
    private float duration;

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&collision.isTrigger)
        {
            GetEffect(collision);
            ReturnToPool();
        }
    }

    private void GetEffect(Collider2D collision)
    {
        collision.GetComponent<PlayerEffectsHolder>().MakeEffect(KindOfDebuff.Fire, currentDamage,duration);
    }
}
