using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeWithWorons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            GetComponent<Animator>().SetBool("Start", true);
        }
    }
    public void onAnimationEnds()
    {
        GetComponent<Animator>().SetBool("Start", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
