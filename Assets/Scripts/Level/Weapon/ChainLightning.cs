using UnityEngine;

public class ChainLightning : MonoBehaviour
{
    public float destroyAfterSeconds = 0.5f;

    private void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
}