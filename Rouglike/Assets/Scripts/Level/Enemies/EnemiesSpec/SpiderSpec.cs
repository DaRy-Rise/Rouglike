using UnityEngine;

public class SpiderSpec : MonoBehaviour
{
    [SerializeField]
    private SpiderWeb spiderWeb;
    private int maxCountOfWebs = 3, currentCountOfWebs;
    private float coolDown = 3, currentCoolDown;

    private void Start()
    {
        currentCoolDown = coolDown;
    }
    private void FixedUpdate()
    {
        if (currentCountOfWebs < maxCountOfWebs)
        {
            currentCoolDown -= Time.deltaTime;

            if (currentCoolDown < 0)
            {
                SpawnWeb();
                currentCoolDown = coolDown;
            }
        }
    }
    private void SpawnWeb()
    {
        Instantiate(spiderWeb, transform.position, Quaternion.identity);
        currentCountOfWebs++;
    }
}