using System;
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

    void Start()
    {
        tooltipPrefab = Resources.Load<GameObject>("Prefab/Tooltips/DialogTooltip");
        player = FindAnyObjectByType<PlayerMovement>().transform;
        if (isMainMaster)
        {
            DELETEITLATER_SETMAINMASTER();
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
        if (collision.tag == "Player" && !isTooltipExist && portal == null)
        {
            tooltip = Instantiate(tooltipPrefab);
            tooltip.transform.position = gameObject.transform.position + new Vector3(0.9f,0.9f,0);
            isTooltipExist = true;
            SetScale();
        }
    }
    private void SetScale()
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