public class PoisonPlayerEffect : PlayerEffect
{
    protected int isPoisonEffect;

    private void OnEnable()
    {
        GoodPotion.onAntidoteEffect += Antidote;
    }
    private void OnDisable()
    {
        GoodPotion.onAntidoteEffect -= Antidote;
    }
    public override void MakeEffect(float damage, float duration)
    {
        isPoisonEffect++;
        base.MakeEffect(damage, duration);
        if (isEffected && isPoisonEffect == 1)
        {
            iconController.SpawnIcon(kindOfIcons, duration);
        }
        else if (isEffected && isPoisonEffect > 1)
        {
            isPoisonEffect = 1;
            durProcess = duration;
            FindAnyObjectByType<IconController>().ResetBarDuration(KindOfIcons.Poison);
        }
    }

    protected override void FixedUpdate()
    {
        if (isPoisonEffect > 0 && !isEffected)
        {
            isPoisonEffect = 0;
        }

        base.FixedUpdate();
    }

    private void Antidote()
    {
        isEffected = false;
        isPoisonEffect = 0;
    }
}