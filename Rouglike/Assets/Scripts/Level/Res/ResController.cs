using UnityEngine;

public class ResController : MonoBehaviour
{
    public static void IncreaseRes(KindOfRes res)
    {
        switch (res)
        {
            case KindOfRes.Wool:
                GlobalStat.wool++;
                break;
            case KindOfRes.Hair:
                GlobalStat.hair++;
                break;
            case KindOfRes.Squama:
                GlobalStat.squama++;
                break;
            default:
                break;
        }
    }
}