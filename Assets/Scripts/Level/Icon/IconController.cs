using UnityEngine;
using System.Collections.Generic;

public class IconController : MonoBehaviour
{
    [SerializeField]
    private GameObject poisonIcon, stoneIcon, slowIcon, bloodIcon;
    [SerializeField]
    private GameObject[] cells;
    [SerializeField]
    private IconBar[] bars;
    List<GameObject> effects = new List<GameObject>();
    private int index;

    public void SpawnIcon(KindOfIcons kind, float dur)
    {
        switch (kind)
        {
            case KindOfIcons.Poison:
                Spawn(poisonIcon, dur);            
                break;
            case KindOfIcons.Stone:
                Spawn(stoneIcon, dur);
                break;
            case KindOfIcons.Bloodly:
                Spawn(bloodIcon, dur);
                break;
            case KindOfIcons.Slow:
                Spawn(slowIcon, dur);
                break;
            default:
                break;
        }
    }
    private void StartBar(float dur)
    {
        bars[index].StartFill(dur);
    }

    private void ReturnIndex()
    {
        index--;
        effects.RemoveAt(index);
    }
    private void Spawn(GameObject icon, float dur)
    {
        effects.Add(Instantiate(icon, cells[index].transform));
        Destroy(effects[index], dur);
        StartBar(dur);
        index++;
        Invoke("ReturnIndex", dur);      
    }

    public void Antidote()
    {
        for (int i = 0; i < effects.Count; i++)
        {
            Destroy(effects[i]);
            effects.RemoveAt(i);
        }
    }
}