using UnityEngine;

public class NecroSpec : MonoBehaviour
{
    [SerializeField]
    private GameObject ghostPrefab;
    private int maxCountOfGhost = 5;
    [HideInInspector]
    public int currentCountOfGhost;
    private float coolDown = 10f, currentCoolDown;

    private void Start()
    {
        SpawnGhost();
        currentCoolDown = coolDown;
    }
    private void FixedUpdate()
    {
        currentCoolDown -= Time.deltaTime;

        if (currentCountOfGhost < maxCountOfGhost)
        {

            if (currentCoolDown < 0)
            {
                SpawnGhost();
                currentCoolDown = coolDown;
            }
        }
    }

    private void SpawnGhost()
    {
        float x;
        float y;
        float prevX = -1;
        float prevY = -1;

        for (currentCountOfGhost++; currentCountOfGhost <= maxCountOfGhost; currentCountOfGhost++)
        {
            do
            {
                x = Random.Range(0, 10);
                y = Random.Range(0, 10);

            } while (x == prevX || y == prevY);

            prevX = x;
            prevY = y;

            Instantiate(ghostPrefab, new Vector2(transform.position.x + x, transform.position.y + y), Quaternion.identity);
        }
    }
}