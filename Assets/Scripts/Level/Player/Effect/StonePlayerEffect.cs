
public class StonePlayerEffect : PlayerEffect
{
    protected int isStoneEffect;
    public static System.Action onReturn;

    private void OnEnable()
    {
        GoodPotion.onAntidoteEffect += ReturnAsWas;
        GoodPotion.onAntidoteEffect += Antidote;
    }
    private void OnDisable()
    {
        GoodPotion.onAntidoteEffect -= ReturnAsWas;
        GoodPotion.onAntidoteEffect -= Antidote;
    }
    protected override void FixedUpdate()
    {

        if (isStoneEffect > 0 && !isEffected)
        {
            isStoneEffect = 0;
            ReturnAsWas();
        }

        base.FixedUpdate();
    }
    public override void MakeEffect(float damage, float duration)
    {
        PlayerMovement.isStoneEffect = true;
        isStoneEffect++;
        base.MakeEffect(damage, duration);
        if (isEffected && isStoneEffect == 1)
        {
            iconController.SpawnIcon(kindOfIcons, duration);
        }
        else if (isEffected && isStoneEffect > 1)
        {

            isStoneEffect = 1;
            durProcess = duration;
            FindAnyObjectByType<IconController>().ResetBarDuration(KindOfIcons.Stone);
        }
    }
    public void ReturnAsWas()
    {
        onReturn?.Invoke();
    }


    private void Antidote()
    {
        isEffected = false;
        isStoneEffect = 0;
    }
}