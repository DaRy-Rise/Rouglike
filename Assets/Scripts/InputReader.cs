using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField]
    public Controllers controls;
    public event UnityAction AttackEvent = delegate { };
    public event UnityAction AttackCanceledEvent = delegate { };
    private void Awake()
    {
        controls = new Controllers();
    }
    private void OnEnable()
    {
        controls.Enable();
        controls.Basic.Attack.performed += OnAttack;
    }
    private void OnDisable()
    {
        controls.Basic.Attack.performed -= OnAttack;
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

}
