using UnityEngine;

public class QTE : MonoBehaviour
{
    [SerializeField]
    public Sprite H, F, T, G;
    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public void Enable(KindOfGoodPotion kindOfGoodPotion)
    {
        sprite.enabled = true;
        switch (kindOfGoodPotion)
        {
            case KindOfGoodPotion.Health:
                sprite.sprite = H;
                break;
            case KindOfGoodPotion.Speed:
                sprite.sprite = F;
                break;
            case KindOfGoodPotion.Antidote:
                sprite.sprite = T;
                break;
            case KindOfGoodPotion.Damage:
                sprite.sprite = G;
                break;
            default:
                break;
        }
    }
}
