using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField]
    private GameObject sword, magic, archer;
    void Start()
    {
        ChooseWeaponController();
    }

    private void ChooseWeaponController()
    {
        print(GlobalStat.mainMaster);
        switch (GlobalStat.mainMaster)
        {
            case "sword":
                sword.SetActive(true);
                break;
            case "magic":
                magic.SetActive(true);
                break;
            case "archer":
                archer.SetActive(true);
                break;
            default:
                break;
        }
    }
}
