using TMPro;
using UnityEngine;

public class AbilityInfoManager : MonoBehaviour
{
    [SerializeField]
    private ParsingJson reader;
    private AbilityInfo abilityInfo;
    [SerializeField]
    private TextMeshProUGUI infoTxt;
    private string infoJsonPath = "Assets/Resources/Json/abilityInfo.json";
    public static string[,] info = new string[3, 5];
    private void Awake()
    {
        abilityInfo = reader.GetInfo<AbilityInfo>(infoJsonPath);
    }
    void Start()
    {
        ParseSwordInfo();
    }
    public void ShowInfo(int clmn, int line)
    {
        infoTxt.text = info[clmn, line];
    }
    public void ParseSwordInfo()
    {
        info[0, 0] = abilityInfo.swordAbilityInfo.kick._1;
        info[0, 1] = abilityInfo.swordAbilityInfo.kick._2;
        info[0, 2] = abilityInfo.swordAbilityInfo.kick._3;
        info[0, 3] = abilityInfo.swordAbilityInfo.kick._4;
        info[0, 4] = abilityInfo.swordAbilityInfo.kick._5;
        info[1, 0] = abilityInfo.swordAbilityInfo.dash._1;
        info[1, 1] = abilityInfo.swordAbilityInfo.dash._2;
        info[1, 2] = abilityInfo.swordAbilityInfo.dash._3;
        info[1, 3] = abilityInfo.swordAbilityInfo.dash._4;
        info[1, 4] = abilityInfo.swordAbilityInfo.dash._5;
        info[2, 0] = abilityInfo.swordAbilityInfo.area._1;
        info[2, 1] = abilityInfo.swordAbilityInfo.area._2;
        info[2, 2] = abilityInfo.swordAbilityInfo.area._3;
        info[2, 3] = abilityInfo.swordAbilityInfo.area._4;
        info[2, 4] = abilityInfo.swordAbilityInfo.area._5;
    }
    public void ParseMagicInfo()
    {
        info[0, 0] = abilityInfo.magicAbilityInfo.chain._1;
        info[0, 1] = abilityInfo.magicAbilityInfo.chain._2;
        info[0, 2] = abilityInfo.magicAbilityInfo.chain._3;
        info[0, 3] = abilityInfo.magicAbilityInfo.chain._4;
        info[0, 4] = abilityInfo.magicAbilityInfo.chain._5;
        info[1, 0] = abilityInfo.magicAbilityInfo.shield._1;
        info[1, 1] = abilityInfo.magicAbilityInfo.shield._2;
        info[1, 2] = abilityInfo.magicAbilityInfo.shield._3;
        info[1, 3] = abilityInfo.magicAbilityInfo.shield._4;
        info[1, 4] = abilityInfo.magicAbilityInfo.shield._5;
        info[2, 0] = abilityInfo.magicAbilityInfo.area._1;
        info[2, 1] = abilityInfo.magicAbilityInfo.area._2;
        info[2, 2] = abilityInfo.magicAbilityInfo.area._3;
        info[2, 3] = abilityInfo.magicAbilityInfo.area._4;
        info[2, 4] = abilityInfo.magicAbilityInfo.area._5;
    }
    public void ParseArcherInfo()
    {
        info[0, 0] = abilityInfo.archerAbilityInfo.poison._1;
        info[0, 1] = abilityInfo.archerAbilityInfo.poison._2;
        info[0, 2] = abilityInfo.archerAbilityInfo.poison._3;
        info[0, 3] = abilityInfo.archerAbilityInfo.poison._4;
        info[0, 4] = abilityInfo.archerAbilityInfo.poison._5;
        info[1, 0] = abilityInfo.archerAbilityInfo.shurikens._1;
        info[1, 1] = abilityInfo.archerAbilityInfo.shurikens._2;
        info[1, 2] = abilityInfo.archerAbilityInfo.shurikens._3;
        info[1, 3] = abilityInfo.archerAbilityInfo.shurikens._4;
        info[1, 4] = abilityInfo.archerAbilityInfo.shurikens._5;
        info[2, 0] = abilityInfo.archerAbilityInfo.rain._1;
        info[2, 1] = abilityInfo.archerAbilityInfo.rain._2;
        info[2, 2] = abilityInfo.archerAbilityInfo.rain._3;
        info[2, 3] = abilityInfo.archerAbilityInfo.rain._4;
        info[2, 4] = abilityInfo.archerAbilityInfo.rain._5;
    }
}
