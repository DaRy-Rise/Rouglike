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
    protected InputReader inputReader;

    protected virtual void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        currentCoolDown = weaponData.CoolDownDur;
        anim = playerMovement.GetComponent<Animator>();
        inputReader = FindAnyObjectByType<InputReader>();
        inputReader.AttackEvent += StartAttack;
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
    }
    protected virtual void StartAttack()
    {
        isAttackAlowed = false;
        currentCoolDown = weaponData.CoolDownDur;
        onRMBClick?.Invoke();
        anim.SetBool("toAttack", true);
    }
}