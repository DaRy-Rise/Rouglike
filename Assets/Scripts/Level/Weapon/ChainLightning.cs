using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : MonoBehaviour
{
    private CircleCollider2D coll;
    public float damage;
    public GameObject chainLightningEffect;
    //public GameObject beenStruck;
    public int amountToChain;
    public GameObject startObject, endObject;
    private Animator animator;
    public ParticleSystem parti;
    private int singleSpawns;

    void Start()
    {
        if (amountToChain == 0) Destroy(gameObject);
        coll = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        parti = GetComponent<ParticleSystem>();
        singleSpawns = 1;
        startObject = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") 
        {
            if (singleSpawns != 0)
            {
                endObject = collision.gameObject;
                amountToChain -= 1;
                Instantiate(chainLightningEffect, collision.gameObject.transform.position, Quaternion.identity);
                //Instantiate(beenStruck, collision.gameObject.transform);
                collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
                animator.StopPlayback();
                coll.enabled = false;
                singleSpawns--;
                parti.Play();
                var emitParams = new ParticleSystem.EmitParams();
                emitParams.position = startObject.transform.position;
                parti.Emit(emitParams, 1);
                emitParams.position = endObject.transform.position;
                parti.Emit(emitParams, 1);
                Destroy(gameObject, 1f);
            }
        
        }
    }
}
