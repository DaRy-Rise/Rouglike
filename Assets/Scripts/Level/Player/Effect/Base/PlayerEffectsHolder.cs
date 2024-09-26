using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectsHolder : MonoBehaviour
{
    [SerializeField]
    private DebufEffect stoneEffect, fireEffect, poisonEffect, bloodlyEffect, slowEffect, halfHealthEffect;
    private Dictionary<KindOfDebuff, DebufEffect> effects = new();
    private void Start()
    {
        SetEffects();
    }
    private void Update()
    {
        CheckEffectState(fireEffect);
    }
    private void SetEffects()
    {
        stoneEffect = Resources.Load<DebufEffect>("Debuff/StoneDebuff");
        fireEffect = Resources.Load<DebufEffect>("Debuff/FireDebuff");
        poisonEffect = Resources.Load<DebufEffect>("Debuff/PoisonDebuff");
        bloodlyEffect = Resources.Load<DebufEffect>("Debuff/BloodlyDebuff");
        slowEffect = Resources.Load<DebufEffect>("Debuff/SlowDebuff");
        halfHealthEffect = Resources.Load<DebufEffect>("Debuff/HalfHealthDebuff");
        effects[KindOfDebuff.Stone] = stoneEffect;
        effects[KindOfDebuff.Fire] = fireEffect;
        effects[KindOfDebuff.Poison] = poisonEffect;
        effects[KindOfDebuff.Bloodly] = bloodlyEffect;
        effects[KindOfDebuff.Slow] = slowEffect;
        effects[KindOfDebuff.HalfHealth] = halfHealthEffect;
    }
    public void MakeEffect(KindOfDebuff debuff, float damage, float dur)
    {
        if (effects[debuff].state == State.Ready)
        {
            effects[debuff].state = State.Active;
            effects[debuff].MakeEffect(damage, dur);
            FindAnyObjectByType<DebuffIconController>().SpawnIcon(effects[debuff].kindOfIcons, dur);
        }
        else
        {
            effects[debuff].durProcess = dur;
            FindAnyObjectByType<DebuffIconController>().ResetBarDuration(debuff);
            effects[debuff].MakeEffect(damage, dur);
        }
    }
    private void CheckEffectState(DebufEffect effect)
    {
        switch (effect.state)
        {
            case State.Active:
                if (effect.durProcess > 0)
                    effect.durProcess -= Time.deltaTime;
                else
                    effect.state = State.Ready;
                if (effect.coolDown > 0)
                    effect.coolDown -= Time.deltaTime;
                else
                {
                    effect.coolDown = effect.coolDownDefault;
                    FindAnyObjectByType<PlayerStats>().TakeDamageFromEffect(effect.valueOfGettingDamage);
                    print("EFFECT DAMAGE");
                }
                break;
            default:
                break;
        }
    }
}
