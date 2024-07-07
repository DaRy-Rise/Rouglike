using UnityEngine;

public class ThrowingEnemies : MonoBehaviour
{
    [SerializeField]
    protected float coolDownDur;
    protected float currentCoolDown;
    protected PlayerMovement playerMovement;
    [SerializeField]
    protected ThrowEnemyWeapon weaponPrefab;
    private ObjectPoolManager objectPoolManager;

    protected virtual void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        currentCoolDown = coolDownDur;
        objectPoolManager = FindAnyObjectByType<ObjectPoolManager>();
    }

    protected void Update()
    {
        currentCoolDown -= Time.deltaTime;
        if (currentCoolDown <= 0f)
        {
            StartAttack();
        }
    }
    public virtual void StartAttack()
    {
        currentCoolDown = coolDownDur;
        ThrowEnemyWeapon wep = objectPoolManager.GetObject(weaponPrefab, transform.position);
        wep.GetComponent<ThrowEnemyWeapon>().SetDirectOptions();
    }
}