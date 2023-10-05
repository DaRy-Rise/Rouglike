using UnityEngine;

public class ThrowingWeapon : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;
    public static float currentDamage, currentSpeed, currentCooldownDuration;
    protected int currentPierce;

    private void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CoolDownDur;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    private void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
            ReducePierce();
        }
        else if (collision.CompareTag("Cage"))
        {
            Cage cage = collision.GetComponent<Cage>();
            cage.TakeDamage(currentDamage);
            ReducePierce();
        }
    }
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirX < 0 && dirY == 0) //left
        {
            scale.x *= -1;
            scale.y *= -1;
        }
        else if (dirX == 0 && dirY < 0) //down
        {
            scale.y *= -1;
        }
        else if (dirX == 0 && dirY > 0) //up
        {
            scale.x *= -1;
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
            scale.x *= -1;
            scale.y *= -1;
            rotation.z = -90f;
        }
        else if (dirX < 0 && dirY < 0) //LDown
        {
            scale.x *= -1;
            scale.y *= -1;
            rotation.z = 0f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }
}