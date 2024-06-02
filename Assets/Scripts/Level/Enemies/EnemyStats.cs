using System;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    protected float currentMoveSpeed, currentHealth, currentDamage;
    public float deSpawnDistance = 20f;
    protected Transform player;
    protected PlayerStats playerStats;
    [SerializeField]
    private Res res;
    protected Res coin;
    protected EnemyMovement movement;
    protected Animator anim;
    private ObjectPoolManager objectPoolManager;

    protected virtual void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }
    protected virtual void Start()
    {
        coin = Resources.Load<Res>("Prefab/Res/Coin");
        player = FindAnyObjectByType<PlayerMovement>().transform;
        playerStats = FindAnyObjectByType<PlayerStats>();
        movement = gameObject.GetComponent<EnemyMovement>();
        anim = gameObject.GetComponent<Animator>();
        objectPoolManager = FindAnyObjectByType<ObjectPoolManager>();
    }
    protected virtual void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= deSpawnDistance)
        {
            ReturnEnemy();
        }
        if (PlayerStats.isKilled)
        {
            //anim.SetBool("toDestroy", true);
            anim.SetBool("toDie", true);
            PolygonCollider2D[] colliders = GetComponents<PolygonCollider2D>();
            foreach (var item in colliders)
            {
                item.enabled = false;
            }
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
        anim.SetBool("toDie", true);
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        movement.isDying = true;
        playerStats.IncreaseExperience();
        CheckResDropChance();
        CheckCoinDropChance();
    }
    protected virtual void OnDestroy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>(); 
        if (es != null) { es.OnEnemyKilled(); }
    }
    protected void ReturnEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + es.relativeSpawnPoints[UnityEngine.Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }
    protected void CheckResDropChance()
    {
        int i = UnityEngine.Random.Range(0, 100);
        if (i <= enemyData.ChanceOfRes)
        {
            DropRes();
        }
    }
    protected void CheckCoinDropChance()
    {
        int i = UnityEngine.Random.Range(0, 100);
        if (i <= enemyData.ChanceOfCoin)
        {
            DropCoin();
        }
    }
    protected virtual void DropRes()
    {
        Instantiate(res, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
    }
    protected virtual void DropCoin()
    {
        //Instantiate(coin, new Vector2(gameObject.transform.position.x+0.5f, gameObject.transform.position.y + 0.3f), Quaternion.identity);
        print("start attack");
        objectPoolManager.GetObject(coin, "COIN");
    }
    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().WakeUp();
        if (collision.tag == "Player" && collision.isTrigger)
        {
            movement.isNearPlayer = true;
            PlayerStats player = collision.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.isTrigger)
        {
            movement.isNearPlayer = false;
        }
    }

    private void ReturnDefaultColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void JustDestroy()
    {
        Destroy(gameObject);
    }
}