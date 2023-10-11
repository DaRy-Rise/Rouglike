using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    protected IconController iconController;
    protected float durProcess;
    protected bool isInvincibleForEffect;
    protected float valueOfGettingDamage;
    [HideInInspector]
    public bool isEffected;
    [SerializeField]
    protected float coolDownDefault;
    protected float coolDown;
    [SerializeField]
    protected KindOfIcons kindOfIcons;

    protected void Start()
    {
        iconController = FindAnyObjectByType<IconController>();
    }
    protected virtual void FixedUpdate()
    {
        if (isEffected)
        {
            if (coolDown > 0)
            {
                coolDown -= Time.deltaTime;
            }
            else
            {
                coolDown = coolDownDefault;
                gameObject.GetComponent<PlayerStats>().TakeDamage(valueOfGettingDamage);
            }
            if (durProcess > 0)
            {
                durProcess -= Time.deltaTime;
            }
            else
            {
                isEffected = false;
            }
        }
    }
    public virtual void MakeEffect(float damage, float duration)
    {
        valueOfGettingDamage = damage;
        durProcess = duration;
        isEffected = true;      
    }
}