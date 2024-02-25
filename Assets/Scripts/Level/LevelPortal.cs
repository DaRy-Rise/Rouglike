using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    private PlayerMovement player;
    private bool isOpened;
    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
    }
    private void Update()
    {
        if (isOpened) player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, 1 * Time.deltaTime);
    }
    public void AttractGG()
    {
        isOpened = true;
    }
    public void LoadCampScene()
    {
        LoadingCampScene.LoadCampScene();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}