using UnityEngine;

public class Master : MonoBehaviour
{
    private float health = 20;
    [SerializeField]
    public KindOfMasters kindOf;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            MasterController.IncreaseMasters(kindOf);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            KillMaster();
        }
    }
    private void KillMaster()
    {
        Destroy(gameObject);
    }

}