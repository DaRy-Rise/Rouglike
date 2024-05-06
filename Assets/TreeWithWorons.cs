using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TreeWithWorons : MonoBehaviour
{

    public GameObject ravenPrefab;
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
        for (int i = 0; i < 5; i++)
        {
            GameObject raven = Instantiate(ravenPrefab, new Vector3(transform.position.x + UnityEngine.Random.Range(0, 2f), transform.position.y + UnityEngine.Random.Range(0, 2f)), Quaternion.identity);
            raven.transform.parent = transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
