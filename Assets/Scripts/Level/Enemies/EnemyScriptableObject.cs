using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField]
    private float moveSpeed, maxHealth, damage, chanceOfRes;

    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
    public float Damage { get => damage; private set => damage = value; }
    public float ChanceOfRes { get => chanceOfRes; private set => chanceOfRes = value; }
}