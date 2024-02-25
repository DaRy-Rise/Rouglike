using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float scale;
    public EnemyScriptableObject enemyData;
    protected Transform player;
    [HideInInspector]
    public bool isNearPlayer;

    protected void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    protected virtual void Update()
    {
        if (!isNearPlayer && !PlayerStats.isKilled)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);
            if (player.position.x - transform.position.x > 0) 
            {
                transform.localScale = new Vector3(scale, scale, scale);
            }
            else
            {
                transform.localScale = new Vector3(-scale, scale, scale);
            }
        }
    }
}