using UnityEngine;

public class GrassMove : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[1];
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
    }
}