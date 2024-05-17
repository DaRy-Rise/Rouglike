using Assets.Scripts.Ability;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    float activeTime;
    AbilityState state = AbilityState.Ready;
    public KeyCode key;
    private void Update()
    {
        switch (state)
        {       
            case AbilityState.Ready:
                if (Input.GetKeyUp(key))
                {
                    ability.Activate(gameObject);
                    state = AbilityState.Active;
                    activeTime = ability.activeTime;
                }
                break;
            case AbilityState.Active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.Cooldown;
                    ability.CoolDown(gameObject);
                    cooldownTime = ability.coolDownTime;
                }
                break;
            case AbilityState.Cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.Ready;
                }
                break;
            default:
                break;
        }
    }
}
