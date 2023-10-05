
public class StonePlayerEffect : PlayerEffect
{
    public override void MakeEffect(float damage)
    {
        if (!isInvincibleForEffect)
        {
            damageCoolDown = coolDownSec;
            isInvincibleForEffect = true;
            isEffected = true;
            iconController.SpawnIcon(kindOfIcons, dur);
            PlayerMovement.isStoneEffect = true;
            Invoke("ReturnAsWas", dur);
        }
    }
    public static void ReturnAsWas()
    {
        PlayerMovement.isStoneEffect = false;
    }
}