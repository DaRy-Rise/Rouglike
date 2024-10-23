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
    public event UnityAction HorizontalUpChoosingEvent = delegate { };
    public event UnityAction HorizontalUpChoosingCanceledEvent = delegate { };
    public event UnityAction HorizontalDownChoosingEvent = delegate { };
    public event UnityAction HorizontalDownChoosingCanceledEvent = delegate { };
    public event UnityAction VerticalUpChoosingEvent = delegate { };
    public event UnityAction VerticalUpChoosingCanceledEvent = delegate { };
    public event UnityAction VerticalDownChoosingEvent = delegate { };
    public event UnityAction VerticalDownChoosingCanceledEvent = delegate { };
    public event UnityAction EnterEvent = delegate { };
    public event UnityAction EnterEventCanceled = delegate { };
    public event UnityAction ExitEvent = delegate { };
    public event UnityAction ExitEventCanceled = delegate { };
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
        controls.Buttons.VerticalChoosingUp.performed += OnVertUpChoosing;
        controls.Buttons.VerticalChoosingDown.performed += OnVertDownChoosing;
        controls.Buttons.HorizontChoosingUp.performed += OnHorizUpChoosing;
        controls.Buttons.HorizontChoosingDown.performed += OnHorizUpChoosing;
        controls.Buttons.Choose.performed += OnEnter;
        controls.Buttons.Exit.performed += OnExit;
    }
    private void OnDisable()
    {
        controls.Basic.Attack.performed -= OnAttack;
        controls.Ability.MoveAbility.performed -= OnMoveAbility;
        controls.Ability.AreaAbility.performed -= OnAreaAtack;
        controls.Ability.UltaAbility.performed -= OnUltaAttack;
        controls.Buttons.VerticalChoosingUp.performed -= OnVertUpChoosing;
        controls.Buttons.VerticalChoosingDown.performed -= OnVertDownChoosing;
        controls.Buttons.HorizontChoosingUp.performed -= OnHorizUpChoosing;
        controls.Buttons.HorizontChoosingDown.performed -= OnHorizUpChoosing;
        controls.Buttons.Choose.performed -= OnEnter;
        controls.Buttons.Exit.performed -= OnExit;
        controls.Disable();
    }
    public void OnExit(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                ExitEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                ExitEventCanceled.Invoke();
                break;
        }
    }
    public void OnEnter(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                EnterEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                EnterEventCanceled.Invoke();
                break;
        }
    }
    public void OnVertDownChoosing(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                VerticalDownChoosingEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                VerticalDownChoosingCanceledEvent.Invoke();
                break;
        }
    }
    public void OnVertUpChoosing(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                VerticalUpChoosingEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                VerticalUpChoosingCanceledEvent.Invoke();
                break;
        }
    }
    public void OnHorizDownChoosing(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                HorizontalDownChoosingEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                HorizontalDownChoosingCanceledEvent.Invoke();
                break;
        }
    }
    public void OnHorizUpChoosing(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                HorizontalUpChoosingEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                HorizontalUpChoosingCanceledEvent.Invoke();
                break;
        }
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
