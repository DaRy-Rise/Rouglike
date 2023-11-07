using System;
using UnityEngine;

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

    void Start()
    {
        tooltipPrefab = Resources.Load<GameObject>("Prefab/Tooltips/DialogTooltip");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isTooltipExist && portal == null)
        {
            tooltip = Instantiate(tooltipPrefab);
            tooltip.transform.position = gameObject.transform.position + new Vector3(0.7f,0.7f,0);
            isTooltipExist = true;          
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(tooltip);
        isTooltipExist = false;
    }

    public void OpenPortal()
    {
        portal = Instantiate(Resources.Load<GameObject>("Prefab/Portal/StartGamePortal"));
        portal.transform.position = gameObject.transform.position + new Vector3(-2.5f, 0, 0);
    }
}