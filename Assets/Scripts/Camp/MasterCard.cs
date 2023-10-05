using UnityEngine;

public class MasterCard : MonoBehaviour
{
    [SerializeField]
    public KindOfMasters kindOf;
    [SerializeField]
    private Master master;
    private Vector2 defaultPosition;
    public static bool isDrag;

    private void Awake()
    {
        defaultPosition = transform.position;
    }
    private void OnMouseEnter()
    {
        if (!isDrag)
        {
            gameObject.transform.position = new Vector2(transform.position.x, -2.78f);
        }
    }
    private void OnMouseExit()
    {
        gameObject.transform.position = defaultPosition;
    }
    private void OnMouseUp()
    {
        gameObject.transform.position = defaultPosition;
    }
    public void DestroyCard()
    {
        Destroy(gameObject);
    }
}