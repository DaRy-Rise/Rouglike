using UnityEngine;

public class Res : MonoBehaviour
{
    [SerializeField]
    KindOfRes kindOf;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.isTrigger)
        {
            ResController.IncreaseRes(kindOf);
            Destroy(gameObject);
            if (kindOf == KindOfRes.Coin) print("coin");
        }
    }
}