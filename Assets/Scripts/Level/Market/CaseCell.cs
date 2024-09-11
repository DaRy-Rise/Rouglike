using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseCell : MonoBehaviour
{
    [System.Serializable]
    private class ListOfSprites
    { 
        public List<Sprite> sprites;      
    }
    [SerializeField]
    private List<ListOfSprites> sprites;
    [SerializeField]
    private int[] chances;
    [SerializeField]
    private Color[] colors;
    [HideInInspector]
    public int id;

    public void SetUp()
    {
        var index = Randomize();
        GetComponent<SpriteRenderer>().sprite = sprites[index].sprites[Random.Range(0, sprites[index].sprites.Count)];
        transform.parent.GetComponent<SpriteRenderer>().color = colors[index];
    }

    private int Randomize()
    {
        int ind = 0;
        for (int i = 0; i < chances.Length; i++)
        {
            int rand = Random.Range(0,101);
            if (rand > chances[i])
                return i;
            ind++;
        }
        return ind;
    }       
}
