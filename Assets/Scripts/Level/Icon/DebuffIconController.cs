using UnityEngine;
using System.Collections.Generic;

public class DebuffIconController : MonoBehaviour
{
    [SerializeField]
    private Debuff poisonIcon, stoneIcon, slowIcon, bloodIcon, fireIcon;
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
    public int SpawnIcon(KindOfDebuff kind, float dur)
    {
        switch (kind)
        {
            case KindOfDebuff.Poison:
                Spawn(poisonIcon, dur, KindOfDebuff.Poison);             
                break;
            case KindOfDebuff.Stone:
                Spawn(stoneIcon, dur, KindOfDebuff.Stone);
                break;
            case KindOfDebuff.Bloodly:
                Spawn(bloodIcon, dur, KindOfDebuff.Bloodly);
                break;
            case KindOfDebuff.Slow:
                Spawn(slowIcon, dur, KindOfDebuff.Slow);
                break;
            case KindOfDebuff.Fire:
                Spawn(fireIcon, dur, KindOfDebuff.Fire);
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
    private void Spawn(Debuff icon, float dur, KindOfDebuff kindOfIcons)
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

    public void ResetBarDuration(KindOfDebuff kindOfIcons)
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