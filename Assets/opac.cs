using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opac : MonoBehaviour
{
    public GameObject tree;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var col = gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var col = gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
