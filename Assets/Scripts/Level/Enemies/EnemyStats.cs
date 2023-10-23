using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    protected float currentMoveSpeed, currentHealth, currentDamage;
    public float deSpawnDistance = 20f;
    Transform player;
    protected PlayerStats playerStats;
    [SerializeField]
    public Res res;
    protected EnemyMovement movement;

    protected virtual void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }
    protected void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
        playerStats = FindAnyObjectByType<PlayerStats>();
        movement = gameObject.GetComponent<EnemyMovement>();
    }
    protected void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= deSpawnDistance)
        {
            ReturnEnemy();
        }
    }
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        Invoke("ReturnDefaultColor", 0.25f);
        if (currentHealth <=0)
        {
            Kill();
        }
    }
    public virtual void Kill()
    {
        Destroy(gameObject);
        playerStats.IncreaseExperience();
        CheckResDropChance();
    }
    protected virtual void OnDestroy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        es.OnEnemyKilled();
    }
    protected void ReturnEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }
    protected void CheckResDropChance()
    {
        int i = Random.Range(0, 100);
        if (i <= enemyData.ChanceOfRes)
        {
            DropRes();
        }
    }

    protected virtual void DropRes()
    {
        Instantiate(res, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().WakeUp();
        if (collision.tag == "Player")
        {
            movement.isNearPlayer = true;
            PlayerStats player = collision.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            movement.isNearPlayer = false;
        }
    }

    private void ReturnDefaultColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}