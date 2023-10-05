using UnityEngine;
using UnityEngine.UI;

public class IconBar : MonoBehaviour
{
    private bool start;
    private float dur;
    private float max;

    private void Start()
    {
        gameObject.GetComponent<Image>().enabled = false;
        start = false;
    }
    private void Update()
    {
        if (start)
        {
            dur -= Time.deltaTime;
            gameObject.GetComponent<Image>().fillAmount = dur/max;

            if (dur < 0)
            {
                StopFill();
            }
        }
    }
    public void StartFill(float dur)
    {
        this.dur = dur;
        gameObject.GetComponent<Image>().enabled = true;
        max = dur;
        start = true;
    }
    public void StopFill()
    {
        start = false;
        gameObject.GetComponent<Image>().enabled = false;
    }
}
