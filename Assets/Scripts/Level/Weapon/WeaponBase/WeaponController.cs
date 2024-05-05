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
        } 
        else
        {
            currentCoolDown -= Time.deltaTime;
        }
        if (anim.GetBool("staticAttack") && anim.GetBool("toRun"))
        {
            print("static to run");
            anim.SetBool("staticAttack", false);
            anim.SetBool("runAttack", true);
        }
        if (anim.GetBool("runAttack") && !anim.GetBool("toRun"))
        {
            print("RUN TO STATIC");
            anim.SetBool("runAttack", false);
            anim.SetBool("staticAttack", true);
        }
    }
    protected virtual void StartAttack()
    {
        isAttackAlowed = false;
        currentCoolDown = weaponData.CoolDownDur;
        onRMBClick?.Invoke();
        if (anim.GetBool("toRun"))
        {
            anim.SetBool("runAttack", true);
        }
        else
        {
            anim.SetBool("staticAttack", true);
        }
    }
}