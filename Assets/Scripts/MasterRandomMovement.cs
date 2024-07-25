using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MasterRandomMovement : MonoBehaviour
{
    public Transform[] chunks; // �����, �� ������� ����� ������������ NPC
    public float timeMin = 1f; // ����������� �������� �����������
    public float timeMax = 3f; // ������������ �������� �����������
    private NavMeshAgent agent;
    private Animator animator;
    private bool isStop;

    private float scale;

    private void OnEnable()
    {
        GetComponent<Master>().onDialog += StopMoving;
        GetComponent<Master>().onDialogEnd += ResumeMoving;
    }
    private void OnDisable()
    {
        GetComponent<Master>().onDialog -= StopMoving;
        GetComponent<Master>().onDialogEnd -= ResumeMoving;
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        scale = GetComponent<Master>().scale;
        animator = GetComponent<Animator>();
        StartCoroutine(MoveRandomly());
    }
    private void Update()
    {
        transform.rotation = Quaternion.identity;
        if (IsMoving())
        {
            animator.SetBool("isReadyToGo", true);
        }
        else
        {
            animator.SetBool("isReadyToGo", false);
        }
    }
    private IEnumerator MoveRandomly()
    {
        while (!isStop)
        {
            // ���� ��������� ��������
            float waitTime = UnityEngine.Random.Range(timeMin, timeMax);
            yield return new WaitForSeconds(waitTime);

            // ���������� NPC �� ��������� ����
            Transform targetChunk = chunks[UnityEngine.Random.Range(0, chunks.Length)];
            agent.SetDestination(targetChunk.position);
            SetScale(targetChunk.position);
            // �����, ���� NPC �� ��������� ����
            if(!isStop)
            {
                while (!agent.pathPending && agent.remainingDistance > 0.1f)
                {
                    yield return null;
                }
            }
        }
    }

    private void SetScale(Vector3 point)
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
    public void StopMoving()
    {
        animator.SetBool("isReadyToGo", false);
        agent.enabled = false;
        isStop = true;
        //agent.isStopped = true;
    }
    public void ResumeMoving()
    {
        animator.SetBool("isReadyToGo", true);
        //agent.isStopped = false;
        agent.enabled = true;
        isStop = false;
        MoveRandomly();
    }
}
