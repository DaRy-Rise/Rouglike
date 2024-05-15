using UnityEngine;
using UnityEngine.UI;

public class ActionIconBar : MonoBehaviour
{
    [HideInInspector]
    public float max, dur;
    [HideInInspector]
    public bool isAttack;

    private void Start()
    {
        SetDefaultAmount();
    }
    private void Update()
    {
        if (isAttack)
        {
            dur += Time.deltaTime;
            if (dur < max)
            {
                gameObject.GetComponent<Image>().fillAmount = dur / max;
            }
        }
    }
    public void SetDefaultAmount()
    {
        gameObject.GetComponent<Image>().fillAmount = 0;

    }
}