using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //important
using UnityEngine.UIElements;

//if you use this code you are contractually obligated to like the YT video
public class CatRandomMovement : MonoBehaviour //don't forget to change the script name if you haven't
{
    public NavMeshAgent agent;
    public float range; //radius of sphere
    [SerializeField]
    private float minCoolDown, maxCooldown, coolDown;
    private float currentCoolDown;
    public Transform[] chunkCenters;//centre of the area the agent wants to move around in
                                    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area
    [SerializeField]
    private float scale;
    private Vector3 point;
    private Animator animator;
    private Vector3 lastDirection;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!agent.isOnNavMesh)
            return;
        currentCoolDown += Time.deltaTime;
        if (currentCoolDown >= coolDown)
        {
            currentCoolDown = 0f;
            SetRandomCooldown(out coolDown);
            if (agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                int randomIndex = UnityEngine.Random.Range(0, chunkCenters.Length); // Выбор случайного чанка
                Vector3 centerPoint = chunkCenters[randomIndex].position;
                if (RandomPoint(centerPoint, range, out point)) //pass in our centre point and radius of area
                {
                    lastDirection = (point - transform.position).normalized;
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(point);
                    SetScale();
                }
            }
        }
        if (IsMoving())
        {
            animator.SetBool("toRun", true);
        }
        else
        {
            animator.SetBool("toRun", false);
        }

        gameObject.transform.rotation = Quaternion.identity;
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range; //random point in a sphere        
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 5.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    private void SetRandomCooldown(out float coolDown)
    {
        coolDown = UnityEngine.Random.Range(minCoolDown, maxCooldown);
    }
    private void SetScale()
    {
        try
        {
            if (transform.position.x - point.x < 0)
            {
                transform.localScale = new Vector3(scale, scale, scale);
            }
            else
            {
                transform.localScale = new Vector3(-scale, scale, scale);
            }
        }
        catch (Exception)
        {
            print("its ok");
        }

    }
    public bool IsMoving()
    {
        return agent.velocity.magnitude >= 0.1f;
    }
}