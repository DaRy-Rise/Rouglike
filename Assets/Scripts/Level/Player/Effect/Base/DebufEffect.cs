using UnityEngine;

public abstract class DebufEffect : ScriptableObject
{
    public float durProcess;
    protected bool isInvincibleForEffect;
    public float valueOfGettingDamage;
    [HideInInspector]
    public bool isEffected;
    [SerializeField]
    public float coolDownDefault;
    public float coolDown;
    [SerializeField]
    public KindOfDebuff kindOfIcons;
    [HideInInspector]
    public State state;

    protected virtual void OnEnable()
    {
        GoodPotion.onAntidoteEffect += Antidote;
    }
    protected virtual void OnDisable()
    {
        GoodPotion.onAntidoteEffect -= Antidote;
    }
    public virtual void MakeEffect(float damage, float duration)
    {
        valueOfGettingDamage = damage;
        durProcess = duration;
        isEffected = true;
    }
    protected void Antidote()
    {
        state = State.Ready;
    }
}