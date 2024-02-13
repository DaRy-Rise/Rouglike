using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Master : MonoBehaviour
{
    private GameObject tooltipPrefab;
    [SerializeField]
    private Sprite masterFace;
    private GameObject tooltip;
    private bool isTooltipExist;
    [SerializeField]
    private bool isMainMaster;
    public KindOfMasters kindOfMasters;
    private GameObject portal;
    protected Transform player;
    private string side;
    private string pathToJson = "Assets/Resources/Json/MastersInfo.json";
    private ParsingJson parser;

    public SwordMovingPath path;
    public float speed = 1, maxDis = .1f;
    private IEnumerator<Transform> pointInPath;
    private float startCoolDown = 10;
    private float goBackCoolDown = 10;
    private bool isGoing, isStop, isGoingBack;
    private Animator animator;

    void Start()
    {
        tooltipPrefab = Resources.Load<GameObject>("Prefab/Tooltips/DialogTooltip");
        player = FindAnyObjectByType<PlayerMovement>().transform;
        if (isMainMaster)
        {
            DELETEITLATER_SETMAINMASTER();
        }

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

    void Update()
    {
       if (isTooltipExist)
       {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindAnyObjectByType<DialogSystem>().StartDialog(masterFace, kindOfMasters, isMainMaster);
            }
       }

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

        if (goBackCoolDown <= 0f && isStop && !isGoing)
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


        if ((isGoing || isGoingBack) && !isStop)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquare < maxDis * maxDis) pointInPath.MoveNext();
    }
    private void DELETEITLATER_SETMAINMASTER()
    {
        parser = FindAnyObjectByType<ParsingJson>();
        MastersInfo mastersInfo = parser.GetInfo<MastersInfo>(pathToJson);
        if (isMainMaster)
        {
            switch (kindOfMasters)
            {
                case KindOfMasters.Sword:
                    mastersInfo.mainMaster = "sword";
                    break;
                case KindOfMasters.Magic:
                    mastersInfo.mainMaster = "magic";
                    break;
                case KindOfMasters.Throwing:
                    mastersInfo.mainMaster = "throw";
                    break;
                default:
                    break;
            }
            parser.SetInfo(mastersInfo, pathToJson);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isTooltipExist && portal == null)
            {
                tooltip = Instantiate(tooltipPrefab);
                tooltip.transform.position = gameObject.transform.position + new Vector3(0.9f, 0.9f, 0);
                isTooltipExist = true;
                SetScaleToPlayer();
            }
            if (isGoing || isGoingBack)
            {
                isStop = true;
                animator.SetBool("isReadyToGo", false);
            }
        }
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
    private void SetScaleToPlayer()
    {
        if (player.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(3, 3, 3);
            side = "right";
        }
        else
        {
            transform.localScale = new Vector3(-3, 3, 3);
            side = "left";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(tooltip);
        isTooltipExist = false;
        if (isStop == true)
        {
            isStop = false;
            SetScale();
            animator.SetBool("isReadyToGo", true);
        }
    }

    public void OpenPortal()
    {
        switch (kindOfMasters)
        {
            case KindOfMasters.Sword:
                portal = Instantiate(Resources.Load<GameObject>("Prefab/Portal/Red_portal"));
                break;
            case KindOfMasters.Magic:
                portal = Instantiate(Resources.Load<GameObject>("Prefab/Portal/Blue_portal"));
                break;
            case KindOfMasters.Throwing:
                portal = Instantiate(Resources.Load<GameObject>("Prefab/Portal/Green_portal"));
                break;
            default:
                break;
        }
        switch (side)
        {
            case "right":
                portal.transform.position = gameObject.transform.position + new Vector3(2.5f, 0, 0);
                break;
            case "left":
                portal.transform.position = gameObject.transform.position + new Vector3(-2.5f, 0, 0);
                break;
            default:
                break;
        }
    }
}