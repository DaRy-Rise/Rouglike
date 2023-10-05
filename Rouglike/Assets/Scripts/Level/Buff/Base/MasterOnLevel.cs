using UnityEngine;

public class MasterOnLevel : MonoBehaviour
{
    [SerializeField]
    protected float standartCoolDown, speed;
    protected float coolDown;
    protected int levelOfBuff = 0;
    protected MasterBuffController masterController;

    protected virtual void Start()
    {
        coolDown = standartCoolDown;
        masterController = FindObjectOfType<MasterBuffController>();
    }
}