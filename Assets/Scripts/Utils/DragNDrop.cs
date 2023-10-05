using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    private bool Drag;
    private Rigidbody2D rb;
    public static bool isPause;

    private void Start()
    {
        isPause = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        MasterCard.isDrag = true;
        rb.gravityScale = 0;
        Drag = true;
    }

    private void OnMouseUp()
    {
        MasterCard.isDrag = false;
        rb.gravityScale = 100;
        Drag = false;
    }

    private void FixedUpdate()
    {
        if (!isPause)
        {
            if (Drag)
            {
                Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(MousePos);
            }
        }
    }
}
