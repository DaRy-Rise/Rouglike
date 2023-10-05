using UnityEngine;

public class DevilSpec : EnemyStats
{
    [SerializeField]
    private DevilLava lava;

    public override void Kill()
    {
        base.Kill();
        Instantiate(lava, gameObject.transform.position, Quaternion.identity);
    }
}