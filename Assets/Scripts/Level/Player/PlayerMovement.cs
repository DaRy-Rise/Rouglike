using UnityEditorInternal;
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
    private Animator anim;
    private string pathToController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SetAnimatorController();
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
        if (!PlayerStats.isKilled)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            moveDir = new Vector2(moveX, moveY).normalized;
            if (moveDir != Vector2.zero)
            {
                anim.SetBool("toRun", true);
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
            else
            {
                anim.SetBool("toRun", false);
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
    private void SetAnimatorController()
    {
        switch (GlobalStat.mainMaster)
        {
            case "sword":
                pathToController = "Animator/GG_sword";
                break;
                case "archer":
                pathToController = "Animator/GG_archer";
                break;
            default:
                break;
        }
        print(pathToController);
        anim.runtimeAnimatorController = Resources.Load(pathToController) as RuntimeAnimatorController;
    }
    private void RemoveDefaultSlow()
    {
        isSlowEffect = false;
    }

    private void RemoveDefaultStone()
    {
        isStoneEffect = false;
    }

    public void StopAttack()
    {
        anim.SetBool("runAttack", false);
        anim.SetBool("staticAttack", false);
    }
}