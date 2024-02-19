using UnityEngine;

public class GlobalStat : MonoBehaviour
{
    [SerializeField]
    private ParsingJson reader;
    public static int hanky, scroll, boot, spiderLeg, essence, flute, tail, soul, book, ash, flesh, scythe, bone, tentacle, emptyGlass, arrow, nitro;
    public static int swordDash, swordKick, swordArea, magicChain, magicShield, magicArea, archerPoison, archerShurikens, archerRain;
    private ResCount resCount;
    private MastersInfo mastersInfo;
    private AbilityTree abilityTree;
    public static string mainMaster;
    private string resCountPath = "Assets/Resources/Json/res.json";
    private string mastersInfoPath = "Assets/Resources/Json/MastersInfo.json";
    private string abilityTreePath = "Assets/Resources/Json/abilityTree.json";

    private void Awake()
    {
        resCount = reader.GetInfo<ResCount>(resCountPath);
        mastersInfo = reader.GetInfo<MastersInfo>(mastersInfoPath);
        abilityTree = reader.GetInfo<AbilityTree>(abilityTreePath);
        GetInfo();
    }
    private void GetInfo()
    {
        hanky = resCount.hanky;
        scroll = resCount.scroll;
        boot = resCount.boot;
        essence = resCount.essence; 
        spiderLeg = resCount.spiderLeg;
        flute = resCount.flute;
        tail = resCount.tail;
        soul = resCount.soul;
        book = resCount.book;
        ash = resCount.ash;
        flesh = resCount.flesh;
        scythe = resCount.scythe;
        bone = resCount.bone;
        tentacle = resCount.tentacle;
        emptyGlass = resCount.emptyGlass;
        arrow = resCount.arrow;
        nitro = resCount.nitro;
        mainMaster = mastersInfo.mainMaster;
        swordDash = abilityTree.swordMaster.dash;
        swordKick = abilityTree.swordMaster.kick;
        swordArea = abilityTree.swordMaster.area;
        magicChain = abilityTree.magicMaster.chain;
        magicShield = abilityTree.magicMaster.shield;
        magicArea = abilityTree.magicMaster.area;
        archerPoison = abilityTree.archerMaster.poison;
        archerShurikens = abilityTree.archerMaster.shurikens;
        archerRain = abilityTree.archerMaster.rain;
    }
    public void SetInfo()
    {
        resCount.hanky = hanky;
        resCount.scroll = scroll;
        resCount.boot = boot;
        resCount.spiderLeg = spiderLeg;
        resCount.essence = essence;
        resCount.flute = flute;
        resCount.tail = tail;
        resCount.soul = soul;
        resCount.book = book;
        resCount.ash = ash;
        resCount.flesh = flesh;
        resCount.scythe = scythe;
        resCount.bone = bone;
        resCount.tentacle = tentacle;
        resCount.emptyGlass = emptyGlass;
        resCount.arrow = arrow;
        resCount.nitro = nitro;
        abilityTree.swordMaster.dash = swordDash;
        abilityTree.swordMaster.kick = swordKick;
        abilityTree.swordMaster.area = swordArea;
        abilityTree.magicMaster.chain = magicChain;
        abilityTree.magicMaster.shield = magicShield;
        abilityTree.magicMaster.area = magicArea;
        abilityTree.archerMaster.poison = archerPoison;
        abilityTree.archerMaster.shurikens = archerShurikens;
        reader.SetInfo(resCount, resCountPath);
    }
}