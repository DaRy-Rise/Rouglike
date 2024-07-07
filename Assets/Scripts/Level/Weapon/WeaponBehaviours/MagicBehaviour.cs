using UnityEngine;

public class MagicBehaviour : ThrowingWeapon
{
    [HideInInspector]
    public MagicController controller;
    protected override void OnEnable()
    {
        base.OnEnable();
        controller = FindAnyObjectByType<MagicController>();
    }
    void Update()
    {
        transform.position += direction * currentSpeed * Time.deltaTime;
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
        if (collision.CompareTag("Enemy") && collision.isTrigger)
        {
            controller.InitChainLightning(collision.gameObject);
        }
    }
}
