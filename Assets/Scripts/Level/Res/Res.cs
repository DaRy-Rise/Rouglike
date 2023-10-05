using UnityEngine;

public class Res : MonoBehaviour
{
    [SerializeField]
    KindOfRes kindOf;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ResController.IncreaseRes(kindOf);
            Destroy(gameObject);           
        }
    }
}