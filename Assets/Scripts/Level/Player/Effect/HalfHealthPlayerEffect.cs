using UnityEngine;

[CreateAssetMenu(menuName = "Debuffs/HalfHealthDebuff", fileName = "HalfHealthDebuff")]
public class HalfHealthPlayerEffect : DebufEffect
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