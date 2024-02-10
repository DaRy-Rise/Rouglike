using UnityEngine;

public class PortalController : MonoBehaviour
{
    private Transform player;
    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }
    public void OpenPortal()
    {
        Instantiate(Resources.Load<GameObject>("Prefab/Portal/Red_portal"), player);
        transform.position = new Vector2(player.position.x - 0.2f, player.position.y);
    }
}
