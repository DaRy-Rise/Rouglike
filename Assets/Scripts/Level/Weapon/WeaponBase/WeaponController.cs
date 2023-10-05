using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    protected float currentCoolDown;
    protected PlayerMovement playerMovement;

    protected virtual void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        currentCoolDown = weaponData.CoolDownDur;
    }

    protected virtual void Update()
    {
        currentCoolDown -= Time.deltaTime;
        if (currentCoolDown <= 0f)
        {
            StartAttack();
        }
    }
    protected virtual void StartAttack()
    {
        currentCoolDown = weaponData.CoolDownDur;
    }
}