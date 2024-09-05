using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    [SerializeField]
    private GameObject abilityCard,backGound; 
    [SerializeField]
    private GameObject[] cells;
    private List<GameObject> cards = new();
    [SerializeField]
    private GameObject gamblingButton, casinoBoards;
    private bool isUnlock = false;
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
    private void CheckUnlockCondition()
    {
        if (true)
        {
            isUnlock = true;
            StartCoroutine(UnlockCasino());
        }
    }
    private IEnumerator UnlockCasino()
    {
        gamblingButton.GetComponent<Image>().enabled = false;
        casinoBoards.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        casinoBoards.GetComponent<Animator>().Play("BoardsUnlock");
        yield return new WaitForSecondsRealtime(1f);
        casinoBoards.SetActive(false);
        gamblingButton.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        gamblingButton.GetComponent<Image>().enabled = true;
        gamblingButton.GetComponent<Button>().enabled = false;
        gamblingButton.GetComponent<Animator>().Play("Unlock_button");
        yield return new WaitForSecondsRealtime(1f);
        gamblingButton.GetComponent<Button>().enabled = true;
    }
    //private void UnlockCasino()
    //{
    //    casinoBoards.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    //    Invoke("UnlockButton",1);

    //}
    //private void UnlockButton()
    //{
    //    gamblingButton.SetActive(true);
    //    gamblingButton.GetComponent<Button>().enabled = false;
    //    gamblingButton.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    //    Invoke("UnlockButtonClick", 1);
    //}
    //private void UnlockButtonClick()
    //{
    //    gamblingButton.SetActive(true);
    //    gamblingButton.GetComponent<Button>().enabled = true;
    //}
    public void OpenMarket()
    {
        Time.timeScale = 0f;
        backGound.SetActive(true);
        if (!isUnlock)
            CheckUnlockCondition();
        else
            casinoBoards.SetActive(false);
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
