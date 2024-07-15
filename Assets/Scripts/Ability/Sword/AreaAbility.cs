using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "Ability/Sword/AreaAbility", fileName = "AreaAbility")]
public class AreaAbility : Ability
{
    public float area;
    public float attackRadius = 1f; 
    public float damagePerSecond = 0.001f;
    public float attackDuration = 5f;
    LayerMask layerMask;
    public override void Activate(GameObject gameObject)
    {
        PlayerMovement movement = gameObject.GetComponent<PlayerMovement>();
        movement.blockMove = true;
        int targetLayer = LayerMask.NameToLayer("Enemies");
        layerMask = 1 << targetLayer;
        gameObject.GetComponent<PlayerStats>().StartCoroutine(AttackCoroutine(gameObject.transform));
     
    }
    private IEnumerator AttackCoroutine(UnityEngine.Transform transform)
    {
        float elapsedTime = 0f;
        while (elapsedTime < attackDuration)
        {
            Collider2D[] enemiesInCircle = Physics2D.OverlapCircleAll(transform.position, attackRadius, layerMask);
            foreach (Collider2D enemy in enemiesInCircle)
            {
                if (enemy.isTrigger)
                {
                    EnemyStats currentEnemy = enemy.GetComponent<EnemyStats>();
                    currentEnemy.TakeDamage(damagePerSecond);
                }
            }

            elapsedTime += 1f;
            yield return new WaitForSeconds(1f);
        }
    }
    public override void CoolDown(GameObject gameObject)
    {
        PlayerMovement movement = gameObject.GetComponent<PlayerMovement>();
        movement.blockMove = false;
    }
}
