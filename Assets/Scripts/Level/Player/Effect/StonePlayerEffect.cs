
public class StonePlayerEffect : PlayerEffect
{
    public static System.Action onReturn;
    private void OnEnable()
    {
        GoodPotion.onAntidoteEffect += ReturnAsWas;
    }
    private void OnDisable()
    {
        GoodPotion.onAntidoteEffect -= ReturnAsWas;
    }
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
    public void ReturnAsWas()
    {
        onReturn?.Invoke();
    }
}