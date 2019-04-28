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

    [SerializeField] private float attackMoveSpeed;
    private bool attackMove = false;

    //Test New Move
    public float attackMoveDistance { get; set; }

    void Start()
    {
        attackDamage = swordDamage;
    }

    void Update()
    {
        transformPos = transform.position;

        AttackDirection();

        //if (attackMove) { Debug.Log(transformPos + " " + attackPos); Vector2.MoveTowards(transformPos, attackPos, attackMoveSpeed); }

        Attack();
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
        }
    }

    void Attack()
    {
        if (attackCoolDown <= 0.1f)
        {
            if (Input.GetButtonDown("Fire2") && canAttack) // initialize an attack
            {
                attackMove = true;

                SwordAttack();

                playerAnims.AttackAnim();

                attackCoolDown = startAttackCoolDown;
            }
        }

        else
        {
            attackCoolDown -= Time.deltaTime;
        }
    }

    void SwordAttack()
    {
        Collider2D[] enemyList;

        enemyList = Physics2D.OverlapCircleAll(attackPos, attackRange, enemyLayerMask);

        for (int i = 0; i < enemyList.Length; i++)
        {
            if (enemyList[i] is BoxCollider2D)
            {
                enemyList[i].transform.parent.GetComponentInParent<EnemyState>().TakeDamage(attackDamage);
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
