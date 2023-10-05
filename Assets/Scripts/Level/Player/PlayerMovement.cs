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
        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);
        }
        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(lastVerticalVector, 0f);
        }
        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}