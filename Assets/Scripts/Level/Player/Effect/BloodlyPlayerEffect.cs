public class BloodlyPlayerEffect : PlayerEffect
{
    protected int isBloodEffect;

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
        isBloodEffect++;
        base.MakeEffect(damage, duration);
        if (isEffected && isBloodEffect == 1)
        {
            iconController.SpawnIcon(kindOfIcons, duration);
        }
        else if (isEffected && isBloodEffect > 1)
        {
            isBloodEffect = 1;
            durProcess = duration;
            FindAnyObjectByType<IconController>().ResetBarDuration(KindOfIcons.Bloodly);
        }
    }

    protected override void FixedUpdate()
    {
        if (isBloodEffect > 0 && !isEffected)
        {
            isBloodEffect = 0;
        }
        base.FixedUpdate();
    }

    private void Antidote()
    {
        isEffected = false;
        isBloodEffect = 0;
    }
}