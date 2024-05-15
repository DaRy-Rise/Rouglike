using UnityEngine;

public class AbilityBtnManager : MonoBehaviour
{
    [SerializeField]
    private TreeOfAbilityManager abilityManager;
    private int selectedIndexLine = 0, selectedIndexColumn = 0, maxLine;

    void Update()
    {
        ChooseButton();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            abilityManager.CloseTree();
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (selectedIndexLine == maxLine && selectedIndexLine != 5)
            {
                abilityManager.Upgrade(selectedIndexColumn, selectedIndexLine);
            }
        }

    }
    private void ChooseButton()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            selectedIndexColumn--;
            selectedIndexLine = 0;
            if (selectedIndexColumn < 0)
            {
                selectedIndexColumn = 0;

            }
            SetButtonState();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            selectedIndexColumn++;
            selectedIndexLine = 0;
            if (selectedIndexColumn > 2)
            {
                selectedIndexColumn = 4;
            }
            SetButtonState();
        }

        SetMaxLineValue();

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            selectedIndexLine--;
            if (selectedIndexLine < 0)
            {
                selectedIndexLine = 0;
            }
            SetButtonState();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            selectedIndexLine++;
            if (selectedIndexLine > maxLine)
            {
                selectedIndexLine = maxLine;
            }
            SetButtonState();
        }
    }
    private void SetMaxLineValue()
    {
        if (abilityManager.kindOfMaster == KindOfMasters.Sword)
        {
            switch (selectedIndexColumn)
            {
                case 0:
                    maxLine = GlobalStat.swordKick;
                    break;
                case 1:
                    maxLine = GlobalStat.swordDash;
                    break;
                case 2:
                    maxLine = GlobalStat.swordArea;
                    break;
                default:
                    break;
            }
        }
        else if (abilityManager.kindOfMaster == KindOfMasters.Magic)
        {
            switch (selectedIndexColumn)
            {
                case 0:
                    maxLine = GlobalStat.magicChain;
                    break;
                case 1:
                    maxLine = GlobalStat.magicShield;
                    break;
                case 2:
                    maxLine = GlobalStat.magicArea;
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (selectedIndexColumn)
            {
                case 0:
                    maxLine = GlobalStat.archerPoison;
                    break;
                case 1:
                    maxLine = GlobalStat.archerShurikens;
                    break;
                case 2:
                    maxLine = GlobalStat.archerRain;
                    break;
                default:
                    break;
            }
        }
    }
    public void SetButtonState()
    {
        foreach (var item in abilityManager.abilitiesPref)
        {
            if (item != null)
                item.GetComponent<SpriteRenderer>().color = Color.white;
        }
        abilityManager.abilitiesPref[selectedIndexColumn, selectedIndexLine].GetComponent<SpriteRenderer>().color = Color.red;
        SetInfo();
    }
    private void SetInfo()
    {
        FindAnyObjectByType<AbilityInfoManager>().ShowInfo(selectedIndexColumn, selectedIndexLine);
    }
    public void ResetValues()
    {
        selectedIndexColumn=0; 
        selectedIndexLine=0;
    }
}