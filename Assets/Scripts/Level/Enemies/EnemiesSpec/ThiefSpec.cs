using UnityEngine;

public class ThiefSpec : EnemyStats
{
    protected override void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= deSpawnDistance)
        {
            if (!GetComponent<ThiefMovement>().isStolen)
            {
                ReturnEnemy();
            }
            else
            {
                JustDestroy();
            }
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

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        if (collision.tag == "Player" && collision.isTrigger && GlobalStat.coin != 0)
        {
            GetComponent<ThiefMovement>().isStolen = true;
            GlobalStat.coin--;
        }
    }
    public override void Kill()
    {
        base.Kill();
        if (GetComponent<ThiefMovement>().isStolen)
        {
            Instantiate(coin, new Vector2(gameObject.transform.position.x + 0.7f, gameObject.transform.position.y + 0.5f), Quaternion.identity);
        }
    }
}
