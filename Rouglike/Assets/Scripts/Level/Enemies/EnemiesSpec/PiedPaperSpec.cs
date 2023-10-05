using UnityEngine;

public class PiedPaperSpec : MonoBehaviour
{
    [SerializeField]
    private GameObject ratPrefab;
    private int maxCountOfRats = 10;
    [HideInInspector]
    public int currentCountOfRats;
    private float coolDown = 10f, currentCoolDown;

    private void Start()
    {
        SpawnRat();
        currentCoolDown = coolDown;
    }

    private void FixedUpdate()
    {
        currentCoolDown -= Time.deltaTime;

        if (currentCountOfRats < maxCountOfRats)
        {

            if (currentCoolDown < 0)
            {
                SpawnRat();
                currentCoolDown = coolDown;
            }
        }
    }

    private void SpawnRat()
    {
        float x;
        float y;
        float prevX = -1;
        float prevY = -1;

        for (currentCountOfRats++; currentCountOfRats <= maxCountOfRats; currentCountOfRats++)
        {
            do
            {
                x = Random.Range(0, 10);
                y = Random.Range(0, 10);

            } while (x == prevX || y == prevY);

            prevX = x;
            prevY = y;

            Instantiate(ratPrefab, new Vector2(transform.position.x + x, transform.position.y + y), Quaternion.identity);
        } 
    }
}