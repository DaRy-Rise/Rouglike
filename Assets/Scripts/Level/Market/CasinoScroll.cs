using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasinoScroll : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;
    private float speed;
    private bool isScrolling;
    private List<CaseCell> cells = new();
    void Start()
    {

    }
    public void Scroll()
    {
        if (isScrolling)
            return;
        speed = Random.Range(0, 4);
        isScrolling = true;
        if (cells.Count == 0)
            for (int i = 0; i < 50; i++)
                cells.Add(Instantiate(cellPrefab, transform).GetComponentInChildren<CaseCell>());

        foreach (var cell in cells)
            cell.SetUp();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left * 100, speed * Time.deltaTime * 1500);
        if (speed > 0)
            speed -= Time.deltaTime;
        else
        {
            speed = 0;
            isScrolling = false;
        }
    }
}
