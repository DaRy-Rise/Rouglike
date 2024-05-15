using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.isTrigger)
        {
            anim.SetBool("hasBeenOpened", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.isTrigger)
        {
            anim.SetBool("hasBeenCollected", true);
        }
    }
    private void JustDestroy()
    {
        Destroy(gameObject);
    }
}
