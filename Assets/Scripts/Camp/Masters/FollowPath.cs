using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPath : MonoBehaviour
{
    public SwordMovingPath path;
    public float speed = 1, maxDis = .1f;
    private IEnumerator<Transform> pointInPath;
    private float startCoolDown = 10;
    private float goBackCoolDown = 10;
    private bool isGoing, isStop, isGoingBack;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (path == null)
        {
            return;
        }

        pointInPath = path.GetNextPathPoitn();
        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    private void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            return;
        }
        if (isGoing && path.isEndPoint && !isGoingBack)
        {
            animator.SetBool("isReadyToGo", false);
            startCoolDown = 10;
            goBackCoolDown = 10;
            isGoing = false;
            isStop = true;
        }

        if (goBackCoolDown <= 0f && isStop)
        {
            isStop = false;
            isGoingBack = true;
            animator.SetBool("isReadyToGo", true);
            SetScale();
        }
        else
        {
            goBackCoolDown -= Time.deltaTime;
        }


        if (startCoolDown <= 0f && !isGoing && !isGoingBack)
        {
            isGoing = true;
            isGoingBack = false;
            animator.SetBool("isReadyToGo", true);
            SetScale();
        }
        else
        {
            startCoolDown -= Time.deltaTime;
        }


        if (isGoing || isGoingBack)
        { 
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquare < maxDis * maxDis) pointInPath.MoveNext();
    }

    private void SetScale()
    {
        if (transform.position.x - pointInPath.Current.position.x < 0)
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
        else
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }
    }
}
