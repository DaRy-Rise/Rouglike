public class FirePlayerEffect : PlayerEffect
{
    protected int isFireEffect;

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
        isFireEffect++;
        base.MakeEffect(damage, duration);
        if (isEffected && isFireEffect == 1)
        {
            iconController.SpawnIcon(kindOfIcons, duration);
        }
        else if (isEffected && isFireEffect > 1)
        {
            isFireEffect = 1;
            durProcess = duration;
            FindAnyObjectByType<DebuffIconController>().ResetBarDuration(KindOfIcons.Fire);
        }
    }

    protected override void FixedUpdate()
    {
        if (isFireEffect > 0 && !isEffected)
        {
            isFireEffect = 0;
        }

        base.FixedUpdate();
    }

    private void Antidote()
    {
        isEffected = false;
        isFireEffect = 0;
    }
}