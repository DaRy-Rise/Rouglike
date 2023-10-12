using UnityEngine;
using UnityEngine.UI;

public class IconBar : MonoBehaviour
{
    [HideInInspector]
    public float max, dur;

    private void Start()
    {
        gameObject.GetComponent<Image>().fillAmount = 0;
    }
    private void Update()
    {
        dur += Time.deltaTime;
        if (dur < max)
        {
            gameObject.GetComponent<Image>().fillAmount = dur / max;
        }     
    }
}