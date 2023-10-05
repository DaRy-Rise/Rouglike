using UnityEngine;

public class SwordWorkShop : MonoBehaviour
{
    [SerializeField]
    public KindOfMasters kindOf;
    private int countOfMasters;
    [SerializeField]
    private int speedOfWork;
    [SerializeField]
    private Master master;

    void Start()
    {
        GetInfo();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MasterCard")
        {
            MasterCard masterCard = collision.GetComponent<MasterCard>();
            if (masterCard.kindOf == kindOf || masterCard.kindOf == KindOfMasters.Helper)
            {
                countOfMasters++;
                MasterController.IncreaseMasters(kindOf);
                SpawnMaster();
                masterCard.DestroyCard();
                GlobalStat.swordMasCard--;
                GlobalStat.swordMas++;
            }
        }
    }
    public void SpawnMaster()
    {
        Instantiate(master, gameObject.transform.position, Quaternion.identity);
    }
    private void GetInfo()
    {
        countOfMasters = GlobalStat.swordMas;
    }
}