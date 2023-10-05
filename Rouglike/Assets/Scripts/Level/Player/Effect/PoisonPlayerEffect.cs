using UnityEngine;

public class PoisonPlayerEffect : PlayerEffect
{
    public override void MakeEffect(float damage)
    {
        if (!isInvincibleForEffect)
        {
            damageCoolDown = coolDownSec;
            isInvincibleForEffect = true;
            isEffected = true;
            iconController.SpawnIcon(kindOfIcons, dur);
            //PlayerStats.is = true;
            Invoke("ReturnAsWas", dur);
        }
    }
    public static void ReturnAsWas()
    {
        PlayerMovement.isSlowEffect = false;
    }
}