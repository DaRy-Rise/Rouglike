using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public new string name;
    public float coolDownTime;
    public float activeTime;
    public virtual void Activate(GameObject gameObject) { }
    public virtual void CoolDown(GameObject gameObject) { }
}
