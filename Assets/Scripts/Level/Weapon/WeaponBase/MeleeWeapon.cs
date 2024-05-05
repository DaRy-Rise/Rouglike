using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    public float destroyAfterSeconds;
    protected Vector3 direction;
    public float currentDamage, currentSpeed, currentCooldownDuration;
    protected int currentPierce;
    public LayerMask enemyLayers;

    private void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CoolDownDur;
        currentPierce = weaponData.Pierce;
    }
    protected virtual void Start()
    {
        //Destroy(gameObject, destroyAfterSeconds);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Enemy"))
        //{
        //    EnemyStats enemy = collision.GetComponent<EnemyStats>();
        //    enemy.TakeDamage(currentDamage);
        //    //ReducePierce();
        //}
    }
    public void Attack(Transform attackPoint, float attackRange)
    {
        Collider2D[] enemiesInCircle = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in enemiesInCircle)
        {
            if (enemy.isTrigger)
            {
                EnemyStats currentEnemy = enemy.GetComponent<EnemyStats>();
                currentEnemy.TakeDamage(currentDamage);
            }
        }
    }
    /* public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;
        if (dirX > 0 && dirY == 0)
        {
            scale.x = 1;
            scale.y = 1;
        }
        else if (dirX < 0 && dirY == 0) //left
        {
            scale.x = -1;
            scale.y = -1;
        }
        else if (dirX == 0 && dirY < 0) //down
        {
            scale.y = -1;
        }
        else if (dirX == 0 && dirY > 0) //up
        {
            scale.x = -1;
        }
        else if (dirX > 0 && dirY > 0) //RUp
        {
            rotation.z = 0f;
        }
        else if (dirX > 0 && dirY < 0) //RDown
        {
            rotation.z = -90f;
        }
        else if (dirX < 0 && dirY > 0) //LUp
        {
            scale.x = -1;
            scale.y = -1;
            rotation.z = -90f;
            rotation.x = 180;
        }
        else if (dirX < 0 && dirY < 0) //LDown
        {
            scale.x = -1;
            scale.y = -1;
            rotation.z = 0f;
            rotation.x = 180;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation); 
    }*/
}