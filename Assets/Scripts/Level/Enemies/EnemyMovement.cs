using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
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
        if (!isNearPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);
        }
    }
}