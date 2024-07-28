using UnityEngine;

[CreateAssetMenu(menuName = "Debuffs/StoneDebuff", fileName = "StoneDebuff")]
public class StonePlayerEffect : DebufEffect
{
    public static System.Action onReturn;

    protected override void OnEnable()
    {
        GoodPotion.onAntidoteEffect += ReturnAsWas;
    }
    protected override void OnDisable()
    {
        GoodPotion.onAntidoteEffect -= ReturnAsWas;
    }
    public override void MakeEffect(float damage, float duration)
    {
        PlayerMovement.isStoneEffect = true;
        base.MakeEffect(damage, duration);
    }
    public void ReturnAsWas()
    {
        onReturn?.Invoke();
        state = State.Ready;
    }
}