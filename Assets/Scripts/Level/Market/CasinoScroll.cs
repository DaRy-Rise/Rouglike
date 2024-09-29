using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class CasinoScroll : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;
    private float initialSpeed, scrollTime;
    private bool isScrolling;
    private List<CaseCell> cells = new();
    private GameObject close;

    public void OnEnable()
    {
        SpawnCells();
    }
    public void SpawnCells()
    {
        if (cells.Count == 0)
            for (int i = 0; i < 100; i++)
            {
                cells.Add(Instantiate(cellPrefab, GetComponent<VerticalLayoutGroup>().transform).GetComponentInChildren<CaseCell>());
                cells[i].id = i;
            }
        foreach (var cell in cells)
            cell.SetUp();
    }
    public void OnScrollClick()
    {      
        if (isScrolling)
        {
            initialSpeed = 20;
            StopCoroutine(Scroll());
            StartCoroutine(ScrollToEl(FastChoosePrize()));
            return;
        }        
        if (cells.Count > 0)
        {
            CleanAll();
            SpawnCells();
        }
        initialSpeed = 10;
        scrollTime = 6;
        isScrolling = true;
        StartCoroutine(Scroll());
    }

    private IEnumerator ScrollToEl(GameObject gameObject)
    {
        while (Mathf.Abs(transform.parent.position.y-gameObject.transform.position.y)>=0.1f)
        {
            transform.position += Vector3.up * initialSpeed * Time.unscaledDeltaTime;
            yield return null;
        }
        initialSpeed = 0;
        StartCoroutine(CenterClosestElement(close));
    }
    private IEnumerator Scroll()
    {
        float elapsedTime = 0f;
        float speed = initialSpeed;

        while (elapsedTime < scrollTime)
        {
            transform.position += Vector3.up * speed * Time.unscaledDeltaTime;
            speed = Mathf.Lerp(initialSpeed, 0, elapsedTime / scrollTime);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        StartCoroutine(CenterClosestElement(GetNearestToCenter()));
        isScrolling = false;
    }
    private IEnumerator CenterClosestElement(GameObject prize)
    {
        Transform child = prize.transform.GetChild(0);
        print("CenterClosestElement  " + child.GetComponent<SpriteRenderer>().sprite + " "+prize.transform.position.y);
        close = prize;
        float point = 0.55f;
        if(Mathf.Abs(prize.transform.position.y) < point)
        {
            while (Mathf.Abs(prize.transform.position.y) < point)
            {
                transform.position += Vector3.up * 1 * Time.unscaledDeltaTime;
                yield return null;
            }
        }
        else if(Mathf.Abs(prize.transform.position.y) > point)
        {
            while (Mathf.Abs(prize.transform.position.y) < point)
            {
                transform.position += Vector3.up * 1 * Time.unscaledDeltaTime;
                yield return null;
            }
        }
    }
    private GameObject GetNearestToCenter()
    {
        GameObject nearest = null;
        float closestDistance = float.MaxValue;
        VerticalLayoutGroup layoutGroup = GetComponent<VerticalLayoutGroup>();
        foreach (RectTransform child in layoutGroup.transform)
        {
            float distance = Mathf.Abs(child.position.y - 0.006f);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearest = child.gameObject;
            }
        }

        return nearest;
    }
    private GameObject FastChoosePrize()
    {
        VerticalLayoutGroup layoutGroup = GetComponent<VerticalLayoutGroup>();

        int count = 0;
        foreach (RectTransform child in layoutGroup.transform)
        {
            if(count == 20+GetNearestToCenter().GetComponentInChildren<CaseCell>().id)
            {
                close = child.gameObject;
                break;
            }
            count++;
        }
        return close;
    }

    private void OnDrawGizmos()//рисует кружок атаки в инспекторе
    {
        if(close != null)
            Gizmos.DrawWireSphere(close.gameObject.transform.position, 1f);
    }
    void CleanAll()
    {
        foreach (var item in cells)
            Destroy(item);
        cells.Clear();
    }
}
