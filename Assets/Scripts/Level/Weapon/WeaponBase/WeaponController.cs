using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    protected float currentCoolDown;
    protected bool isAttackAlowed = true;
    protected PlayerMovement playerMovement;
    public static System.Action onRMBClick;
    private Animator anim;

    protected virtual void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        currentCoolDown = weaponData.CoolDownDur;
        anim = playerMovement.GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        if (currentCoolDown <= 0f)
        {
            isAttackAlowed = true;
        } else
        {
            currentCoolDown -= Time.deltaTime;
        }
    }
    protected virtual void StartAttack()
    {
        isAttackAlowed = false;
        currentCoolDown = weaponData.CoolDownDur;
        onRMBClick?.Invoke();
        if (anim.GetBool("toRun"))
        {
            anim.SetBool("runAttack", false);
            anim.SetBool("runAttack", true);
        }
        else
        {
            anim.SetBool("staticAttack", true);
        }
    }
}