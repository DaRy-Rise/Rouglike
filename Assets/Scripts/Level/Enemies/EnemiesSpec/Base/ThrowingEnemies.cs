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
        //GameObject spawnedWeapon = Instantiate(weaponPrefab);
        //spawnedWeapon.transform.position = transform.position;
        print("start attack");
        ThrowEnemyWeapon wep = objectPoolManager.GetObject(weaponPrefab, "Fireball");
        wep.transform.position = transform.position;
    }
}