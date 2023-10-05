public class RatSpec : EnemyStats
{
    private PiedPaperSpec piedPaper;
    protected override void Awake()
    {
        base.Awake();
        piedPaper = FindObjectOfType<PiedPaperSpec>();
    }
    protected override void OnDestroy()
    {
        if (piedPaper != null)
        {
            piedPaper.currentCountOfRats--;
        }
    }
    public override void Kill()
    {
        Destroy(gameObject);
        CheckResDropChance();
    }
}