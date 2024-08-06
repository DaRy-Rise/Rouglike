using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class CasinoScroll : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;
    private float speed;
    private bool isScrolling;
    private List<CaseCell> cells = new();
    public void Scroll()
    {      
        if (isScrolling)
            return;
        if (cells.Count > 0)
            CleanAll();
        speed = 10;
        isScrolling = true;
        if (cells.Count == 0)
            for (int i = 0; i < 50; i++)
                cells.Add(Instantiate(cellPrefab, GetComponent<VerticalLayoutGroup>().transform).GetComponentInChildren<CaseCell>());
        foreach (var cell in cells)
            cell.SetUp();
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (speed > 0)
            speed -= Time.deltaTime;
        else
        {
            speed = 0;
            isScrolling = false;
        }
    }
    void CleanAll()
    {
        foreach (var item in cells)
            Destroy(item);
        cells.Clear();
    }
}
