using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropOpacity : MonoBehaviour
{
    public GameObject prop;
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
        if (collision.gameObject.tag == "Player") {
            prop.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            prop.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
