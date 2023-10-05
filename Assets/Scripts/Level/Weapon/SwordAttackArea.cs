using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwordAttackArea : MonoBehaviour, IPointerClickHandler
{
    public static Action onStartAttack;
    public static Action onStopAttack;
    private bool isAttack;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!isAttack)
            {
                onStartAttack?.Invoke();
                isAttack = true;
            }
            else
            {
                onStopAttack?.Invoke();
                isAttack= false;
            }
        }
    }
}