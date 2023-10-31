using UnityEngine;

public class SwordController : WeaponController
{
    private GameObject sword;
    private Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (PlayerMovement.isSwordAttack == false)
            {
                StartAttack();
            }
            else
            {
                AnimationControll();

            }
        }
            if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StopAttack();
        }
    }

    protected override void StartAttack()
    {
        //TurnAllAnimOff();
        sword.GetComponent<PolygonCollider2D>().enabled = true;
        PlayerMovement.isSwordAttack = true;
        animator.SetTrigger("start");
    }
    private void StopAttack()
    {
        //TurnAllAnimOff();
        sword.GetComponent<PolygonCollider2D>().enabled = false;
        PlayerMovement.isSwordAttack = false;
        animator.SetTrigger("stop");
        Invoke("TurnAllAnimOff", 0.25f);
    }
    //private void TurnAllAnimOff()
    //{
    //    animator.SetBool("IsStart", false);
    //    animator.SetBool("IsStop", false);
    //    animator.SetBool("IsRight", false);
    //    animator.SetBool("IsLeft", false);
    //    animator.SetBool("IsUp", false);
    //    animator.SetBool("IsDown", false);
    //}
    private void AnimationControll()
    {
        //TurnAllAnimOff();
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("right");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("left");
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            animator.SetTrigger("left");
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetTrigger("left");
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