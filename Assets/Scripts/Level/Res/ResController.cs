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
            default:
                break;
        }
    }
}