using UnityEngine;

public class KataBehavior : ThrowingWeapon
{
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        transform.position += direction * currentSpeed * Time.deltaTime;
    }
}
