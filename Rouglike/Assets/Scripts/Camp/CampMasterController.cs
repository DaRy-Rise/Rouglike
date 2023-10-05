using UnityEngine;

public class CampMasterController : MonoBehaviour
{
    [SerializeField]
    private MasterCard SwordCardPrefab;
    [SerializeField]
    private MasterCard KataCardPrefab;
    [SerializeField]
    private Vector2[] spawnPoints;
    private int index = 0;

    private void Start()
    {
        SpawnCards();
    }
    private void SpawnCards()
    {
        if (GlobalStat.swordMasCard > 0)
        {
            Instantiate(SwordCardPrefab, spawnPoints[index], Quaternion.identity).GetComponent<SpriteRenderer>().sortingOrder = 10;
            index++;
        }
        if (GlobalStat.kataMasCard > 0)
        {
            Instantiate(KataCardPrefab, spawnPoints[index], Quaternion.identity).GetComponent<SpriteRenderer>().sortingOrder = 9;
            index++;
        }
    }
}