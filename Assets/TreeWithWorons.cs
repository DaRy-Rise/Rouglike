using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TreeWithWorons : MonoBehaviour
{

    public GameObject ravenPrefab;
    private bool isTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger && !isTriggered) {
            GetComponent<Animator>().SetBool("Start", true);
            isTriggered = true;
        }
    }
    public void onAnimationEnds()
    {
        GetComponent<Animator>().SetBool("Start", false);
        StartCoroutine(spawnRavens());
    }
    // Update is called once per frame
    private IEnumerator spawnRavens()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject raven = Instantiate(ravenPrefab, new Vector3(transform.position.x + UnityEngine.Random.Range(0, 1f), transform.position.y + UnityEngine.Random.Range(0, 1f)), Quaternion.identity);
            raven.transform.parent = transform;
            yield return new WaitForSeconds(0.25f);
        }
        yield break;
    }
    void Update()
    {
        
    }
}
