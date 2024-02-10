using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    [HideInInspector]
    public float maxHealth;
    [HideInInspector]
    public float HP;
    void Start()
    {
        maxHealth = FindObjectOfType<PlayerStats>().characterData.MaxHealth;
        HP = maxHealth;
        healthBar = GetComponent<Image>();
    }

    void FixedUpdate()
    {
        healthBar.fillAmount = HP/maxHealth;
        HP = FindObjectOfType<PlayerStats>().currentHealth;
    }
   
}