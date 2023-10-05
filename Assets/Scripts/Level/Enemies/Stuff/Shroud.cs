using UnityEngine;

public class Shroud : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 0.5f);
    }
}