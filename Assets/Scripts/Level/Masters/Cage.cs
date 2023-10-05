using UnityEngine;

public class Cage : MonoBehaviour
{
    private float health;
    public static System.Action onDestroy;

    private void Awake()
    {
        SetHealth();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyCage();
        }
    }

    private void SetHealth()
    {
        switch (PlayerStats.level)
        {
            case 1: health = 20;
                break;
            case 2:
                health = 50;
                break;
            default:
                break;
        }
    }

    private void DestroyCage()
    {
        onDestroy?.Invoke();
        Destroy(gameObject);
    }
}