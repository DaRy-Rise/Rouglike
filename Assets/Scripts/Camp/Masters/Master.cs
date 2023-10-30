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


    // Start is called before the first frame update
    void Start()
    {
        tooltipPrefab = Resources.Load<GameObject>("Prefab/Tooltips/DialogTooltip");
    }

    // Update is called once per frame
    void Update()
    {
       if (isTooltipExist)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindAnyObjectByType<DialogSystem>().StartDialog(masterFace);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isTooltipExist)
        {
            tooltip = Instantiate(tooltipPrefab);
            tooltip.transform.position = gameObject.transform.position + new Vector3(0.7f,0.7f,0);
            isTooltipExist = true;          
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(tooltip);
            isTooltipExist = false;
            FindAnyObjectByType<DialogSystem>().StopDialog();
        }
    }*/
}