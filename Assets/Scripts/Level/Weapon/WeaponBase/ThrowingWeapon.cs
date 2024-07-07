using UnityEngine;

public class ThrowingWeapon : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected Vector3 direction, localScale;
    public float destroyAfterSeconds;
    public static float currentDamage, currentSpeed, currentCooldownDuration;
    protected int currentPierce;
    private ObjectPoolManager objectPoolManager;

    private void Awake()
    {
        localScale = transform.localScale;
        objectPoolManager = FindAnyObjectByType<ObjectPoolManager>();
    }

    protected virtual void OnEnable()
    {
        Invoke("ReturnToPool", destroyAfterSeconds);
    }
    private void OnDisable()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CoolDownDur;
        currentPierce = weaponData.Pierce;
    }
    private void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            ReturnToPool();
        }
    }
    private void ReturnToPool()
    {
        if (objectPoolManager.enabled == true)
        {
            objectPoolManager.ReturnObject(gameObject.GetComponent<Projectile>());
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && collision.isTrigger)
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
            ReducePierce();
        }
    }
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
        float dirX = direction.x;
        float dirY = direction.y;
        Vector3 scale = localScale;
        Vector3 rotation = new Vector3(0,0,0);
        if (dirX < 0 && dirY == 0) //left
        {
            scale.x *= -1;
            scale.y *= 1;
        }
        else if (dirX == 0 && dirY < 0) //down
        {
            rotation.z = -90f;
        }
        else if (dirX == 0 && dirY > 0) //up
        {
            rotation.z = 90f;
        }
        else if (dirX > 0 && dirY > 0) //RUp
        {
            rotation.z = 45f;
        }
        else if (dirX > 0 && dirY < 0) //RDown
        {
            rotation.z = -45f;
        }
        else if (dirX < 0 && dirY > 0) //LUp
        {
            scale.x *= -1;
            scale.y *= -1;
            rotation.z = -45f;
        }
        else if (dirX < 0 && dirY < 0) //LDown
        {
            scale.x *= -1;
            scale.y *= -1;
            rotation.z = 45f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }
}