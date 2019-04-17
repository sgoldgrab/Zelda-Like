using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackSkill : Skill
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private EnemyAnims enemyAnims;

    [SerializeField] private float rangeOfAttack;
    [SerializeField] private int swordDamage;

    [SerializeField] private Transform attackPosition;
    [SerializeField] private float swordBlowZoneRadius;
    [SerializeField] private LayerMask thisIsThePlayer;

    [SerializeField] private int startRate;
    public int rate { get; private set; }

    [SerializeField] private float startAttackWaitRate;
    public float attackWaitRate { get; private set; }

    void Update()
    {
        Debug.Log(skillIsActive + " " + enemyState.enemyCanUseSkill);

        if (skillIsActive)
        {
            EnemyBehavior();
            enemyState.enemyCanUseSkill = false;
        }
    }

    public override void EnemyBehavior()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) <= rangeOfAttack)
        {
            SwordAttack();
        }
    }

    void SwordAttack()
    {
        if (rate > 0)
        {
            if (attackWaitRate <= 0.1f)
            {
                enemyAnims.AttackAnim();
                attackWaitRate = startAttackWaitRate;
                rate--;
            }

            else
            {
                attackWaitRate -= Time.deltaTime;
            }
        }

        else
        {
            rate = startRate;
            skillIsActive = false;
            enemyState.enemyCanUseSkill = true;
        }
    }

    void SwordBlow()
    {
        Collider2D[] playerCollider = Physics2D.OverlapCircleAll(attackPosition.position, swordBlowZoneRadius, thisIsThePlayer);

        for (int u = 0; u < playerCollider.Length; u++)
        {
            if (playerCollider[u] is BoxCollider2D)
            {
                playerCollider[u].GetComponent<PlayerState>().TakeDamage(swordDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(attackPosition.position, swordBlowZoneRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeOfAttack);
    }
}
