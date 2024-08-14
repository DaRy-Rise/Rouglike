using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class CasinoScroll : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;
    private float initialSpeed, scrollTime;
    private bool isScrolling;
    private List<CaseCell> cells = new();
    public void OnEnable()
    {
        SpawnCells();
    }
    public void SpawnCells()
    {
        if (cells.Count == 0)
            for (int i = 0; i < 50; i++)
                cells.Add(Instantiate(cellPrefab, GetComponent<VerticalLayoutGroup>().transform).GetComponentInChildren<CaseCell>());
        foreach (var cell in cells)
            cell.SetUp();
    }
    public void OnScrollClick()
    {      
        if (isScrolling)
        {
            initialSpeed = 20;
            StopCoroutine(Scroll());
            StartCoroutine(ScrollToEl(ShowPrize()));
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
    private void ScrollToElement()
    {
        initialSpeed = 20;
        StartCoroutine(ScrollToEl(ShowPrize()));
    }
    private IEnumerator ScrollToEl(GameObject gameObject)
    {
        while (gameObject.transform.position.y != transform.position.y)
        {
            transform.position += Vector3.up * initialSpeed * Time.deltaTime;
            
            yield return null;
        }
        initialSpeed = 0;
        print(ShowPrize().gameObject.GetComponent<SpriteRenderer>().sprite.name);
    }
    private IEnumerator Scroll()
    {
        float elapsedTime = 0f;
        float speed = initialSpeed;

        while (elapsedTime < scrollTime)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            speed = Mathf.Lerp(initialSpeed, 0, elapsedTime / scrollTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        CenterClosestElement();
        //print(ShowPrize().gameObject.GetComponent<SpriteRenderer>().sprite.name);
    }
    private void CenterClosestElement()
    {
        var closestElement = ShowPrize().transform;
        if (closestElement != null)
        {
            float offset = -closestElement.position.y;
            foreach (var element in cells)
            {
                element.transform.position += Vector3.up * offset;
            }
        }
    }

    private GameObject ShowPrize()
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
        return closestElement.gameObject;
    }
    //void Update()
   // {
      //  transform.position += Vector3.up * speed * Time.deltaTime;
      //  if (speed > 0)
       //     speed -= Time.deltaTime;
       // else
      //  {
       //     speed = 0;
       //     isScrolling = false;
       //     ShowPrize();
       // }
  //  }
    void CleanAll()
    {
        foreach (var item in cells)
            Destroy(item);
        cells.Clear();
    }
}
