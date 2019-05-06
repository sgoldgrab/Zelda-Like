using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAnims playerAnims;

    [SerializeField] private int swordDamage;
    public int attackDamage { get; set; }

    public bool canAttack { get; set; } = true;

    [SerializeField] private float attackRange;
    [SerializeField] private float attackRadius;
    private Vector2 attackPos;

    private Vector2 transformPos;

    private float attackCoolDown;
    [SerializeField] private float startAttackCoolDown;
    public float attackCoolDownSpeed { get => startAttackCoolDown; set => startAttackCoolDown = value; } // constructor for combo P1S3 (attack speed)

    [SerializeField] private LayerMask enemyLayerMask;

    //Attack Move
    private float attackMoveDuration;
    [SerializeField] private float startAttackMoveDuration;
    public float attackMoveTime { get => startAttackMoveDuration; set => startAttackMoveDuration = value; } // constructor for consumable locket of winged soul

    [SerializeField] private float attackMoveSpeed;

    private bool attackMove = false;

    //Testing
    [SerializeField] private GameObject attackPosition;

    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        attackDamage = swordDamage;
    }

    void Update()
    {
        transformPos = transform.position;

        AttackDirection();

        Attack();

        AttackMove();
    }

    void AttackDirection()
    {
        if (playerMovement.lastX != 0 || playerMovement.lastY != 0)
        {
            float attackPosX = playerMovement.lastX;
            float attackPosY = playerMovement.lastY;

            Vector2 rawAttackCoordinates = new Vector2(attackPosX, attackPosY);
            Vector2 rawAttackPos = rawAttackCoordinates.normalized * attackRange;
            attackPos = transformPos + rawAttackPos;

            //Test Strauss Braüm Reich
            float angle = (Mathf.Atan2(attackPosX, attackPosY) * - Mathf.Rad2Deg) + 45;

            attackPosition.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void Attack()
    {
        if (attackCoolDown <= 0.1f)
        {
            if (Input.GetButtonDown("Fire2") && canAttack) // initialize an attack
            {
                playerMovement.canMove = false;
                attackMove = true;
                attackMoveDuration = startAttackMoveDuration;

                //SwordAttack();

                //SwordAttack2();

                playerAnims.AttackAnim();

                attackCoolDown = startAttackCoolDown;
            }
        }

        else
        {
            attackCoolDown -= Time.deltaTime;
        }
    }

    public void SwordAttack()
    {
        Collider2D[] enemyList;

        enemyList = Physics2D.OverlapCircleAll(attackPos, attackRadius, enemyLayerMask);

        for (int i = 0; i < enemyList.Length; i++)
        {
            if (enemyList[i] is BoxCollider2D)
            {
                enemyList[i].transform.parent.GetComponentInParent<EnemyState>().TakeDamage(attackDamage);
            }
        }
    }

    public void Clear()
    {
        enemies.Clear();
    }

    void AttackMove()
    {
        if (attackMove)
        {
            transform.position = Vector2.MoveTowards(transformPos, attackPos, attackMoveSpeed * Time.deltaTime);

            if (attackMoveDuration <= 0.0f)
            {
                attackMove = false;
            }

            else
            {
                attackMoveDuration -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject enemy = other.transform.parent.parent.gameObject;

            if (!enemies.Contains(enemy))
            {
                enemy.GetComponent<EnemyState>().TakeDamage(1);
                enemies.Add(enemy);
            }
        }
    }

    void OnDrawGizmosSelected() // draws the area of effect of the attack in the editor, used for visualisation
    {
        //ATTACK POSITIONING
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos, attackRadius);
    }
}
