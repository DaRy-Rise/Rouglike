using UnityEngine;
using System;

public class ImprovePlate : MonoBehaviour
{
    [SerializeField]
    public Sprite sword, kata, potion, damage, speed, healthPotion, speedPotion, antidotePotion, damagePotion;
    [SerializeField]
    private GameObject buffIcon;
    [SerializeField]
    private QTE qte;
    private SpriteRenderer buffIconSR, qteSR;
    private SpriteRenderer sprite;
    private Animation appearAnimation;
    public static Action onSpawnQTE;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        buffIconSR = buffIcon.GetComponent<SpriteRenderer>();
        buffIconSR.enabled = false;
        appearAnimation = GetComponent<Animation>();
        qteSR = qte.GetComponent<SpriteRenderer>();
        qteSR.enabled = false;
    }
    private void OnEnable()
    {
        PotionMasterOnLevel.onQTE += QTETurnOff;
    }
    private void OnDisable()
    {
        PotionMasterOnLevel.onQTE -= QTETurnOff;
    }
    public void Spawn(KindOfMasters master, KindOfBuff buff)
    {      
        switch (master)
        {
            case KindOfMasters.Sword:
                sprite.sprite = sword;
                break;
            case KindOfMasters.Throwing:
                sprite.sprite = kata;
                break;
            default:
                break;
        }
        switch (buff)
        {
            case KindOfBuff.Damage:
                buffIconSR.sprite = damage;
                break;
            case KindOfBuff.Speed:
                buffIconSR.sprite = speed;
                break;
            default:
                break;
        }
        buffIconSR.enabled = true;
        appearAnimation.Play("PlateMove");
        Invoke("TurnOffPanel", 5);
    }
    public void SpawnPotionQTE()
    {
        sprite.sprite = potion;
        ChoosePotion();
        buffIconSR.enabled = true;
        onSpawnQTE?.Invoke();
        qteSR.enabled = true;
        qte.Enable(PotionMasterOnLevel.kindOfPotion);
        appearAnimation.Play("PlateShake");
        Invoke("TurnOffPanel", 5);
    }
    private void ChoosePotion()
    {
        switch (PotionMasterOnLevel.kindOfPotion)
        {
            case KindOfGoodPotion.Health:
                buffIconSR.sprite = healthPotion;
                break;
            case KindOfGoodPotion.Speed:
                buffIconSR.sprite = speedPotion;
                break;
            case KindOfGoodPotion.Antidote:
                buffIconSR.sprite = antidotePotion;
                break;
            case KindOfGoodPotion.Damage:
                buffIconSR.sprite = damagePotion;
                break;
            default:
                break;
        }
    }
    private void TurnOffPanel()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        qteSR.enabled = false;
        buffIconSR.enabled = false;
    }
    private void QTETurnOff()
    {
        Invoke("TurnOffPanel", 0.15f);
    }
}