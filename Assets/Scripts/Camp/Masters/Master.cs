using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Master : MonoBehaviour
{
    private GameObject tooltipPrefab, dialogIconPrefab;
    [SerializeField]
    private Sprite masterFace;
    private GameObject tooltip, dialogIcon;
    [HideInInspector]
    public bool isTooltipExist;
    [SerializeField]
    private bool isMainMaster;
    public KindOfMasters kindOfMasters;
    private GameObject portal;
    protected Transform player;
    private string side;
    [SerializeField]
    public float scale;
    private string pathToJson = "Assets/Resources/Json/MastersInfo.json";
    private ParsingJson parser;
    public Action onDialog, onDialogEnd;
    [SerializeField]
    private int chanceForDialog;
    private bool isDialog;
    public float timeOfDialog;

    void Start()
    {
        tooltipPrefab = Resources.Load<GameObject>("Prefab/Tooltips/DialogTooltip");
        dialogIconPrefab = Resources.Load<GameObject>("Prefab/Tooltips/dialog_icon");
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
            onDialog?.Invoke();
            SetScaleByGameObject(collision.transform);
            if (!isTooltipExist && portal == null)
            {
                EndDialog();
                tooltip = Instantiate(tooltipPrefab);
                tooltip.transform.position = gameObject.transform.position + new Vector3(0.4f, 0.4f, 0);
                isTooltipExist = true;
            }
        }
        else if (collision.tag == "Master" && collision.isTrigger)
        {
            CheckForDialogue(collision);
            if (isDialog == true)
                StartDialogueWithMaster(collision);
            else if(!isDialog && collision.GetComponent<Master>().isDialog)
            {
                print("in else if");
                isDialog = true;
                timeOfDialog = collision.GetComponent<Master>().timeOfDialog;
                StartDialogueWithMaster(collision);
            }
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
        if(collision.tag == "Player" && collision.isTrigger)
        {
            Destroy(tooltip);
            isTooltipExist = false;
            onDialogEnd?.Invoke();
        }
        else if (collision.tag == "Master" && collision.isTrigger)
        {
            EndDialog();
        }
    }

    private void CheckForDialogue(Collider2D collision)
    {
        int chance = UnityEngine.Random.Range(0,101);
        if (chanceForDialog >= chance)
        {
            timeOfDialog = UnityEngine.Random.Range(5, 20);
            isDialog = true;
        }
        print("after checking: " + isDialog);
    }

    public void StartDialogueWithMaster(Collider2D collision)
    {
        Debug.Log($"{gameObject.name} начал диалог");
        onDialog?.Invoke();
        SetScaleByGameObject(collision.transform);
        dialogIcon = Instantiate(dialogIconPrefab);
        dialogIcon.transform.position = gameObject.transform.position + new Vector3(0.4f, 0.4f, 0);
        Invoke("EndDialog", timeOfDialog);
    }
    public void EndDialog()
    {
        print("EndDialog");
        isDialog = false;
        if (dialogIcon!=null)
        {
            Destroy(dialogIcon);
        }
        onDialogEnd?.Invoke();
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