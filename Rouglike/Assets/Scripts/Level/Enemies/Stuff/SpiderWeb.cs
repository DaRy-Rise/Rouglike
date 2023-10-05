using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    private PlayerMovement player;
    [Header("Optimization")]
    public float maxOpDist = 20;
    private float opDist;
    private float optimizerCooldown;
    private float optimizerCooldownDur;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.isWeb = true;
        }
        else if (collision.tag == "Weapon")
        {
            DestroyWeb();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerMovement.isWeb = false;
    }
    private void FixedUpdate()
    {
        WebOptimizer();
    }
    private void DestroyWeb()
    {
        //тту анимиашка уничтожения
        Destroy(gameObject);
    }

    private void WebOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;
        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;
        }
        else
        {
            return;
        }
        opDist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (opDist > maxOpDist)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}