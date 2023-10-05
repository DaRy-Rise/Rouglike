using UnityEngine;

public class GlobalStat : MonoBehaviour
{
    [SerializeField]
    private ParsingJson reader;

    public static int wool, hair, squama, spiderLeg, essence, flute, tail, soul, book, ash, flesh, scythe, bone, tentacle, emptyGlass, arrow, nitro;

    public static int swordMas, kataMas, potionMas;

    public static int swordMasCard, kataMasCard, potionMasCard;

    private ResCount resCount;
    private MasterCount masterCount;
    private CardMasterCount cardMasterCount;
    private string resCountPath = "Assets/Resources/Json/res.json";
    private string masCountPath = "Assets/Resources/Json/masters.json";
    private string masCardCountPath = "Assets/Resources/Json/mastersCard.json";

    private void Awake()
    {
        resCount = reader.GetInfo<ResCount>(resCountPath);
        masterCount = reader.GetInfo<MasterCount>(masCountPath);
        cardMasterCount = reader.GetInfo<CardMasterCount>(masCardCountPath);
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
        swordMas = masterCount.sword;
        kataMas = masterCount.kata;
        potionMas = masterCount.potion;
        swordMasCard = cardMasterCount.cardSword;
        kataMasCard = cardMasterCount.cardKata;
        potionMasCard = cardMasterCount.cardPotion;
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
        masterCount.sword = swordMas;
        masterCount.kata = kataMas;
        masterCount.potion = potionMas;
        cardMasterCount.cardSword = swordMasCard;
        cardMasterCount.cardKata = kataMasCard;
        cardMasterCount.cardPotion = potionMasCard;
        reader.SetInfo(resCount, resCountPath);
        reader.SetInfo(masterCount, masCountPath);
        reader.SetInfo(cardMasterCount, masCardCountPath);
    }
}