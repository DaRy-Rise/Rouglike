using UnityEngine;

public class ThrowingEnemies : MonoBehaviour
{
    [SerializeField]
    protected float coolDownDur;
    protected float currentCoolDown;
    protected PlayerMovement playerMovement;
    [SerializeField]
    protected GameObject weaponPrefab;

    protected virtual void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        currentCoolDown = coolDownDur;
    }

    protected void Update()
    {
        currentCoolDown -= Time.deltaTime;
        if (currentCoolDown <= 0f)
        {
            StartAttack();
        }
    }
    protected virtual void StartAttack()
    {
        currentCoolDown = coolDownDur;
        GameObject spawnedWeapon = Instantiate(weaponPrefab);
        spawnedWeapon.transform.position = transform.position;
    }
}