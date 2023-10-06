using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class GoodPotion : MonoBehaviour
{
    [SerializeField]
    private Vector3 defaultPosition;
    [SerializeField]
    private ImprovePlate improvePlate;
    [SerializeField]
    AnimationClip goodPotionAnim;
    private PlayerStats playerStats;
    private MeleeWeapon meleeWeapon;
    private ThrowingWeapon throwingWeapon;
    private float meleeDefaultDmg, throwingDefaultDmg;
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void Start()
    {
        playerStats = FindAnyObjectByType<PlayerStats>();
    }

    void OnEnable()
    {
        ChoosePotion();
        Invoke("TurnOff", goodPotionAnim.length);
    }
    void TurnOff()
    {
        PotionEffect();
        gameObject.SetActive(false);
        ReturnToDefaultPosition();
    }
    void ReturnToDefaultPosition()
    {
        gameObject.transform.position = defaultPosition;
    }
    void ChoosePotion()
    {
        switch (PotionMasterOnLevel.kindOfPotion)
        {
            case KindOfGoodPotion.Health:
                gameObject.GetComponent<SpriteRenderer>().sprite = improvePlate.healthPotion;
                break;
            case KindOfGoodPotion.Speed:
                gameObject.GetComponent<SpriteRenderer>().sprite = improvePlate.speedPotion;
                break;
            case KindOfGoodPotion.Antidote:
                gameObject.GetComponent<SpriteRenderer>().sprite = improvePlate.antidotePotion;
                break;
            case KindOfGoodPotion.Damage:
                gameObject.GetComponent<SpriteRenderer>().sprite = improvePlate.damagePotion;
                break;
            default:
                break;
        }
    }

    void PotionEffect()
    {
        switch (PotionMasterOnLevel.kindOfPotion)
        {
            case KindOfGoodPotion.Health:
                HealthEffect();
                break;
            case KindOfGoodPotion.Speed:
                SpeedEffect();
                break;
            case KindOfGoodPotion.Antidote:
                AntidoteEffect();
                break;
            case KindOfGoodPotion.Damage:
                DamageEffect();
                break;
            default:
                break;
        }
    }
    void HealthEffect()
    {
        float value = (playerStats.characterData.MaxHealth * 5) / 100;
        if (playerStats.currentHealth + value > playerStats.characterData.MaxHealth)
        {
            float x = (-playerStats.characterData.MaxHealth + playerStats.currentHealth + value);
            value -= x;
            playerStats.currentHealth += value;
        }
        else
        {
            playerStats.currentHealth += value;
        }
    }

    void SpeedEffect()
    {
        PlayerMovement.isSpeedPotion = true;
        Invoke("ReturnSpeed", 5);
    }

    void ReturnSpeed()
    {
        PlayerMovement.isSpeedPotion = false;
    }

    void AntidoteEffect()
    {
        IconBar[] iconsBar = FindObjectsOfType<IconBar>();
        foreach (var item in iconsBar)
        {
            item.StopFill();
        }
        FindObjectOfType<IconController>().Antidote();

        StonePlayerEffect.ReturnAsWas();
        SlowPlayerEffect.ReturnAsWas();
    }

    void DamageEffect()
    {
        meleeDefaultDmg = meleeWeapon.currentDamage;
        throwingDefaultDmg = ThrowingWeapon.currentDamage;
        meleeWeapon.currentDamage = meleeWeapon.currentDamage + (meleeWeapon.currentDamage * 10) / 100;
        ThrowingWeapon.currentDamage = ThrowingWeapon.currentDamage + (ThrowingWeapon.currentDamage * 10) / 100;
        Invoke("ReturnDamage", 5);
    }

    void ReturnDamage()
    {
        meleeWeapon.currentDamage = meleeDefaultDmg;
        ThrowingWeapon.currentDamage = throwingDefaultDmg;
    }
}