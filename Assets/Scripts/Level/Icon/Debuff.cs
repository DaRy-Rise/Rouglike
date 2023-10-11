using UnityEngine;

public class Debuff : MonoBehaviour
{
    [HideInInspector]
    public float dur;
    [HideInInspector]
    public int indexOfCell;
    [SerializeField]
    private IconBar iconBar;
    void Start()
    {
        iconBar.dur = dur;
    }

    void Update()
    {
        dur -= Time.deltaTime;
        if (dur <= 0)
        {
            FindAnyObjectByType<IconController>().RemoveEffect(indexOfCell);
            Destroy(gameObject);
        }
    }
}