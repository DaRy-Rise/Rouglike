using UnityEngine;

public class WerewolfSpec : EnemyStats
{
    [SerializeField]
    private GameObject wolfPref;

    public override void Kill()
    {
        Destroy(gameObject);
        Instantiate(wolfPref, gameObject.transform.position, Quaternion.identity);
    }
}