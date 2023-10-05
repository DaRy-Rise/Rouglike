using UnityEngine;

public class SlendermanSpec : MonoBehaviour
{
    private float currentCoolDown, coolDownValue = 5;
    private PolygonCollider2D coll;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        currentCoolDown = coolDownValue;
        coll = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        currentCoolDown -= Time.deltaTime;
        if (currentCoolDown <= 0f)
        {
            currentCoolDown = coolDownValue;
            BecomeInvisible();
        }
    }

    private void BecomeInvisible()
    {
        coll.enabled = false;
        //animation вместо этого
        spriteRenderer.enabled = false;
        Invoke("BecomeVisible", 2);
    }
    private void BecomeVisible()
    {
        coll.enabled = true;
        spriteRenderer.enabled = true;
    }
}