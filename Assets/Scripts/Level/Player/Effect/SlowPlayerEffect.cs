
using UnityEngine;

public class SlowPlayerEffect : PlayerEffect
{
    protected int isSlowEffect;
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

        if (isSlowEffect > 0 && !isEffected)
        {
            isSlowEffect = 0;
            ReturnAsWas();
        }
        if (durProcess > 0)
        {
            durProcess -= Time.deltaTime;
        }
        else
        {
            isEffected = false;
        }
        //base.FixedUpdate();
    }
    public override void MakeEffect(float damage, float duration)
    {
        PlayerMovement.isSlowEffect = true;
        isSlowEffect++;
        base.MakeEffect(damage, duration);
        if (isEffected && isSlowEffect == 1)
        {
            iconController.SpawnIcon(kindOfIcons, duration);
        }
        else if (isEffected && isSlowEffect > 1)
        {

            isSlowEffect = 1;
            durProcess = duration;
            FindAnyObjectByType<IconController>().ResetBarDuration(KindOfIcons.Slow);
        }
    }
    public void ReturnAsWas()
    {
        onReturn?.Invoke();
    }

    private void Antidote()
    {
        isEffected = false;
        isSlowEffect = 0;
    }
}