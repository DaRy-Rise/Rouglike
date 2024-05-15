using UnityEngine;

public class ActionIcon : MonoBehaviour
{
    [HideInInspector]
    public float durDefault;
    [HideInInspector]
    public float dur;
    [HideInInspector]
    public int indexOfCell;
    [SerializeField]
    public ActionIconBar iconBar;
    [HideInInspector]
    public KindOfIcons kindOfIcons;
    [HideInInspector]
    public bool isAttack;
    private WeaponController weaponController;


    protected virtual void Start()
    {
        weaponController = FindAnyObjectByType<WeaponController>();
        durDefault = weaponController.weaponData.CoolDownDur;
        iconBar.max = durDefault;
        dur = durDefault;
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
