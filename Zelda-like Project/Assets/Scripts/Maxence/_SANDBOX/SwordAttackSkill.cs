using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackSkill : Skill
{
    [SerializeField] private float attackRange;
    [SerializeField] private int swordDamage;

    private Vector2 attackPosition;
    private Vector2 fixedAttackPos;
    [SerializeField] private float swordBlowZoneRadius;
    [SerializeField] private LayerMask thisIsThePlayer;

    [SerializeField] private int startRate;
    public int rate { get; private set; }

    [SerializeField] private float startAttackWaitRate;
    public float attackWaitRate { get; private set; } = 0.0f;

    void Start()
    {
        additionalCooldown = 1.0f;
        rate = startRate;
    }

    void Update()
    {
        SwordAttackDirection();

        if (skillIsActive && enemyState.enemyCanUseSkill)
        {
            EnemyBehavior();
        }

        attackWaitRate -= Time.deltaTime;
    }

    public override void EnemyBehavior()
    {
        SwordAttack();

        /*if (Vector2.Distance(transform.position, enemyState.playerTransform.position) <= rangeOfAttack)
        {
            SwordAttack();
        }

        else
        {
            skillIsActive = false;
            enemyState.enemyCanMove = true;
        }*/
    }

    void SwordAttack()
    {
        if (rate > 0)
        {
            if (attackWaitRate <= 0.0f)
            {
                fixedAttackPos = attackPosition;
                enemyAnims.AttackAnim();
                attackWaitRate = startAttackWaitRate;
                rate--;
            }
        }

        else
        {
            rate = startRate;
            skillIsActive = false;
            enemyState.enemyCanMove = true;
        }
    }

    public override void AbilityAnimMethod() // SwordBlow
    {
        Collider2D[] playerCollider = Physics2D.OverlapCircleAll(fixedAttackPos, swordBlowZoneRadius, thisIsThePlayer);

        for (int u = 0; u < playerCollider.Length; u++)
        {
            if (playerCollider[u] is BoxCollider2D)
            {
                playerCollider[u].transform.parent.parent.gameObject.GetComponent<PlayerState>().TakeDamage(swordDamage);
            }
        }
    }

    void SwordAttackDirection()
    {
        float attackX = enemyState.playerTransform.position.x - transform.position.x;
        float attackY = enemyState.playerTransform.position.y - transform.position.y;

        Vector2 attackCoordinates = new Vector2(attackX, attackY);
        Vector3 attackDir = attackCoordinates.normalized * attackRange;
        attackPosition = transform.position + attackDir;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(attackPosition, swordBlowZoneRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, infos[0].value);
    }
}
