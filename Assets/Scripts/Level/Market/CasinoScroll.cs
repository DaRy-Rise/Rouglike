using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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
    }
    private IEnumerator CenterClosestElement(GameObject prize)
    {
        print("CenterClosestElement  " + prize.GetComponentInChildren<CaseCell>().GetComponent<SpriteRenderer>().name + " "+prize.transform.position.y);
        if(Mathf.Abs(prize.transform.position.y) < 32.8)
        {
            while (Mathf.Abs(prize.transform.position.y) < 32.8)
            {
                transform.position += Vector3.up * 1 * Time.unscaledDeltaTime;
                yield return null;
            }
        }
        else if(Mathf.Abs(prize.transform.position.y) > 32.8)
        {
            while (Mathf.Abs(prize.transform.position.y) < 32.8)
            {
                transform.position += Vector3.up * 1 * Time.unscaledDeltaTime;
                yield return null;
            }
        }
    }
    private GameObject GetNearestToCenter()
    {
        VerticalLayoutGroup layoutGroup = GetComponent<VerticalLayoutGroup>();
        RectTransform layoutRect = layoutGroup.GetComponent<RectTransform>();
        float centerY = layoutRect.rect.height / 2;
        Transform closestElement = null;
        float smallestDistance = float.MaxValue;

        foreach (RectTransform child in layoutGroup.transform)
        {
            float childCenterY = child.localPosition.y + child.rect.height / 2;
            float distance = Mathf.Abs(childCenterY - centerY);

            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                closestElement = child;
            }
        }
        //close = closestElement.gameObject;
        return closestElement.gameObject;
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
