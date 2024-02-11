using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    protected Transform player;
    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
        SetScale();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
    private void SetScale()
    {
        if (player.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(5, 5, 5);
        }
        else
        {
            transform.localScale = new Vector3(-5, 5, 5);
        }
    }
}
