using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public CharacterScriptableObject characterData;
    [HideInInspector]
    public float lastHorizontalVector, lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDir, lastMovedVector;
    public static bool isSwordAttack, isWeb, isSlowEffect, isStoneEffect, isSpeedPotion;
    public float moveSpeed;
    [SerializeField]
    private float scale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
    }
    private void OnEnable()
    {
        SlowPlayerEffect.onReturn += RemoveDefaultSlow;
        StonePlayerEffect.onReturn += RemoveDefaultStone;
    }
    private void OnDisable()
    {
        SlowPlayerEffect.onReturn -= RemoveDefaultSlow;
        StonePlayerEffect.onReturn -= RemoveDefaultStone;
    }
    void Update()
    {
        InputManagment();
    }
    private void FixedUpdate()
    {
        if (PlayerStats.isKilled) 
        {
            moveSpeed = 0;
        }
        else if (isSwordAttack)
        {
            moveSpeed = characterData.MoveSpeed - characterData.MoveSpeed * 0.2f;
        }
        else if (isWeb)
        {
            moveSpeed = 1;
        }
        else if(isSlowEffect)
        {
            moveSpeed = 2f;
        }
        else if (isStoneEffect)
        {
            moveSpeed = 0;
        }
        else if (isSpeedPotion)
        {
            moveSpeed = characterData.MoveSpeed * 1.5f;
        }
        else if (SceneManager.sceneCount == 1)
        {
            moveSpeed = 7;
        }
        else
        {
            moveSpeed = characterData.MoveSpeed;
        }
        Move();
    }
    private void InputManagment()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;
        if (moveDir != Vector2.zero)
        {
            if (Mathf.Abs(moveDir.x) > Mathf.Abs(moveDir.y))
            {
                lastMovedVector = new Vector2(moveDir.x, 0f);
            }
            else if (Mathf.Abs(moveDir.y) > Mathf.Abs(moveDir.x))
            {
                lastMovedVector = new Vector2(0f, moveDir.y);
            }
            else
            {
                lastMovedVector = moveDir;
            }
        }
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
        if (!PlayerStats.isKilled)
        {
            SetScale();
        }
    }
    private void SetScale()
    {
        if (lastMovedVector.x < 0)
        {
            transform.localScale = new Vector3(-scale, scale, scale);
        }
        else if (lastMovedVector.x > 0)
        {
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    private void RemoveDefaultSlow()
    {
        isSlowEffect = false;
    }

    private void RemoveDefaultStone()
    {
        isStoneEffect = false;
    }
}