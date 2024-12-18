using UnityEngine;

public class Seller : MonoBehaviour
{
    private GameObject tooltipPrefab;
    private GameObject tooltip;
    private bool isTooltipExist;
    protected Transform player;
    [SerializeField]
    private float scale;
    private void Start()
    {
        tooltipPrefab = Resources.Load<GameObject>("Prefab/Tooltips/DialogTooltip");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.isTrigger)
        {
            SetScaleByGameObject(collision.transform);
            if (!isTooltipExist)
            {
                tooltip = Instantiate(tooltipPrefab);
                tooltip.transform.position = gameObject.transform.position + new Vector3(0.9f, 0.9f, 0);
                isTooltipExist = true;
            }
        }
    }
    private void SetScaleByGameObject(Transform gameObject)
    {
        if (gameObject.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            transform.localScale = new Vector3(-scale, scale, scale);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.tag == "Player" && collision.isTrigger))
        {
            Destroy(tooltip);
            isTooltipExist = false;
        }
    }
}
