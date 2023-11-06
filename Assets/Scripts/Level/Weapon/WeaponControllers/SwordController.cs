using UnityEngine;

public class SwordController : WeaponController
{
    private GameObject sword;
    private Animator animator;
    [SerializeField]
    private Transform attackPoint;
    public float attackRange = 0.5f;
    PlayerMovement movement;
    private SwordBehaviour behaviour;
    protected override void Start()
    {
        movement = FindAnyObjectByType<PlayerMovement>();
        sword = Instantiate(Resources.Load<GameObject>("Prefab/Weapons/Katana"));
        animator = sword.GetComponent<Animator>();
        sword.GetComponent<PolygonCollider2D>().enabled = false;
        behaviour = FindAnyObjectByType<SwordBehaviour>();
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
                Attack();

            }
        }
            if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StopAttack();
        }
    }

    protected override void StartAttack()
    {
        sword.GetComponent<PolygonCollider2D>().enabled = true;
        PlayerMovement.isSwordAttack = true;
        animator.SetTrigger("start");
    }
    private void StopAttack()
    {
        sword.GetComponent<PolygonCollider2D>().enabled = false;
        PlayerMovement.isSwordAttack = false;
        animator.SetTrigger("stop");
        Invoke("TurnAllAnimOff", 0.25f);
    }
    private void Attack()
    {
        if (movement.lastMovedVector.x < 0)
        {
            animator.SetTrigger("left");
            attackPoint.position = new Vector3(movement.transform.position.x - 1.261f, movement.transform.position.y - 0.006f);
        }
        else
        {
            animator.SetTrigger("right");
            attackPoint.position = new Vector3(movement.transform.position.x + 1.261f, movement.transform.position.y - 0.006f);
        }
        behaviour.Attack(attackPoint, attackRange);

    }
    private void OnDrawGizmosSelected()//рисует кружок атаки в инспекторе
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    //направление меча, направление области, cooldown
}