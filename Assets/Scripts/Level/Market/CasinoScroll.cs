using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasinoScroll : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;
    private float speed;
    private bool isScrolling;
    private List<GameObject> cells = new();
    void Start()
    {
        
    }
    public void Scroll()
    {
        if (isScrolling)
            return;
        speed = Random.Range(0,4);
        isScrolling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(speed>0)
            speed -= Time.deltaTime;
        else
        {
            speed = 0;
            isScrolling = false;
        }

    }
}
