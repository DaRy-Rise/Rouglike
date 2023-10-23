using UnityEngine;
using System;
using System.Collections.Generic;

public class IconController : MonoBehaviour
{
    [SerializeField]
    private Debuff poisonIcon, stoneIcon, slowIcon, bloodIcon;
    [SerializeField]
    private GameObject[] cells;
    private static List<Debuff> effects = new List<Debuff>();
    private static int index;

    private void OnEnable()
    {
        GoodPotion.onAntidoteEffect += Antidote;
    }
    private void OnDisable()
    {
        GoodPotion.onAntidoteEffect -= Antidote;
    }
    public int SpawnIcon(KindOfIcons kind, float dur)
    {
        switch (kind)
        {
            case KindOfIcons.Poison:
                Spawn(poisonIcon, dur, KindOfIcons.Poison);             
                break;
            case KindOfIcons.Stone:
                Spawn(stoneIcon, dur, KindOfIcons.Stone);
                break;
            case KindOfIcons.Bloodly:
                Spawn(bloodIcon, dur, KindOfIcons.Bloodly);
                break;
            case KindOfIcons.Slow:
                Spawn(slowIcon, dur, KindOfIcons.Slow);
                break;
            default:
                break;
        }
        return index-1;
    }

    public static void ReturnIndex()
    {
        index--;
    }
    private void Spawn(Debuff icon, float dur, KindOfIcons kindOfIcons)
    {
        effects.Add(Instantiate(icon, cells[index].transform));
        effects[effects.Count - 1].transform.position = cells[index].transform.position;
        effects[effects.Count - 1].durDefault = dur;
        effects[effects.Count - 1].indexOfCell = index;
        effects[effects.Count - 1].kindOfIcons = kindOfIcons;
        index++;
    }

    public void Antidote()
    {
        for (int i = 0; i < effects.Count; i++)
        {
            Destroy(effects[i]);
            effects.RemoveAt(i);
        }
    }

    public void RemoveEffect(int indexOfExistBar)
    {
        ReturnIndex();
        effects.RemoveAt(indexOfExistBar);
        if (index > 0 && effects.Count != 0)
        {
            ShiftEffects(indexOfExistBar);
        }
    }

    private void ShiftEffects(int bound)
    {
        for (int i = index - 1; i >= bound; i--)
        {
            effects[i].transform.position = cells[i].transform.position;
            effects[i].indexOfCell = i;
        }
    }

    public void ResetBarDuration(KindOfIcons kindOfIcons)
    {
        foreach (var item in effects)
        {
            if (item.kindOfIcons == kindOfIcons)
            {
                item.ResetDuration();
            }
        }
    }
}