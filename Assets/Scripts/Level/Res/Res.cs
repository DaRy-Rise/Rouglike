using UnityEngine;

public class Res : MonoBehaviour
{
    [SerializeField]
    KindOfRes kindOf;
    private ObjectPoolManager objectPoolManager;

    private void Start()
    {
        objectPoolManager = FindAnyObjectByType<ObjectPoolManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.isTrigger)
        {
            ResController.IncreaseRes(kindOf);
            //Destroy(gameObject);
            objectPoolManager.ReturnObject<Res>(gameObject.GetComponent<Res>());
            if (kindOf == KindOfRes.Coin) print("coin");
        }
    }
}