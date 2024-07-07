using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private ObjectPoolManager objectPoolManager;
    protected void Start()
    {
        objectPoolManager = FindAnyObjectByType<ObjectPoolManager>();
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.isTrigger)
        {
            ResController.IncreaseRes(KindOfRes.Coin);
            //Destroy(gameObject);
            objectPoolManager.ReturnObject(gameObject.GetComponent<Coin>());
            print("coin");
        }
    }
}
