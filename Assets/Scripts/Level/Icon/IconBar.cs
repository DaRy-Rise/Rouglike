using UnityEngine;
using UnityEngine.UI;

public class IconBar : MonoBehaviour
{
    public float dur;
    private float max;

    private void Start()
    {
        gameObject.GetComponent<Image>().fillAmount = 0;
        max = dur;
    }
    private void Update()
    {
        dur -= Time.deltaTime;
        gameObject.GetComponent<Image>().fillAmount = dur / max;
    }
}