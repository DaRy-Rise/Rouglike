using UnityEngine;

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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
    }

    void Update()
    {
        InputManagmnet();
    }
    private void FixedUpdate()
    {
        if (isSwordAttack)
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
        else
        {
            moveSpeed = characterData.MoveSpeed;
        }
        Move();
    }
    private void InputManagmnet()
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
    }
}