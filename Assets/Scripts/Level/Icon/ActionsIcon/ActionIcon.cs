using UnityEditor.Rendering;
using UnityEngine;

public class ActionIcon : MonoBehaviour
{
    [SerializeField]
    public Ability scriptableObject;
    [HideInInspector]
    public float durDefault;
    [HideInInspector]
    public float dur;
    [HideInInspector]
    public int indexOfCell;
    [SerializeField]
    public ActionIconBar iconBar;
    [SerializeField]
    private bool isAttackIcon;
    [HideInInspector]
    public bool isAttack;


    protected virtual void Start()
    {
        SetDefaultCoolDownValue();
        iconBar.max = durDefault;
        dur = durDefault;
    }
    private void SetDefaultCoolDownValue()
    {
        if (isAttackIcon)
            durDefault = FindAnyObjectByType<WeaponController>().weaponData.CoolDownDur;
        else
            durDefault = scriptableObject.coolDownTime;
    }
    protected virtual void Update()
    {
        if (isAttack)
        {
            dur -= Time.deltaTime;
            if (dur <= 0)
            {
                isAttack = false;
                iconBar.isAttack = false;
                dur = durDefault;
                iconBar.dur = 0;
                iconBar.SetDefaultAmount();
            }
        }
    }

    public void ResetDuration()
    {
        if (dur > 0)
        {
            dur = durDefault;
            iconBar.dur = 0;
        }
    }
}
