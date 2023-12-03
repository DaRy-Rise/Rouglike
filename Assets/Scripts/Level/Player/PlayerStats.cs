using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [HideInInspector]
    public float currentHealth, currentRecovery, currentMoveSpeed, currentMight, currentThrowSpeed;
    public CharacterScriptableObject characterData;
    private float damageCoolDown;
    private bool isInvincible;
    private float coolDownSec = 0.5f;
    [Header("Experience/Level")]
    public float exp = 0, expCap = 10, expCapIncrease;
    public static int level = 1;
    public static System.Action onNextLevel;

    private void Awake()
    {
        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        //currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentThrowSpeed = characterData.ThrowSpeed;
    }
    private void Update()
    {
        if (damageCoolDown > 0)
        {
            damageCoolDown -= Time.deltaTime;
        }
        else if (isInvincible)
        {         
            isInvincible = false;
        }
    }
    private void LevelUpChecker()
    {
        if (exp >= expCap)
        {
            level++;
            exp -= expCap;
            expCap += expCapIncrease;
            print("Level: " + level);
        }
    }

    public void IncreaseExperience()
    {
        exp++;
        LevelUpChecker();
    }
    
    public void TakeDamageFromEffect(float damage)
    {
        if (!isInvincible)
        {
            isInvincible = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ReturnDefaultColor", 0.25f);
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Kill();
            }
        }
    }
    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            damageCoolDown = coolDownSec;
            isInvincible = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ReturnDefaultColor", 0.25f);
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Kill();
            }
        }
    }
    public void Kill()
    {
        Time.timeScale = 0f;
        print("GAME OVER");
        LoadingCampScene.LoadCampScene();
    }
    private void ReturnDefaultColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}