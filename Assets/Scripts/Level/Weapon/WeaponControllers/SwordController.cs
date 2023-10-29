using UnityEngine;

public class SwordController : WeaponController
{
    private GameObject sword;
    private Animator animator;
    private bool attack;
    protected override void Start()
    {
        sword = Instantiate(Resources.Load<GameObject>("Prefab/Weapons/Katana"));
        animator = sword.GetComponent<Animator>();
        sword.GetComponent<PolygonCollider2D>().enabled = false;
        base.Start();
    }
    protected override void Update()
    {
        sword.transform.position = transform.position;
        sword.transform.parent = transform;
        if (attack)
        {
            AnimationControll();
        }
    }

    protected override void StartAttack()
    {
        TurnAllAnimOff();
        sword.GetComponent<PolygonCollider2D>().enabled = true;
        PlayerMovement.isSwordAttack = true;
        animator.SetBool("IsStart", true);
        Invoke("SetAttackTrue", 0.25f);
    }
    private void SetAttackTrue()
    {
        attack = true;
    }
    private void StopAttack()
    {
        attack = false;
        TurnAllAnimOff();
        sword.GetComponent<PolygonCollider2D>().enabled = false;
        PlayerMovement.isSwordAttack = false;
        animator.SetBool("IsStop", true);
        Invoke("TurnAllAnimOff", 0.25f);
    }
    private void TurnAllAnimOff()
    {
        animator.SetBool("IsStart", false);
        animator.SetBool("IsStop", false);
        animator.SetBool("IsRight", false);
        animator.SetBool("IsLeft", false);
        animator.SetBool("IsUp", false);
        animator.SetBool("IsDown", false);
    }
    private void AnimationControll()
    {
        TurnAllAnimOff();
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsRight", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsLeft", true);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            animator.SetBool("IsLeft", true);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("IsRight", true);
        }
        /*else if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsUp", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsDown", true);
        }*/
    }
}