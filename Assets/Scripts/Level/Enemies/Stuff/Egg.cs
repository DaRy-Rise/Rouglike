public class Egg : EnemyStats
{
    private KoscheiSpec koschei;

    protected override void Awake()
    {
        base.Awake();
        koschei = transform.parent.gameObject.GetComponent<KoscheiSpec>();
    }

    public override void TakeDamage(float damage)
    {
        koschei.TakeDamage();
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Kill();
            koschei.Kill();
        }
    }
}