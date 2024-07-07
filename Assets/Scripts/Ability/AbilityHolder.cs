using Assets.Scripts.Ability;
using System;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField]
    private Ability moveAbility, areaAbility, ultaAbility;
    private float moveAbilityCooldownTime, areaAbilityCooldownTime, ultaAbilityCooldownTime;
    private float moveAbilityActiveTime, areaAbilityActiveTime, ultaAbilityActiveTime;
    public static Action onSpaceClick,onRMBClick,onQClick;
    protected InputReader inputReader;

    private void OnDisable()
    {
        inputReader.MoveAbilityEvent -= ReleaseMove;
        inputReader.AreaAttackEvent -= ReleaseArea;
        inputReader.UltaAttackEvent -= ReleaseUlta;
    }
    private void Start()
    {
        SetAbility();
        inputReader = FindAnyObjectByType<InputReader>();
        inputReader.MoveAbilityEvent += ReleaseMove;
        inputReader.AreaAttackEvent += ReleaseArea;
        inputReader.UltaAttackEvent += ReleaseUlta;
    }
    private void Update()
    {
        MoveAbility();
        AreaAbility();
        UltaAbility();
    }
    private void ReleaseMove()
    {
        if (moveAbility.abilityState == AbilityState.Ready)
        {
            print("DASH");
            moveAbility.Activate(gameObject);
            moveAbility.abilityState = AbilityState.Active;
            moveAbilityActiveTime = moveAbility.activeTime;
            onSpaceClick.Invoke();
        }
    }
    private void ReleaseArea()
    {
        if (areaAbility.abilityState == AbilityState.Ready)
        {
            print("AREA");
            areaAbility.Activate(gameObject);
            areaAbility.abilityState = AbilityState.Active;
            areaAbilityActiveTime = areaAbility.activeTime;
            onRMBClick.Invoke();
        }
    }
    private void ReleaseUlta()
    {
        if (ultaAbility.abilityState == AbilityState.Ready)
        {
            print("ULTRA");
            ultaAbility.Activate(gameObject);
            ultaAbility.abilityState = AbilityState.Active;
            ultaAbilityActiveTime = ultaAbility.activeTime;
            onQClick.Invoke();
        }
    }
    private void SetAbility()
    {
        moveAbility = Resources.Load<DashAbility>($"Ability/{GlobalStat.mainMaster}/MoveAbility");
        areaAbility = Resources.Load<AreaAbility>($"Ability/{GlobalStat.mainMaster}/AreaAbility");
        ultaAbility = Resources.Load<UltaAbility>($"Ability/{GlobalStat.mainMaster}/UltaAbility");
    }
    private void AreaAbility()
    {
        switch (areaAbility.abilityState)
        {
            case AbilityState.Active:
                if (areaAbilityActiveTime > 0)
                {
                    areaAbilityActiveTime -= Time.deltaTime;
                }
                else
                {
                    areaAbility.abilityState = AbilityState.Cooldown;
                    areaAbility.CoolDown(gameObject);
                    areaAbilityCooldownTime = areaAbility.coolDownTime;
                }
                break;
            case AbilityState.Cooldown:

                if (areaAbilityCooldownTime > 0)
                {
                    areaAbilityCooldownTime -= Time.deltaTime;
                }
                else
                {
                    areaAbility.abilityState = AbilityState.Ready;
                }
                break;
            default:
                break;
        }
    }
    private void UltaAbility()
    {
        switch (ultaAbility.abilityState)
        {
            case AbilityState.Active:
                if (ultaAbilityActiveTime > 0)
                {
                    ultaAbilityActiveTime -= Time.deltaTime;
                }
                else
                {
                    ultaAbility.abilityState = AbilityState.Cooldown;
                    ultaAbility.CoolDown(gameObject);
                    ultaAbilityCooldownTime = ultaAbility.coolDownTime;
                }
                break;
            case AbilityState.Cooldown:

                if (ultaAbilityCooldownTime > 0)
                {
                    ultaAbilityCooldownTime -= Time.deltaTime;
                }
                else
                {
                    ultaAbility.abilityState = AbilityState.Ready;
                }
                break;
            default:
                break;
        }
    }
    private void MoveAbility()
    {
        switch (moveAbility.abilityState)
        {
            case AbilityState.Active:
                if (moveAbilityActiveTime > 0)
                {
                    moveAbilityActiveTime -= Time.deltaTime;
                }
                else
                {
                    moveAbility.abilityState = AbilityState.Cooldown;
                    moveAbility.CoolDown(gameObject);
                    moveAbilityCooldownTime = moveAbility.coolDownTime;
                }
                break;
            case AbilityState.Cooldown:

                if (moveAbilityCooldownTime > 0)
                {
                    moveAbilityCooldownTime -= Time.deltaTime;
                }
                else
                {
                    moveAbility.abilityState = AbilityState.Ready;
                }
                break;
            default:
                break;
        }
    }
}
