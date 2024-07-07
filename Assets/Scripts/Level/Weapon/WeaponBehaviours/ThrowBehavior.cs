using UnityEngine;

public class ThrowBehavior : ThrowingWeapon
{
    protected override void OnEnable()
    {
        base.OnEnable();
    }

    void Update()
    {
        transform.position += direction * currentSpeed * Time.deltaTime;
    }
}
