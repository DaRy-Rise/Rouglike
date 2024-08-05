using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    [SerializeField]
    private GameObject abilityCard,backGound; 
    [SerializeField]
    private GameObject[] cells;
    private List<GameObject> cards = new();
    //public bool marketOpen;

    private void Start()
    {
        //backGound.SetActive(false);
    }
    private void OnEnable()
    {
        Seller.onOpenMarket += OpenMarket;
    }
    private void OnDisable()
    {
        Seller.onOpenMarket -= OpenMarket;
    }
    public void OpenMarket()
    {
        Time.timeScale = 0f;
        backGound.SetActive(true);
        SpawnCards();
    }
    public void CloseMarket()
    {
        print("CloseMarket");
        Time.timeScale = 1f;
        backGound.SetActive(false);
        DestroyCards();
    }
    private void SpawnCards()
    {
        //заглушка
        int count = Random.Range(1, cells.Length);
        for (int i = 0; i < count; i++)
        {
            cards.Add(Instantiate(abilityCard, cells[i].transform));
            cards[i].transform.position = cells[i].transform.position;
        }
    }
    private void DestroyCards()
    {
        print("DestroyCards");
        for (int i = 0; i < cards.Count; i++)
        {
            Destroy(cards[i]);
            cards.Remove(cards[i]);
        }
    }
}
