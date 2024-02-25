using UnityEngine;

public class HeartBar : MonoBehaviour
{
    [HideInInspector]
    public float maxHealth;
    [HideInInspector]
    public float HP;
    Animator animator;
    void Start()
    {
        maxHealth = FindObjectOfType<PlayerStats>().characterData.MaxHealth;
        HP = maxHealth;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        HP = FindObjectOfType<PlayerStats>().currentHealth;
        SetSpeedBeat();
    }
    void SetSpeedBeat()
    {
        switch (HP)
        {
            case > 80:
                animator.SetFloat("Speed", 1);
                break;
            case > 60:
                  animator.SetFloat("Speed", 1.4f);
                break;
            case > 40:
                animator.SetFloat("Speed", 1.8f);
                break;
            case > 20:
                animator.SetFloat("Speed", 2f);
                break;
            case > 0:
                animator.SetFloat("Speed", 2.4f);
                break;
            default:
                break;
        }
    }
}