using UnityEngine;

public class RamSpec : EnemyMovement
{
    private bool startMove;

    protected override void Update()
    {
        if (startMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            startMove = true;
        }
    }
}