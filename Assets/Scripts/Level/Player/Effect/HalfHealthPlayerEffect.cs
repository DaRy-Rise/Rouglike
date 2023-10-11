public class HalfHealthPlayerEffect : PlayerEffect
{
    private PlayerStats playerStats;
    public override void MakeEffect(float damage, float duration)
    {
        playerStats = FindAnyObjectByType<PlayerStats>();

        if (!isInvincibleForEffect)
        {
            playerStats.currentHealth *= 0.5f;
        }
    }
}