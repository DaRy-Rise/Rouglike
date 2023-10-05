using UnityEngine;

public class GhostSpec : MonoBehaviour
{
    [SerializeField]
    private GameObject shroud;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(shroud, new Vector2(0, 0), Quaternion.identity, collision.transform);
        }
    }
}