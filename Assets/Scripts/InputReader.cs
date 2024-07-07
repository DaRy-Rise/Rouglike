using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField]
    public Controllers controls;
    public event UnityAction AttackEvent = delegate { };
    public event UnityAction AttackCanceledEvent = delegate { };
    public event UnityAction MoveAbilityEvent = delegate { };
    public event UnityAction MoveAbilityCanceledEvent = delegate { };
    public event UnityAction AreaAttackEvent = delegate { };
    public event UnityAction AreaAttackCanceledEvent = delegate { };
    public event UnityAction UltaAttackEvent = delegate { };
    public event UnityAction UltaAttackCanceledEvent = delegate { };
    private void Awake()
    {
        controls = new Controllers();
    }
    private void OnEnable()
    {
        controls.Enable();
        controls.Basic.Attack.performed += OnAttack;
        controls.Ability.MoveAbility.performed += OnMoveAbility;
        controls.Ability.AreaAbility.performed += OnAreaAtack;
        controls.Ability.UltaAbility.performed += OnUltaAttack;
    }
    private void OnDisable()
    {
        controls.Basic.Attack.performed -= OnAttack;
        controls.Ability.MoveAbility.performed -= OnMoveAbility;
        controls.Ability.AreaAbility.performed -= OnAreaAtack;
        controls.Ability.UltaAbility.performed -= OnUltaAttack;
        controls.Disable();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                AttackEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                AttackCanceledEvent.Invoke();
                break;
        }
    }
    public void OnMoveAbility(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                MoveAbilityEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                MoveAbilityCanceledEvent.Invoke();
                break;
        }
    }
    public void OnAreaAtack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                AreaAttackEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                AreaAttackCanceledEvent.Invoke();
                break;
        }
    }
    public void OnUltaAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                UltaAttackEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                UltaAttackCanceledEvent.Invoke();
                break;
        }
    }
}
