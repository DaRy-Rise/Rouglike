using UnityEngine;

public class GlobalStat : MonoBehaviour
{
    [SerializeField]
    private ParsingJson reader;
    public static int wool, hair, squama, spiderLeg, essence, flute, tail, soul, book, ash, flesh, scythe, bone, tentacle, emptyGlass, arrow, nitro;
    public static int swordMas, kataMas, potionMas;
    private ResCount resCount;
    private MastersInfo mastersInfo;
    public static string mainMaster;
    private string resCountPath = "Assets/Resources/Json/res.json";
    private string mastersInfoPath = "Assets/Resources/Json/MastersInfo.json";

    private void Awake()
    {
        resCount = reader.GetInfo<ResCount>(resCountPath);
        mastersInfo = reader.GetInfo<MastersInfo>(mastersInfoPath);
        GetInfo();
    }
    private void GetInfo()
    {
        wool = resCount.wool;
        hair = resCount.hair;
        squama = resCount.squama;
        essence = resCount.squama; 
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
    }
    public void SetInfo()
    {
        resCount.wool = wool;
        resCount.hair = hair;
        resCount.squama = squama;
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
        reader.SetInfo(resCount, resCountPath);
    }
}