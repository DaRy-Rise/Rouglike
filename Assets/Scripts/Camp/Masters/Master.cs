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
    [SerializeField]
    private float scale;
    private string pathToJson = "Assets/Resources/Json/MastersInfo.json";
    private ParsingJson parser;
    [SerializeField]
    private Path[] paths;
    private Path currentPath;
    public float speed = 1, maxDis = .1f;
    private IEnumerator<Transform> pointInPath;
    [SerializeField]
    private float pathCoolDownValue, choosePathCoolDownValue;
    private float pathCoolDown, choosePathCoolDown;
    private bool isGoing, isStop, isBack, isPause;
    private Animator animator;

    void Start()
    {
        pathCoolDown = pathCoolDownValue;
        choosePathCoolDown = choosePathCoolDownValue;
        tooltipPrefab = Resources.Load<GameObject>("Prefab/Tooltips/DialogTooltip");
        player = FindAnyObjectByType<PlayerMovement>().transform;
        if (isMainMaster)
        {
            DELETEITLATER_SETMAINMASTER();
        }

        animator = GetComponent<Animator>();
        ChoosePath();
        if (currentPath == null)
        {
            return;
        }

        pointInPath = currentPath.GetNextPathPoitn();
        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            return;
        }

        transform.position = pointInPath.Current.position;
    }
    private void FixedUpdate()
    {
        if (choosePathCoolDown <= 0f && !isGoing && !isBack)
        {
            int i = UnityEngine.Random.Range(0, paths.Length);
            currentPath = paths[i];
            isPause = false;

            isGoing = true;
            animator.SetBool("isReadyToGo", true);
        }
        else
        {
            choosePathCoolDown -= Time.deltaTime;
        }
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
        if (isBack && currentPath.isStartPoint)
        {
            isBack = false;
            isGoing = false;
            choosePathCoolDown = choosePathCoolDownValue;
        }
        if (pathCoolDown <= 0f && isBack && !isGoing && !isStop && !isPause)
        {
            isGoing = true;
            isPause = false;
            animator.SetBool("isReadyToGo", true);
        }
        else
        {
            pathCoolDown -= Time.deltaTime;
        }
        if (isGoing && currentPath.isEndPoint && !isBack)
        {
            isGoing = false;
            animator.SetBool("isReadyToGo", false);
            pathCoolDown = pathCoolDownValue;
            isBack = true;
        }
        if (isGoing)
        {
            SetScale();
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
                    mastersInfo.mainMaster = "archer";
                    break;
                default:
                    break;
            }
            parser.SetInfo(mastersInfo, pathToJson);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.isTrigger)
        {
            SetScaleByGameObject(collision.transform);
            if (!isTooltipExist && portal == null)
            {
                tooltip = Instantiate(tooltipPrefab);
                tooltip.transform.position = gameObject.transform.position + new Vector3(0.9f, 0.9f, 0);
                isTooltipExist = true;
            }
            if (isGoing)
            {
                isStop = true;
                isGoing = false;
                animator.SetBool("isReadyToGo", false);
            }
        }
    }
    private void SetScale()
    {
        try
        {
            if (transform.position.x - pointInPath.Current.position.x < 0)
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
    private void SetScaleByGameObject(Transform gameObject)
    {
        if (gameObject.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(scale, scale, scale);
            side = "right";
        }
        else
        {
            transform.localScale = new Vector3(-scale, scale, scale);
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
            isGoing = true;
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

    private void ChoosePath()
    {
        int i = UnityEngine.Random.Range(0, paths.Length);
        currentPath = paths[i];
    }
}