using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField]
    private GameObject startingWeapon;

    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }

    [SerializeField]
    private float maxHealth;

    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField]
    private float recovery;

    public float Recovery { get => recovery; private set => recovery = value; }

    [SerializeField]
    private float moveSpeed;

    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField]
    private float might;

    public float Might { get => might; private set => might = value; }

    [SerializeField]
    private float throwSpeed;

    public float ThrowSpeed { get => throwSpeed; private set => throwSpeed = value; }
}
