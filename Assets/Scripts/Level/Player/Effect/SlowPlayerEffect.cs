
public class SlowPlayerEffect : PlayerEffect
{
    public static System.Action onReturn;
    public override void MakeEffect(float damage)
    {
        if (!isInvincibleForEffect)
        {
            damageCoolDown = coolDownSec;
            isInvincibleForEffect = true;
            isEffected = true;
            iconController.SpawnIcon(kindOfIcons, dur);
            PlayerMovement.isSlowEffect = true;
            Invoke("ReturnAsWas", dur);
        }
    }
    public void ReturnAsWas()
    {
        onReturn?.Invoke();
    }
}