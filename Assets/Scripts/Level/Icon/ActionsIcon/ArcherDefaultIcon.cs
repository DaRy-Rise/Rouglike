using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherDefault : ActionIcon
{
    private ThrowController throwController;
    protected override void Start()
    {
        throwController = FindAnyObjectByType<ThrowController>();
        durDefault = throwController.weaponData.CoolDownDur;
        base.Start();
    }

}
