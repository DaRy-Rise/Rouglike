using System.Collections.Generic;
using UnityEngine;

public class ActionIconController : MonoBehaviour
{
    private ActionIcon attackIcon, moveAbilityIcon, areaAbilityIcon, ultaAbilityIcon;
    [SerializeField]
    private GameObject[] cells;
    private List<ActionIcon> icon = new List<ActionIcon>();
    private void OnEnable()
    {
        WeaponController.onLMBClick += MakeAttackCoolDown;
        AbilityHolder.onSpaceClick += MakeMoveCoolDown;
        AbilityHolder.onRMBClick += MakeAreaCoolDown;
        AbilityHolder.onQClick += MakeUltaCoolDown;
    }
    private void OnDisable()
    {
        WeaponController.onLMBClick -= MakeAttackCoolDown;
        AbilityHolder.onSpaceClick -= MakeMoveCoolDown;
        AbilityHolder.onRMBClick -= MakeAreaCoolDown;
        AbilityHolder.onQClick -= MakeUltaCoolDown;
    }
    private void Start()
    {
        SetIcons();
        SpawnIcons();
    }
    private void MakeAttackCoolDown()
    {
        icon[0].isAttack = true;
        icon[0].iconBar.isAttack = true;
    }
    private void MakeMoveCoolDown()
    {
        icon[1].isAttack = true;
        icon[1].iconBar.isAttack = true;
    }
    private void MakeAreaCoolDown()
    {
        icon[2].isAttack = true;
        icon[2].iconBar.isAttack = true;
    }
    private void MakeUltaCoolDown()
    {
        icon[3].isAttack = true;
        icon[3].iconBar.isAttack = true;
    }
    private void SetIcons()
    {
        attackIcon = Resources.Load<ActionIcon>($"Prefab/ActionsIcons/{GlobalStat.mainMaster}/AttackIcon");
        moveAbilityIcon = Resources.Load<ActionIcon>($"Prefab/ActionsIcons/{GlobalStat.mainMaster}/MoveIcon");
        areaAbilityIcon = Resources.Load<ActionIcon>($"Prefab/ActionsIcons/{GlobalStat.mainMaster}/AreaIcon");
        ultaAbilityIcon = Resources.Load<ActionIcon>($"Prefab/ActionsIcons/{GlobalStat.mainMaster}/UltaIcon");
    }
    public void SpawnIcons()
    {
        icon.Add(Instantiate(attackIcon, cells[0].transform));
        icon[0].transform.position = cells[0].transform.position;
        icon.Add(Instantiate(moveAbilityIcon, cells[1].transform));
        icon[1].transform.position = cells[1].transform.position;
        icon.Add(Instantiate(areaAbilityIcon, cells[2].transform));
        icon[2].transform.position = cells[2].transform.position;
        icon.Add(Instantiate(ultaAbilityIcon, cells[3].transform));
        icon[3].transform.position = cells[3].transform.position;
    }
}
