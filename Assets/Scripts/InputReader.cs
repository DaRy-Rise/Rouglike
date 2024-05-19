using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private static InputReader instance;
    public Controllers controls;
    public event UnityAction AttackEvent = delegate { };
    public event UnityAction AttackCanceledEvent = delegate { }; 
    public static InputReader Instance
    {
        get
        {
            if (!instance)
            {
                instance = new GameObject("InputReader Singleton", typeof(InputReader)).GetComponent<InputReader>();
                instance.controls = new Controllers();
            }
            return instance;
        }
    }
    void Start()
    {
        controls.Basic.Attack.performed += OnAttack;
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
