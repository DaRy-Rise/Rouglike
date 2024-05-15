using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ThiefMovement : EnemyMovement
{
    [HideInInspector]
    public bool isStolen;

    protected override void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    protected override void Update()
    {
        if (!isNearPlayer && !PlayerStats.isKilled && !isDying && !isStolen)
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
        if (!PlayerStats.isKilled && isStolen) 
        {
            Vector3 direction = transform.position - player.transform.position;
            direction.Normalize();
            Vector3 newPosition = transform.position + direction * enemyData.MoveSpeed * Time.deltaTime;
            transform.position = newPosition;
            if (player.position.x - transform.position.x > 0)
            {
                transform.localScale = new Vector3(-scale, scale, scale);
            }
            else
            {
                transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }
}
