using UnityEngine;

public class ResController : MonoBehaviour
{
    public static void IncreaseRes(KindOfRes res)
    {
        switch (res)
        {
            case KindOfRes.Hanky:
                GlobalStat.hanky++;
                break;
            case KindOfRes.Scroll:
                GlobalStat.scroll++;
                break;
            case KindOfRes.Boot:
                GlobalStat.boot++;
                break;
            case KindOfRes.Coin:
                print("Before: " + GlobalStat.coin);
                   GlobalStat.coin++;
                print("After: " + GlobalStat.coin);
                break;
            default:
                break;
        }
    }
}