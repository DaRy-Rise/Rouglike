using UnityEngine;
[CreateAssetMenu(menuName = "Debuffs/SlowDebuff", fileName = "SlowDebuff")]
public class SlowPlayerEffect : DebufEffect
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
    public void ReturnAsWas()
    {
        onReturn?.Invoke();
        state = State.Ready;
    }
}