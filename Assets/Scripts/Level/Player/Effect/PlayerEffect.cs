using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    protected IconController iconController;
    protected float damageCoolDown;
    protected bool isInvincibleForEffect;
    protected float valueOfGettingDamage;
    [HideInInspector]
    public bool isEffected;
    [SerializeField]
    protected float oneCoolDownSec, coolDownSec, dur;
    protected float oneDamageCoolDown;
    [SerializeField]
    protected KindOfIcons kindOfIcons;

    protected void Start()
    {
        iconController = FindAnyObjectByType<IconController>();
    }
    protected void FixedUpdate()
    {
        if (isEffected)
        {
            if (oneDamageCoolDown > 0)
            {
                oneDamageCoolDown -= Time.deltaTime;
            }
            else if (isInvincibleForEffect)
            {
                oneDamageCoolDown = oneCoolDownSec;
                gameObject.GetComponent<PlayerStats>().TakeDamage(valueOfGettingDamage);
            }
        }

        if (damageCoolDown > 0)
        {
            damageCoolDown -= Time.deltaTime;
        }
        else if (isInvincibleForEffect)
        {
            isInvincibleForEffect = false;
        }
    }
    public virtual void MakeEffect(float damage)
    {
        if (!isInvincibleForEffect)
        {
            valueOfGettingDamage = damage;
            damageCoolDown = coolDownSec;
            isInvincibleForEffect = true;
            isEffected = true;
            iconController.SpawnIcon(kindOfIcons, dur);
        }
    }
}