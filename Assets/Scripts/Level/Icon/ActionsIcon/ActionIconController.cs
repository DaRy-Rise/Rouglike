using System.Collections.Generic;
using UnityEngine;

public class ActionIconController : MonoBehaviour
{
    [SerializeField]
    private ActionIcon swordIcon, magicIcon, archerIcon;
    [SerializeField]
    private GameObject[] cells;
    private List<ActionIcon> icon = new List<ActionIcon>();
    private void OnEnable()
    {
        WeaponController.onRMBClick += MakeRMBCoolDown;
    }
    private void OnDisable()
    {
        WeaponController.onRMBClick -= MakeRMBCoolDown;
    }
    private void Start()
    {
        SpawnIcons();
    }
    private void MakeRMBCoolDown()
    {
        icon[0].isAttack = true;
        icon[0].iconBar.isAttack = true;
    }
    public void SpawnIcons()
    {
        switch (GlobalStat.mainMaster)        
        {
            case "sword":
                icon.Add(Instantiate(swordIcon, cells[0].transform));
                icon[0].transform.position = cells[0].transform.position;
                break;
            case "magic":
                icon.Add(Instantiate(magicIcon, cells[0].transform));
                icon[0].transform.position = cells[0].transform.position;
                break;
            case "archer":
                icon.Add(Instantiate(archerIcon, cells[0].transform));
                icon[0].transform.position = cells[0].transform.position;
                break;
            default:
                break;
        }
    }
}
