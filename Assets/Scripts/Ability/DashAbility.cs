using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashVelocity;
    public override void Activate(GameObject gameObject)
    {
        PlayerMovement movement = gameObject.GetComponent<PlayerMovement>();
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        movement.blockMove = true;
        rb.velocity = movement.moveDir.normalized * dashVelocity;

    }
    public override void CoolDown(GameObject gameObject)
    {
        PlayerMovement movement = gameObject.GetComponent<PlayerMovement>();
        movement.blockMove = false;
    }
} 
