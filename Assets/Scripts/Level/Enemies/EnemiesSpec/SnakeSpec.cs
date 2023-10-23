using UnityEngine;

public class SnakeSpec : MonoBehaviour
{
    [SerializeField]
    private int poisonDamage = 3;
    [SerializeField]
    private float poisonDur = 3;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PoisonPlayerEffect player = collision.GetComponent<PoisonPlayerEffect>();
            player.MakeEffect(poisonDamage, poisonDur);
        }
    }
}