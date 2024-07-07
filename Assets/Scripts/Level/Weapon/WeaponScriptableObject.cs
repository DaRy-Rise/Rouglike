using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]
    private int pierce;
    [SerializeField]
    private float damage, speed, coolDownDur;
    [SerializeField]
    private Projectile prefab;

    public Projectile Prefab { get => prefab; private set => prefab = value; } 
    public float Damage { get => damage; set => damage = value; }
    public float Speed { get => speed; set => speed = value; }
    public float CoolDownDur { get => coolDownDur; set => coolDownDur = value; }
    public int Pierce { get => pierce; set => pierce = value; }
}