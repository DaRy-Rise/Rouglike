using UnityEngine;

public class KoscheiSpec : MonoBehaviour
{
    public void TakeDamage()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        Invoke("ReturnDefaultColor", 0.25f);
    }
    private void ReturnDefaultColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<EnemyMovement>().isNearPlayer = true;
        }
    }
}
