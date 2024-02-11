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
        if (!PlayerStats.isKilled)
        {
            sword.transform.position = transform.position;
            sword.transform.parent = transform;
            base.Update();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (PlayerMovement.isSwordAttack == false)
                {
                    ShowKatana();
                }
                else if (isAttackAlowed)
                {
                    StartAttack();

                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                HideKatana();
            }
        }
        else
        {
            Destroy(sword);
        }
    }

    protected override void StartAttack()
    {
        if (movement.lastMovedVector.x < 0)
        {
            animator.SetTrigger("left");
            attackPoint.position = new Vector3(movement.transform.position.x - 1.150f, movement.transform.position.y - 0.006f);
        }
        else
        {
            animator.SetTrigger("right");
            attackPoint.position = new Vector3(movement.transform.position.x + 1.150f, movement.transform.position.y - 0.006f);
        }
        base.StartAttack();
        behaviour.Attack(attackPoint, attackRange);

    }
    private void HideKatana()
    {
        sword.GetComponent<PolygonCollider2D>().enabled = false;
        PlayerMovement.isSwordAttack = false;
        animator.SetTrigger("stop");
    }
    private void ShowKatana()
    {
        sword.GetComponent<PolygonCollider2D>().enabled = true;
        PlayerMovement.isSwordAttack = true;
        animator.SetTrigger("start");
    }
    private void OnDrawGizmosSelected()//рисует кружок атаки в инспекторе
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    //направление меча, направление области, cooldown
}