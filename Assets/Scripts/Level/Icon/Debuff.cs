using UnityEngine;

public class Debuff : MonoBehaviour
{
    [HideInInspector]
    public float durDefault;
    [HideInInspector]
    public float dur;
    [HideInInspector]
    public int indexOfCell;
    [SerializeField]
    private IconBar iconBar;
    [HideInInspector]
    public KindOfDebuff kindOfIcons;

    void Start()
    {
        iconBar.max = durDefault;
        dur = durDefault;
    }

    void Update()
    {
        dur -= Time.deltaTime;
        if (dur <= 0)
        {
            FindAnyObjectByType<DebuffIconController>().RemoveEffect(indexOfCell);
            Destroy(gameObject);
        }
    }

    public void ResetDuration()
    {
        if (dur > 0)
        {
            dur = durDefault;
            iconBar.dur = 0;
        }
    }
}