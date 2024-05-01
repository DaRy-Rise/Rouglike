using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ChainLightning : MonoBehaviour
{
    public float destroyAfterSeconds = 0.5f;
    public int currentDamage = 1;
    private GameObject firstEnemy;
    private GameObject secondEnemy;
    private Vector3 firstEnemyPos;
    private Vector3 secondEnemyPos;
    public void theStart(GameObject firstEnemy, GameObject secondEnemy, Vector3 startPos, Vector3 endPos)
    {
        this.firstEnemy = firstEnemy;
        this.firstEnemyPos = startPos;
        this.secondEnemy = secondEnemy;
        this.secondEnemyPos = endPos;
        //print(firstEnemyPos + secondEnemyPos);
        Destroy(gameObject, destroyAfterSeconds);
    }
    private void OnDestroy()
    {
        EnemyStats enemyStats = secondEnemy.GetComponent<EnemyStats>();
        enemyStats.TakeDamage(currentDamage);
    }
    public void Update()
    {
        Vector3 startPos;
        Vector3 endPos;
         if (firstEnemy != null)
        {
            startPos = firstEnemy.transform.position;
            firstEnemyPos = startPos;
        } else
        {
            startPos = firstEnemyPos;
        }
         if (secondEnemy != null)
        {
            endPos = secondEnemy.transform.position;
            secondEnemyPos = endPos;
        } else
        {
            endPos = secondEnemyPos;
        }
        StickLightningToObjects(startPos, endPos);
    }

    private void StickLightningToObjects(Vector3 startPos, Vector3 endPos)
    {
        transform.position = (startPos + endPos) / 2;
        Vector3 direction = endPos - startPos;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        GetComponent<SpriteRenderer>().size = new Vector2(0.08f, direction.magnitude);
    }
}